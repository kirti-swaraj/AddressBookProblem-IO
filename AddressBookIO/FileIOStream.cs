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
            string path = @"C:\Users\Sai\source\repos\AddressBookIO\AddressBookIO\ContactList.txt";
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
            string path = @"C:\Users\Sai\source\repos\AddressBookIO\AddressBookIO\ContactList.txt";
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
        /// <summary>
        /// UC 14 : Read the CSV file contents if existing otherwise throw exception
        /// </summary>
        /// <param name="addressBook"></param>
        public static void CSVFileReading(AddressBookMain addressBook)
        {
            try
            {
                string csvFilePath = @$"C:\Users\Sai\source\repos\AddressBookIO\AddressBookIO\{addressBook.addressBookName}ADDRESSBOOK.csv";
                /// Initialize a new instance of the StreamReader class
                var reader = new StreamReader(csvFilePath);
                /// Creates an new CSV reader using the given TextReader
                var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                /// Store into the list the details which we get by GetRecords() method
                var records = csv.GetRecords<Contact>().ToList();
                foreach (Contact contact in records)
                {
                    Console.WriteLine("\nFullName: " + contact.firstName + " " + contact.lastName + "\nAddress: " + contact.address + "\nCity: " + contact.city + "\nState: " + contact.state + "\nZip: " + contact.zip + "\nPhoneNumber: " + contact.phoneNumber + "\nEmail: " + contact.email + "\n");
                }
                /// Close the object so others can use the file residing at the path
                reader.Close();
            }
            catch (Exception e)
            {
                /// If the file is not present at the path you need to create new file at that path
                Console.WriteLine(e.Message);
                Console.WriteLine("File you are trying to access does not exist please create one");
            }

        }

        /// <summary>
        /// UC 14 : 
        /// </summary>
        /// <param name="addressBook"></param>
        public static void CSVFileWriting(AddressBookMain addressBook)
        {
            string csvFilePath = @$"C:\Users\Sai\source\repos\AddressBookIO\AddressBookIO\{addressBook.addressBookName}ADDRESSBOOK.csv";
            /// Initialize an instance of StreamWriter class to perform write operation
            var writer = new StreamWriter(csvFilePath);
            /// Creates an new CSV writer using the given TextWriter
            /// CultureInfo provides the information about the delimeter and accordingly creates csv writer
            var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            /// Writes the records into the csv file
            csv.WriteRecords(addressBook.contactList);
            /// Clears all the buffered data and cache
            writer.Flush();
            writer.Close();
        }
    }
}