using AutoItX3Lib;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  initialize web elements
        //Click on Share skill tab
        [FindsBy(How = How.XPath, Using = "//a[@class='ui basic green button']")]
        private IWebElement ShareSkillBtn { get; set; }

        //Enter Title on text box
        [FindsBy(How = How.XPath, Using = "//*[@name='title']")]
        private IWebElement Title { get; set; }

        //Enter Description on text box
        [FindsBy(How = How.XPath, Using = "//*[@name='description']")]
        public IWebElement Description { get; set; }

        //Choose a category
        [FindsBy(How = How.Name, Using = "categoryId")]
        public IWebElement Category { get; set; }

        //Choose a subcategory
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        public IWebElement SubCategory { get; set; }

        //Enter tags
        [FindsBy(How = How.XPath, Using = "(//input[@class='ReactTags__tagInputField'])[1]")]
        public IWebElement Tags { get; set; }

        //Click on radio buttton
        [FindsBy(How = How.ClassName, Using = "field")]
        public IWebElement RadioButtonsofThePage { get; set; }

        //click on location type radio button
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType']")]
        public IWebElement LocationTypeRadiobtn { get; set; }

        //Enter start date
        [FindsBy(How = How.Name, Using = "startDate")]
        public IWebElement StartDate { get; set; }

        //Enter end date
        [FindsBy(How = How.Name, Using = "endDate")]
        public IWebElement EndDate { get; set; }

        //Click on available days
        [FindsBy(How = How.Name, Using = "Available")]
        public IWebElement AvailableDays { get; set; }

        //Enter start times in each available date
        [FindsBy(How = How.Name, Using = "StartTime")]
        public IWebElement StartTime { get; set; }

        //Enter end time in each available date 
        [FindsBy(How = How.Name, Using = "EndTime")]
        public IWebElement EndTime { get; set; }

        //Click on skill trade radio button
        [FindsBy(How = How.XPath, Using = "//input[@name='skillTrades']")]
        public IWebElement SkillTrade { get; set; }

        //Enter tags for the skill exchange field
        [FindsBy(How = How.XPath, Using = "(//input[@class='ReactTags__tagInputField'])[2]")]
        public IWebElement SkillExchange { get; set; }

        //Click on work samples upload button
        [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")]
        public IWebElement workSamplesUpload { get; set; }

        //Click on Active radio button
        [FindsBy(How = How.XPath, Using = "//input[@name='isActive']")]
        public IWebElement ActiveRadioBtn { get; set; }

        //Click on save button
        [FindsBy(How = How.XPath, Using = "//input[@class='ui teal button']")]
        public IWebElement SaveBtn { get; set; }

        //Click on cancel button
        [FindsBy(How = How.XPath, Using = "//input[@class='ui button']")]
        public IWebElement CancelBtn { get; set; }

        //Find the Table in Manage Listings page
        [FindsBy(How = How.XPath, Using = "//table/tbody")]
        public IWebElement TableElements { get; set; }

        #endregion
        public void ClickonShareSkillBtn()
        {
            //Click on Share skills button
            ShareSkillBtn.Click();
        }

        public void ShareProfile(string Decission)
        {

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
            Thread.Sleep(1000);


            //Enter Details to title filed
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Enter details to description
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Select the category
            IList<IWebElement> CategoryOptions = Category.FindElements(By.TagName("option"));

            for (int i = 0; i < CategoryOptions.Count; i++)
            {
                if (CategoryOptions[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Category"))
                {
                    CategoryOptions[i].Click();
                    Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Category selected");
                }
            }
            //-------------------------------------------------------------------------------------

            //Select Subcategory
            IList<IWebElement> SubcategoryOptions = SubCategory.FindElements(By.TagName("option"));

            for (int i = 0; i < SubcategoryOptions.Count; i++)
            {
                if (SubcategoryOptions[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Subcategory"))
                {
                    SubcategoryOptions[i].Click();
                    Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Subcategory Selected");
                }

            }
            //-------------------------------------------------------------------------------------------

            //Enter a Tag
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tag1"));
            Tags.SendKeys(Keys.Enter);

            //Define Lists of radio button options in Skill Share page
            IList<IWebElement> ServiceTypeOptions = GlobalDefinitions.driver.FindElements(By.XPath("//div[@class='field']/div"));
            IList<IWebElement> Radiobtn = GlobalDefinitions.driver.FindElements(By.XPath("//div[@class='field']/div/input"));

            Thread.Sleep(1000);

            //---------------------------------------------------------------------------------------------

            //Select Service Type
            for (int i = 0; i < ServiceTypeOptions.Count; i++)
            {

                if (ServiceTypeOptions[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Service Type"))
                {
                    Radiobtn[i].Click();
                    Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Service Type Selected");
                }

            }
            //------------------------------------------------------------------------------------------
            //Select Location Type
            for (int i = 0; i < ServiceTypeOptions.Count; i++)
            {

                if (ServiceTypeOptions[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Location Type"))
                {
                    Radiobtn[i].Click();
                    Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Location Type Selected");
                }

            }

            //-----------------------------------------------------------------------------------------------
            //Enter start date
            StartDate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Start Date"));
            Console.WriteLine(GlobalDefinitions.ExcelLib.ReadData(2, "Start Date"));
            //StartDate.SendKeys("06/16/2019");
            Thread.Sleep(1000);

            //Enter end date
            //EndDate.Clear();
            EndDate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "End Date"));
            // ---------------------------------------------------------------------------------

            //Select Available Date and Time
            List<int> AvailableDays = new List<int> { 0, 1, 0, 1, 0, 0, 0 };
            IList<IWebElement> Dayspath = Global.GlobalDefinitions.driver.FindElements(By.XPath("//input[@name='Available']"));
            IList<IWebElement> StartTime = Global.GlobalDefinitions.driver.FindElements(By.XPath("//input[@name='StartTime']"));
            IList<IWebElement> EndTime = Global.GlobalDefinitions.driver.FindElements(By.XPath("//input[@name='EndTime']"));

            if (AvailableDays[0] == 1)
            {
                Dayspath[0].Click();

                StartTime[1].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartTime"));
                EndTime[0].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndTime"));
            }

            if (AvailableDays[1] == 1)
            {
                Dayspath[1].Click();

                StartTime[1].SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "StartTime"));
                StartTime[1].SendKeys(Keys.ArrowDown);
                StartTime[1].SendKeys(Keys.ArrowDown);
                Console.WriteLine(GlobalDefinitions.ExcelLib.ReadData(3, "StartTime"));
                EndTime[1].SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "EndTime"));
                EndTime[1].SendKeys(Keys.ArrowDown);
            }

            if (AvailableDays[2] == 1)
            {
                Dayspath[2].Click();
                StartTime[2].SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "StartTime"));
                EndTime[2].SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "EndTime"));
            }

            if (AvailableDays[3] == 1)
            {
                Dayspath[3].Click();
                StartTime[3].SendKeys(GlobalDefinitions.ExcelLib.ReadData(5, "StartTime"));
                StartTime[3].SendKeys(Keys.ArrowDown);
                StartTime[3].SendKeys(Keys.ArrowDown);
                EndTime[3].SendKeys(GlobalDefinitions.ExcelLib.ReadData(5, "EndTime"));
                EndTime[3].SendKeys(Keys.ArrowDown);
            }

            if (AvailableDays[4] == 1)
            {
                Dayspath[4].Click();
                StartTime[4].SendKeys(GlobalDefinitions.ExcelLib.ReadData(6, "StartTime"));
                EndTime[4].SendKeys(GlobalDefinitions.ExcelLib.ReadData(6, "EndTime"));
            }

            if (AvailableDays[5] == 1)
            {
                Dayspath[5].Click();
                StartTime[5].SendKeys(GlobalDefinitions.ExcelLib.ReadData(7, "StartTime"));
                EndTime[5].SendKeys(GlobalDefinitions.ExcelLib.ReadData(7, "EndTime"));
            }

            if (AvailableDays[6] == 1)
            {
                Dayspath[6].Click();
                StartTime[6].SendKeys(GlobalDefinitions.ExcelLib.ReadData(8, "StartTime"));
                EndTime[6].SendKeys(GlobalDefinitions.ExcelLib.ReadData(8, "EndTime"));
            }


            Thread.Sleep(1000);
            //--------------------------------------------------------------------------------
            //Select Skill trade
            for (int i = 0; i < ServiceTypeOptions.Count; i++)
            {
                
                if (ServiceTypeOptions[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Skill Trade"))
                {
                    Radiobtn[i].Click();
                    Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Skill Trade Selected");
                }

            }
            //----------------------------------------------------------------------------------------

            //Enter Skill Exchange tags
            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill Exchange"));
            SkillExchange.SendKeys(Keys.Enter);

            //----------------------------------------------------------------------------------------
            //Work Samples File Upload

            //workSamplesUpload.Click();
            //Thread.Sleep(4000);
            //AutoItX3 autoit = new AutoItX3();
            //autoit.WinActivate("Open"); //Activate the window
            //autoit.Send(@"C:\Users\dell\Desktop\DESKTOP_AKILA\MVP studio\Mars Competition1\MarsFramework\MarsFramework\download.jpg");
            //Thread.Sleep(4000);
            //autoit.Send("{ENTER}");
            //Thread.Sleep(4000);
            //--------------------------------------------------------------------------------------------
            //Select Active
            for (int i = 0; i < ServiceTypeOptions.Count; i++)
            {
                
                if (ServiceTypeOptions[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Active"))
                {
                    Radiobtn[i].Click();
                    Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Active Selected");
                }

            }

            if (Decission == "Save")
            {
                SaveBtn.Click();
                Thread.Sleep(3000);
            }
            else
                CancelBtn.Click();


            //Check added skills is list in Manage listings
            try
            {
                //Iterate through Manage Listing Table
                IList<IWebElement> RowElements = TableElements.FindElements(By.TagName("tr"));
                Console.WriteLine(RowElements.Count);
                

                foreach(IWebElement row in RowElements)
                {
                    IList<IWebElement> col = row.FindElements(By.TagName("td"));
                    if (col[2].Text.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "Title")))
                    {
                        
                        Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Newly added skill service is listed in Manage Listings");
                        break;
                       
                    }

                    else
                    {
                        Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Newly added skill service is not listed in Manage Listings");
                        break;
                    }

                }
               
            }

            catch (Exception e)
            {
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass,"Test Failed", e.Message);
            }
        }
    }
}
