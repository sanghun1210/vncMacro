using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VncMarco2.Sessions
{
    public class TunnelBearClient : ClientBase
    {
        public void Setup(DesktopClient desktopClient)
        {
            if (_session == null)
            {
                try
                {
                    var tunnelBearWindow = desktopClient.Session.FindElementByName("TunnelBear");
                    var tunnelBearTopLevelWindowHandle = tunnelBearWindow.GetAttribute("NativeWindowHandle");
                    tunnelBearTopLevelWindowHandle = (int.Parse(tunnelBearTopLevelWindowHandle)).ToString("x");

                    DesiredCapabilities appCapabilities = new DesiredCapabilities();
                    appCapabilities.SetCapability("appTopLevelWindow", tunnelBearTopLevelWindowHandle);
                    _session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);

                    // Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
                    _session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
                }
                catch
                {
                    throw new System.Exception("TunnelBear 프로그램을 찾을수 없습니다.");
                }
                
            }
        }
    }
}
