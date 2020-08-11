using bankapp_refactored_week4.ClassLibraries;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.TestProjects
{
    class RegisterationTests
    {
        //ARRANGE
        //INITIAL CREATION OF CUSTOMERS FOR ALL REGISTRATION TESTS
        Customer customer1 = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
        Customer customer2 = new Customer("Deola", "Idowu", "Deola@maing.guy", "deola");

        [Test]
        public void SameCustomerWithDifferentAccountHaveSameCustomerId()
        {
            //ACT
            //REGISTERED BANK ACCOUNTS WITH CORRECT INPUTS FOR CUSTOMER 1
            BankAccount customer1BankAccount1 = BankAccount.RegisterAccount(customer1, 1200, "savings");
            BankAccount customer1BankAccount2 = BankAccount.RegisterAccount(customer1, 1300, "current");

            //ASSERT
            //TWO ACCOUNTS FOR CUSTOMER 1 WITH SAME CUSTOMER ID
            Assert.That(customer1BankAccount1.CustomerId, Is.EqualTo(customer1BankAccount2.CustomerId));
        }

        [Test]
        public void CustomerWithDifferentAccountHaveDifferentCustomerId()
        {
            //ACT
            //REGISTERED BANK ACCOUNTS FOR DIFFERENT CUSTOMERS 1 AND CUSTOMER 2
            BankAccount customer1BankAccount = BankAccount.RegisterAccount(customer1, 1200, "savings");
            BankAccount customer2BankAccount = BankAccount.RegisterAccount(customer2, 1300, "current");

            //ASSERT
            //CUSTOMER 1 AND CUSTOMER 2 HAVE DIFFERENT CUSTOMER ID
            Assert.That(customer1BankAccount.CustomerId, Is.Not.EqualTo(customer2BankAccount.CustomerId));
        }
        [Test]
        public void AccountNumberIsDifferentForSameCustomerWithMoreThanOneAccount()
        {
            //ACT
            //CREATED 2 ACCOUNTS FOR CUSTOMER 1
            BankAccount customer1BankAccount1 = BankAccount.RegisterAccount(customer1, 1200, "savings");
            BankAccount customer1BankAccount2 = BankAccount.RegisterAccount(customer1, 1300, "current");

            //ASSERT
            //DIFFERENT BANK ACCOUNTS FOR CUSTOMER 1 HAVE DIFFERENT ACCOUNT NUMBERS
            Assert.That(customer1BankAccount1.AccountNumber, Is.Not.EqualTo(customer1BankAccount2.AccountNumber));
        }

        [Test]
        public void AccountNumberIsDifferentForDifferentCustomers()
        {
            //ACT
            // CREATED ACCOUNT FOR CUSTOMER 1 AND CUSTOMER 2
            BankAccount customer1BankAccount = BankAccount.RegisterAccount(customer1, 1200, "savings");
            BankAccount customer2BankAccount = BankAccount.RegisterAccount(customer2, 1300, "current");

            //ASSERT
            //ACCOUNT NUMBER ARE DIFFERENT FOR DIFFERENT CUSTOMERS
            Assert.That(customer1BankAccount.AccountNumber, Is.Not.EqualTo(customer2BankAccount.AccountNumber));
        }

        [Test]
        public void ARegisteredAccountIsInTheDataBase()
        {
            //CREATED AN ACCOUNT FOR CUSTOER 1
            BankAccount customer1BankAccount = BankAccount.RegisterAccount(customer1, 1200, "savings");

            //ASSERT
            //FETCHING ACCOUNT DETAILS FOR CUSTOMER 1 DOES NOT RETURN NULL
            Assert.That(BankAccount.GetBankAccount(customer1BankAccount.AccountNumber), Is.Not.EqualTo(null));
        }
        [Test]
        public void NonRegisteredaccountIsNotInTheDataBase()
        {
            // ARRANGE
            //INITIALIZED A RANDOM ACCOUNT NUMBER
            int randomAccountNumber = 1234567890;

            //ASSERT
            //FETCHING AN ACCOUNT THAT DOES NOT EXIST RETURNS NULL
            Assert.That(BankAccount.GetBankAccount(randomAccountNumber), Is.EqualTo(null));
        }

        [Test]
        public void SavingsAccountMustRegisterWithMinimumOf_100()
        {
            //ASSERT
            //REGISTERING ACCOUNT FOR SAVINGS ACCOUNT WITH LESS THAN 100 THROWS
            Assert.Throws<Exception>(
                () => BankAccount.RegisterAccount(customer2, 90, "savings")
                );
        }

        [Test]
        public void CurrentAccountMustRegisterWithMinimumOf_1000()
        {
            //ASSERT
            //REGISTERING ACCOUNT FOR CURRENT ACCOUNT WITH LESS THAN 1000 THROWS
            Assert.Throws<Exception>(
                () => BankAccount.RegisterAccount(customer2, 999, "current")
                );
        }

        [Test]
        public void AccountTypeMustBeEitherSavingsOrCurrent()
        {
            //ASSERT
            //REGISTERING AN ACCOUNT WITH RANDON ACCOUNT TYPE THROWS
            Assert.Throws<Exception>(
                () => BankAccount.RegisterAccount(customer2, 999, "anyType")
                );
        }
    }
}
