using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.ClassLibraries
{
    class BankAccount
    {
        private static int accountNumber = 1058848950;
        public BankAccount(Customer customer, decimal initialDeposit, string accountType)
        {
            CustomerName = $"{customer.FirstName} {customer.LastName}";
            AccountType = accountType;
            AccountNumber = accountNumber;
            CustomerId = customer.CustomerId;
            accountNumber += 123;
            AllBankAccounts.Add(this);
            AllCustomers.Add(customer);
            MakeDeposite(this, initialDeposit, "initial Deposit");
        }

        public string CustomerName { get; set; }
        public string AccountType { get; }
        public decimal AccountBalance { get; set; }
        public int AccountNumber { get; }
        public int CustomerId { get; }

        private List<BankTransactions> AllTransactions = new List<BankTransactions>();

        private static List<BankAccount> AllBankAccounts = new List<BankAccount>();

        private static List<Customer> AllCustomers = new List<Customer>();
        public void MakeDeposite(BankAccount account, decimal amount, string note)
        {
            if (amount < 1)
                throw new InvalidOperationException("You are trying to deposit an invalid amount");
            AccountBalance += amount;
            BankTransactions transaction = new BankTransactions(account, amount, AccountBalance, note, DateTime.Now);
            AllTransactions.Add(transaction);

        }
        public static void GetAllAccounts()
        {
            foreach (var transction in AllBankAccounts)
            {
                Console.WriteLine($"{transction.AccountType}\t {transction.AccountNumber}\t {transction.CustomerName}\t {transction.AccountBalance} ");

            }
        }

        //TO PRING ALL CUSTOMERS TO THE CONSOLE
        public static void GetAllCustomers()
        {
            foreach (var customer in AllCustomers)
            {
                Console.WriteLine($"{customer.CustomerId}\t {customer.FirstName}\t {customer.LastName}\t {customer.Email}");
            }
        }
        //TO MAKE WITHDRAWAL
        public void MakeWithdrawal(BankAccount account, decimal amount, string note)
        {
            AccountBalance -= amount;
            BankTransactions transaction = new BankTransactions(account, -amount, AccountBalance, note, DateTime.Now);
            AllTransactions.Add(transaction);
        }
        //TO TRANSFER FUNDS FROM ONE ACCOUNT TO ANOTHER
        public void TransferFunds(BankAccount recipient, decimal amount, DateTime date, string note)
        {
            foreach (var account in AllBankAccounts)
            {
                if (account.AccountNumber == recipient.AccountNumber)
                {
                    MakeWithdrawal(this, amount, note);
                    recipient.MakeDeposite(recipient, amount, note);
                    Console.WriteLine($"You have successfully transfered {amount} to {recipient.CustomerName}\n\t\tAccount balance: {AccountBalance}");
                    break;
                }
            }
        }
        //TO GET CUSTOMER TRANSACTION DETAILS
        public void GetTransactionDetails(int customerAccountNumber)
        {
            foreach (var transction in AllTransactions)
            {
                if (transction.AccountNumber == customerAccountNumber)
                {
                    Console.WriteLine($"{transction.AccountType}\t {transction.AccountNumber}\t {transction.CustomerFullName}\t {transction.Amount}\t {transction.Note}\t {transction.Date} ");
                }
            }
        }
        public void GetAccountBalance()
        {
            Console.WriteLine($"You have {AccountBalance} left in your account {AccountNumber}");
        }

        //TO CHECK IF A BANK ACCOUNT EXIST
        public static bool bankAccountExists(string accountNumberstring)
        {
            bool bankAccountExist = false;
            if (AllBankAccounts.Count < 1)
            {
                return bankAccountExist;
            }
            if (int.TryParse(accountNumberstring, out int accountNumber))
            {
                foreach (var bankAccount in AllBankAccounts)
                {
                    if (bankAccount.AccountNumber == accountNumber)
                        bankAccountExist = true;
                }
            }
            else
                bankAccountExist = false;

            return bankAccountExist;
        }
        //TO RETURN A CUSTOMER'S BANK ACCOUNT
        public static BankAccount GetBankAccount(int accountNumber)
        {
            BankAccount customerBankAccount = null;
            foreach (var account in AllBankAccounts)
            {
                if (accountNumber == account.AccountNumber)
                    customerBankAccount = account;
            }
            return customerBankAccount;
        }
    }
}
