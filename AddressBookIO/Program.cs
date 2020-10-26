// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kirti Swaraj"/>
// --------------------------------------------------------------------------------------------------------------------
namespace AddressBookIO
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO ADDRESS BOOK PROGRAM");
            MainMenuOperation();
        }
        public static void MainMenuOperation()
        {
            AddressBookList addressBookList = new AddressBookList();
            bool flag1 = true;
            while (flag1)
            {
                string currentAddressBookName = "";
                Console.WriteLine("\nEnter:\n1-To add a new address Book\n2-To access an existing address book" +
                    "\n3-To search person in a state or city across multiple address books\n4-View all persons of a city or state" +
                    "\n5-To get count of contacts present at a city or state\n6-To exit");
                int options1 = Convert.ToInt32(Console.ReadLine());
                switch (options1)
                {
                    case 1:
                        addressBookList.AddNewAddressBook();
                        break;
                    case 2:
                        currentAddressBookName = addressBookList.ExistingAddressBook();
                        break;
                    case 3:
                        addressBookList.SearchPersonByCityOrState();
                        break;
                    case 4:
                        AddressBookMain.ViewPeopleByCityOrState();
                        break;
                    case 5:
                        AddressBookMain.GetCountByCityOrState();
                        break;
                    case 6:
                        flag1 = false;
                        break;
                }
                if (currentAddressBookName != "")
                {
                    bool flag2 = true;
                    while (flag2)
                    {
                        Console.WriteLine("\nCurrent address book:" + currentAddressBookName);
                        Console.WriteLine("Enter:\n1-To add a new contact\n2-To edit an existing contact\n3-To search for an existing contact\n4-To delete a contact\n5-To display all contacts in the address book sorted by Name\n6-To display contacts sorted by city,state or zip\n7-To return to main menu");
                        int options2 = Convert.ToInt32(Console.ReadLine());
                        switch (options2)
                        {
                            case 1:
                                addressBookList.addressBookListDictionary[currentAddressBookName].AddNewContact();
                                break;
                            case 2:
                                addressBookList.addressBookListDictionary[currentAddressBookName].EditContact();
                                break;
                            case 3:
                                addressBookList.addressBookListDictionary[currentAddressBookName].SearchContactByName();
                                break;
                            case 4:
                                addressBookList.addressBookListDictionary[currentAddressBookName].DeleteContact();
                                break;
                            case 5:
                                addressBookList.addressBookListDictionary[currentAddressBookName].SortByName();
                                break;
                            case 6:
                                addressBookList.addressBookListDictionary[currentAddressBookName].SortByCityStateOrZip();
                                break;
                            case 7:
                                flag2 = false;
                                break;
                        }
                    }
                }
            }
        }
    }
}