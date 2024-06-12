using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class LoginTest:Base_Class.Test
    {

        [Test]
        public async Task LoginSuccessTest()
        {
            Driver.Navigate().GoToUrl("https://localhost:7036/Account/Login");
            await Task.Delay(7000);
            var username = Driver.FindElement(By.Id("login_username"));
            username.Clear();
            username.SendKeys("admin@admin.ro");
            var password = Driver.FindElement(By.Id("password_login"));
            password.Clear();
            password.SendKeys("Admin1234!");
            var loginButton = Driver.FindElement(By.Id("login_button"));
            loginButton.Click();
            await Task.Delay(5000);
            Assert.AreNotEqual("https://localhost:7036/Account/Login", Driver.Url);
        }

        [Test]
        public async Task LoginWrongPasswordTest()
        {

            Driver.Navigate().GoToUrl("https://localhost:7036/Account/Login");
            await Task.Delay(2000);
            var username = Driver.FindElement(By.Id("login_username"));
            username.Clear();
            username.SendKeys("admin@admin.ro");
            var password = Driver.FindElement(By.Id("password_login"));
            password.Clear();
            password.SendKeys("Admin123!");
            var loginButton = Driver.FindElement(By.Id("login_button"));
            loginButton.Click();
            await Task.Delay(5000);
            Assert.AreEqual("https://localhost:7036/Account/Login", Driver.Url);
        }

        [Test]
        public async Task LoginWrongUsernameTest()
        {

            Driver.Navigate().GoToUrl("https://localhost:7036/Account/Login");
            await Task.Delay(2000);
            var username = Driver.FindElement(By.Id("login_username"));
            username.Clear();
            username.SendKeys("Ana");
            var password = Driver.FindElement(By.Id("password_login"));
            password.Clear();
            password.SendKeys("Admin1234!");
            var loginButton = Driver.FindElement(By.Id("login_button"));
            loginButton.Click();
            await Task.Delay(5000);
            Assert.AreEqual("https://localhost:7036/Account/Login", Driver.Url);
        }

    }
}
