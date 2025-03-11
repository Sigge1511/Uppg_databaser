using System;
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

                    //Kolla om lokala variabler är null, loopa isf tillbaka
                    if (fname == "" || lname == "" || city == "") 
                    {
                        Console.WriteLine("Ogiltig inmatning. Alla fälten måste fyllas i.");
                        loopselec = false;
                    }
                    else 
                    {
                        //Kolla om anv vill spara dem till en ny student, om nej, loopa tillbaka
                        Console.WriteLine("Vill du spara följande information till din nya student?");
                        Console.WriteLine($"{fname} {lname}, {city}.");
                        Console.WriteLine("Om ja, tryck 1. Annars skickas du tillbaka till huvudmenyn");
                        int savechoice = 0;
                        bool trysave = int.TryParse(Console.ReadLine(), out savechoice);
                        if (savechoice == 1) {loopselec = true;}
                        else { loopselec = false; }
                    }
                    loopnumber++;
                    //Kolla loopnumber, och om det är 3 så säg att användaren skickas tillbaka till menyn

                } while (loopselec == false || loopnumber>4);

                //Spara till newstudent
                //Lägg till i databas och spara ändringar
                newstudent.FirstName = fname;
                newstudent.LastName = lname;
                newstudent.City = city;
                dbCntxt.Add(newstudent);
                dbCntxt.SaveChanges();
            }
            catch 
            {
                Console.WriteLine("Något gick fel. Du skickas nu tillbaka till huvudmenyn.");
            }
                ReturnToMenu();
        }
        internal void ModifyStudent()
        {

            ReturnToMenu();
        }
        internal void PrintAllStudent()
        {
            if (dbCntxt != null)
            {
                foreach (var s in dbCntxt)
                {
                    Console.WriteLine($"{s.Firstname} {s.Lastname}, {s.City}.");
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

            ReturnToMenu();
        }
        internal int StudentSelector()
        {
            int studentchoice = 0;

            //Skriv ut alla i foreach med ett lokalt nummer i
            //Använd i som studentid för att välja student som ska ändras eller tas bort

            return studentchoice;
        }
        internal void ReturnToMenu() 
        {
            Console.WriteLine("\nTryck enter för att återgå till menyn");
            Console.ReadKey();
            Console.Clear();
            PrintMenu();
        }
    }
}
