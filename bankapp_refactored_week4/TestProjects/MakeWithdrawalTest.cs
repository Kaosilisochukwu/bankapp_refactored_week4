using bankapp_refactored_week4.ClassLibraries;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.TestProjects
{
    public class MakeWithdrawalTest
    {
        [Test]
        public void WithdrawalsLessThan1IsnotAllowed()
        {
            Customer go = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
            var customerAccount = new BankAccount(go, 1000, "current");
            decimal customerInitialAccountBalance = customerAccount.AccountBalance;
            decimal withdrawalAmount = -1;
            Assert.Throws<InvalidOperationException>(
                       () => customerAccount.MakeWithdrawal(customerAccount, withdrawalAmount, "School fees")
                       );
        }

        [Test]
        public void CustomersWithCurrentAccountCanWithdrawAlltheirMoney()
        {
            Customer go = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
            var customerAccount = new BankAccount(go, 1000, "current");
            decimal customerInitialAccountBalance = customerAccount.AccountBalance;
            decimal withdrawalAmount = 1000;
            customerAccount.MakeWithdrawal(customerAccount, withdrawalAmount, "House Rent");
            Assert.That(customerAccount.AccountBalance, Is.EqualTo(0));
        }

        [Test]
        public void CustomersWithSavingsAccountCannotHaveLessTahn100InTheAccount()
        {
            Customer go = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
            var customerAccount = new BankAccount(go, 1000, "savings");
            decimal customerInitialAccountBalance = customerAccount.AccountBalance;
            decimal withdrawalAmount = 900;

            customerAccount.MakeWithdrawal(customerAccount, withdrawalAmount, "Food Stuff");
            Assert.That(customerAccount.AccountBalance, Is.EqualTo(customerInitialAccountBalance - withdrawalAmount));
        }

        [Test]
        public void WithdrawalIsNotAllowedForNonExistingCustomers()
        {
            int randomAccountNumber = 1234567890;
            BankAccount customerAccount = BankAccount.GetBankAccount(randomAccountNumber);
            decimal withdrawalAmount = 2000;

            Assert.Throws<NullReferenceException>(
                        () => customerAccount.MakeWithdrawal(customerAccount, withdrawalAmount, "School fees")
                        );
        }

        [Test]
        public void AccountBalanceReflectsWithdrawalTransaction()
        {
            Customer go = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
            var customerAccount = new BankAccount(go, 1200, "savings");
            decimal customerInitialAccountBalance = customerAccount.AccountBalance;
            decimal withdrawalAmount = 1000;

            customerAccount.MakeWithdrawal(customerAccount, withdrawalAmount, "Monthly levy");
            Assert.That(customerAccount.AccountBalance, Is.EqualTo(customerInitialAccountBalance - withdrawalAmount));
        }
    }
}
