using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VncMarco2.Sessions
{
    abstract public class ClientBase
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        protected WindowsDriver<WindowsElement> _session;
        public WindowsDriver<WindowsElement> Session { get { return _session; } }

        public void Close()
        {
            if (_session != null)
            {
                _session.Quit();
                _session = null;
            }
        }
    }
}
