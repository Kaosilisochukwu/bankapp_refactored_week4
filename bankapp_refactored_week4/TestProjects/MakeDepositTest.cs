using System;
using System.Collections.Generic;
using System.Text;
using bankapp_refactored_week4.ClassLibraries;
using NUnit.Framework;

namespace bankapp_refactored_week4.TestProjects
{

    public class MakeDepositTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CustomerDepositReflectsInAccountBalance()
        {
            Customer go = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
            var customerAccount = new BankAccount(go, 1200, "savings");
            decimal customerInitialAccountBalance = customerAccount.AccountBalance;
            decimal depositAmount = 2000;

            customerAccount.MakeDeposite(customerAccount, depositAmount, "Monthly levy");
            Assert.That(customerAccount.AccountBalance, Is.EqualTo(customerInitialAccountBalance + depositAmount));
        }


        [Test]
        public void CustomerDepositInvalidAmount()
        {
            Customer go = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
            var customerAccount = new BankAccount(go, 1200, "savings");
            decimal depositAmount = 0;

            Assert.Throws<InvalidOperationException>(
                        () => customerAccount.MakeDeposite(customerAccount, depositAmount, "School fees")
                        );
        }

        [Test]
        public void AccountMustBeRegisteredToMakeDeposit()
        {
            BankAccount customerAccount = null;
            decimal depositAmount = 2000;

            Assert.Throws<NullReferenceException>(
                        () => customerAccount.MakeDeposite(customerAccount, depositAmount, "School fees")
                        );
        }


    }

}
