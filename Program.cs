using System;

namespace mehmet_anket_36501
{
    class Program
    {
       private static readonly Executer ProgramExe = new();
       private static bool _program = true;

       static void Main(string[] args)
        {
            Application();
        }

        private static void Application()
        {
            while (_program)
            {
                int selection;

                Console.WriteLine("Please select from options : ");
                Console.WriteLine();
                Console.WriteLine("1) Add contact");
                Console.WriteLine("2) Print contacts");
                Console.WriteLine("3) Check current birth dates");
                Console.WriteLine("4) Edit contact");
                Console.WriteLine("5) Delete contact");
                Console.WriteLine("6) Search contact");
                Console.WriteLine();


                try
                {
                    selection = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Please use only numbers according to menu !");
                    continue;
                }

                switch (selection)
                {
                    case 1:
                        ProgramExe.AddContact();
                        break;
                    case 2:
                        ProgramExe.PrintAll();
                        break;
                    case 3:
                        ProgramExe.CheckBirthDate();
                        break;
                    case 4:
                        ProgramExe.cont_edit();
                        break;
                    case 5:
                        ProgramExe.DeleteContact();
                        break;
                    case 6:
                        ProgramExe.SearchContacts();
                        break;
                    
                    
                    default:
                        Console.WriteLine("Please select only numbers according to menu !");
                        break;
                }
            }
        }
    }
}
