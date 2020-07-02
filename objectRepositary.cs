using OpenQA.Selenium;

namespace New1.TestPagesObjects
{
    internal class objectRepositary
    {
        public void clickCarrers(IWebDriver driver)
        {
            IJavaScriptExecutor btnCarrers = (IJavaScriptExecutor)driver;
            btnCarrers.ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//*[@id='menu-item-1373']/a")));
        }

        public void selectCountry(IWebDriver driver, string country)
        {
            switch (country)
            {
                case "North America":

                    IJavaScriptExecutor btnNorthAmerica = (IJavaScriptExecutor)driver;
                    btnNorthAmerica.ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("/html/body/section/div[2]/div/div/div/div[3]/div[2]/div/div/div[3]/div[2]/div/div/div[3]/a")));

                    break;

                case "South Africa":

                    IJavaScriptExecutor btnSA = (IJavaScriptExecutor)driver;
                    btnSA.ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("/html/body/section/div[2]/div/div/div/div[3]/div[2]/div/div/div[3]/div[2]/div/div/div[4]/a")));

                    break;

                case "Australia":
                    IJavaScriptExecutor btnAustralia = (IJavaScriptExecutor)driver;
                    btnAustralia.ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("/html/body/section/div[2]/div/div/div/div[3]/div[2]/div/div/div[3]/div[2]/div/div/div[5]/a")));

                    break;

                case "United Kingdom":

                    IJavaScriptExecutor btnUK = (IJavaScriptExecutor)driver;
                    btnUK.ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("/html/body/section/div[2]/div/div/div/div[3]/div[2]/div/div/div[3]/div[2]/div/div/div[6]/a")));

                    break;

                case "Brazil":
                    IJavaScriptExecutor btnBrazil = (IJavaScriptExecutor)driver;
                    btnBrazil.ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("/html/body/section/div[2]/div/div/div/div[3]/div[2]/div/div/div[3]/div[2]/div/div/div[7]/a")));
                    driver.FindElement(By.XPath("/html/body/section/div[2]/div/div/div/div[3]/div[2]/div/div/div[3]/div[2]/div/div/div[7]/a"));
                    break;
            }
        }

        public void clickFirstJobOpenning(IWebDriver driver)
        {
            IJavaScriptExecutor btnJobOpening = (IJavaScriptExecutor)driver;
            btnJobOpening.ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("/html/body/section/div[2]/div/div/div/div[3]/div[2]/div/div/div/div/div/div[1]/div[1]/div[2]/div[1]/a")));
        }

        public void clickApplyNow(IWebDriver driver)
        {
            IJavaScriptExecutor btnApplyNow = (IJavaScriptExecutor)driver;
            btnApplyNow.ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//*[@id='wpjb-scroll']/div[1]/a")));
        }

        public void typeApplicantName(IWebDriver driver, string appName)
        {
            driver.FindElement(By.XPath("//*[@id='applicant_name']")).SendKeys(appName);
        }

        public void typeApplicantEmail(IWebDriver driver, string appEmail)
        {
            driver.FindElement(By.XPath("//*[@id='email']")).SendKeys(appEmail);
        }

        public void typeApplicantCellNumber(IWebDriver driver, string appCell)
        {
            driver.FindElement(By.XPath("//*[@id='phone']")).SendKeys(appCell);
        }

        public void sendApplication(IWebDriver driver)
        {
            IJavaScriptExecutor btnSubmitApp = (IJavaScriptExecutor)driver;
            btnSubmitApp.ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//*[@id='wpjb_submit']")));
        }

        public string getResultantError(IWebDriver driver, string resultantError, string xpath)
        {
            resultantError = driver.FindElement(By.XPath(xpath)).Text;

            return resultantError;
        }
    }
}