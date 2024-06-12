using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


namespace Test.Base_Class
{
    public class Test
    {
        protected IWebDriver Driver;

        [OneTimeSetUp]
        public void Setup()
        {
            var path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            var chromeOptions = new ChromeOptions
            {
                AcceptInsecureCertificates = true
            };

            chromeOptions.AddArguments("--incognito");


            chromeOptions.AddArgument("--start-maximized");


            chromeOptions.AddUserProfilePreference("download.default_directory", path);

            chromeOptions.AddArguments("--no-sandbox");
            Driver = new ChromeDriver(path + @"\drivers\", chromeOptions);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://localhost:7036/");

        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
