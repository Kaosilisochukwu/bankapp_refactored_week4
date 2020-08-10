using System;
using System.Collections.Generic;
using System.Text;
using bankapp_refactored_week4.ClassLibraries;
using NUnit.Framework;

namespace bankapp_refactored_week4.TestProjects
{

   
    public class LoginTest
    {
        [SetUp]
        public void Setup()
        {
        }

        Customer Kaosi = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
        Customer Deola = new Customer("Deola", "Idowu", "Idowu@maing.guy", "idowu");


        [Test]
        public void WhenACustormerExistsAndIsLoggedIn()
        {
            var LoggedInCustomer = CustomerAuth.Login("Kaosi@maing.guy", "kaosi");
            Assert.That(LoggedInCustomer.IsLoggedIn, Is.EqualTo(true));
        }

        [Test]
        public void WhenLoginDetailsDontExistInDataBase()
        {
            Assert.Throws<NullReferenceException>(
                () => CustomerAuth.Login("nodetails@non.com", "noPassword")
            );
        }
        [Test]
        public void WhenACustormerExistsButIsNotLoggedIn()
        {
            Assert.That(Deola.IsLoggedIn, Is.EqualTo(false));
        }
    }
    
}
