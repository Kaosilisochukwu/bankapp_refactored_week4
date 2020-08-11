using System;
using System.Collections.Generic;
using System.Text;
using bankapp_refactored_week4.ClassLibraries;
using NUnit.Framework;

namespace bankapp_refactored_week4.TestProjects
{

    public class MakeDepositTest
    {

        [Test]
        public void CustomerDepositReflectsInAccountBalance()
        {
            //ARRANGE
            Customer go = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
            var newCustomerAccount = new BankAccount(go, 1200, "savings");
            var customerAccount = BankAccount.GetBankAccount(newCustomerAccount.AccountNumber);
            decimal customerInitialAccountBalance = customerAccount.AccountBalance;
            decimal depositAmount = 2000;

            //ACT
            customerAccount.MakeDeposit(customerAccount, depositAmount, "Savings");

            //ASSERT
            Assert.That(customerAccount.AccountBalance, Is.EqualTo(customerInitialAccountBalance + depositAmount));
        }


        [Test]
        public void CustomerDepositInvalidAmount()
        {
            //ARRANGE
            Customer go = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
            var customerAccount = new BankAccount(go, 1200, "savings");
            decimal depositAmount = 0;

            //ASSERT
            //CANNOT DEPOSIT INVALID AMOUNT
            Assert.Throws<InvalidOperationException>(
                        () => customerAccount.MakeDeposit(customerAccount, depositAmount, "School fees")
                        );
        }

        [Test]
        public void AccountMustBeRegisteredToMakeDeposit()
        {
            //ARRANGE
            int randomAccountNumber = 1234567890;
            BankAccount customerAccount = BankAccount.GetBankAccount(randomAccountNumber);
            decimal depositAmount = 2000;

            //ASSERT
            //DEPOSITING INTO A NON EXISTING ACCOUNT THROWS
            Assert.Throws<NullReferenceException>(
                        () => customerAccount.TransferFunds(customerAccount, depositAmount, "School fees")
                        );
        }


    }

}
