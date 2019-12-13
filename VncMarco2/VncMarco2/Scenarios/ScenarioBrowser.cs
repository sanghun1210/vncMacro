using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
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

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(OpenQA.Selenium.By.Id("id")));

            var idField = _driver.FindElementById("id");
            idField.Click();
            Clipboard.SetText(id);
            new OpenQA.Selenium.Interactions.Actions(_driver).KeyDown(OpenQA.Selenium.Keys.Control).SendKeys("v").KeyUp(OpenQA.Selenium.Keys.Control).Perform();

            var pwField = _driver.FindElementById("pw");
            Clipboard.SetText(pw);
            pwField.Click();
            new OpenQA.Selenium.Interactions.Actions(_driver).KeyDown(OpenQA.Selenium.Keys.Control).SendKeys("v").KeyUp(OpenQA.Selenium.Keys.Control).Perform();

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
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(OpenQA.Selenium.By.Id("query")));

            var searchField = _driver.FindElementById("query");
            searchField.Click();
            searchField.SendKeys(target);

            var searchButton = _driver.FindElementById("search_btn");
            searchButton.Click();
        }

        public void NaverSearchFromSub(string target)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(OpenQA.Selenium.By.XPath("//input[@id='nx_query']")));

            var searchField = _driver.FindElement(OpenQA.Selenium.By.XPath("//input[@id='nx_query']"));
            searchField.Clear();
            searchField.SendKeys(target);

            var searchButton = _driver.FindElement(OpenQA.Selenium.By.XPath("//button[@class='bt_search']"));
            searchButton.Click();
        }

        public void NaverTabMoveToBlog()
        {
            try
            {
                //블로그는 lnb3
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(OpenQA.Selenium.By.ClassName("lnb3")));

                var blogTab = _driver.FindElement(OpenQA.Selenium.By.ClassName("lnb3"));
                blogTab.Click();
            }
            catch
            {
                // 블로그탭을 못찾았을 경우
                NaverTabMoveToBlogFromMore();
            }
        }

        public void NaverTabMoveToBlogFromMore()
        {
            //블로그는 lnb3
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(OpenQA.Selenium.By.ClassName("lnb_more")));

            var moreButton = _driver.FindElement(OpenQA.Selenium.By.ClassName("lnb_more"));
            moreButton.Click();

            var blogButton = _driver.FindElement(OpenQA.Selenium.By.PartialLinkText("블로그"));
            blogButton.Click();
        }

        public void NaverBlogSelect()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(OpenQA.Selenium.By.XPath("//a[@class='sh_blog_title _sp_each_url _sp_each_title']")));

            var selectBlog = _driver.FindElement(OpenQA.Selenium.By.XPath("//a[@class='sh_blog_title _sp_each_url _sp_each_title']"));
            selectBlog.Click();


        }
    }
}
