using System.Drawing;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Selenium
{
    internal class Chrome
    {
        private IWebDriver driver;
        public void OpenChrome(int sizeX, int sizeY, int positionX, int positionY)
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            ChromeOptions op = new ChromeOptions();
            op.AddArguments("--disable-notifications");
            driver = new ChromeDriver(driverService, op);
            driver.Manage().Window.Size = new Size(sizeX, sizeY);
            driver.Manage().Window.Position = new Point(positionX, positionY);
        }
        public void login(string usename, string password)
        {
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            var user = driver.FindElement(By.Id("email"));
            var pass = driver.FindElement(By.Id("pass"));
            foreach (var item in usename)
            {
                user.SendKeys(item.ToString());
                Thread.Sleep(Valiable.random.Next(50,1000));
            }
            foreach (var item in password)
            {
                pass.SendKeys(item.ToString());
                Thread.Sleep(Valiable.random.Next(50, 1000));
            }
            pass.SendKeys(Keys.Return);
        }
        public void auto_slip(int stop)
        {
            Actions actions = new Actions(driver);
            if (stop == 1)
            {
                actions
                .KeyDown(Keys.Down)
                .Build()
                .Perform();
            }
            else
            {
                return;
            }
        }
        public void CloseChrom()
        {
            driver.Close();
        }
    }
}
