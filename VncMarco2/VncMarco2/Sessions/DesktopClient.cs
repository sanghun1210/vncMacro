using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VncMarco2.Sessions
{
    public class DesktopClient : ClientBase
    {
        public void Setup()
        {
            if (_session == null)
            {
                try
                {
                    DesiredCapabilities appCapabilities = new DesiredCapabilities();
                    appCapabilities.SetCapability("app", "Root");
                    _session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabilities);
                }
                catch
                {
                    throw new System.Exception("WinAppDriver를 실행하세요.");
                }
            }
        }
    }
}
