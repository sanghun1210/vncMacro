using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VncMarco2.Sessions
{
    public class TunnelBearClient : ClientBase, IDisposable
    {
        public TunnelBearClient(DesktopClient desktopClient)
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

        public void SwitchToggle()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            WindowsElement button = _session.FindElementByXPath($"//Button[@Name=\"VPN\"][@AutomationId=\"vpnSwitch\"]");
            button.Click();
        }

        public void SwitchToggleOn()
        {
            SwitchToggle();

            for (int i = 0; i < 5; i++)
            {
                if(IsVpnConnected())
                {
                    break;
                }
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
        }

        public void SwitchToggleOff()
        {
            SwitchToggle();
        }

        public bool IsVpnConnected()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface Interface in interfaces)
                {
                    if (Interface.OperationalStatus == OperationalStatus.Up)
                    {
                        if ((Interface.NetworkInterfaceType == NetworkInterfaceType.Ppp) && (Interface.NetworkInterfaceType != NetworkInterfaceType.Loopback))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        ~TunnelBearClient()
        {
            this.Dispose(false);
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
            if(_session != null)
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
