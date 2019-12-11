using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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


        public VpnMacro()
        {
            InitializeComponent();
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

        private void VpnTask(TunnelBearClient tunnelBearClient)
        {
            // 스위치 온
            TunnelBearSwitch tunnelBearOnOffSwitch = new TunnelBearSwitch(tunnelBearClient);
            tunnelBearOnOffSwitch.SwitchToggle(); //On
            Thread.Sleep(TimeSpan.FromSeconds(6));

            var driver = BrowserDriver.CreateBrowserDriver(_browserType);
            ScenarioBrowser scenarioBrowser = new ScenarioBrowser(driver);

            //로그인
            scenarioBrowser.NaverLogin(textBox_id.Text, textBox_pw.Text);
            Thread.Sleep(TimeSpan.FromSeconds(5));

            //전화번호 입력
            //scenarioBrowser.NaverLoginPhoneNumber(textBox_phoneNumber.Text);
            //Thread.Sleep(TimeSpan.FromSeconds(2));

            scenarioBrowser.NaverSearchFromMain(textBox_mainTarget.Text);
            Thread.Sleep(TimeSpan.FromSeconds(5));

            scenarioBrowser.NaverTabMoveToBlog();
            Thread.Sleep(TimeSpan.FromSeconds(5));

            scenarioBrowser.NaverBlogSelect();
            Thread.Sleep(TimeSpan.FromSeconds(42));

            //뒤로가기
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            driver.Navigate().Back();
            Thread.Sleep(TimeSpan.FromSeconds(5));

            scenarioBrowser.NaverSearchFromSub(textBox_subTarget.Text);
            Thread.Sleep(TimeSpan.FromSeconds(5));

            scenarioBrowser.NaverTabMoveToBlog();
            Thread.Sleep(TimeSpan.FromSeconds(5));

            scenarioBrowser.NaverBlogSelect();
            Thread.Sleep(TimeSpan.FromSeconds(42));

            driver.Quit();
            driver = null;

            tunnelBearOnOffSwitch.SwitchToggle(); //Off   
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
                TunnelBearClient tunnelBearClient = GetTunnelBearClient();
                int count = Int32.Parse(textBox_iterationCount.Text);
                for (int i=0; i<count;i++)
                {
                    VpnTask(tunnelBearClient);

                    //대기시간
                    int waitTime = Int32.Parse(textBox_waitTime.Text);
                    Thread.Sleep(TimeSpan.FromMinutes(waitTime));
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
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
    }
}
