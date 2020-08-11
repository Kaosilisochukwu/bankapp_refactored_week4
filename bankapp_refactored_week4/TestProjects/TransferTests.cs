using bankapp_refactored_week4.ClassLibraries;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.TestProjects
{
    class TransferTests
    {

        //Arrange
        //CREATED TWO CUSTOMERS TO TEST FOR TRANSFER
        Customer customer1 = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
        Customer customer2 = new Customer("Deola", "Idowu", "Deola@maing.guy", "deola");
        [Test]
        public void CustomerCanTransferToTheirOtherAccount()
        {
            //Arrange
            //INITIALIZED SOME VARIABLES
            decimal transferAmount = 1000;
            decimal customer1Account1Balance;
            decimal customer1Account2Balance;

            //Act 
            //CREATED TWO ACCOUNTS FOR THE SAME CUSTOMER
            BankAccount customer1Account1 = new BankAccount(customer1, 1200, "savings");
            BankAccount customer1Account2 = new BankAccount(customer1, 1000, "savings");
            customer1Account1Balance = customer1Account1.AccountBalance;
            customer1Account2Balance = customer1Account2.AccountBalance;

            //ASSERT
            //CHECKED IF THE ACCOUNT BALANCE IS INCREASED BY THE TRANSFER AMOUNT
            customer1Account1.TransferFunds(customer1Account2, transferAmount, "lending");
            Assert.That(customer1Account2.AccountBalance, Is.EqualTo(customer1Account2Balance + transferAmount));
        }
        [Test]
        public void CustomerWithSavingsAccountCannotTransferMoreBeyondWithdrawalLimitOf100()
        {
            //ARRANGE
            //CREATED SOME VARIABLES
            decimal transferAmount = 1210;
            decimal customer1Account1Balance;
            decimal customer1Account2Balance;

            //ACT 
            //CREATED SOME BANK ACCOUNTS
            BankAccount customer1Account1 = new BankAccount(customer1, 1200, "savings");
            BankAccount customer1Account2 = new BankAccount(customer1, 1000, "savings");
            customer1Account1Balance = customer1Account1.AccountBalance;
            customer1Account2Balance = customer1Account2.AccountBalance;

            //ASSERT
            //CHECK IF A CUSTOMER WITH SAVINGS ACCOUNT CAN TRANSFER BEYOND THEIR TRANFER LIMIT
            Assert.Throws<InvalidOperationException>(
                            () => customer1Account1.TransferFunds(customer1Account2, transferAmount, "School fees")
                            );
        }

        [Test]
        public void TransferedAmountIsRemovedFromTheBenefactorAccount()
        {
            //ARRANGE
            decimal customer1Account1Balance;
            decimal customer1Account2Balance;
            decimal transferAmount = 1000;

            //ACT
            BankAccount customer1Account1 = new BankAccount(customer1, 1200, "savings");
            BankAccount customer1Account2 = new BankAccount(customer1, 1000, "savings");
            customer1Account1Balance = customer1Account1.AccountBalance;
            customer1Account2Balance = customer1Account2.AccountBalance;

            //ASSERT
            //TRANSFERED AMOUNT IS REMOVED FROM CUSTOMER'S ACCOUNT BALANCE
            customer1Account1.TransferFunds(customer1Account2, transferAmount, "lending");
            Assert.That(customer1Account1.AccountBalance, Is.EqualTo(customer1Account1Balance - transferAmount));
        }

        [Test]
        public void CustomerCanTransferAnotherCustomerAccount()
        {
            //ARRANGE
            decimal customer1AccountBalance;
            decimal customer2AccountBalance;
            decimal transferAmount = 1000;

            //ACT
            BankAccount customer1Account = new BankAccount(customer1, 1200, "savings");
            BankAccount customer2Account = new BankAccount(customer1, 1000, "current");
            customer1AccountBalance = customer1Account.AccountBalance;
            customer2AccountBalance = customer2Account.AccountBalance;

            //ASSERT
            //RECIEVER'S ACCOUNT BALACE IS INCREASED
            customer1Account.TransferFunds(customer2Account, transferAmount, "lending");
            Assert.That(customer2Account.AccountBalance, Is.EqualTo(customer2AccountBalance + transferAmount));
        }

        [Test]
        public void CustomerWithCurrentAccountCanTransferAllTheirMoney()
        {
            //ARRANGE
            decimal customer1AccountBalance;
            decimal customer2AccountBalance;
            decimal transferAmount = 1200;

            //ACT
            BankAccount customer1Account = new BankAccount(customer1, 1200, "current");
            BankAccount customer2Account = new BankAccount(customer1, 1000, "current");
            customer1AccountBalance = customer1Account.AccountBalance;
            customer2AccountBalance = customer2Account.AccountBalance;
           
            //ASSERT
            customer1Account.TransferFunds(customer2Account, transferAmount, "lending");
            Assert.That(customer2Account.AccountBalance, Is.EqualTo(customer2AccountBalance + transferAmount));
        }


        [Test]
        public void TranferIsNotAllowedForNonExistingCustomers()
        {
            //ARRANGE
            int randomAccountNumber = 1234567890;
            decimal withdrawalAmount = 2000;

            //ACT
            BankAccount customerAccount = BankAccount.GetBankAccount(randomAccountNumber);

            //ASSERT
            Assert.Throws<NullReferenceException>(
                        () => customerAccount.MakeWithdrawal(customerAccount, withdrawalAmount, "School fees")
                        );
        }

        [Test]
        public void TranferMustBeMadeToAnExistingCustomer()
        {
            //ARRANGE
            int randomAccountNumber = 1234567890;
            decimal withdrawalAmount = 2000;

            //ACT
            BankAccount customerAccount = BankAccount.GetBankAccount(randomAccountNumber);

            //ASSERT
            Assert.Throws<NullReferenceException>(
                        () => customerAccount.MakeWithdrawal(customerAccount, withdrawalAmount, "School fees")
                        );
        }
    }
}
