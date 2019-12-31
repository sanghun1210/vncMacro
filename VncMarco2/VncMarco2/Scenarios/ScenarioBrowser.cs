using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        ChromeDriver _driver;

        public ScenarioBrowser(ChromeDriver driver)
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

        public void PageDown()
        {
            Thread.Sleep(5000);
            int size = _driver.FindElements(By.TagName("iframe")).Count;
            for (int i = 0; i < size; i++)
            {
                try
                {
                    _driver.SwitchTo().Frame(i);
                    Thread.Sleep(3000);
                    ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,1200)");
                }
                catch
                {}

                try
                {
                    Thread.Sleep(2000);
                    _driver.SwitchTo().Frame(i);
                    Thread.Sleep(3000);
                    var element = _driver.FindElement(By.Id("saveTagName"));
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                }
                catch
                { }
            }
            //_driver.SwitchTo().DefaultContent();

            //IJavaScriptExecutor js = _driver as IJavaScriptExecutor;
            //Thread.Sleep(5000);
            //js.ExecuteScript("window.scrollBy(0,950);");
            //Console.Read();
        }

        public void MouseMove(int moveTime)
        {
            //var endPoint = Screen.PrimaryScreen.Bounds;
            //System.Windows.Forms.Cursor.Position = new Point(endPoint.Bottom / 2, endPoint.Right / 2);

            Point centerPoint = Cursor.Position;
            Random r = new Random();
            for (int i = 0; i < moveTime; i++)
            {
                MouseMoveTo(centerPoint.X + r.Next(120), centerPoint.Y + r.Next(120));
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        private void MouseMoveTo(int offsetX, int offsetY)
        {
            PointConverter pc = new PointConverter();
            Point pt = new Point(offsetX, offsetY);
            Cursor.Position = pt;
        }

        public void MouseMoveCenter()
        {
            int size = _driver.FindElements(By.TagName("iframe")).Count;
            for (int i = 0; i < size; i++)
            {
                try
                {
                    _driver.SwitchTo().Frame(i);
                    var gnb = _driver.FindElement(By.Id("blog-gnb"));
                    Actions action1 = new Actions(_driver);
                    action1.MoveToElement(gnb).Perform();

                    PointConverter pc = new PointConverter();
                    Point pt = new Point(gnb.Location.X + 300, gnb.Location.Y + 300);
                    Cursor.Position = pt;
                }
                catch { }
            }
        }
    }
}
