using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBookIO
{
    /// <summary>
    /// Class to perform IO operations
    /// </summary>
    class FileIOStream
    {
        /// <summary>
        /// UC 13 : Reads the file present at the path and displays details in console.
        /// </summary>
        public static void ReadFilestream()
        {
            string path = @"C:\Users\hp\source\repos\AddressBookIO\AddressBookIO\ContactList.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                        Console.WriteLine(line); ;
                }
            }
            else
                Console.WriteLine("File not found");
        }

        /// <summary>
        /// UC 13 : Writes into the file present at the path the details of the passed address book.
        /// </summary>
        /// <param name="addressBook">The address book.</param>
        public static void WriteFileStream(AddressBookMain addressBook)
        {
            string path = @"C:\Users\hp\source\repos\AddressBookIO\AddressBookIO\ContactList.txt";
            if (File.Exists(path))
            {
                using (StreamWriter sr = File.AppendText(path))
                {
                    /// Writes the entered string into the file
                    sr.Write("\nCONTACT DETAILS IN ADDRESSBOOK: {0}=>\n", addressBook.addressBookName);
                    for (int i = 0; i < addressBook.contactList.Count; i++)
                    {
                        string line = "\n" + (i + 1) + ".\tFullName: " + addressBook.contactList[i].firstName + " " + addressBook.contactList[i].lastName + "\n\tAddress: " + addressBook.contactList[i].address + "\n\tCity: " + addressBook.contactList[i].city + "\n\tState: " + addressBook.contactList[i].state + "\n\tZip: " + addressBook.contactList[i].zip + "\n\tPhoneNumber: " + addressBook.contactList[i].phoneNumber + "\n\tEmail: " + addressBook.contactList[i].email + "\n";
                        sr.Write(line);
                    }
                }
            }
            ReadFilestream();
        }
    }
}