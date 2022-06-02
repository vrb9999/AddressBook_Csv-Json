using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ReadWrite_CSV
{
    public class FileIOStream
    {
        public static void ReadFilestream()
        {
            string path = @"D:\RFP\AddressBook_FileIO\ReadOrWriteAddressBook_UsingFileIO\ReadOrWriteAddressBook_UsingFileIO\ContactList.txt";
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
        public static void WriteFileStream(AddressBook addressBook)
        {
            string path = @"D:\RFP\AddressBook_FileIO\ReadOrWriteAddressBook_UsingFileIO\ReadOrWriteAddressBook_UsingFileIO\ContactList.txt";
            if (File.Exists(path))
            {
                using (StreamWriter sr = File.AppendText(path))
                {
                    //Writes the entered string into the file
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
        public static void CSVFileReading(AddressBook addressBook)
        {
            try
            {
                string csvFilePath = @$"D:\RFP\AddressBook_Csv-Json\ReadWrite_CSV\ReadWrite_CSV\csv files\{addressBook.addressBookName}AddressBook.csv";
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
        public static void CSVFileWriting(AddressBook addressBook)
        {
            string csvFilePath = @$"D:\RFP\AddressBook_Csv-Json\ReadWrite_CSV\ReadWrite_CSV\csv files\{addressBook.addressBookName}AddressBook.csv";
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
