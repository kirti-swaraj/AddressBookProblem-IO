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
                Console.WriteLine("Enter:\n1-To add a new contact\n2-To edit an existing contact\n3-To search for an existing contact+" +
                    "\n4-To delete a contact\n5-To display all contacts in the address book sorted by Name+" +
                    "\n6-To display contacts sorted by city,state or zip\n7-To Write and then Read all contacts into the file+" +
                    "\n8-To return to main menu");
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
                        Console.WriteLine("Enter:\n1-To add a new contact\n2-To edit an existing contact\n3-To search for an existing contact\n4-To delete a contact\n5-To display all contacts in the address book sorted by Name\n6-To display contacts sorted by city,state or zip\n7-To Write and then Read all contacts into a txt file\n8-To Write/Read contact details into the addressBook CSV file\n9-To return to main menu");
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
                                FileIOStream.WriteFileStream(addressBookList.addressBookListDictionary[currentAddressBookName]);
                                break;
                            case 8:
                                Console.WriteLine("press\n1-To Write\n2-To Read");
                                int options = Convert.ToInt32(Console.ReadLine());
                                if (options == 1)
                                {
                                    FileIOStream.CSVFileWriting(addressBookList.addressBookListDictionary[currentAddressBookName]);
                                    Console.WriteLine("File created/Details added successfully");
                                }
                                else if (options == 2)
                                    FileIOStream.CSVFileReading(addressBookList.addressBookListDictionary[currentAddressBookName]);
                                break;
                            case 9:
                                flag2 = false;
                                break;
                        }
                    }
                }
            }
        }
    }
}