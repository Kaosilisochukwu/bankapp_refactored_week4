using bankapp_refactored_week4.ClassLibraries;
using bankapp_refactored_week4.HelperClasses;
using System;

namespace bankapp_refactored_week4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BankAccount.GetAllAccounts());
            BankController.RunBank();
            BankAccount.GetAllAccounts();
            BankAccount.GetAllCustomers();
        }
    }
}
