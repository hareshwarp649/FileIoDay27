using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOOperationAddress
{
    internal class AddressBookBinder
    {
        public Dictionary<string, List<Contact>> Binder = new Dictionary<string, List<Contact>>();
        public Dictionary<string, List<Contact>> CityDictionary = new Dictionary<string, List<Contact>>();

       

        public List<Contact> AddAddrBook(string key, List<Contact> set)
        {
            if (this.Binder.ContainsKey(key))
            {
                Console.WriteLine("Address book already exists");
                return Binder[key];
            }
            else
            {
                Console.WriteLine("New address book created");
                Binder.Add(key, set);
                return Binder[key];
            }
        }

      

        public List<string> DistinctCities()
        {
            List<string> City = new List<string>();
            foreach (var key in Binder.Keys)
            {
                foreach (Contact c in Binder[key])
                {
                    if (City.Contains(c.City))
                        continue;
                    else
                        City.Add(c.City);
                }
            }
            return City;
        }

      

        public void CreateDictionary()
        {
            List<string> City1 = DistinctCities();
            foreach (string city in City1)
            {
                List<Contact> CityContact = new List<Contact>();
                foreach (var key in Binder.Keys)
                {
                    foreach (Contact c in Binder[key])
                    {
                        if (c.City == city)
                            CityContact.Add(c);
                    }
                }
                if (this.CityDictionary.ContainsKey(city))
                    CityDictionary[city] = CityContact;
                else
                    CityDictionary.Add(city, CityContact);
            }
        }
    }
}
