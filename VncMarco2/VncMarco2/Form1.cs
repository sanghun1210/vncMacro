using OpenQA.Selenium;
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

        private void BrowserTask()
        {
            try
            {
                using (RemoteWebDriver driver = BrowserDriver.CreateBrowserDriver(_browserType))
                {
                    OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    ScenarioBrowser scenarioBrowser = new ScenarioBrowser(driver);
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                    //로그인
                    scenarioBrowser.NaverLogin(textBox_id.Text, textBox_pw.Text);

                    //전화번호 입력
                    //scenarioBrowser.NaverLoginPhoneNumber(textBox_phoneNumber.Text);
                    scenarioBrowser.NaverSearchFromMain(textBox_mainTarget.Text);

                    scenarioBrowser.NaverTabMoveToBlog();
                    scenarioBrowser.NaverBlogSelect();
                    Thread.Sleep(TimeSpan.FromSeconds(5));


                    //ChromeClient client = new ChromeClient(_desktopClient);
                    //_desktopClient.Session.Keyboard.SendKeys(OpenQA.Selenium.Keys.PageDown);
                    //client.KeyPageDown();
                     scenarioBrowser.PageKeyDown();
                    // WindowScrollDown(driver);
                    Thread.Sleep(TimeSpan.FromSeconds(5));

                    //scenarioBrowser.MouseMove(driver);

                    //뒤로가기
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                    driver.Navigate().Back();

                    scenarioBrowser.NaverSearchFromSub(textBox_subTarget.Text);
                    scenarioBrowser.NaverTabMoveToBlog();

                    scenarioBrowser.NaverBlogSelect();
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    WindowScrollDown(driver);
                    Thread.Sleep(TimeSpan.FromSeconds(5));

                    // scenarioBrowser.MouseMove(driver);
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
                    tunnelBearClient.SwitchToggleOn();
                    textBox_log.AppendText(string.Format("{0} - 작업시작(#{1})", DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"), count));
                    textBox_log.AppendText(Environment.NewLine);
                    BrowserTask();

                    textBox_log.AppendText(string.Format("{0} - 작업종료(#{1})", DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"), count));
                    textBox_log.AppendText(Environment.NewLine);
                    textBox_log.AppendText(string.Format("{0} - 작업대기({1}(분))", DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"), textBox_waitTime.Text));
                    textBox_log.AppendText(Environment.NewLine);

                    //대기시간
                    int waitTime = Int32.Parse(textBox_waitTime.Text);
                    Thread.Sleep(TimeSpan.FromMinutes(waitTime));
                    count++;

                    tunnelBearClient.SwitchToggleOff();
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
