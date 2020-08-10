using bankapp_refactored_week4.ClassLibraries;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.TestProjects
{
    class TransactionTests
    {
        Customer customer1 = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
        Customer customer2 = new Customer("Deola", "Idowu", "Deola@maing.guy", "deola");
        [Test]
        public void AllCustomerTransactionsAreRecorded()
        {
            int currentNumberOfTransactions = BankAccount.AllTransactions.Count;
            BankAccount customerAccount = new BankAccount(customer1, 1000, "savings");
            BankAccount customerAccount2 = new BankAccount(customer1, 2000, "current");
            customerAccount.MakeDeposit(customerAccount, 100, "savings");
            customerAccount.MakeWithdrawal(customerAccount, 400, "flexing");

            Assert.That(BankAccount.AllTransactions.Count, Is.EqualTo(currentNumberOfTransactions + 4));

        }

    }
}
