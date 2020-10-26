// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressBookList.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kirti Swaraj"/>
// --------------------------------------------------------------------------------------------------------------------
namespace AddressBookIO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// CONTAINS NUMEROUS ADDRESS BOOKS
    /// </summary>
    public class AddressBookList
    {
        /// <summary>
        /// STORES THE NUMEROUS ADDRESS BOOKS WITH KEY AS THE ADDDRESS BOOK NAME
        /// </summary>
        public Dictionary<string, AddressBookMain> addressBookListDictionary = new Dictionary<string, AddressBookMain>();

        /// <summary>
        /// UC 6 : ADDS A NEW ADDRESS BOOK WITH UNIQUE NAME TO THE SYSTEM
        /// </summary>
        public void AddNewAddressBook()
        {
            Console.WriteLine("Enter the name of address book:");
            string addressBookName = Console.ReadLine().ToUpper();
            AddressBookMain addressBook = new AddressBookMain(addressBookName);
            /// HANDLES THE EXCEPTION WHEN THE USER TRIES TO ENTER DUPLICATE ADDRESS BOOK NAME
            try
            {
                addressBookListDictionary.Add(addressBookName, addressBook);
                Console.WriteLine("\nAddress Book " + addressBookName + " added successfully");
                Console.WriteLine("Updated Address Book List:");
                foreach (var kvp in addressBookListDictionary)
                {
                    Console.WriteLine(kvp.Key);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Address Book {0} already exists, please access it or add a new address book with different name!", addressBookName);
            }
        }

        /// <summary>
        /// CHECKS FOR AN EXISTING ADDRESS BOOK IN THE SYSTEM
        /// IF FOUND RETURNS ITS NAME ELSE RETURNS NULL VALUE
        /// </summary>
        /// <returns>addressBookName</returns>
        public string ExistingAddressBook()
        {
            Console.WriteLine("Enter the Address Book name");
            string addressBookName = Console.ReadLine().ToUpper();
            string result = "";
            bool flag = true;
            foreach (var kvp in addressBookListDictionary)
            {
                if (kvp.Key == addressBookName)
                {
                    result = addressBookName;
                    flag = false;
                    break;
                }
            }
            if (flag == true)
            {
                Console.WriteLine("No Address Book with name " + addressBookName + " found\nPlease create a new address book");
            }
            return result;
        }

        /// <summary>
        /// UC 8 : SEARCHES FOR THE PERSON IN A PARTICULAR STATE OR CITY ACROSS ALL ADDRESS BOOKS AND DISPLAYS THE DETAILS
        /// </summary>
        public void SearchPersonByCityOrState()
        {
            AddressBookMain addressBook = new AddressBookMain();
            Console.WriteLine("Enter either a city or state name below to search for people:");
            string cityOrStateName = Console.ReadLine().ToUpper();
            Console.WriteLine("Enter first name of the person you are searching");
            string firstName = Console.ReadLine().ToUpper();
            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine().ToUpper();
            if (addressBookListDictionary.Count != 0)
            {
                bool flag = false;
                foreach (var kvp in addressBookListDictionary)
                {
                    for (int i = 0; i < kvp.Value.contactList.Count; i++)
                    {
                        if (kvp.Value.contactList[i].city == cityOrStateName || kvp.Value.contactList[i].state == cityOrStateName)
                        {
                            if (kvp.Value.contactList[i].firstName == firstName && kvp.Value.contactList[i].lastName == lastName)
                            {
                                /// IF BOTH NAME AND CITY/STATE OF A CONTACT ACROSS ANY ADDRESS BOOK MATCHES THE ENTERED DETAILS
                                Console.WriteLine("\nContact found inside address book: " + kvp.Key);
                                Console.WriteLine("FullName: " + kvp.Value.contactList[i].firstName + " " + kvp.Value.contactList[i].lastName + "\nAddress: " + kvp.Value.contactList[i].address + "\nCity: " + kvp.Value.contactList[i].city + "\nState: " + kvp.Value.contactList[i].state + "\nZip: " + kvp.Value.contactList[i].zip + "\nPhoneNumber: " + kvp.Value.contactList[i].phoneNumber + "\nEmail: " + kvp.Value.contactList[i].email + "\n");
                                flag = true;
                                break;
                            }
                        }
                    }
                }
                /// IF flag VALUE DOES NOT CHANGE MEANS NO MATCH FOR THE ENTERED DETAILS WAS FOUND
                if (flag == false)
                    Console.WriteLine("\nNo such contact found");
            }
            else
                Console.WriteLine("\nNo stored address book found, please add one");
        }
    }
}
