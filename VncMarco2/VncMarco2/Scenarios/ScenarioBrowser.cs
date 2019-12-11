using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VncMarco2.Scenarios
{
    public class ScenarioBrowser
    {
        RemoteWebDriver _driver;

        public ScenarioBrowser(RemoteWebDriver driver)
        {
            _driver = driver;
        }

        public void NaverLogin(string id, string pw)
        {
            _driver.Navigate().GoToUrl("https://nid.naver.com/nidlogin.login");
            var idField = _driver.FindElementById("id");
            idField.Click();
            Clipboard.SetText(id);
            new OpenQA.Selenium.Interactions.Actions(_driver).KeyDown(OpenQA.Selenium.Keys.Control).SendKeys("v").KeyUp(OpenQA.Selenium.Keys.Control).Perform();

            var pwField = _driver.FindElementById("pw");
            Clipboard.SetText(pw);
            pwField.Click();
            new OpenQA.Selenium.Interactions.Actions(_driver).KeyDown(OpenQA.Selenium.Keys.Control).SendKeys("v").KeyUp(OpenQA.Selenium.Keys.Control).Perform();

            Thread.Sleep(TimeSpan.FromSeconds(2));

            var loginButton = _driver.FindElement(OpenQA.Selenium.By.ClassName("btn_global"));
            loginButton.Click();
        }

        public void NaverLoginPhoneNumber(string phoneNumber)
        {
            Clipboard.SetText(phoneNumber);
            var phoneFieldWraper = _driver.FindElement(OpenQA.Selenium.By.XPath("//span[@class='input_box']"));
            phoneFieldWraper.Click();
            new OpenQA.Selenium.Interactions.Actions(_driver).KeyDown(OpenQA.Selenium.Keys.Control).SendKeys("v").KeyUp(OpenQA.Selenium.Keys.Control).Perform();
            
            var loginButton = _driver.FindElement(OpenQA.Selenium.By.ClassName("btn int_ok"));
            loginButton.Click();
           
        }

        public void NaverSearchFromMain(string target)
        {
            var searchField = _driver.FindElementById("query");
            searchField.Click();
            searchField.SendKeys(target);

            var searchButton = _driver.FindElementById("search_btn");
            searchButton.Click();
        }

        public void NaverSearchFromSub(string target)
        {
            var searchField = _driver.FindElement(OpenQA.Selenium.By.XPath("//input[@id='nx_query']"));
            searchField.Clear();
            searchField.SendKeys(target);

            var searchButton = _driver.FindElement(OpenQA.Selenium.By.XPath("//button[@class='bt_search']"));
            searchButton.Click();
        }

        public void NaverTabMoveToBlog()
        {
            //블로그는 lnb3
            var blogTab = _driver.FindElement(OpenQA.Selenium.By.ClassName("lnb3"));
            blogTab.Click();
        }

        public void NaverBlogSelect()
        {
            var selectBlog = _driver.FindElement(OpenQA.Selenium.By.XPath("//a[@class='sh_blog_title _sp_each_url _sp_each_title']"));
            selectBlog.Click();
        }
    }
}
