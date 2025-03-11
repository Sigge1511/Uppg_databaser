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

            ReturnToMenu();
        }
        internal void ModifyStudent()
        {

            ReturnToMenu();
        }
        internal void PrintAllStudent()
        {
            //Lägg i en ifsats som kollar om listan är tom?
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
