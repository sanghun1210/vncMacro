using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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
        Dictionary<string, string> _loginInfo =new Dictionary<string, string>();

        public VpnMacro()
        {
            InitializeComponent();
            comboBox_ipchnage.SelectedIndex = 0;
            textBox_log.ReadOnly = true;     
        }

        private void VpnMacro_Load(object sender, EventArgs e)
        {
            listView_Main.Columns.Add("네이버 ID", 110);
            listView_Main.Columns.Add("네이버 PW", 110);
            listView_Main.Columns.Add("메인 검색어", 140);
            listView_Main.Columns.Add("연관 검색어", 140);
            listView_Main.Columns.Add("대기시간(초)", 90);

            listView_Main.View = View.Details;

            listView_Main.FullRowSelect = true;
            listView_Main.GridLines = true;

            textBox_unitWaitTime.Text = "40";
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

        private void BrowserTask(string id, string pw, string mainTarget, string subTarget)
        {
            try
            {
                using (ChromeDriver driver = BrowserDriver.CreateChromeBrowserDriver())
                {
                    OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    ScenarioBrowser scenarioBrowser = new ScenarioBrowser(driver);
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                    //로그인
                    scenarioBrowser.NaverLogin(id, pw);

                    //전화번호 입력
                    //scenarioBrowser.NaverLoginPhoneNumber(textBox_phoneNumber.Text);
                    scenarioBrowser.NaverSearchFromMain(mainTarget);

                    scenarioBrowser.NaverTabMoveToBlog();
                    scenarioBrowser.NaverBlogSelect();

                    Thread.Sleep(TimeSpan.FromSeconds(3));
                    driver.SwitchTo().Window(driver.WindowHandles[1]);
                    scenarioBrowser.MouseMove();
                    scenarioBrowser.PageDown();
                    scenarioBrowser.MouseMove();
                    driver.Close();


                    //뒤로가기

                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                    driver.Navigate().Back();

                    scenarioBrowser.NaverSearchFromSub(subTarget);
                    scenarioBrowser.NaverTabMoveToBlog();
                    scenarioBrowser.NaverBlogSelect();

                    Thread.Sleep(TimeSpan.FromSeconds(3));
                    driver.SwitchTo().Window(driver.WindowHandles[1]);
                    scenarioBrowser.MouseMove();
                    scenarioBrowser.PageDown();
                    scenarioBrowser.MouseMove();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        //private void TestTask()
        //{
        //    try
        //    {
        //        var driverService = ChromeDriverService.CreateDefaultService();

        //        var options = new ChromeOptions();
        //        options.AddArgument("--start-maximized");
        //        //options.AddArgument("headless");
        //        //options.AddArgument("javascript.enabled", "");
        //        //DesiredCapabilities caps = DesiredCapabilities.chrome();
        //        //caps.SetCapability("chrome.switches", Arrays.asList("--disable-javascript"));

        //        //윈도우창 위치값을 화면밖으로 조정 
        //        // driverService.HideCommandPromptWindow = true;

        //        using (var driver = new ChromeDriver(driverService, options))
        //        {
        //            OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //            ScenarioBrowser scenarioBrowser = new ScenarioBrowser(driver);
        //            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

        //            //로그인

        //            driver.Navigate().GoToUrl("https://blog.naver.com/minjeon1/221266583284");
        //            driver.Navigate().GoToUrl("https://blog.naver.com/0jakso/221272691640");
        //            //driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");
                    
        //            int size = driver.FindElements(By.TagName("iframe")).Count;
        //            for (int i = 0; i < size; i++)
        //            {
        //                try
        //                {
        //                    driver.SwitchTo().Frame(i);
        //                    var gnb = driver.FindElement(By.Id("blog-gnb"));
        //                    Actions action1 = new Actions(driver);
        //                    action1.MoveToElement(gnb).Perform();

        //                    PointConverter pc = new PointConverter();
        //                    Point pt = new Point(gnb.Location.X + 300, gnb.Location.Y + 300);
        //                    Cursor.Position = pt;
        //                }
        //                catch { }
        //            }

        //            scenarioBrowser.MouseMove(20);

        //            for (int i = 0; i < size; i++)
        //            {
        //                try
        //                {
        //                    driver.SwitchTo().Frame(i);
        //                    var element = driver.FindElement(By.Id("saveTagName"));
        //                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        //                }
        //                catch { }
        //            }
        //            driver.SwitchTo().DefaultContent();

                    


        //            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
        //            Thread.Sleep(5000);
        //            js.ExecuteScript("window.scrollBy(0,950);");
        //            //var element = driver.FindElement(By.Id("area_sympathy221272691640")); 
        //            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", element);
        //            Console.Read();
        //            //scenarioBrowser.PageKeyDown();
        //            Thread.Sleep(TimeSpan.FromSeconds(5));
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private void TestTask()
        //{
        //    BrowserTask(textBox_id.Text, textBox_pw.Text);
        //}

        private void Ok_Click(object sender, EventArgs e)
        {

            
            try
            {
                Ok.Enabled = false;

                TunnelBearClient tunnelBearClient = null;
                if (checkBox_isUseTunnerBear.Checked)
                {
                    tunnelBearClient = GetTunnelBearClient();
                }
                
                textBox_log.Clear();
                int count = 1;
                while (true)
                {
                    for (int i=0; i < listView_Main.Items.Count; i++)
                    {
                        if (checkBox_isUseTunnerBear.Checked)
                        {
                            tunnelBearClient.SwitchToggleOn();
                        }

                        textBox_log.AppendText(string.Format("{0} - 작업시작(#{1})", DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"), count));
                        textBox_log.AppendText(Environment.NewLine);

                        string id = listView_Main.Items[i].SubItems[0].Text;
                        string pw = _loginInfo[id];
                        string mainTarget = listView_Main.Items[i].SubItems[2].Text;
                        string subTarget = listView_Main.Items[i].SubItems[3].Text;

                        BrowserTask(id, pw, mainTarget, subTarget);

                        if (checkBox_isUseTunnerBear.Checked)
                        {
                            tunnelBearClient.SwitchToggleOff();
                        }
                        
                        Thread.Sleep(TimeSpan.FromSeconds(Int32.Parse(listView_Main.Items[i].SubItems[4].Text)));

                        textBox_log.AppendText(string.Format("{0} - 작업종료(#{1})", DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"), count));
                        textBox_log.AppendText(Environment.NewLine);
                        textBox_log.AppendText(string.Format("{0} - 작업대기({1}(초))", DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"), textBox_unitWaitTime.Text));
                        textBox_log.AppendText(Environment.NewLine);

                        count++;
                    }
                }                
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
            finally
            {
                Ok.Enabled = true;
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
            textBox_log.AppendText("작업 종료 중...");
        }

        private void button1_Click(object sender, EventArgs e)
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

            if(!_loginInfo.ContainsKey(textBox_id.Text))
            {
                _loginInfo.Add(textBox_id.Text, textBox_pw.Text);
            }
            
            String[] arr = new String[5];
            arr[0] = textBox_id.Text;
            arr[1] = new String('*', textBox_pw.Text.Length);
            arr[2] = textBox_mainTarget.Text;
            arr[3] = textBox_subTarget.Text;
            arr[4] = textBox_unitWaitTime.Text;

            ListViewItem lvt = new ListViewItem(arr);
            lvt = new ListViewItem(arr);
            listView_Main.Items.Add(lvt);   
        }
    }
}
