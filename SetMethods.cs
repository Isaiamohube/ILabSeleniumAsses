using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;


namespace New1
{
    class SetMethods
    {
        //Enter text

        public static void EnterText(IWebDriver driver, string Object, string value, string objectType)
        {
            if (objectType == "Id")
                driver.FindElement(By.Id(Object)).SendKeys(value);
            if (objectType == "name")
                driver.FindElement(By.Name(Object)).SendKeys(value);
            if (objectType == "XPath")
                driver.FindElement(By.XPath(Object)).SendKeys(value);
        }

        // clicking a button, checkbox or option

        public static void Click(IWebDriver driver, string Object, string objectType)
        {
            if (objectType == "Id")
                driver.FindElement(By.Id(Object)).Click();
            if (objectType == "name")
                driver.FindElement(By.Name(Object)).Click();
            if (objectType == "XPath")
                driver.FindElement(By.XPath(Object)).Click();
        }

        //Selecting a drop down

        public static void Selecting(IWebDriver driver, string Object, string value, string objectType)
        {
            if (objectType == "Id")
                new SelectElement(driver.FindElement(By.Id(Object))).SelectByText(value);
            if (objectType == "name")
                new SelectElement(driver.FindElement(By.Name(Object))).SelectByText(value);
            if (objectType == "XPath")
                new SelectElement(driver.FindElement(By.XPath(Object))).SelectByText(value);
        }

        //Highlighting

        public static void highlightObj(IWebDriver driver, IWebElement element)
        {
            for (int i = 0; i < 2; i++)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].setAttribute('style',arguments[1]);", element, "color:yellow;border:2px solid yellow;");
                js.ExecuteScript("arguments[0].setAttribute('style',arguments[1];", element, "");

            }

        }

    

        public static void TellUsAbtYourCarPositive(IWebDriver driver)
        {

             driver.FindElement(By.Name("vehicle_one_description")).SendKeys("2014 VOLKSWAGEN POLO VIVO 1.4");         
             System.Threading.Thread.Sleep(2000);
             driver.FindElement(By.Name("vehicle_one_description")).SendKeys(Keys.Down);
             System.Threading.Thread.Sleep(2000);
             driver.FindElement(By.Name("vehicle_one_description")).SendKeys(Keys.Enter);
             System.Threading.Thread.Sleep(2000);
             SetMethods.Selecting(driver, "/html/body/div[10]/div/div[2]/div/div[1]/div[2]/div[2]/div[1]/select", "LOCKED GARAGE", "XPath");

          

            Screenshot s7 = ((ITakesScreenshot)driver).GetScreenshot();
            s7.SaveAsFile(@"C:\\Users\\mo5599\\Documents\Visual Studio 2013\\Projects\\New1\\New1\\Images\\S7.jpg");

            IJavaScriptExecutor jx = (IJavaScriptExecutor)driver;
            jx.ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("/html/body/div[10]/div/div[2]/div/div[2]/button[2]")));

        }

        public static void PersonalDetailsFill(IWebDriver driver)
        {
             SetMethods.Click(driver, "/html/body/div[11]/div/div[2]/div/div[1]/div[2]/div[2]/div[2]/button/img", "XPath");
             SetMethods.EnterText(driver, "//*[@id='person-details-man']/div/div[1]/div[2]/div[1]/div/div/input", "John", "XPath");
             SetMethods.EnterText(driver, "//*[@id='person-details-man']/div/div[1]/div[2]/div[2]/div/div/input", "Smith", "XPath");
             SetMethods.EnterText(driver, "dayOfBirth-man", "01", "name");
             SetMethods.EnterText(driver, "monthOfBirth-man", "05", "name");
             SetMethods.EnterText(driver, "yearOfBirth-man", "1970", "name");
             SetMethods.Selecting(driver, "//*[@id='person-details-man']/div/div[1]/div[2]/div[4]/div/select", "Single", "XPath");
             SetMethods.EnterText(driver, "cell", "0815699088", "name");
             SetMethods.EnterText(driver, "email", "johnSmith@test.com", "name");
             SetMethods.Click(driver, "//*[@id='person-details-man']/div/div[1]/div[2]/div[7]/label[2]/i", "XPath");
             SetMethods.EnterText(driver, "//*[@id='address-man']", "9th Rd, Midrand", "XPath");
        }

        public static void TellUsAbtRegularDriverPos(IWebDriver driver)
        {
            SetMethods.EnterText(driver, "/html/body/div[14]/div/div[2]/div/div[1]/div/div[2]/div[1]/div/div/input[1]", "02", "XPath");
            SetMethods.EnterText(driver, "/html/body/div[14]/div/div[2]/div/div[1]/div/div[2]/div[1]/div/div/input[2]", "1990", "XPath");
            SetMethods.Selecting(driver, "/html/body/div[14]/div/div[2]/div/div[1]/div/div[2]/div[2]/div/select", "RSA Drivers Licence", "XPath");
            SetMethods.Selecting(driver, "/html/body/div[14]/div/div[2]/div/div[1]/div/div[2]/div[3]/div/select", "2 Years Comprehensive Insurance", "XPath");
        }
        public static void ChatBotNavigation(IWebDriver driver)
        {

            SetMethods.Click(driver, "//*[@id='floatingButtonDiv']/img", "XPath");
            SetMethods.Click(driver, "//*[@id='innerChatButton']/img", "XPath");
            SetMethods.EnterText(driver, "//*[@id='name_Field']", "John", "XPath");
            SetMethods.EnterText(driver, "//*[@id='surname_Field']", "Ford", "XPath");
            SetMethods.EnterText(driver, "//*[@id='email_Field']", "John@test.com", "XPath");
            SetMethods.EnterText(driver, "//*[@id='ContactNo_Field']", "0839677814", "XPath");
            SetMethods.Click(driver, "//*[@id='startButton']", "XPath");
            System.Threading.Thread.Sleep(3000);

        }






    }
}
