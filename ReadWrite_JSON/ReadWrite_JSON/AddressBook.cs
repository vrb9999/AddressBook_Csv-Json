using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReadWrite_JSON
{
    public class AddressBook
    {
        //THE LIST STORES MULTIPLE CONTACTS THE USER ADDS
        public List<Contact> contactList = new List<Contact>();
        public static Dictionary<string, List<string>> cityAndStatePersonDictionary = new Dictionary<string, List<string>>();
        // SPECIFIES THE NAME OF THE ADDRESS BOOK
        public string addressBookName;

        public AddressBook(string addressBookName)
        {
            this.addressBookName = addressBookName;
        }
        //ADDS A NEW CONTACT TO THE LIST "CONTACTLIST"
        public void AddNewContact()
        {
            Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine().ToUpper();

            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine().ToUpper();

            Console.WriteLine("Enter address");
            string address = Console.ReadLine().ToUpper();

            Console.WriteLine("Enter city name");
            string city = Console.ReadLine().ToUpper();

            Console.WriteLine("Enter state");
            string state = Console.ReadLine().ToUpper();

            Console.WriteLine("Enter zip");
            double zip = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter phone number");
            double phoneNumber = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter email");
            string email = Console.ReadLine().ToLower();

            Contact contact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
            //Contact contact = new Contact();
            bool flag = false;
            string fullName = firstName + " " + lastName;
            foreach (var v in contactList)
            {
                //CALLING OVERRIDDEN Equals() METHOD WITH EACH OBJECT IN CONTACTLIST AS PARAMETER TO CHECK FOR DUPLICATES
                if (contact.Equals(v))
                {
                    Console.WriteLine("\nError: A Contact already exists with name {0} {1}, please enter a different name to add new contact", firstName, lastName);
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                contactList.Add(contact);
                Console.WriteLine("\nContact " + firstName + " " + lastName + " added successfully");
                //ADDS THE ENTERED NAME IN A LIST IN THE DICTIONARY ALONG THE PROPER CITY AND STATE NAME
                AddPersonInStateOrCityDictionary(city, fullName);
                AddPersonInStateOrCityDictionary(state, fullName);
            }
        }
        public void SearchContactByName()
        {
            bool flag = true;
            Console.WriteLine("Enter the first name of contact you want to view");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the last name of contact you want to view");
            string lastName = Console.ReadLine();
            Console.WriteLine("\nDetails of " + firstName + " " + lastName + ":");
            foreach (var v in contactList)
            {
                //MATCHES THE FIRST NAME AND LAST NAME TO DISPLAY CONTACT DETAILS
                if (firstName == v.firstName && lastName == v.lastName)
                {
                    Console.WriteLine("FullName: " + v.firstName + " " + v.lastName + "\nAddress: " + v.address + "\nCity: " + v.city + "\nState: " + v.state + "\nZip: " + v.zip + "\nPhoneNumber: " + v.phoneNumber + "\nEmail: " + v.email + "\n");
                    flag = false;
                    break;
                }
            }
            if (flag == true)
                Console.WriteLine("Contact not found");
        }
        //DISPLAYS ALL AVAILABLE CONTACTS IN THE CURRENT ADDRESS BOOK
        public void ViewAllContacts()
        {
            if (contactList.Count == 0)
            {
                Console.WriteLine("\nNo contact found, please add a contact to display");
            }
            foreach (var contact in contactList)
            {
                Console.WriteLine("\nFullName: " + contact.firstName + " " + contact.lastName + "\nAddress: " + contact.address + "\nCity: " + contact.city + "\nState: " + contact.state + "\nZip: " + contact.zip + "\nPhoneNumber: " + contact.phoneNumber + "\nEmail: " + contact.email + "\n");
            }
            //Console.WriteLine("Name of the Person : " + contact.firstName + " " + contact.lastName);
            //Console.WriteLine("Email ID : " + contact.email);
            //Console.WriteLine("Mobile Number : " + contact.phoneNumber);
            //Console.WriteLine("Address : " + contact.address);
            //Console.WriteLine("City : " + contact.city);
            //Console.WriteLine("Zip : " + contact.zip);
            //Console.WriteLine("\n");
        }
        public void EditContact()
        {
            bool flag1 = true;
            Console.WriteLine("Enter first name of the contact to edit");
            string firstName = Console.ReadLine().ToUpper();
            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine().ToUpper();
            foreach (var contact in contactList)
            {
                if (firstName == contact.firstName && lastName == contact.lastName)
                {
                    Console.WriteLine("\nTo edit contact details of " + firstName + " " + lastName + " enter:");
                    bool flag2 = true;
                    while (flag2)
                    {
                        Console.WriteLine("1-To update first name\n2-To update last name\n3-To update address\n4-To update city\n5-To update state\n6-To update zip\n7-To update phone number\n8-To update email\n9-To exit edit portal and save updates");
                        int updatePointer = Convert.ToInt32(Console.ReadLine());
                        if (updatePointer == 9)
                            break;
                        Console.WriteLine("Enter the new value");
                        var newValue = Console.ReadLine();
                        switch (updatePointer)
                        {
                            case 1:
                                contact.firstName = newValue;
                                break;
                            case 2:
                                contact.lastName = newValue;
                                break;
                            case 3:
                                contact.address = newValue;
                                break;
                            case 4:
                                contact.city = newValue;
                                break;
                            case 5:
                                contact.state = newValue;
                                break;
                            case 6:
                                contact.zip = Convert.ToDouble(newValue);
                                break;
                            case 7:
                                contact.phoneNumber = Convert.ToDouble(newValue);
                                break;
                            case 8:
                                contact.email = newValue;
                                break;
                            case 9:
                                flag2 = false;
                                break;
                        }
                        Console.WriteLine("Contact details updated successfully");
                        flag1 = false;
                    }
                }
            }
            if (flag1 == true)
                Console.WriteLine("Error:Contact not found");
        }
        public void DeleteContact()
        {
            bool flag = true;
            Console.WriteLine("Enter the first name of contact you want to delete");
            string firstName = Console.ReadLine().ToUpper();
            Console.WriteLine("Enter the last name of contact you want to delete");
            string lastName = Console.ReadLine().ToUpper();
            for (int i = 0; i < contactList.Count; i++)
            {
                if (firstName == contactList[i].firstName && lastName == contactList[i].lastName)
                {
                    //REMOVES THE VALUE AT THE POSITION WHICH CONTAINS THE ENTERED NAME
                    contactList.RemoveAt(i);
                    Console.WriteLine("\nContact {0} {1} deleted successfully", firstName, lastName);
                    flag = false;
                    //UPDATION OF DICTIONARY AFTER REMOVAL OF ANY ELEMENT
                    foreach (var kvp in cityAndStatePersonDictionary)
                    {
                        if (kvp.Value.Contains(firstName + " " + lastName))
                            kvp.Value.Remove(firstName + " " + lastName);
                    }
                }
            }
            if (flag == true)
                Console.WriteLine("Error:Contact not found");
        }
        //DISPLAYS NAME OF ALL CONTACTS WHO LIVE IN THE GIVEN STATE OR CITY
        public static void ViewPeopleByCityOrState()
        {
            Console.WriteLine("Enter either a city or state name to view contacts:");
            string cityOrStateName = Console.ReadLine().ToUpper();
            foreach (var kvp in cityAndStatePersonDictionary)
            {
                if (kvp.Key == cityOrStateName)
                {
                    foreach (var v in kvp.Value)
                    {
                        Console.WriteLine("Location " + cityOrStateName + ": " + v);
                    }
                    if (kvp.Value.Count == 0)
                        Console.WriteLine("\nNo contact found");
                }
            }
            if (cityAndStatePersonDictionary.Count == 0)
                Console.WriteLine("\nNo contact person found in " + cityOrStateName);
        }
        public void AddPersonInStateOrCityDictionary(string cityOrStateName, string fullName)
        {
            if (cityAndStatePersonDictionary.ContainsKey(cityOrStateName))
            {
                cityAndStatePersonDictionary[cityOrStateName].Add(fullName);
            }
            else
            {
                List<string> personNameList = new List<string>();
                personNameList.Add(fullName);
                cityAndStatePersonDictionary.Add(cityOrStateName, personNameList);
            }
        }
        public void SortByName()
        {
            if (contactList.Count == 0)
            {
                Console.WriteLine("\nNo contact found, please add a contact to display");
            }
            //Sort the list according to condition provided
            var v = contactList.OrderBy(c => c.firstName + c.lastName);
            foreach (var contact in v)
            {
                Console.WriteLine("\nFullName: " + contact.firstName + " " + contact.lastName + "\nAddress: " + contact.address + "\nCity: " + contact.city + "\nState: " + contact.state + "\nZip: " + contact.zip + "\nPhoneNumber: " + contact.phoneNumber + "\nEmail: " + contact.email + "\n");
            }
        }
        public void SortByCityStateOrZip()
        {
            if (contactList.Count == 0)
            {
                Console.WriteLine("\nNo contact found, please add a contact to display");
                return;
            }
            Console.WriteLine("Enter:\n1-To sort by city name\n2-To sort by state name\n3-To sort by zip");
            int options = Convert.ToInt32(Console.ReadLine());
            switch (options)
            {
                case 1:
                    var sortedList = contactList.OrderBy(person => person.city);
                    foreach (var contact in sortedList)
                    {
                        Console.WriteLine("\nCity: " + contact.city + "\nFullName: " + contact.firstName + " " + contact.lastName + "\nAddress: " + contact.address + "\nState: " + contact.state + "\nZip: " + contact.zip + "\nPhoneNumber: " + contact.phoneNumber + "\nEmail: " + contact.email + "\n");
                    }
                    break;
                case 2:
                    sortedList = contactList.OrderBy(person => person.state);
                    foreach (var contact in sortedList)
                    {
                        Console.WriteLine("\nState: " + contact.state + "\nFullName: " + contact.firstName + " " + contact.lastName + "\nAddress: " + contact.address + "\nCity: " + contact.city + "\nZip: " + contact.zip + "\nPhoneNumber: " + contact.phoneNumber + "\nEmail: " + contact.email + "\n");
                    }
                    break;
                case 3:
                    sortedList = contactList.OrderBy(person => person.zip);
                    foreach (var contact in sortedList)
                    {
                        Console.WriteLine("\nZip: " + contact.zip + "\nFullName: " + contact.firstName + " " + contact.lastName + "\nAddress: " + contact.address + "\nCity: " + contact.city + "\nState: " + contact.state + "\nPhoneNumber: " + contact.phoneNumber + "\nEmail: " + contact.email + "\n");
                    }
                    break;
            }
        }
    }
}
