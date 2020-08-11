using System;
using System.Collections.Generic;
using System.Text;
using bankapp_refactored_week4.ClassLibraries;
using NUnit.Framework;

namespace bankapp_refactored_week4.TestProjects
{

   
    public class LoginTest
    {
      
        //ARRANGE 
        //CREATED CUSTOMERS FOR TESTING CUSTOMER LOGIN
        Customer Kaosi = new Customer("Kaosi", "Nwizu", "Kaosi@maing.guy", "kaosi");
        Customer Deola = new Customer("Deola", "Idowu", "Idowu@maing.guy", "idowu");


        [Test]
        public void WhenACustormerExistsAndIsLoggedIn()
        {
            //ARRANGE
            var LoggedInCustomer = CustomerAuth.Login("Kaosi@maing.guy", "kaosi");

            //ACT
            //CUSTOMER ATTEMPTS LOGGING IN
            bool customerLoginStatus = LoggedInCustomer.IsLoggedIn;

            //ASSERT REGISTERD CUSTOMER CAN LOG IN
            Assert.That(customerLoginStatus, Is.EqualTo(true));
        }

        [Test]
        public void WhenLoginDetailsDontExistInDataBase()
        {
            //ASSERT 
            //NON-REGISERED CUSTOMERS CANNOT LOGIN
            Assert.Throws<NullReferenceException>(
                () => CustomerAuth.Login("nodetails@non.com", "noPassword")
            );
        }
        [Test]
        public void WhenACustormerExistsButIsNotLoggedIn()
        {
            //ASSERT
            //A CUSTOMER CAN EXIST BUT NOT LOGGED IN
            Assert.That(Deola.IsLoggedIn, Is.EqualTo(false));
        }
    }
    
}
