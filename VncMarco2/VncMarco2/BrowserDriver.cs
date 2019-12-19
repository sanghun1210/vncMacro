using OpenQA.Selenium;
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
        private Dictionary<string, int> _proxyServerList;

        public enum BrowserType
        {
            Chrome,
            Firefox
        }

        public BrowserDriver()
        {
            _proxyServerList = new Dictionary<string, int>()
            {
                {"58.233.211.104", 443},
                {"118.222.243.227", 80},
                {"58.233.211.104", 80},
                {"222.97.175.34", 80}
            };
        }

        private static ChromeDriver CreateChromeBrowserDriver()
        {
            var driverService = ChromeDriverService.CreateDefaultService();
           
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            // options.AddArgument("headless");
            // options.AddArgument("javascript.enabled", "");
            // DesiredCapabilities caps = DesiredCapabilities.chrome();
            // caps.SetCapability("chrome.switches", Arrays.asList("--disable-javascript"));

            // 윈도우창 위치값을 화면밖으로 조정 
            // driverService.HideCommandPromptWindow = true;

            return new ChromeDriver(driverService, options);
        }

        private static ChromeDriver CreateChromeBrowserDriver(string proxyServerIp, int proxyPort)
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            //driverService.HideCommandPromptWindow = true; //크롬 콘솔창 숨기기 
            // driverService.LogPath = "E:\\chromedriver.log";
            // driverService.EnableVerboseLogging = true;

            var options = new ChromeOptions();
            var proxy = new Proxy();
            proxy.HttpProxy = string.Format("{0}:{1}", proxyServerIp, proxyPort);
            proxy.SslProxy = string.Format("{0}:{1}", proxyServerIp, proxyPort);
            options.Proxy = proxy;
            
            //윈도우창 위치값을 화면밖으로 조정 
            return new ChromeDriver(driverService, options);
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

        public static RemoteWebDriver CreateBrowserDriver(BrowserType type, string proxyServerIp, int port)
        {
            if (type == BrowserType.Chrome)
            {
                return CreateChromeBrowserDriver(proxyServerIp, port);
            }
            else
            {
                return CreateFirefoxBrowserDriver();
            }
        }
    }
}
