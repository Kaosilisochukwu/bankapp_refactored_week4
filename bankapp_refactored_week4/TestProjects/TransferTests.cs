using bankapp_refactored_week4.ClassLibraries;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.TestProjects
{
    class TransferTests
    {
        Customer customer1 = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
        Customer customer2 = new Customer("Deola", "Idowu", "Deola@maing.guy", "deola");
        [Test]
        public void CustomerCanTransferToTheirOtherAccount()
        {
            BankAccount customer1Account1 = new BankAccount(customer1, 1200, "savings");
            BankAccount customer1Account2 = new BankAccount(customer1, 1000, "savings");
            decimal customer1Account1Balance = customer1Account1.AccountBalance;
            decimal customer1Account2Balance = customer1Account2.AccountBalance;
            decimal transferAmount = 1000;

            customer1Account1.TransferFunds(customer1Account2, transferAmount, "lending");
            Assert.That(customer1Account2.AccountBalance, Is.EqualTo(customer1Account2Balance + transferAmount));
        }
        [Test]
        public void CustomerWithSavingsAccountCannotTransferMoreBeyondWithdrawalLimitOf100()
        {
            BankAccount customer1Account1 = new BankAccount(customer1, 1200, "savings");
            BankAccount customer1Account2 = new BankAccount(customer1, 1000, "savings");
            decimal customer1Account1Balance = customer1Account1.AccountBalance;
            decimal customer1Account2Balance = customer1Account2.AccountBalance;
            decimal transferAmount = 1210;

            Assert.Throws<InvalidOperationException>(
                            () => customer1Account1.TransferFunds(customer1Account2, transferAmount, "School fees")
                            );
        }

        [Test]
        public void TransferedAmountIsRemovedFromTheBenefactorAccount()
        {
            BankAccount customer1Account1 = new BankAccount(customer1, 1200, "savings");
            BankAccount customer1Account2 = new BankAccount(customer1, 1000, "savings");
            decimal customer1Account1Balance = customer1Account1.AccountBalance;
            decimal customer1Account2Balance = customer1Account2.AccountBalance;
            decimal transferAmount = 1000;

            customer1Account1.TransferFunds(customer1Account2, transferAmount, "lending");
            Assert.That(customer1Account1.AccountBalance, Is.EqualTo(customer1Account1Balance - transferAmount));
        }

        [Test]
        public void CustomerCanTransferAnotherCustomerAccount()
        {
            BankAccount customer1Account = new BankAccount(customer1, 1200, "savings");
            BankAccount customer2Account = new BankAccount(customer1, 1000, "current");
            decimal customer1AccountBalance = customer1Account.AccountBalance;
            decimal customer2AccountBalance = customer2Account.AccountBalance;
            decimal transferAmount = 1000;

            customer1Account.TransferFunds(customer2Account, transferAmount, "lending");
            Assert.That(customer2Account.AccountBalance, Is.EqualTo(customer2AccountBalance + transferAmount));
        }

        [Test]
        public void CustomerWithCurrentAccountCanTransferAllTheirMoney()
        {
            BankAccount customer1Account = new BankAccount(customer1, 1200, "current");
            BankAccount customer2Account = new BankAccount(customer1, 1000, "current");
            decimal customer1AccountBalance = customer1Account.AccountBalance;
            decimal customer2AccountBalance = customer2Account.AccountBalance;
            decimal transferAmount = 1200;

            customer1Account.TransferFunds(customer2Account, transferAmount, "lending");
            Assert.That(customer2Account.AccountBalance, Is.EqualTo(customer2AccountBalance + transferAmount));
        }


        [Test]
        public void TranferIsNotAllowedForNonExistingCustomers()
        {
            int randomAccountNumber = 1234567890;
            BankAccount customerAccount = BankAccount.GetBankAccount(randomAccountNumber);
            decimal withdrawalAmount = 2000;

            Assert.Throws<NullReferenceException>(
                        () => customerAccount.MakeWithdrawal(customerAccount, withdrawalAmount, "School fees")
                        );
        }

        [Test]
        public void TranferMustBeMadeToAnExistingCustomer()
        {
            int randomAccountNumber = 1234567890;
            BankAccount customerAccount = BankAccount.GetBankAccount(randomAccountNumber);
            decimal withdrawalAmount = 2000;

            Assert.Throws<NullReferenceException>(
                        () => customerAccount.MakeWithdrawal(customerAccount, withdrawalAmount, "School fees")
                        );
        }
    }
}
