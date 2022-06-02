using System;

namespace ReadWrite_JSON
{
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
                Console.WriteLine("\nEnter:\n1-To add a new address Book\n2-Print all address book\n3-To access an existing address book" +
                "\n4-To search person in a state or city across multiple address books\n5-View all persons of a city or state\n6-To get count of contacts present at a city or state\n7-To exit");
                int options1 = Convert.ToInt32(Console.ReadLine());
                switch (options1)
                {
                    case 1:
                        addressBookList.AddNewAddressBook();
                        break;
                    case 2:
                        addressBookList.PrintAllAddressBookNames();
                        break;
                    case 3:
                        currentAddressBookName = addressBookList.ExistingAddressBook();
                        break;
                    case 4:
                        addressBookList.SearchPersonByCityOrState();
                        break;
                    case 5:
                        AddressBook.ViewPeopleByCityOrState();
                        break;
                    case 6:
                        addressBookList.GetCountByCityOrState();
                        break;
                    case 7:
                        flag1 = false;
                        break;
                }
                if (currentAddressBookName != "")
                {
                    bool flag2 = true;
                    while (flag2)
                    {
                        Console.WriteLine("\nCurrent address book:" + currentAddressBookName);
                        Console.WriteLine("Enter:\n1-To add a new contact\n2-To edit an existing contact\n3-To search for an existing contact\n4-To delete a contact\n5-To display all contacts in the address book"+"" +
                            "\n6-Sort names alphabetically\n7-Sort by city, state or zip\n8-To Write and then Read all contacts into the file\n9-To Write/Read contact details into the addressBook CSV file"+
                            "\n10-To Write/Read contact details into the addressBook json file\n11-To return to main menu");
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
                                addressBookList.addressBookListDictionary[currentAddressBookName].ViewAllContacts();
                                break;
                            case 6:
                                addressBookList.addressBookListDictionary[currentAddressBookName].SortByName();
                                break;
                            case 7:
                                addressBookList.addressBookListDictionary[currentAddressBookName].SortByCityStateOrZip();
                                break;
                            case 8:
                                FileIOStream.WriteFileStream(addressBookList.addressBookListDictionary[currentAddressBookName]);
                                break;
                            case 9:
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
                            case 10:
                                Console.WriteLine("press\n1-To Write\n2-To Read");
                                int opt = Convert.ToInt32(Console.ReadLine());
                                if (opt == 1)
                                {
                                    FileIOStream.JSONFileWriting(addressBookList.addressBookListDictionary[currentAddressBookName]);
                                    Console.WriteLine("File created/Details added successfully");
                                }
                                else if (opt == 2)
                                    FileIOStream.JSONFileReading(addressBookList.addressBookListDictionary[currentAddressBookName]);
                                break;
                            case 11:
                                flag2 = false;
                                break;
                        }
                    }
                }
            }
        }
    }
}
