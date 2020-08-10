using bankapp_refactored_week4.ClassLibraries;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.TestProjects
{
    class RegisterationTests
    {

        Customer customer1 = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
        Customer customer2 = new Customer("Deola", "Idowu", "Deola@maing.guy", "deola");
        [Test]
        public void SameCustomerWithDifferentAccountHaveSameCustomerId()
        {
            BankAccount customer1BankAccount1 = BankAccount.RegisterAccount(customer1, 1200, "savings");
            BankAccount customer1BankAccount2 = BankAccount.RegisterAccount(customer1, 1300, "current");

            Assert.That(customer1BankAccount1.CustomerId, Is.EqualTo(customer1BankAccount2.CustomerId));
        }

        [Test]
        public void CustomerWithDifferentAccountHaveDifferentCustomerId()
        {
            BankAccount customer1BankAccount = BankAccount.RegisterAccount(customer1, 1200, "savings");
            BankAccount customer2BankAccount = BankAccount.RegisterAccount(customer2, 1300, "current");

            Assert.That(customer1BankAccount.CustomerId, Is.Not.EqualTo(customer2BankAccount.CustomerId));
        }
        [Test]
        public void AccountNumberIsDifferentForSameCustomerWithMoreThanOneAccount()
        {
            BankAccount customer1BankAccount1 = BankAccount.RegisterAccount(customer1, 1200, "savings");
            BankAccount customer1BankAccount2 = BankAccount.RegisterAccount(customer1, 1300, "current");

            Assert.That(customer1BankAccount1.AccountNumber, Is.Not.EqualTo(customer1BankAccount2.AccountNumber));
        }

        [Test]
        public void AccountNumberIsDifferentForDifferentCustomers()
        {
            BankAccount customer1BankAccount = BankAccount.RegisterAccount(customer1, 1200, "savings");
            BankAccount customer2BankAccount = BankAccount.RegisterAccount(customer2, 1300, "current");

            Assert.That(customer1BankAccount.AccountNumber, Is.Not.EqualTo(customer2BankAccount.AccountNumber));
        }

        [Test]
        public void ARegisteredAccountIsInTheDataBase()
        {
            BankAccount customer1BankAccount = BankAccount.RegisterAccount(customer1, 1200, "savings");
            Assert.That(BankAccount.GetBankAccount(customer1BankAccount.AccountNumber), Is.Not.EqualTo(null));
        }
        [Test]
        public void NonRegisteredaccountIsNotInTheDataBase()
        {
            int randomAccountNumber = 1234567890;
            Assert.That(BankAccount.GetBankAccount(randomAccountNumber), Is.EqualTo(null));
        }

        [Test]
        public void SavingsAccountMustRegisterWithMinimumOf_100()
        {
            Assert.Throws<Exception>(
                () => BankAccount.RegisterAccount(customer2, 90, "savings")
                );
        }

        [Test]
        public void CurrentAccountMustRegisterWithMinimumOf_1000()
        {
            Assert.Throws<Exception>(
                () => BankAccount.RegisterAccount(customer2, 999, "current")
                );
        }

        [Test]
        public void AccountTypeMustBeEitherSavingsOrCurrent()
        {
            Assert.Throws<Exception>(
                () => BankAccount.RegisterAccount(customer2, 999, "anyType")
                );
        }
    }
}
