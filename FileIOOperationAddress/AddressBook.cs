using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOOperationAddress
{
    internal class AddressBook
    {
        public List<Contact> People;

        public AddressBook()
        {
            People = new List<Contact>();
        }

        public Contact FindContact(string fname)
        {
            Contact contact = null;
            foreach (var person in People)
            {
                if (person.FirstName.Equals(fname))
                {
                    contact = person;
                    break;
                }
            }
            return contact;
        }

        public bool AddContact(string FirstName, string LastName, string Address, string City, string State, string ZipCode, string PhoneNumber, string Email)
        {
            Contact contact = new Contact(FirstName, LastName, Address, City, State, ZipCode, PhoneNumber, Email);
            //finds contact and stores into result
            Contact result = FindContact(FirstName);
           
            if (result == null)
            {
                People.Add(contact);
                return true;
            }
            else
                return false;
        }

        public bool RemoveContact(string name)
        {
            //creation of object for contact
            Contact c = FindContact(name);
           
            if (c != null)
            {
                People.Remove(c);
                return true;
            }
            else
            {
                return false;
            }
        }

       
        public void AlphabeticallyArrange()
        {
            //creation of list
            List<string> alphabeticalList = new List<string>();
           
            foreach (Contact c in People)
            {
                string sort = c.ToString();
                alphabeticalList.Add(sort);
            }
            alphabeticalList.Sort();
            foreach (string s in alphabeticalList)
            {
                Console.WriteLine(s);
            }
        }

        public void SortByPincode()
        {
            //Comparision method is used to compare two objects of same type
            People.Sort(new Comparison<Contact>((x, y) => string.Compare(x.ZipCode, y.ZipCode)));
            //traversing through contact class
            foreach (Contact c in People)
            {
                Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.PhoneNumber + "\t" + c.Email);
            }

        }

     
        public void SortByCity()
        {
            //Comparision method is used to compare two objects of same type
            People.Sort(new Comparison<Contact>((x, y) => string.Compare(x.City, y.City)));
            //traversing through contact class
            foreach (Contact c in People)
            {
                Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.PhoneNumber + "\t" + c.Email);
            }

        }

      
        public void SortByState()
        {
            //Comparision method is used to compare two objects of same type
            People.Sort(new Comparison<Contact>((x, y) => string.Compare(x.State, y.State)));
            //traverse through contact class
            foreach (Contact c in People)
            {
                Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.PhoneNumber + "\t" + c.Email);
            }

        }

        public void WriteUsingStreamWriter()
        {
            string FilePath = @"C:\Users\ADMIN\source\repos\FileIOperation\FileIOOperationAddress\TextFile1.txt";

            using (StreamWriter sw = File.CreateText(FilePath))
            {
                foreach (var con in People)
                {
                    Console.WriteLine("Added record in file");
                    sw.WriteLine("****************Peoples In address book********************");
                    sw.WriteLine("First Name:" + con.FirstName); sw.WriteLine("Last Name:" + con.LastName);
                    sw.WriteLine("Address:" + con.Address);
                    sw.WriteLine("City:" + con.City);
                    sw.WriteLine("Email:" + con.Email);
                    sw.WriteLine("PhoneNumber:" + con.PhoneNumber);
                    sw.WriteLine("ZipCode:" + con.ZipCode);
                    sw.WriteLine("State:" + con.State);
                }
            }
        }
        public void WriteUsingCSV()
        {
            string Filepath = @"C:\Users\ADMIN\source\repos\FileIOperation\FileIOOperationAddress\Csv1.csv";
            using (CsvWriter sw = new CsvWriter(new StreamWriter(Filepath), CultureInfo.InvariantCulture))
            {
                sw.WriteHeader<Contact>();
                sw.WriteRecords("\n");
                sw.WriteRecords(People);
            }
        }
    }
}
