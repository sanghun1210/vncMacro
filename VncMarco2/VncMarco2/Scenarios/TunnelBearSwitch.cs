using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VncMarco2.Sessions;

namespace VncMarco2.Scenarios
{
    public class TunnelBearSwitch
    {
        private TunnelBearClient _client;

        public TunnelBearSwitch(TunnelBearClient client)
        {
            _client = client;
        }

        public void SwitchToggle()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            WindowsElement button = _client.Session.FindElementByXPath($"//Button[@Name=\"VPN\"][@AutomationId=\"vpnSwitch\"]");
            button.Click();
        }
    }
}
