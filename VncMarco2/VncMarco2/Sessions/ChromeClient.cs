using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VncMarco2.Sessions
{
    public class ChromeClient : ClientBase, IDisposable
    {
        public ChromeClient(DesktopClient desktopClient)
        {
            try
            {
                var chromeWindow = desktopClient.Session.FindElementByName("Google Chrome");
                var tunnelBearTopLevelWindowHandle = chromeWindow.GetAttribute("NativeWindowHandle");
                tunnelBearTopLevelWindowHandle = (int.Parse(tunnelBearTopLevelWindowHandle)).ToString("x");

                DesiredCapabilities appCapabilities = new DesiredCapabilities();
                appCapabilities.SetCapability("appTopLevelWindow", tunnelBearTopLevelWindowHandle);
                _session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);

                // Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
                _session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
            }
            catch
            {
                throw new System.Exception("크롬 프로그램을 찾을수 없습니다.");
            }
        }

        ~ChromeClient()
        {
            this.Dispose(false);
        }

        public void KeyPageDown()
        {
            _session.Keyboard.SendKeys(Keys.PageDown);
        }

        private bool _disposed;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // IDisposable 인터페이스를 구현하는 멤버들을 여기서 정리합니다.
            }

            // .NET Framework에 의하여 관리되지 않는 외부 리소스들을 여기서 정리합니다.
            if (_session != null)
            {
                try
                {
                    _session.Close();
                    _session = null;
                }
                catch
                { }
            }

            _disposed = true;
        }
    }
}
