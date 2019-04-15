using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class Tenant : Global.Base
        {

            [Test]
            public void UserAccount()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Search for a Property");

                // Create an class and object to call the method
                Profile obj = new Profile();
                obj.EditProfile();
            }

            [Test]
            public void SaveShareSkill()
            {
                // Creates a toggle for the given test, adds all log events under it
                test = extent.StartTest("Add a share skill");

                // Create an class and object to call the method
                ShareSkill obj = new ShareSkill();
                obj.ClickonShareSkillBtn();
                obj.ShareProfile("Save");
            }

            [Test]
            public void CancelShareSkill()
            {
                // Creates a toggle for the given test, adds all log events under it
                test = extent.StartTest("Cancel a share skill");

                // Create an class and object to call the method
                ShareSkill obj = new ShareSkill();
                obj.ClickonShareSkillBtn();
                obj.ShareProfile("Cancel");
            }

            [Test]
            public void EditManageListings()
            {
                // Creates a toggle for the given test, adds all log events under it
                test = extent.StartTest("Cancel a share skill");

                // Create an class and object to call the method
                ManageListing obj = new ManageListing();
                ShareSkill ssobj = new ShareSkill();
                obj.EditManageListings();
                //ssobj.ClickonShareSkillBtn();
                ssobj.ShareProfile("Save");
                
            }

            [Test]
            public void DeleteManageListings()
            {
                // Creates a toggle for the given test, adds all log events under it
                test = extent.StartTest("Delete share skill");

                // Create an class and object to call the method
                ManageListing obj = new ManageListing();
                
                obj.DeleteManageListing();

                
            }
        }
    }
}