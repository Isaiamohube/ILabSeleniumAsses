using Microsoft.VisualStudio.TestTools.UnitTesting;
using New1.TestPagesObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using excel = Microsoft.Office.Interop.Excel;

namespace New1
{
    [TestClass]
    public class UnitTest1
    {
        protected IWebDriver driver;

        private JobApplication jobApp = new JobApplication();

        private objectRepositary objectRep = new objectRepositary();

        [TestInitialize]
        public void Initialise()
        {
            string browserName = "Chrome";

            if (browserName.Equals("Chrome"))
            {
                driver = new ChromeDriver(@"C:\Workspace\Hippo\Frontend_Auto\Exe");
            }
            else if (browserName.Equals("IE"))
            {
                driver = new InternetExplorerDriver(@"C:\Workspace\Hippo\Frontend_Auto\IE Driver");
            }

            driver.Navigate().GoToUrl("https://www.ilabquality.com/");

            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void validateUploadError()
        {
            excel.Application x1App = new excel.Application();
            excel.Workbook x1WorkBook = x1App.Workbooks.Open(@"C:\Workspace\Hippo\Frontend_Auto\Excel\iLab.xlsx");
            excel._Worksheet x1WorkSheet = x1WorkBook.Sheets[1];
            excel.Range x1Range = x1WorkSheet.UsedRange;
            int xlRowCnt;

            for (xlRowCnt = 2; xlRowCnt <= x1Range.Rows.Count; xlRowCnt++)
            {
                jobApp.country = (string)(x1Range.Cells[xlRowCnt, 2] as excel.Range).Value2;
                jobApp.applicantName = (string)(x1Range.Cells[xlRowCnt, 3] as excel.Range).Value2;
                jobApp.applicantEmail = (string)(x1Range.Cells[xlRowCnt, 4] as excel.Range).Value2;

                Random rnd = new Random();
                var tempCell = rnd.Next(99999999);
                jobApp.applicantCelNumber = String.Format("{0:0## ### ####}", tempCell);

                objectRep.clickCarrers(driver);
                objectRep.selectCountry(driver, jobApp.country);
                objectRep.clickFirstJobOpenning(driver);
                objectRep.clickApplyNow(driver);
                objectRep.typeApplicantName(driver, jobApp.applicantName);
                objectRep.typeApplicantEmail(driver, jobApp.applicantEmail);

                objectRep.typeApplicantCellNumber(driver, jobApp.applicantCelNumber.ToString());
                objectRep.sendApplication(driver);

                string expectedUploadError = "You need to upload at least one file.";

                IWebElement actualUploadErrorField = driver.FindElement(By.XPath("//*[@id='wpjb-apply-form']/fieldset[1]/div[5]/div/ul/li"));

                string actualUploadError = actualUploadErrorField.Text;

                // NUnit.Framework.Assert.AreEqual(expectedUploadError, actualUploadError);

                (x1Range.Cells[xlRowCnt, 5] as excel.Range).Value2 = jobApp.applicantCelNumber;

                if (expectedUploadError == actualUploadError)
                {
                    (x1Range.Cells[xlRowCnt, 6] as excel.Range).Value2 = "Pass";
                }
                else
                {
                    (x1Range.Cells[xlRowCnt, 6] as excel.Range).Value2 = "False";
                }
            }
        }

        [TestCleanup]
        public void cleanUp()
        {
            System.Threading.Thread.Sleep(10000);

            driver.Close();
        }
    }
}