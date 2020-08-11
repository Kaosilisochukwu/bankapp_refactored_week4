using bankapp_refactored_week4.ClassLibraries;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.TestProjects
{
    class TransactionTests
    {

        [Test]
        public void AllCustomerTransactionsAreRecorded()
        {
            //Arrange
            //created new customer
            Customer customer1 = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
            Customer customer2 = new Customer("Deola", "Idowu", "Deola@maing.guy", "deola");
            int currentNumberOfTransactions = BankAccount.AllTransactions.Count;

            //Act
            //Make 4 new transactions
            BankAccount customerAccount = new BankAccount(customer1, 1000, "savings");
            BankAccount customerAccount2 = new BankAccount(customer1, 2000, "current");
            customerAccount.MakeDeposit(customerAccount, 100, "savings");
            customerAccount.MakeWithdrawal(customerAccount, 400, "flexing");

            //Assert
            //checked if transaction in the store is increased by 4;
            Assert.That(BankAccount.AllTransactions.Count, Is.EqualTo(currentNumberOfTransactions + 4));

        }

    }
}
