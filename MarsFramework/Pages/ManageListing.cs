using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class ManageListing
    {
        public ManageListing()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region
        //Click on Manage Listings button
        [FindsBy(How = How.XPath, Using = "//section[@class='nav-secondary']/div/a[3]")]
        private IWebElement ManageListingBtn { get; set; }

        //Click on Active button
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr/td/div")]
        private IWebElement ActiveBtn { get; set; }
        
        //Click on eye icon
        [FindsBy(How = How.XPath, Using = "//i[@class='eye icon']")]
        private IWebElement EyeIcon { get; set; }

        //Click on edit icon
        [FindsBy(How = How.XPath, Using = "//td[@class='one wide']")]
        private IWebElement EditIcon { get; set; }

        //Click on remove icon
        [FindsBy(How = How.XPath, Using = "//i[@class='remove icon']")]
        private IWebElement RemoveIcon { get; set; }

        //Click on remove icon
        [FindsBy(How = How.XPath, Using = "//i[@class='checkmark icon']")]
        private IWebElement DeleteConfirmbtn { get; set; }

        //Select records
        [FindsBy(How = How.XPath, Using = "//table/tbody")]
        private IWebElement RecordDetails { get; set; }

        #endregion

        public void EditManageListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Manage Listings");
            Thread.Sleep(1000);

            //Click on Manage Listings tab
            ManageListingBtn.Click();
            Thread.Sleep(1000);

            IList<IWebElement> ActiveBtns = Global.GlobalDefinitions.driver.FindElements(By.XPath("//table/tbody/tr/td/div/input"));
            IList<IWebElement> EditBtns = Global.GlobalDefinitions.driver.FindElements(By.XPath("//i[@class='outline write icon']"));
            List<string> TitleNames = new List<string> { "Writing and Translation Services", "Writing and Translation Services","Writing and Translation Services","Writing and Translation Services","Writing and Translation Services" };

            //EditIcon.Click();
            Console.WriteLine(ActiveBtns.Count);
            Console.WriteLine(EditBtns.Count);
            
            for (int i = 0; i < ActiveBtns.Count; i++)
            {
                //Console.WriteLine(ManageListingsRecords[i].Text);
                if (TitleNames[i] == Global.GlobalDefinitions.ExcelLib.ReadData(2,"Title"))
                {
                    Thread.Sleep(1000);
                    ActiveBtns[i].Click();
                    EditBtns[i].Click();
                    break;
                }
            }
            
        }

        public void DeleteManageListing()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Manage Listings");
            Thread.Sleep(1000);

            //Click on Manage Listings tab
            ManageListingBtn.Click();
            Thread.Sleep(2000);

            IList <IWebElement> RowElements = RecordDetails.FindElements(By.TagName("tr"));
            //Delete a Record
            foreach(IWebElement row in RowElements)
            {
                IList<IWebElement> col = row.FindElements(By.TagName("td"));
                if(col[2].Text.Equals(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Delete record")))
                {
                    RemoveIcon.Click();
                    Thread.Sleep(5000);
                    DeleteConfirmbtn.Click();
                    Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Service deleted");
                }
            }

            //Check Deleted Listing is still present in the Manage Listing
            foreach (IWebElement row in RowElements)
            {
                IList<IWebElement> col = row.FindElements(By.TagName("td"));
                if (col[3].Text.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "Title")))
                {

                    Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Deleted record still in the Manage Listings");
                    break;

                }

                else
                {
                    Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Record Deleted from the manage Listing");
                    break;
                }

            }
        }
    }
}
