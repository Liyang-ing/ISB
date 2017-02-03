using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WatiN.Core;
using WatiN.Core.Native.Windows;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;

namespace Helo
{
    public partial class Form1 : System.Windows.Forms.Form
    {

        private Process _browserProcess;
        private IE _browser;
        private IE browser
        {
            get 
            {
                //瀏覽器執行個體還在
                if (_browser != null && !_browserProcess.HasExited)
                {
                    try
                    {
                        //測試Browser是否可使用
                        IntPtr tmp = _browser.hWnd;
                    }
                    catch
                    {
                        _browser = null;
                        _browserProcess = null;
                    }
                }
                //如果執行個體不在
                if (_browser == null || _browserProcess == null || _browserProcess.HasExited)
                {
                    var FindIE = Find.ByUrl(new Regex(@"http://www.emome.net/"));
                    //開一個新的IE
                    if (IE.Exists<IE>(FindIE))
                        _browser = IE.AttachTo<IE>(FindIE);
                    else
                        _browser = new IE();
                    _browserProcess = Process.GetProcessById(_browser.ProcessID);
                }
                return _browser;
            }
        }
        int h;
        int i;
        int j;
        int k;
        int m;
        int numlo;
        int hey;
        int word;
        string number;

        public Form1()
        {
            //初始化控制項
            InitializeComponent();
            //設定等待網頁時間不超過10秒
            Settings.WaitForCompleteTimeOut = 30;
            Settings.WaitUntilExistsTimeOut = 30;
            //避免執行緒受影響
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
            btnSend.Enabled = false;
            //btnSendBack.Enabled = false;
            
            //將讀取到的PORT放到選單中
            string[] ports = SerialPort.GetPortNames();

            for (int i = 0; i < ports.Length; i++)
            {
                txtCom.Text = ports[i].ToString();
                comboBox1.Items.Add(txtCom.Text);
            }
            try
            {
                comboBox1.SelectedIndex = 1;
            }
            catch
            {
                
            }

        }
        
        //將字串淨空
        private static string RxString = "";


        //按鈕按下開始查詢網內外
        public void btnGo_Click(object sender, EventArgs e)
        {
            label7.Text = "";
            lblResult2.Text = "等待中...";
            //找尋最大id的指令
            string a = "select * from tel where id=(select max(id) from tel)";
            //與資料庫連線
            String connString1 = "Server=localhost;Port=3306;Database=data;uid=root;password=288266;";
            MySqlConnection conn1 = new MySqlConnection(connString1);
            MySqlCommand command1 = conn1.CreateCommand();
            command1.CommandText = a.ToString();

            try
            {
                conn1.Open();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                j = (int)reader1["id"];
                txtMaxId.Text = j.ToString();
            }
            conn1.Close();

            progressBar2.Maximum = j*2;
            progressBar2.Value = 0;
            progressBar2.Step = 1;

            MessageBox.Show("程式開始，會關閉目前所有IE網頁，請準備好再按確定","注意!");
            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcesses();

            //關閉所有的IE
            foreach (System.Diagnostics.Process myProcess in myProcesses)
            {
                if (myProcess.ProcessName.ToUpper() == "IEXPLORE")
                {
                    myProcess.Kill();
                }
            }
            
            
            //輸入網頁帳號密碼
            try
            {
                //將IE隱藏起來
                //browser.ShowWindow(NativeMethods.WindowShowStyle.Hide);
                browser.GoTo("http://www.emome.net/");
                browser.WaitForComplete();
                browser.Image(Find.ByAlt("登入")).Click();
                browser.TextField(Find.ById("uid")).TypeText("0920625964");
                browser.TextField(Find.ById("pw")).TypeText("288266");
                browser.Image(Find.ByAlt("登入會員")).Click();
                browser.WaitForComplete();
                //到網內外判斷網站，開始辨別網內外
                browser.GoTo("http://auth.emome.net/emome/membersvc/AuthServlet?serviceId=mobilebms&url=qryTelnum.jsp");
                browser.WaitForComplete();
            }

            catch
            {
                MessageBox.Show("網頁異常，請稍後再試!");
            }
            
            

            //藉由"id"欄位取得資料庫內的號碼
            for (i = 1; i <= j; i++)
            {
                progressBar2.Value += progressBar2.Step;
                string getting = "Select number from tel where id = "+i+"";
                String connString = "Server=localhost;Port=3306;Database=data;uid=root;password=288266;";
                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = getting.ToString();
                txtId.Text = i.ToString();

                try
                {
                    conn.Open();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtNumber.Text = reader["number"].ToString();
                    
                }

                //判斷是否還有需要辨別的號碼
                if (txtNumber.Text != "Finding...")
                {
                    browser.TextField(Find.ById("telnum")).TypeText(txtNumber.Text.Trim());
                    browser.Button(Find.ById("btn_submit")).Click();
                    conn.Close();
                    browser.WaitForComplete();

                    try
                    {
                        string myHtml = browser.Body.Parent.OuterHtml;
                        string result = myHtml;
                        int first = result.IndexOf("您所查詢之行動門號");
                        int last = result.LastIndexOf("為「");
                        string cut1 = result.Substring(first + 21, last - first - 17);
                        if (cut1 == "網內")
                        {
                            txtResult.Text = txtNumber.Text + "  此號碼為中華電信";
                            string b = "Update tel SET ope='c' WHERE id='" + i + "'";
                            String connString2 = "Server=localhost;Port=3306;Database=data;uid=root;password=288266;";
                            MySqlConnection conn2 = new MySqlConnection(connString2);
                            MySqlCommand command2 = conn2.CreateCommand();
                            command2.CommandText = b.ToString();

                            try
                            {
                                conn2.Open();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            MySqlDataReader reader2 = command2.ExecuteReader();
                            while (reader2.Read())
                            {
                                ;
                            }
                            conn2.Close();

                        }
                        else
                        {
                            txtResult.Text = txtNumber.Text + "  此號碼並不是中華電信";
                            string b = "Update tel SET ope='n' WHERE id='" + i + "'";
                            String connString2 = "Server=localhost;Port=3306;Database=data;uid=root;password=288266;";
                            MySqlConnection conn2 = new MySqlConnection(connString2);
                            MySqlCommand command2 = conn2.CreateCommand();
                            command2.CommandText = b.ToString();

                            try
                            {
                                conn2.Open();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            MySqlDataReader reader2 = command2.ExecuteReader();
                            while (reader2.Read())
                            {
                                ;
                            }
                            conn2.Close();
                        }
                    }
                    catch
                    {
                        //MessageBox.Show(ex.Message);
                    }
                    txtNumber.Text = "中華電信判斷結束";
                    
                }
            }
            if (txtNumber.Text == "中華電信判斷結束")
            {
                browser.GoTo("http://www.fetnet.net/ecare/eService/web/public/forwardController.do?forwardPage=ucs/queryNetworkType/esqnt01&csType=cs");
                browser.WaitForComplete();
                for (int aj = 1; aj <= j; aj++)
                {
                    progressBar2.Value += progressBar2.Step;
                    string getting = "Select ope from tel where id = " + aj + "";
                    String connString = "Server=localhost;Port=3306;Database=data;uid=root;password=288266;";
                    MySqlConnection conn = new MySqlConnection(connString);
                    MySqlCommand command = conn.CreateCommand();
                    command.CommandText = getting.ToString();
                    txtId.Text = aj.ToString();

                    try
                    {
                        conn.Open();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        txtOpe.Text = reader["ope"].ToString();
                        
                    }
                    conn.Close();
                    
                    if (txtOpe.Text == "n")
                    {
                        string getnum = "Select number from tel where id = " + aj + "";
                        String connString3 = "Server=localhost;Port=3306;Database=data;uid=root;password=288266;";
                        MySqlConnection conn3 = new MySqlConnection(connString3);
                        MySqlCommand command3 = conn3.CreateCommand();
                        command3.CommandText = getnum.ToString();

                        try
                        {
                            conn3.Open();
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


                        MySqlDataReader reader3 = command3.ExecuteReader();
                        while (reader3.Read())
                        {
                            txtNumber.Text = reader3["number"].ToString();

                        }

                        try
                        {
                            browser.TextField("msisdn").TypeText(txtNumber.Text);
                            browser.Button(Find.ById("queryButton")).Click();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        try
                        {
                            string myHtml2 = browser.Body.Parent.OuterHtml;
                            string result2 = myHtml2;
                            int first2 = result2.IndexOf("「<font color=");
                            int last2 = result2.LastIndexOf("</font>」門號");
                            string cut2 = result2.Substring(first2 + 19, last2 - first2 - 19);
                            if (cut2 == "網內")
                            {
                                txtResult.Text = txtNumber.Text + "  此號碼為遠傳電信";
                                string b = "Update tel SET ope='f' WHERE id='" + aj + "'";
                                String connString2 = "Server=localhost;Port=3306;Database=data;uid=root;password=288266;";
                                MySqlConnection conn2 = new MySqlConnection(connString2);
                                MySqlCommand command2 = conn2.CreateCommand();
                                command2.CommandText = b.ToString();

                                try
                                {
                                    conn2.Open();
                                }

                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                MySqlDataReader reader2 = command2.ExecuteReader();
                                while (reader2.Read())
                                {
                                    ;
                                }
                                conn2.Close();

                            }
                            else
                            {
                                txtResult.Text = txtNumber.Text + "  此號碼並不是遠傳電信";
                                string b = "Update tel SET ope='n' WHERE id='" + aj + "'";
                                String connString2 = "Server=localhost;Port=3306;Database=data;uid=root;password=288266;";
                                MySqlConnection conn2 = new MySqlConnection(connString2);
                                MySqlCommand command2 = conn2.CreateCommand();
                                command2.CommandText = b.ToString();

                                try
                                {
                                    conn2.Open();
                                }

                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                MySqlDataReader reader2 = command2.ExecuteReader();
                                while (reader2.Read())
                                {
                                    ;
                                }
                                conn2.Close();
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    } 
                }
            }
            browser.Close();
            txtNumber.Text = "號碼已查詢完畢";
            btnGo.Enabled = false;
            lblResult2.Text = "成功!";
            btnSendBack.Enabled = true;
        }

        //初始化RS232
        private void btnInit_Click(object sender, EventArgs e)
        {
            
            try
            {
                serialPort.PortName = comboBox1.Text;
                if (!serialPort.IsOpen)
                {
                    serialPort.Open();
                    btnInit.Enabled = false;
                    //傳送 "S" 表示開始接收資料
                    serialPort.Write("s");
                    Thread.Sleep(100); //Delay 0.1秒
                }
            }

            catch 
            {
                MessageBox.Show("請選擇正確的端口，並確認端口是否正確");
            }
            
            //再次尋找最大的id值,避免混在一起
            string a = "select * from tel where id=(select max(id) from tel)";
            String connString1 = "Server=localhost;Port=3306;Database=data;uid=root;password=288266;";
            MySqlConnection conn1 = new MySqlConnection(connString1);
            MySqlCommand command1 = conn1.CreateCommand();
            command1.CommandText = a.ToString();

            try
            {
                conn1.Open();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                h = (int)reader1["id"];
                h = h + 1;
            }
            conn1.Close();
            
            if (txtRead.Text == null)
            {
                MessageBox.Show("傳輸異常，目前無資料輸入","警告");
                serialPort.Close();
                btnInit.Enabled = true;
            }
            else
            {
             
                btnSend.Enabled = true;
            }

            
            
        }


        private void serialPortRead_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                RxString = serialPort.ReadExisting();
                this.Invoke(new EventHandler(DisplayText));
            }
            catch (System.TimeoutException)
            {
            }
        }

        private void DisplayText(object s, EventArgs e)
        {
            txtRead.AppendText(RxString);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            lblResult1.Text = "等待中...";
            int a = 0;
            int HowMuchLong;

            string length = txtRead.Text.Trim();
            if (txtRead.Text != "")
            {
                HowMuchLong = length.Length;
                HowMuchLong = HowMuchLong / 11;
                progressBar1.Maximum = HowMuchLong;//設置最大長度值
                progressBar1.Value = 0;//設置當前值
                progressBar1.Step = 1;//設置每次增長多少
                for (int abc = 0; abc < HowMuchLong; abc++)
                {
                    //取得來源字串
                    string SRC = txtRead.Text.Trim();
                    //將取得的字串 轉換成陣列
                    char[] ArraySRC = SRC.ToCharArray();
                    //使用迴圈取出該陣列的元素 逐一加到結果輸出
                    for (int k = a; k < 10 + a; k++)
                    {
                        txtCatched.Text = txtCatched.Text + ArraySRC[k].ToString();
                    }
                    progressBar1.Value += progressBar1.Step;

                    for (i = 0; i < h; i++)
                    {
                        hey = 0;
                        string catched = "Select number from tel where id = " + i + "";
                        String connString2 = "Server=localhost;Port=3306;Database=data;uid=root;password=288266;";
                        MySqlConnection conn2 = new MySqlConnection(connString2);
                        MySqlCommand command2 = conn2.CreateCommand();
                        command2.CommandText = catched.ToString();
                        try
                        {
                            conn2.Open();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        MySqlDataReader reader = command2.ExecuteReader();
                        while (reader.Read())
                        {
                            txtRightNumber.Text = reader["number"].ToString();
                        }
                        if (txtRightNumber.Text == txtCatched.Text)
                        {
                            hey = 1;
                            break;
                        }
                    }

                    if (hey != 1)
                        check();
                    txtCatched.Text = "";
                    a += 11;
                    if (abc + 1 == HowMuchLong)
                    {
                        lblResult1.Text = "成功!";
                        btnSend.Enabled = false;
                    }
                }

            }
            else
            {
                lblResult1.Text = "無號碼";
                btnSend.Enabled = false;
            }
        }

        //函式check()將電話號碼輸入進資料庫
        private void check()
        {
            string getting = "INSERT INTO tel (number,ope) VALUES ('" + txtCatched.Text + "', 'n');";
            String connString = "Server=localhost;Port=3306;Database=data;uid=root;password=288266;";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = getting.ToString();
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort.Close();
        }

        private void btnSendBack_Click(object sender, EventArgs e)
        {
            txtRead.Text = "";
            Thread.Sleep(100); //Delay 0.1秒
            lblResult3.Text = "等待中...";
            //第三次尋找最大的id值,避免與前兩次混在一起
            string a = "select * from tel where id=(select max(id) from tel)";
            String connString1 = "Server=localhost;Port=3306;Database=data;uid=root;password=288266;";
            MySqlConnection conn1 = new MySqlConnection(connString1);
            MySqlCommand command1 = conn1.CreateCommand();
            command1.CommandText = a.ToString();

            try
            {
                conn1.Open();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                k = (int)reader1["id"];
                m = k;
                k = k + 1;
            }
            conn1.Close();
            for (int i = 1; i < k; i++)
            {
                string gettingnumber = "Select number from tel where id = " + i + "";
                String connString = "Server=localhost;Port=3306;Database=data;uid=root;password=288266;";
                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = gettingnumber.ToString();

                try
                {
                    conn.Open();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtRead.Text = txtRead.Text + reader["number"].ToString();

                }
                conn.Close();

                string gettingope = "Select ope from tel where id = " + i + "";
                String connString5 = "Server=localhost;Port=3306;Database=data;uid=root;password=288266;";
                MySqlConnection conn5 = new MySqlConnection(connString5);
                MySqlCommand command5 = conn5.CreateCommand();
                command5.CommandText = gettingope.ToString();

                try
                {
                    conn5.Open();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MySqlDataReader reader5 = command5.ExecuteReader();
                while (reader5.Read())
                {
                    txtRead.Text = txtRead.Text + reader5["ope"].ToString();
                }
                conn5.Close();
                btnSendBack.Enabled = false;
            }
            numlo = txtRead.Text.Length;
            m = numlo/11;
            progressBar3.Maximum = numlo+1;
            progressBar3.Step = 1;
            progressBar3.Value = 1;
            word = 0;
            try
            {
                //傳送"b"讓8051開始接收資料
                serialPort.Write("b");
                Thread.Sleep(100); //Delay 0.1秒
                /*
                if (m < 10)
                {
                    serialPort.Write("0" + m.ToString());
                }
                else
                {
                    serialPort.Write(m.ToString());
                }
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " 請連接好再試！", "錯誤");
                word = 1;
            }
            if (word == 0)
            {
                for (int i = 0; i < numlo; i++)
                {
                    //將視窗內字串變為單一字元傳送
                    number = txtRead.Text[i].ToString();
                    try
                    {
                        serialPort.Write(number);
                        Thread.Sleep(100); //Delay 0.1秒
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        word = 1;
                    }
                    progressBar3.Value += progressBar3.Step;
                }
                lblResult3.Text = "成功!";
                //傳送"E"代表全部號碼傳輸完畢
                serialPort.Write("E");
            }
            else
                lblResult3.Text = "錯誤!";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort.Write(txtRead.Text);
        }

    }
}
