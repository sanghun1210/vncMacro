﻿using OpenQA.Selenium.Remote;
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
        private TunnelBearClient _tunnelBearClient;
        private string _localIp;
        private volatile bool _isContinue = true;


        public VpnMacro()
        {
            InitializeComponent();
            comboBox_ipchnage.SelectedIndex = 0;            
            _localIp = GetLocalIp();
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

            if (_tunnelBearClient == null)
            {
                _tunnelBearClient = new TunnelBearClient();
                _tunnelBearClient.Setup(_desktopClient);
            }

            Debug.Assert(_tunnelBearClient != null);
            Debug.Assert(_tunnelBearClient.Session != null, "TunnelBear 세션에 연결할수 없습니다.");

            return _tunnelBearClient;
        }

        private async Task VpnTask(TunnelBearClient tunnelBearClient)
        {
            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            var task = Task.Factory.StartNew(() => 
            {
                // 스위치 온
                TunnelBearSwitch tunnelBearOnOffSwitch = new TunnelBearSwitch(tunnelBearClient);
                tunnelBearOnOffSwitch.SwitchToggle(); //On

                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        var currentIp = GetLocalIp();
                        if (!string.IsNullOrEmpty(currentIp) &&
                        currentIp.Length > 3 &&
                        currentIp != _localIp &&
                        System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                            break;
                    }
                    catch { }
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }

                Thread.Sleep(TimeSpan.FromSeconds(3));
                RemoteWebDriver driver = null;
                if (comboBox_ipchnage.SelectedIndex == 1)
                {
                    driver = BrowserDriver.CreateBrowserDriver(_browserType, "52.231.34.43", 3128);
                }
                else
                {
                    driver = BrowserDriver.CreateBrowserDriver(_browserType);
                }
                
                try
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

                    MouseMoves();

                    //뒤로가기
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                    driver.Navigate().Back();
                    
                    scenarioBrowser.NaverSearchFromSub(textBox_subTarget.Text);
                    scenarioBrowser.NaverTabMoveToBlog();

                    scenarioBrowser.NaverBlogSelect();
                    MouseMoves();
                }
                catch(System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    try
                    {
                        driver.Quit();
                        driver = null;
                    }
                    catch { }
                    try
                    {
                        //tunnelBearOnOffSwitch.SwitchToggle(); //off
                    }
                    catch { }
                }
            }, CancellationToken.None, TaskCreationOptions.None, scheduler);

            try
            {
                Task allTasks = Task.WhenAll(task);
                await allTasks;
            }
            catch (AggregateException ae)
            {
                // Assume we know what's going on with this particular exception. 
                // Rethrow anything else. AggregateException.Handle provides 
                // another way to express this. See later example. 
                foreach (var e in ae.InnerExceptions)
                {
                    throw;
                }
            }
        }

        private async Task VpnTask(string ip, int port)
        {
            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            var task = Task.Factory.StartNew(() =>
            {
                RemoteWebDriver driver = null;
                if (comboBox_ipchnage.SelectedIndex == 1)
                {
                    driver = BrowserDriver.CreateBrowserDriver(_browserType, ip, port);
                }
                else
                {
                    driver = BrowserDriver.CreateBrowserDriver(_browserType);
                }

                try
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

                    MouseMoves();

                    //뒤로가기
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                    driver.Navigate().Back();

                    scenarioBrowser.NaverSearchFromSub(textBox_subTarget.Text);
                    scenarioBrowser.NaverTabMoveToBlog();

                    scenarioBrowser.NaverBlogSelect();
                    MouseMoves();
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    try
                    {
                        driver.Quit();
                        driver = null;
                    }
                    catch { }
                    try
                    {
                        //tunnelBearOnOffSwitch.SwitchToggle(); //off
                    }
                    catch { }
                }
            }, CancellationToken.None, TaskCreationOptions.None, scheduler);

            try
            {
                Task allTasks = Task.WhenAll(task);
                await allTasks;
            }
            catch (AggregateException ae)
            {
                // Assume we know what's going on with this particular exception. 
                // Rethrow anything else. AggregateException.Handle provides 
                // another way to express this. See later example. 
                foreach (var e in ae.InnerExceptions)
                {
                    throw;
                }
            }
        }

        public void MouseMoves()
        {
            Point orgPoint = Cursor.Position;
            Random r = new Random();

            for (int i = 0; i < 42; i++)
            {
                MouseMoveTo(orgPoint.X + r.Next(80), orgPoint.Y + r.Next(80));
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        public void MouseMoveTo(int offsetX, int offsetY)
        {
            PointConverter pc = new PointConverter();
            Point pt = new Point(offsetX, offsetY);
            Cursor.Position = pt;
        }

        private async void Ok_Click(object sender, EventArgs e)
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

            
            if (_desktopClient != null)
            {
                try { _desktopClient.Session.Close();  } catch { }
                _desktopClient = null;
            }

            if (_tunnelBearClient != null)
            {
                try { _tunnelBearClient.Session.Close(); } catch { }
                _tunnelBearClient = null;
            }

            try
            {
                Ok.Enabled = false;
                Stop.Enabled = true;

                if (comboBox_ipchnage.SelectedIndex == 1)
                {
                    textBox_log.Clear();
                    int count = 1;
                    while (true)
                    {
                        textBox_log.AppendText(string.Format("{0} - 작업시작(#{1})", DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"), count));
                        textBox_log.AppendText(Environment.NewLine);
                        await VpnTask("52.231.34.43", 3128);

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
                else
                {
                    TunnelBearClient tunnelBearClient = GetTunnelBearClient();
                    textBox_log.Clear();
                    int count = 1;
                    while (true)
                    {
                        textBox_log.AppendText(string.Format("{0} - 작업시작(#{1})", DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"), count));
                        textBox_log.AppendText(Environment.NewLine);
                        await VpnTask(tunnelBearClient);

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

        private string GetLocalIp()
        {
            try
            {
                string localIP = "";
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        localIP = ip.ToString();
                        break;
                    }
                }
                return localIP;
            }
            catch
            {
                return string.Empty;
            }
            
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            _isContinue = false;
            Stop.Enabled = false;
            textBox_log.AppendText("작업 종료 중...");
        }
    }
}
