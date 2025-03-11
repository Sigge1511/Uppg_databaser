﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppg_databaser
{
    internal class HelperClass
    {
        public StudentDbCntxt dbCntxt = new StudentDbCntxt();
        public void Run() 
        {
            PrintMenu();
            Console.ReadKey();
        }
        //**************************************************************************************************
        internal void PrintMenu() 
        {
            Console.Clear();
            Console.WriteLine("MENY:\n");
            Console.WriteLine("1. Lägg till en student");
            Console.WriteLine("2. Ändra en student");
            Console.WriteLine("3. Skriv ut alla studenter");
            Console.WriteLine("4. Ta bort en student");
            Console.WriteLine("5. Avsluta programmet");
            Console.WriteLine("\nVälj ett alternativ genom att skriva in en siffra:\n");
            MenuSelection();
        }
        internal void MenuSelection()
        {
            int selection =0;
            bool parseselec = false;
            while (parseselec == false)
            {
                parseselec = int.TryParse(Console.ReadLine(), out selection);
                if (selection < 1 || selection > 5 || parseselec == false)
                {
                    Console.WriteLine("Ogiltigt val. Vänligen försök igen.\n");
                    parseselec = false;
                }
                else { parseselec = true; }
            }
            MenuHandler(selection);
        }
        internal void MenuHandler(int selection)
        {
            switch (selection) 
            {
                case 1:
                    Console.Clear();
                    AddStudent();
                    break;

                case 2:
                    Console.Clear();
                    ModifyStudent();
                    break;

                case 3:
                    Console.Clear();
                    PrintAllStudent();
                    break;

                case 4:
                    Console.Clear();
                    DeleteStudent();
                    break;

                case 5:
                    Console.Clear();
                    Console.WriteLine("Programmet avslutas nu");
                    break;
            }
        }
        //**************************************************************************************************

        internal void AddStudent()
        {
            var newstudent = new Student();
            bool loopselec = true;
            int loopnumber = 0;
            string fname;
            string lname;
            string city;
            try
            {
                do
                {
                    //Ta emot lokala variabler
                    Console.WriteLine("Ange förnamn:");
                    fname = Console.ReadLine() ?? "";
                    Console.WriteLine("Ange efternamn:");
                    lname = Console.ReadLine() ?? "";
                    Console.WriteLine("Ange stad:");
                    city = Console.ReadLine() ?? "";
                    loopnumber++;

                    //Kolla om lokala variabler är null, loopa isf tillbaka
                    if (fname == "" || lname == "" || city == "") 
                    {
                        Console.Clear();
                        Console.WriteLine("Ogiltig inmatning. Alla fälten måste fyllas i.");
                        if (loopnumber == 3)
                        {
                            Console.WriteLine("Du har fått tre försök och skickas nu tillbaka till menyn.\n");
                            loopselec = true;
                            
                        }
                        else { loopselec = false; }
                    }
                    else 
                    {
                        Console.Clear();
                        //Kolla om anv vill spara dem till en ny student, om nej, loopa tillbaka
                        Console.WriteLine("Vill du spara följande information till din nya student?");
                        Console.WriteLine($"{fname} {lname}, {city}.");
                        Console.WriteLine("Om ja, tryck 1. Annars skickas du tillbaka till huvudmenyn");
                        int savechoice = 0;
                        bool trysave = int.TryParse(Console.ReadLine(), out savechoice);
                        if (savechoice == 1) 
                        {
                            //Spara till newstudent
                            //Lägg till i databas och spara ändringar
                            newstudent.FirstName = fname;
                            newstudent.LastName = lname;
                            newstudent.City = city;
                            dbCntxt.Add(newstudent);
                            dbCntxt.SaveChanges();
                            loopselec = true;
                        }
                        else { loopselec = true; }
                    }   
                    
                } while (loopselec == false || loopnumber>3);
                //Kolla loopnumber, och om det är 3 så säg att användaren skickas tillbaka till menyn
                
            }
            catch 
            {
                Console.WriteLine("Något gick fel. Du skickas nu tillbaka till huvudmenyn.");
            }
            ReturnToMenu();
        }
        internal void ModifyStudent()
        {
            int stdntid = StudentSelector();
            bool loopselec = true;
            int loopnumber = 0;
            string fname;
            string lname;
            string city;
            try
            {
                Student modstudent = dbCntxt.Students.Single(s => s.StudentId == stdntid);

                Console.Clear();
                Console.WriteLine("Vald student innan ändringen:");
                Console.WriteLine($"{modstudent.FirstName} {modstudent.LastName}, {modstudent.City}\n");

                do
                {
                    //Ta emot lokala variabler
                    Console.WriteLine("Ange ny information för att ändra");
                    Console.WriteLine("Ange förnamn:");
                    fname = Console.ReadLine() ?? "";
                    Console.WriteLine("Ange efternamn:");
                    lname = Console.ReadLine() ?? "";
                    Console.WriteLine("Ange stad:");
                    city = Console.ReadLine() ?? "";
                    loopnumber++;

                    //Kolla om lokala variabler är null, loopa isf tillbaka
                    if (fname == "" || lname == "" || city == "")
                    {
                        Console.Clear();
                        Console.WriteLine("Ogiltig inmatning. Alla fälten måste fyllas i.");
                        if (loopnumber == 3)
                        {
                            Console.WriteLine("Du har fått tre försök och skickas nu tillbaka till menyn.\n");
                            loopselec = true;

                        }
                        else { loopselec = false; }
                    }
                    else
                    {
                        Console.Clear();
                        //Kolla om anv vill spara dem student, om nej, loopa tillbaka
                        Console.WriteLine("Vill du spara följande information till din nya student?");
                        Console.WriteLine($"{fname} {lname}, {city}.");
                        Console.WriteLine("Om ja, tryck 1. Annars skickas du tillbaka till huvudmenyn");
                        int savechoice = 0;
                        bool trysave = int.TryParse(Console.ReadLine(), out savechoice);
                        if (savechoice == 1)
                        {
                            //Lägg till i databas och spara ändringar
                            modstudent.FirstName = fname;
                            modstudent.LastName = lname;
                            modstudent.City = city;
                            //dbCntxt.Add(newstudent); MODIFY
                            dbCntxt.SaveChanges();
                            loopselec = true;
                        }
                        else { loopselec = true; }
                    }

                } while (loopselec == false || loopnumber > 3);
            }
            catch 
            {
                Console.WriteLine("Något gick fel. Du skickas tillbaka till menyn.");
            }
            ReturnToMenu();
        }
        internal void PrintAllStudent()
        {
            if (dbCntxt.Students != null)
            {
                foreach (var s in dbCntxt.Students)
                {
                    Console.WriteLine($"{s.FirstName} {s.LastName}, {s.City}.");
                }
            }
            else 
            {
                Console.WriteLine("Det finns inga studenter i databasen.");
            }
            ReturnToMenu();
        }
        internal void DeleteStudent()
        {
            int stdntid = StudentSelector();

            try
            {
                Student modstudent = dbCntxt.Students.Single(s => s.StudentId == stdntid);

                Console.Clear();
                Console.WriteLine("Vald student innan ändringen:");
                Console.WriteLine($"{modstudent.FirstName} {modstudent.LastName}, {modstudent.City}\n");
            }
            catch 
            {
                Console.WriteLine("Något gick fel. Du skickas tillbaka till menyn.");
            }
            ReturnToMenu();
        }
        internal int StudentSelector()
        {
            int studentchoice = 0;
            bool tryselect = false;

            Console.Clear();
            //Skriv ut hela listan för att visa vad som finns i den
            if (dbCntxt.Students != null)
            {
                Console.WriteLine("Registrerade studenter:\n");
                foreach (var s in dbCntxt.Students)
                {
                    Console.WriteLine($"Id {s.StudentId}: {s.FirstName} {s.LastName}, {s.City}.");
                }
            }
            else
            {
                Console.WriteLine("Det finns inga studenter i databasen.");
                ReturnToMenu();
            }
            Console.WriteLine("\nAnge id på personen du vill ta bort:");
            do
            {
                tryselect = int.TryParse(Console.ReadLine(), out studentchoice);
            } while (tryselect == false);
            return studentchoice;
        }
        //**************************************************************************************************

        //Metod för att kolla valid id?

        internal void ReturnToMenu() 
        {
            Console.WriteLine("\nTryck enter för att återgå till menyn");
            Console.ReadKey();
            Console.Clear();
            PrintMenu();
        }
    }
}
