using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace mehmet_anket_36501
{
    public class Executer
    {
        
        
        private readonly List<Contact> _contacts = new();

        public Executer()
        {
            var contact1 = new Contact("Arda", "Anket", "ardapolskapl@gmail.com",
                DateTime.ParseExact("19-11-1999", "dd-MM-yyyy", CultureInfo.InvariantCulture), 000036501);
            var contact2 = new Contact("Ewa", "Angelika", "eww72@hotmail.com",
                DateTime.ParseExact("01-05-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture), 415498395);
            

            _contacts.Add(contact1);
            _contacts.Add(contact2);
        }

        public void AddContact(int index = -1)
        {
            if (index == -1)
            {
                Console.WriteLine("Adding new contact . . . ");
            }

            Console.WriteLine("Enter contact name : ");
            var name = Console.ReadLine();

            Console.WriteLine("Contact surname : ");
            var surname = Console.ReadLine();

            Console.WriteLine("Contact email : ");
            var email = Console.ReadLine();

            Console.WriteLine("Contact birth date (dd-MM-yyyy) : ");
            var dateOfBirth =
                Convert.ToDateTime(DateTime.ParseExact(Console.ReadLine()!, "dd-MM-yyyy",
                    CultureInfo.InvariantCulture));

            Console.WriteLine("Contact telephone number : ");
            var telephoneNumber = Convert.ToInt64(Console.ReadLine());

            var contact = new Contact(name, surname, email, dateOfBirth, telephoneNumber);

            if (index == -1)
            {
                _contacts.Add(contact);
                Console.WriteLine("Contact added.");
            }
            else
            {
                _contacts[index] = contact;
                Console.WriteLine("Contact edited.");
            }
        }

        public void PrintAll()
        {
            Console.WriteLine("Contacts: ");
            for (var i = 0; i < _contacts.Count; i++)
            {
                Console.Write($"{i + 1}-)");
                _contacts[i].PrintProperties();
            }
        }

        public void CheckBirthDate()
        {
            foreach (var contact in _contacts)
            {
                if (DateInside(contact.DateOfBirth))
                {
                    contact.PrintProperties();
                }
            }
        }

        private static bool DateInside(DateTime contactDate)
        {
            var startDateOfWeek = DateTime.Now.Date;
            var missingYears = startDateOfWeek.Year - contactDate.Year;
            var checkDate = contactDate.AddYears(missingYears);

            while (startDateOfWeek.DayOfWeek != DayOfWeek.Monday)
            {
                startDateOfWeek = startDateOfWeek.AddDays(-1d);
            }

            var toDate = startDateOfWeek.AddDays(6d);

            return checkDate >= startDateOfWeek && checkDate <= toDate;
        }

        public void cont_edit()
        {
            var selection = -1;
            var hasError = false;
            PrintAll();
            Console.Write("Please select the contact you want to edit :");
            try
            {
                selection = Convert.ToInt32(Console.ReadLine()) - 1;
                if (selection >= _contacts.Count && selection != -1)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                hasError = true;
                
            }

            if (!hasError)
            {
                AddContact(selection);
            }
        }

        public void DeleteContact()
        {
            var selection = -1;
            var hasError = false;
            PrintAll();
            Console.Write("Please select the contact:");
            try
            {
                selection = Convert.ToInt32(Console.ReadLine()) - 1;
                if (selection >= _contacts.Count || selection < 0)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                hasError = true;
                
            }

            if (hasError) return;
            _contacts.RemoveAt(selection);
        }


        public void SearchContacts()
        {
            int selection;

            Console.WriteLine();
            Console.WriteLine("1-) Search by Name");
            Console.WriteLine("2-) Search by Surname");
            Console.WriteLine("3-) Search by Email");
            Console.WriteLine("4-) Search by Birth Date");
            Console.WriteLine("5-) Search by Telephone Number");
            Console.WriteLine();

            try
            {
                selection = Convert.ToInt32(Console.ReadLine());
                if (selection >= 6 || selection <= 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please use only numbers according to menu !");
                return;
            }

            switch (selection)
            {
                case 1:
                    SearchByName();
                    break;
                case 2:
                    SearchBySurname();
                    break;
                case 3:
                    SearchByEmail();
                    break;
                case 4:
                    SearchByBirthDate();
                    break;
                case 5:
                    SearchByTelNumber();
                    break;
                default:
                    Console.WriteLine("Please select only numbers according to menu !");
                    break;
            }
        }

        private void SearchByName()
        {
            Console.WriteLine("Enter the name you want to search for: ");
            string name;
            try
            {
                name = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            foreach (var contact in _contacts.Where(contact => contact.Name == name))
            {
                contact.PrintProperties();
            }
        }

        private void SearchBySurname()
        {
            Console.WriteLine("Enter the surname you want to search for: ");
            string surname;

            try
            {
                surname = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            foreach (var contact in _contacts.Where(contact => contact.Surname == surname))
            {
                contact.PrintProperties();
            }
        }

        private void SearchByEmail()
        {
            Console.WriteLine("Enter the email you want to search for: ");
            string email;

            try
            {
                email = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            foreach (var contact in _contacts.Where(contact => contact.Email == email))
            {
                contact.PrintProperties();
            }
        }

        private void SearchByTelNumber()
        {
            Console.WriteLine("Enter the telephone number: ");
            long number;

            try
            {
                number = Convert.ToInt64(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            foreach (var contact in _contacts.Where(contact => contact.TelephoneNumber == number))
            {
                contact.PrintProperties();
            }
        }

        private void SearchByBirthDate()
        {
            Console.WriteLine("Enter the birth date (dd-MM-yyyy): ");
            DateTime date;

            try
            {
                date = Convert.ToDateTime(DateTime.ParseExact(Console.ReadLine()!, "dd-MM-yyyy",
                    CultureInfo.InvariantCulture));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            foreach (var contact in _contacts.Where(contact => contact.DateOfBirth == date))
            {
                contact.PrintProperties();
            }
        }
    }
}