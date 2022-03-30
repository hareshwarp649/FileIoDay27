using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOOperationAddress
{
    internal class Program
    {
       
              public static List<string> data = new List<string>();
        static void Main(string[] args)
        {
            //reference for binder class
            AddressBookBinder binder = new AddressBookBinder();
            Console.WriteLine("Hello, Welcome to Address Book");
            int result = 1;
            while (result == 1)
            {
                Console.WriteLine("Enter the name of the Address Book to be used");
                string addrName = Console.ReadLine();
                AddressBook book = new AddressBook();
                book.People = binder.AddAddrBook(addrName, book.People);
                int loop = 1;
                while (loop == 1)
                {
                    Console.WriteLine("\nSelect the option. \n1. Add new contact. \n2. Edit existing contact.\n3. Delete Contact \n4. Search By City \n5. Count citywise contacts \n6. Display Alphabetically \n7. Sort By Zipcode \n8. Sort By City \n9. Sort By State  \n10. ReadWriteCase \n11.ReadWriteCSVFile  \n12.Exit.");
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Enter the person details to be added in the address book");
                            Console.WriteLine("First Name");
                            string FirstName = Console.ReadLine();
                            Console.WriteLine("Last Name");
                            string LastName = Console.ReadLine();
                            Console.WriteLine("Address");
                            string Address = Console.ReadLine();
                            Console.WriteLine("City");
                            string City = Console.ReadLine();
                            Console.WriteLine("State");
                            string State = Console.ReadLine();
                            Console.WriteLine("Zip code");
                            string ZipCode = Console.ReadLine();
                            Console.WriteLine("Phone Number");
                            string PhoneNumber = Console.ReadLine();
                            Console.WriteLine("Email");
                            string Email = Console.ReadLine();
                            if (book.AddContact(FirstName, LastName, Address, City, State, ZipCode, PhoneNumber, Email))
                            {
                                Console.WriteLine("Contact added successfully");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Contact already exists");
                                break;
                            }
                        case 2:
                            Console.WriteLine("Enter the first name of the contact to be edited ");
                            string name = Console.ReadLine();
                            Contact c = book.FindContact(name);
                            if (c == null)
                            {
                                Console.WriteLine("Address for {0} count not be found.", name);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("New Last Name");
                                c.LastName = Console.ReadLine();
                                Console.WriteLine("New Address");
                                c.Address = Console.ReadLine();
                                Console.WriteLine("New City");
                                c.City = Console.ReadLine();
                                Console.WriteLine("New State");
                                c.State = Console.ReadLine();
                                Console.WriteLine("New Zip code");
                                c.ZipCode = Console.ReadLine();
                                Console.WriteLine("New Phone Number");
                                c.PhoneNumber = Console.ReadLine();
                                Console.WriteLine("New Email");
                                c.Email = Console.ReadLine();
                                Console.WriteLine("Details updated for " + name);
                                break;
                            }
                        case 3:
                            Console.WriteLine("Enter the first name of the contact to be deleted ");
                            string name1 = Console.ReadLine();
                            if (book.RemoveContact(name1))
                            {
                                Console.WriteLine("Contact removed successfully");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Contact not found");
                                break;
                            }
                        case 4:
                            binder.CreateDictionary();
                            Console.WriteLine("Enter city whose contacts need to be searched");
                            string city = Console.ReadLine();
                            foreach (Contact contact in binder.CityDictionary[city])
                            {
                                Console.WriteLine(contact.FirstName + "\t" + contact.LastName + "\t" + contact.Address + "\t" + contact.City + "\t" + contact.State + "\t" + contact.ZipCode + "\t" + contact.PhoneNumber + "\t" + contact.Email);
                            }
                            break;
                        case 5:
                            binder.CreateDictionary();
                            foreach (var key in binder.CityDictionary.Keys)
                            {
                                Console.WriteLine(key + "\t" + binder.CityDictionary[key].Count);
                            }
                            break;
                        case 6:
                            book.AlphabeticallyArrange();
                            break;
                        case 7:
                            book.SortByPincode();
                            break;
                        case 8:
                            book.SortByCity();
                            break;
                        case 9:
                            book.SortByState();
                            break;
                        case 10:
                            Console.WriteLine("Writing contacts in file");
                            //writes using stream writer
                            //AddressBook book = new AddressBook();
                            book.WriteUsingStreamWriter();
                            //reads from stream reader
                            //ReadWrite.ReadFromStreamReader();
                            break;
                        case 11:
                            Console.WriteLine("riting contacts in csv file");
                            book.WriteUsingCSV();
                            //ReadWrite.ReadFromStreamReader();
                            break;
                        case 12:
                            loop = 0;
                            break;


                    }
                    binder.Binder[addrName] = (book.People);
                }
                Console.WriteLine("Do you want to enter an address book. \n1. yes \n2. no");
                result = int.Parse(Console.ReadLine());
            }
            //traversing through binder class
            foreach (var key in binder.Binder.Keys)
            {
                data.Add(key);
                //traversing ithrough contact class
                foreach (Contact c in binder.Binder[key])
                {
                    data.Add(c.ToString());
                }
            }

        }
    }
    
}
