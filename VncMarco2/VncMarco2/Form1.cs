using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VncMarco2.Scenarios;
using VncMarco2.Sessions;

namespace VncMarco2
{
    public partial class VpnMacro : Form
    {
        private BrowserDriver.BrowserType _browserType = BrowserDriver.BrowserType.Chrome;
        private DesktopClient _desktopClient;
        private volatile bool _isContinue = true;


        public VpnMacro()
        {
            InitializeComponent();
            comboBox_ipchnage.SelectedIndex = 0;
            textBox_log.ReadOnly = true;     
        }

        public TunnelBearClient GetTunnelBearClient()
        {
  
            if (_desktopClient == null)
            {
                _desktopClient = new DesktopClient();
                _desktopClient.Setup();
            }
            
            Debug.Assert(_desktopClient != null);
            Debug.Assert(_desktopClient.Session != null, "데스크톱 세션에 연결할수 없습니다.");

            return new TunnelBearClient(_desktopClient);
        }

        private void BrowserTask(string id, string pw)
        {
            try
            {
                using (RemoteWebDriver driver = BrowserDriver.CreateBrowserDriver(_browserType))
                {
                    OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    ScenarioBrowser scenarioBrowser = new ScenarioBrowser(driver);
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                    //로그인
                    scenarioBrowser.NaverLogin(id, pw);

                    //전화번호 입력
                    //scenarioBrowser.NaverLoginPhoneNumber(textBox_phoneNumber.Text);
                    scenarioBrowser.NaverSearchFromMain(textBox_mainTarget.Text);

                    scenarioBrowser.NaverTabMoveToBlog();
                    scenarioBrowser.NaverBlogSelect();
                    Thread.Sleep(TimeSpan.FromSeconds(42));

                    //뒤로가기
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                    driver.Navigate().Back();

                    scenarioBrowser.NaverSearchFromSub(textBox_subTarget.Text);
                    scenarioBrowser.NaverTabMoveToBlog();

                    scenarioBrowser.NaverBlogSelect();
                    Thread.Sleep(TimeSpan.FromSeconds(42));
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void TestTask()
        {
            try
            {
                var driverService = ChromeDriverService.CreateDefaultService();

                var options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                //options.AddArgument("headless");
                //options.AddArgument("javascript.enabled", "");
                //DesiredCapabilities caps = DesiredCapabilities.chrome();
                //caps.SetCapability("chrome.switches", Arrays.asList("--disable-javascript"));

                //윈도우창 위치값을 화면밖으로 조정 
                // driverService.HideCommandPromptWindow = true;

                using (var driver = new ChromeDriver(driverService, options))
                {
                    OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    ScenarioBrowser scenarioBrowser = new ScenarioBrowser(driver);
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                    //로그인

                    driver.Navigate().GoToUrl("https://blog.naver.com/0jakso/221272691640");
                    //driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");

                    IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                    Thread.Sleep(5000);
                    js.ExecuteScript("window.scrollBy(0,950);");
                    //var element = driver.FindElement(By.Id("area_sympathy221272691640")); 
                    //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", element);
                    Console.Read();
                    //scenarioBrowser.PageKeyDown();
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void WindowScrollDown(RemoteWebDriver driver)
        {

            //driver.ExecuteScript("document.getElementById('Id of the control').value='khajamoizuddin@gmail.com'");

            
            Thread.Sleep(TimeSpan.FromSeconds(3));
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
            //Console.Read();

            //body = driver.FindElementByXPath\('body')
            //body.send_keys(Keys.PAGE_DOWN)
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            //TestTask();
            //return;

            if (string.IsNullOrEmpty(textBox_id.Text) || string.IsNullOrWhiteSpace(textBox_id.Text))
            {
                MessageBox.Show("ID를 입력하세요.");
                return;
            }
            if (string.IsNullOrEmpty(textBox_pw.Text) || string.IsNullOrWhiteSpace(textBox_pw.Text))
            {
                MessageBox.Show("PW를 입력하세요.");
                return;
            }
            if (string.IsNullOrEmpty(textBox_mainTarget.Text) || string.IsNullOrWhiteSpace(textBox_mainTarget.Text))
            {
                MessageBox.Show("메인검색어를 입력하세요.");
                return;
            }
            if (string.IsNullOrEmpty(textBox_subTarget.Text) || string.IsNullOrWhiteSpace(textBox_subTarget.Text))
            {
                MessageBox.Show("연관검색어를 입력하세요.");
                return;
            }

            if (string.IsNullOrEmpty(textBox_subTarget.Text) || string.IsNullOrWhiteSpace(textBox_subTarget.Text))
            {
                MessageBox.Show("연관검색어를 입력하세요.");
                return;
            }

            

            try
            {
                Ok.Enabled = false;
                Stop.Enabled = true;

                TunnelBearClient tunnelBearClient = GetTunnelBearClient();
                textBox_log.Clear();
                int count = 1;
                while (true)
                {
                    
                    textBox_log.AppendText(string.Format("{0} - 작업시작(#{1})", DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"), count));
                    textBox_log.AppendText(Environment.NewLine);

                    //1차 아이디
                    tunnelBearClient.SwitchToggleOn();
                    BrowserTask(textBox_id.Text, textBox_pw.Text);
                    tunnelBearClient.SwitchToggleOff();
                    Thread.Sleep(TimeSpan.FromSeconds(10));

                    //2차 아이디
                    tunnelBearClient.SwitchToggleOn();
                    BrowserTask(textBox_id2.Text, textBox_pw2.Text);
                    tunnelBearClient.SwitchToggleOff();
                    Thread.Sleep(TimeSpan.FromSeconds(10));

                    //3차 아이디
                    tunnelBearClient.SwitchToggleOn();
                    BrowserTask(textBox_id3.Text, textBox_pw3.Text);
                    tunnelBearClient.SwitchToggleOff();
                    Thread.Sleep(TimeSpan.FromSeconds(10));

                    textBox_log.AppendText(string.Format("{0} - 작업종료(#{1})", DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"), count));
                    textBox_log.AppendText(Environment.NewLine);
                    textBox_log.AppendText(string.Format("{0} - 작업대기({1}(분))", DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"), textBox_waitTime.Text));
                    textBox_log.AppendText(Environment.NewLine);

                    //대기시간
                    int waitTime = Int32.Parse(textBox_waitTime.Text);
                    Thread.Sleep(TimeSpan.FromMinutes(waitTime));
                    count++;

                    
                    if (!_isContinue)
                        break;
                }                
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
            finally
            {
                Ok.Enabled = true;
                Stop.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _browserType = BrowserDriver.BrowserType.Chrome;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _browserType = BrowserDriver.BrowserType.Firefox;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            _isContinue = false;
            Stop.Enabled = false;
            textBox_log.AppendText("작업 종료 중...");
        }
    }
}
