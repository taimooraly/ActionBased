using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Assignment_8_Part_2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //RightClickActionCommand();
            //MoveToElementActionCommand();
            //DoubleClickInteractionActionCommands();

            Task_1();
            Task_2();
            Task_3();
            Task_4();
            Task_5();

        }

        public void Task_1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();  // Windows maximize action perform
            driver.Url = "https://adactinhotelapp.com/";
            driver.Navigate().Refresh(); // window refresh action perform
            driver.FindElement(By.Id("username")).SendKeys("AmirImam");   // sendkeys action perform
            driver.FindElement(By.Name("password")).SendKeys("AmirImam");
            driver.FindElement(By.ClassName("login_button")).Click();  // click action perform
            string text = driver.FindElement(By.XPath("/html/body/table[2]/tbody/tr[1]/td[1]")).Text;  // text action perform
            MessageBox.Show(text);
            driver.FindElement(By.XPath("//*[@id='location']/option[4]")).Click();
            //driver.FindElement(By.XPath("//*[@id='location']/option[4]")).SendKeys(Keys.Tab);
            driver.FindElement(By.XPath("//*[@id='hotels']/option[4]")).Click();
            driver.FindElement(By.XPath(" //*[@id='room_type']/option[3]")).Click();
            driver.FindElement(By.XPath("//*[@id='room_nos']/option[6]")).Click();
            driver.FindElement(By.XPath("//*[@id='datepick_in']")).Clear();  // clear action perform
            driver.FindElement(By.XPath("//*[@id='datepick_in']")).SendKeys("26/06/2022");
            driver.FindElement(By.XPath("  //*[@id='datepick_out']")).Clear();
            driver.FindElement(By.XPath("//*[@id='datepick_out']")).SendKeys("27/06/2022");
            driver.FindElement(By.XPath("//*[@id='adult_room']/option[3]")).Click();
            driver.FindElement(By.XPath("//*[@id='child_room']/option[3]")).Click();
            driver.FindElement(By.Name("Submit")).Click();
            driver.FindElement(By.Name("radiobutton_0")).Click();
            driver.FindElement(By.XPath("//*[@id='continue']")).Click();
            driver.FindElement(By.Name("first_name")).SendKeys("Osama");
            driver.FindElement(By.Name("last_name")).SendKeys("Hasnain");
            driver.FindElement(By.Name("address")).SendKeys("Karachi");
            driver.Navigate().Back();    //Navigate action perform
            Thread.Sleep(2000);
        }
        public void RightClickActionCommand()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://adactinhotelapp.com/";
            var element = driver.FindElement(By.Id("username"));
            //Actions
            Actions action = new Actions(driver);
            action.ContextClick(element).Perform(); //Right Click Element}

            MessageBox.Show("Right Click is Pressed");
        }
        public void MoveToElementActionCommand()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://adactinhotelapp.com/";
            var element = driver.FindElement(By.Id("username"));
            //Actions
            Actions action = new Actions(driver);
            action.MoveToElement(element).Build().Perform(); //Move To Element

            MessageBox.Show("Move to Element action Performed");

        }
        public void DoubleClickInteractionActionCommands()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://adactinhotelapp.com/";
            var element = driver.FindElement(By.Id("username"));
            //Actions
            Actions action = new Actions(driver);
            action.DoubleClick(element).Perform();

            MessageBox.Show("Double Click is Performed");
        }

    public void Task_2()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url = "http://adactinhotelapp.com/";
        driver.FindElement(By.Id("username")).SendKeys("AmirImam");
        driver.FindElement(By.Id("password")).SendKeys("AmirImam");
        driver.FindElement(By.Id("login")).Click();

        IWebElement title = driver.FindElement(By.ClassName("welcome_menu"));
        Console.WriteLine(title.GetAttribute("innerHTML"));

        var element = driver.FindElement(By.CssSelector("#location > option:nth-child(2)"));
        Console.WriteLine(element.GetAttribute("value"));

        var elementText = driver.FindElement(By.CssSelector("#location > option:nth-child(3)"));
        Console.WriteLine(elementText.GetAttribute("text"));
   
    }


        public void Task_3()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://adactinhotelapp.com/";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('username').value='AmirImam'");
            js.ExecuteScript("document.getElementById('password').value='AmirImam'");
            js.ExecuteScript("document.getElementById('login').click()");
            var element1 = driver.FindElement(By.Id("location"));
            var selectdropdown = new SelectElement(element1);
            js.ExecuteScript("arguments[0].value='Sydney'", element1);
            js.ExecuteScript("document.getElementById('Submit').click()");
            Thread.Sleep(3000);
            js.ExecuteScript("document.getElementById('radiobutton_1').click()");
            js.ExecuteScript("document.getElementById('continue').click()");


            //Disable

            var element = driver.FindElement(By.XPath("/html/body/table[2]/tbody/tr[2]/td/form/table/tbody/tr[8]/td[2]/input"));

            string elementState = element.GetAttribute("Disabled");

            if (elementState == null)
            {
                elementState = "enabled";

                MessageBox.Show("Enabled");
            }
            else if (elementState == "true")
            {
                elementState = "disabled";

                MessageBox.Show("Disabled");
            }

            //Enaable

            var element2 = driver.FindElement(By.XPath("/html/body/table[2]/tbody/tr[2]/td/form/table/tbody/tr[13]/td[2]/input"));

            string element2State = element2.GetAttribute("Disabled");

            if (element2State == null)
            {
                element2State = "enabled";

                MessageBox.Show("Enabled");
            }
            else if (element2State == "true")
            {
                element2State = "disabled";

                MessageBox.Show("Disabled");
            }

         
        }


        public void Task_4()
        {


            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Url = "http://adactinhotelapp.com/";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('username').value='AmirImam'");
            js.ExecuteScript("document.getElementById('password').value='AmirImam'");
            js.ExecuteScript("document.getElementById('login').click()");
            var element1 = driver.FindElement(By.Id("location"));
            var element2 = driver.FindElement(By.Id("hotels"));
            var element3 = driver.FindElement(By.Id("room_type"));
            var element4 = driver.FindElement(By.CssSelector("#room_nos"));
            var element5 = driver.FindElement(By.Id("datepick_in"));
            var element6 = driver.FindElement(By.Id("datepick_out"));
            var element7 = driver.FindElement(By.Id("adult_room"));
            var element8 = driver.FindElement(By.Id("child_room"));



            js.ExecuteScript("arguments[0].value='Sydney'", element1);
            js.ExecuteScript("arguments[0].value='Hotel Sunshine'", element2);
            js.ExecuteScript("arguments[0].value='Double'", element3);
            js.ExecuteScript("arguments[0].value='1'", element4);
            js.ExecuteScript("arguments[0].value='03/07/1998'", element5);
            js.ExecuteScript("arguments[0].value='09/03/2023'", element6);
            js.ExecuteScript("arguments[0].value='2'", element7);
            js.ExecuteScript("arguments[0].value='2'", element8);
            js.ExecuteScript("document.getElementById('Submit').click()");

            js.ExecuteScript("document.getElementById('radiobutton_0').click()");
            js.ExecuteScript("document.getElementById('continue').click()");

            js.ExecuteScript("document.getElementById('first_name').value='Mujahid'");
            js.ExecuteScript("document.getElementById('last_name').value='Akber Ali'");
            js.ExecuteScript("document.getElementById('address').value='Nazimabad block 1'");
            js.ExecuteScript("document.getElementById('cc_num').value='565111111111111111111'");
            var element9 = driver.FindElement(By.Id("cc_type"));
            var element10 = driver.FindElement(By.Id("cc_exp_month"));
            var element11 = driver.FindElement(By.Id("cc_exp_year"));
            js.ExecuteScript("arguments[0].value='AMEX'", element9);
            js.ExecuteScript("arguments[0].value='1'", element10);
            js.ExecuteScript("arguments[0].value='2012'", element11);
            js.ExecuteScript("document.getElementById('cc_cvv').value='676'");

         
            js.ExecuteScript("document.getElementById('book_now').click()");



        }

        public void Task_5()
        {


            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://demoqa.com/";
            driver.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div/div[1]/div/div[3]/h5")).Click();
            driver.FindElement(By.CssSelector("#item-1 > span")).Click();
         

            //Check Box not selected

            IWebElement checkBoxElement = driver.FindElement(By.CssSelector("#tree-node > ol > li > span > label > span.rct-title"));

            bool isSelected = checkBoxElement.Selected;
            if (isSelected == false)
            {
                MessageBox.Show("Check Box is Not Selected");
            }
            else if (isSelected == true)
            {
                MessageBox.Show("Check Box is Selected");
            }

            driver.FindElement(By.CssSelector("#tree-node > ol > li > span > label > span.rct-title")).Click();
            //Check Box Selected
            IWebElement checkBoxElement1 = driver.FindElement(By.CssSelector("#tree-node > ol > li > span > label > span.rct-title"));

            bool isSelected1 = checkBoxElement.Selected;
            if (isSelected1 == false)
            {
                MessageBox.Show("Check Box is Selected");
            }
            else if (isSelected1 == true)
            {
                MessageBox.Show("Check Box is Not Selected");
            }



        }




    }

}