using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using StbManager.CustomMessageBox;

namespace StbManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_connectStb_Click(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show(this, "正在连接机顶盒中...", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            //MyMessageBox.Show("ehlle","hee");
            
            string stbIp = tb_stbIp.Text.Trim().ToString();
            if (string.IsNullOrEmpty(stbIp)) {
                MessageBox.Show("IP不能为空,请输入", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
            }else{
                pbStatus.Visibility = Visibility.Visible;//display progressbar
                tb_pbText.Visibility = Visibility.Visible;
                btn_connectStb.IsEnabled = false;
                BackgroundWorker connectADBWork = new BackgroundWorker();
                connectADBWork.WorkerReportsProgress = true;
                connectADBWork.DoWork += connectADBWork_DoWork;
                connectADBWork.ProgressChanged += connectADBWork_ProgressChange;
                connectADBWork.RunWorkerCompleted += connectADBWork_DoWork_RunWorkerCompleted;
                connectADBWork.RunWorkerAsync(stbIp);
            }

        }

        private void connectADBWork_DoWork(object sender, DoWorkEventArgs e)
        {
            string stbIp = (string)e.Argument;
            Console.WriteLine(stbIp);
            string result = connectADB(stbIp);
            Console.WriteLine("connect result: " + result);

            if (result.Trim().Contains("already connected to"))
            {
                (sender as BackgroundWorker).ReportProgress(50);
            }
            else if (result.Trim().Contains("failed to connect"))
            {
                (sender as BackgroundWorker).ReportProgress(0);
            }
            else if (result.Trim().Contains("connected to")) {
                (sender as BackgroundWorker).ReportProgress(100);
            }
            
        }

        private void connectADBWork_ProgressChange(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine(e.ProgressPercentage);
            if (e.ProgressPercentage == 100)
            {
                MessageBox.Show(this, "连接成功               ", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (e.ProgressPercentage == 0) {   
                MessageBox.Show(this, "连接失败               ", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (e.ProgressPercentage == 50)
            {
                MessageBox.Show(this, "已连接，不用重复连接", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void connectADBWork_DoWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Console.WriteLine("cmd end"+e.Result.ToString());
            pbStatus.Visibility = Visibility.Hidden;
            tb_pbText.Visibility = Visibility.Hidden;
            btn_connectStb.IsEnabled = true;

        }

        private string connectADB(string ip) {
            string str = "adb connect " + ip;
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";//调用命令提示符
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(str + "&exit");

            p.StandardInput.AutoFlush = true;
            //p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令

            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();

            //StreamReader reader = p.StandardOutput;
            //string line=reader.ReadLine();
            //while (!reader.EndOfStream)
            //{
            //    str += line + "  ";
            //    line = reader.ReadLine();
            //}

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();
            //Console.WriteLine(output);
            return output;
        }
    }

}
