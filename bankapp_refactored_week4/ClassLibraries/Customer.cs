using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.ClassLibraries
{

    public class Customer
    {
        private static int customerId = 1;
        public Customer(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CustomerId = customerId;
            customerId += 1;
            Password = password;
            AllCustomers.Add(this);
        }

        private static List<Customer> AllCustomers = new List<Customer>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CustomerId { get; }
        public bool IsLoggedIn { get; set; }
        public string Password { get; private set; }

        //TO CHECK IF A CUSTOMER EXIST
        public static bool customerExists(string password, string email)
        {
            bool customerExist = false;
            if (AllCustomers.Count < 1)
            {
                return customerExist;
            }
            foreach (var customer in AllCustomers)
            {
                if (customer.Password == password && customer.Email.ToLower() == email.ToLower())
                    customerExist = true;
            }
            return customerExist;
        }

        //TO RETURN A REGISTERED CUSTOMERS
        public static Customer GetCurrentCustomer(string email, string password)
        {
            Customer currentCustomer = null;
            foreach (var customer in AllCustomers)
            {
                if (customer.Password == password && customer.Email == email)
                {
                    currentCustomer = customer;
                    break;
                }
            }
            return currentCustomer;
        }

    }
}
