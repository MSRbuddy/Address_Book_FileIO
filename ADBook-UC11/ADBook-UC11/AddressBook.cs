﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProblem
{   
    public class AddressBook
    {
        // List Collection used to cover the domain of contact addition inside an address book
        public List<ContactDetails> contactList = new List<ContactDetails>();
        // List Collection used to cover the domain of contact addition inside an address book in a sorted manner by name
        public List<ContactDetails> sortedContactList = new List<ContactDetails>();
        // Field storing the name of the address book
        public string nameOfAddressBook = "";
        // Delegate declared to define a lambda function for checking duplicacy
        public delegate bool CheckForDuplicate(string firstName, string lastName);
        // Delegate declared to define a lambda function for ordering by the state name and storing in a dictionary
        public delegate void ListByState(string state);
        // Delegate declared to define a lambda function for ordering by the city name and storing in a dictionary
        public delegate void ListByCity(string city);

        // Contact detail variables
        public string firstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public long zip;
        public long phoneNumber;
        public string email;

        // Dictionary to add the list of person with the as the state name
        public static Dictionary<string, List<string>> nameByState = new Dictionary<string, List<string>>();
        
        // Dictionary to add the list of person with the as the city name
        public static Dictionary<string, List<string>> nameByCity = new Dictionary<string, List<string>>();
       
        // Initializes a new instance of the <see cref="AddressBook"/> class.     
        public AddressBook(string nameOfAddressBook)
        {
            this.nameOfAddressBook = nameOfAddressBook;
        }

        // Add a contact detail inside the address book
        public void AddContact()
        {
            // Flag to check the willingness to enter more contact details
            char ch = 'y';
            while (ch == 'y' || ch == 'Y')
            {
                Console.WriteLine("\nEnter The First Name = ");
                firstName = Console.ReadLine();

                Console.WriteLine("\nEnter The Last Name =");
                lastName = Console.ReadLine();

                //Lambda Function defined to check duplicacy of the contact
                CheckForDuplicate duplicate = (firstName, lastName) =>
                {
                    foreach (var contactObj in this.contactList)
                    {
                        if ((firstName == contactObj.firstName) && (lastName == contactObj.secondName))
                        {
                            Console.WriteLine("Same Entry is present in the contact list");
                            return true;
                        }
                    }
                    return false;
                };
                //Invoking the lambda function for checking duplicacy
                bool prescenceDuplicate = duplicate.Invoke(firstName, lastName);
                //Ternary statement for indicating the prescence
                Console.WriteLine(prescenceDuplicate ? "Already Present" : "Absent, Go ahead with new entry!");
                // UC-7 Checking for duplicate of the contacts inside the address book on basis of the name
                if (prescenceDuplicate)
                {
                    Console.WriteLine("No duplicate entry allowed");
                }
                else
                {
                    Console.WriteLine("\nEnter The Address =");
                    address = Console.ReadLine();

                    Console.WriteLine("\nEnter The City =");
                    city = Console.ReadLine();

                    Console.WriteLine("\nEnter The State =");
                    state = Console.ReadLine();

                    Console.WriteLine("\nEnter the Zip code");
                    zip = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("\nEnter The phone number = ");
                    phoneNumber = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("\nEnter The Email of Contact");
                    email = Console.ReadLine();

                    // Adding the details once validated for not a duplicate entry
                    ContactDetails addNewContact = new ContactDetails(firstName, lastName, address, city, state, zip, phoneNumber, email);
                    this.contactList.Add(addNewContact);
                    Console.WriteLine("\nContact Was added to the contact list");
                }
                Console.WriteLine("Press y or Y to enter more Data OR Press any other word key to exit....");
                ch = Convert.ToChar(Console.ReadLine());
            }

        }

        // Edits the contact details.
        public void EditContactDetails()
        {
            int index = 0;

            Console.WriteLine("Enter the first name of person whose data to be modified=");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter the second name of person whose data to be modified=");
            lastName = Console.ReadLine();
            //Checking the index at which the designated data is present
            foreach (var contactObj in this.contactList)
            {

                if ((firstName == contactObj.firstName) && (lastName == contactObj.secondName))
                {
                    break;
                }
                index++;
            }
            Console.WriteLine("Enter the modified data===>");

            Console.WriteLine("Enter the first name=");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter the second name=");
            lastName = Console.ReadLine();
            Console.WriteLine("Enter the address=");
            address = Console.ReadLine();
            Console.WriteLine("Enter the City=");
            city = Console.ReadLine();
            Console.WriteLine("Enter the State=");
            state = Console.ReadLine();
            Console.WriteLine("Enter the zip code=");
            zip = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter the Phone number=");
            phoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter the emailId=");
            email = Console.ReadLine();

            contactList[index].firstName = firstName;
            contactList[index].secondName = lastName;
            contactList[index].address = address;
            contactList[index].city = city;
            contactList[index].state = state;
            contactList[index].zip = zip;
            contactList[index].phoneNumber = phoneNumber;
            contactList[index].emailId = email;
        }

        // Delete the records inside an address book
        public void DeleteDetails()
        {
            Console.WriteLine("Enter the first name of person whose data to be modified=");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter the second name of person whose data to be modified=");
            lastName = Console.ReadLine();

            int index = 0;
            foreach (var contactObj in contactList)
            {

                if ((firstName == contactObj.firstName) && (lastName == contactObj.secondName))
                {
                    break;
                }
                index++;
            }
            contactList.RemoveAt(index);
        }

        public void DisplayDetails()
        {
            Console.WriteLine("First Name  ----- Second Name ----- Addres ----- City ----- State ----- Zip ----- Phone Number ----- Email Id");
            foreach (var contactObj in this.contactList)
            {
                Console.WriteLine(contactObj.firstName + "            " + contactObj.secondName + "            " + contactObj.address + "       " + contactObj.city + "      " + contactObj.state + "       " + contactObj.zip + "       " + contactObj.phoneNumber + "        " + contactObj.emailId);
            }
        }

        // Function to sort the contact details stored inside a address book on basis of distinct state name      
        public Dictionary<string, List<string>> GetContactNameByState()
        {
            //A List to store the state name distinctly
            List<string> stateDistinct = new List<string>();
            //Lambda expression aimed to make a route of entire address book for getting the contacts of same state
            ListByState listByState = (state) =>
            {
                //List to store the found contact names
                List<string> contactName = new List<string>();
                //Loop iterating over the contact List of an contact list to store the matching contacts name
                foreach (var contactObject in contactList)
                {
                    //Matching condition of state with the lambda parameter
                    if (contactObject.state == state)
                        contactName.Add(contactObject.firstName + "\t" + contactObject.secondName);
                }
                //Adding a mapped value of state to contact name
                nameByState.Add(state, contactName);
            };
            //Loop iterating over the contact list to get distinct state
            foreach (var contactObj in contactList)
            {
                if ((stateDistinct.Contains(contactObj.state)))
                {
                    continue;
                }
                else
                    stateDistinct.Add(contactObj.state);
            }
            foreach (var stateName in stateDistinct)
            {
                //Invoking the lambda function by passing the state name as the parameter and then evaluating contact details
                listByState.Invoke(stateName);
            }
            return nameByState;
        }

        // Function to sort the contact details stored inside a address book on basis of distinct city name
       
        public Dictionary<string, List<string>> GetContactNameByCity()
        {
            //A List to store the city name distinctly
            List<string> cityDistinct = new List<string>();
            //Lambda expression aimed to make a route of entire contact detail for getting the contacts of same city
            ListByCity listByCity = (city) =>
            {
                List<string> contactName = new List<string>();
                foreach (var contactObject in contactList)
                {
                    //Matching condition of city with the lambda parameter
                    if (contactObject.city == city)
                        contactName.Add(contactObject.firstName + "\t" + contactObject.secondName);
                }
                //Adding a mapped value of state to contact name
                nameByCity.Add(city, contactName);
            };
            //Loop iterating over the contact list to get distinct city
            foreach (var contactObj in contactList)
            {
                if ((cityDistinct.Contains(contactObj.city)))
                {
                    continue;
                }
                else
                    cityDistinct.Add(contactObj.city);
            }
            foreach (var cityName in cityDistinct)
            {
                //Invoking the lambda function by passing the city name as the parameter and then evaluating contact details
                listByCity.Invoke(cityName);
            }
            return nameByCity;
        }

        // Display the name of the person order by the state name      
        public void DisplayByState()
        {
            Dictionary<string, List<string>> nameByState = GetContactNameByState();
            foreach (var dictionaryElement in nameByState)
            {
                Console.WriteLine("================" + dictionaryElement.Key + "================");
                List<string> name = dictionaryElement.Value;
                foreach (string contactName in name)
                    Console.WriteLine(contactName + "\n");
            }
        }

        // Display the name of the person order by the city name      
        public void DisplayByCity()
        {
            Dictionary<string, List<string>> nameByCity = GetContactNameByCity();
            //Iterating over the dictionary to print the details we mapped
            foreach (var dictionaryElement in nameByCity)
            {
                Console.WriteLine("================" + dictionaryElement.Key + "================");
                List<string> name = dictionaryElement.Value;
                foreach (string contactName in name)
                    Console.WriteLine(contactName + "\n");
            }
        }

        // UC-10 Display the count of the person order by the state name     
        public void DisplayCountByState()
        {
            Dictionary<string, List<string>> nameByState = GetContactNameByState();
            //Displaying count of  all the contacts recieved
            foreach (var dictionaryElement in nameByState)
            {
                Console.WriteLine(dictionaryElement.Key + "=" + dictionaryElement.Value.Count);
            }

            Console.WriteLine("Display by name");
            Console.WriteLine("Enter the name of the state=");
            string state = Console.ReadLine();
            //Displaying the count of the contact list as per the state matched when entered by the user
            foreach (var dictionaryElement in nameByState)
            {
                if (dictionaryElement.Key == state)
                    Console.WriteLine(dictionaryElement.Key + "=" + dictionaryElement.Value.Count);
            }
        }

        // UC10 Display the count of the person order by the state name     
        public void DisplayCountByCity()
        {
            //Calling the getting contact name by city inside a dictionary
            Dictionary<string, List<string>> nameByCity = GetContactNameByCity();
            foreach (var dictionaryElement in nameByCity)
            {
                Console.WriteLine(dictionaryElement.Key + "=" + dictionaryElement.Value.Count);
            }

            Console.WriteLine("Display by name");
            Console.WriteLine("Enter the name of the city=");
            string city = Console.ReadLine();
            foreach (var dictionaryElement in nameByCity)
            {
                if (dictionaryElement.Key == city)
                    Console.WriteLine(dictionaryElement.Key + "=" + dictionaryElement.Value.Count);
            }
        }
       
        // UC11- Sorting by the name to get a sorted list of contacts
       
        public void SortByName()
        {
            //Using a sorted list and sorting by key of first name
            SortedList<string, ContactDetails> sortByName = new SortedList<string, ContactDetails>();
            foreach (var contact in this.contactList)
            {
                sortByName.Add(contact.firstName, contact);
            }
            Console.WriteLine("First Name  ----- Second Name ----- Address ----- City ----- State ----- Zip ----- Phone Number ----- Email Id");
            foreach (var contactObj in sortByName)
            {
                Console.WriteLine(contactObj.Value.firstName + "\t" + contactObj.Value.secondName + "\t"
                    + "\t" + contactObj.Value.address + "\t" + contactObj.Value.city + "\t" + contactObj.Value.state
                    + "\t" + contactObj.Value.zip + "\t" + contactObj.Value.phoneNumber + "\t" + contactObj.Value.emailId);
            }
        }
    }
}