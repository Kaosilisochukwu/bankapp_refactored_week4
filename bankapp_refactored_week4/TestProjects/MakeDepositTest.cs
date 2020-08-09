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

        Customer go = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");


        [Test]
        public void WhenACustormerExistsAndIsLoggedIn()
        {
            var LoggedInCustomer = CustomerAuth.Login("Kaosi@maing.guy", "kaosi");
            Assert.That(LoggedInCustomer.IsLoggedIn, Is.EqualTo(true));
        }

 
    }

}
