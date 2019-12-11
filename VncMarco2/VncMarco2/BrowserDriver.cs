using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VncMarco2
{
    public class BrowserDriver
    {
        public enum BrowserType
        {
            Chrome,
            Firefox
        }

        private static ChromeDriver CreateChromeBrowserDriver()
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            //driverService.HideCommandPromptWindow = true; //크롬 콘솔창 숨기기 
            driverService.LogPath = "E:\\chromedriver.log";
            driverService.EnableVerboseLogging = true;

            var options = new ChromeOptions();
            //options.AddArgument("--window-position=-32000,-32000"); 
            //options.AddArgument("headless"); 

            //윈도우창 위치값을 화면밖으로 조정 
            return new ChromeDriver(driverService);
        }

        private static FirefoxDriver CreateFirefoxBrowserDriver()
        {
            var driverService = FirefoxDriverService.CreateDefaultService();
            // driverService.HideCommandPromptWindow = true; //크롬 콘솔창 숨기기 
           

            var options = new FirefoxOptions();
            //options.AddArgument("--window-position=-32000,-32000"); 
            //options.AddArgument("headless"); 


            //윈도우창 위치값을 화면밖으로 조정 
            return new FirefoxDriver(driverService);
        }

        public static RemoteWebDriver CreateBrowserDriver(BrowserType type)
        {
            if(type == BrowserType.Chrome)
            {
                return CreateChromeBrowserDriver();
            }
            else
            {
                return CreateFirefoxBrowserDriver();
            }
        }
    }
}
