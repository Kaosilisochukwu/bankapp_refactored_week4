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
            //ARRANGE
            decimal withdrawalAmount = -1;
            Customer go = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
            var customerAccount = new BankAccount(go, 1000, "current");
            decimal customerInitialAccountBalance = customerAccount.AccountBalance;

            //ASSERT
            //WITHDRAWING AN INVALID AMOUNT THROWS
            Assert.Throws<InvalidOperationException>(
                       () => customerAccount.MakeWithdrawal(customerAccount, withdrawalAmount, "School fees")
                       );
        }

        [Test]
        public void CustomersWithCurrentAccountCanWithdrawAlltheirMoney()
        {
            //ARRANGE
            Customer go = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
            var customerAccount = new BankAccount(go, 1000, "current");
            decimal customerInitialAccountBalance = customerAccount.AccountBalance;
            decimal withdrawalAmount = 1000;

            //ACT
            //CUSTOMER MAKES WITHDRAWAL
            customerAccount.MakeWithdrawal(customerAccount, withdrawalAmount, "House Rent");

            //ASSERT
            //CURRENT ACCOUNT CAN WITHDRAW ALL THEIR BALANCE
            Assert.That(customerAccount.AccountBalance, Is.EqualTo(0));
        }

        [Test]
        public void CustomersWithSavingsAccountCannotHaveLessTahn100InTheAccount()
        {
            //ARRANGE
            Customer go = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
            var customerAccount = new BankAccount(go, 1000, "savings");
            decimal customerInitialAccountBalance = customerAccount.AccountBalance;
            decimal withdrawalAmount = 900;

            //ACT
            customerAccount.MakeWithdrawal(customerAccount, withdrawalAmount, "Food Stuff");

            //ASSERT
            Assert.That(customerAccount.AccountBalance, Is.EqualTo(customerInitialAccountBalance - withdrawalAmount));
        }

        [Test]
        public void WithdrawalIsNotAllowedForNonExistingCustomers()
        {
            //ARRANGE
            int randomAccountNumber = 1234567890;
            BankAccount customerAccount = BankAccount.GetBankAccount(randomAccountNumber);
            decimal withdrawalAmount = 2000;

            //ASSERT
            //CANNOT WITHDRAW FROM A NON-EXISTING ACCOUNT NUMBER
            Assert.Throws<NullReferenceException>(
                        () => customerAccount.MakeWithdrawal(customerAccount, withdrawalAmount, "School fees")
                        );
        }

        [Test]
        public void AccountBalanceReflectsWithdrawalTransaction()
        {
            //ARRANGE
            Customer go = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
            var customerAccount = new BankAccount(go, 1200, "savings");
            decimal customerInitialAccountBalance = customerAccount.AccountBalance;
            decimal withdrawalAmount = 1000;

            //ACT
            customerAccount.MakeWithdrawal(customerAccount, withdrawalAmount, "Monthly levy");

            //ASSERT
            //WITHDRAWAL REFLECTS IN ACCOUNT BALANCE
            Assert.That(customerAccount.AccountBalance, Is.EqualTo(customerInitialAccountBalance - withdrawalAmount));
        }
    }
}
