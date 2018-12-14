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
            
            MessageBox.Show(this, "正在连接机顶盒中...", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            connectADB();
            //BackgroundWorker connectADBWork = new  BackgroundWorker();
            //connectADBWork.WorkerReportsProgress = true;
            //connectADBWork.DoWork += connectADBWork_DoWork;
            //connectADBWork.ProgressChanged += connectADBWork_ProgressChange;
            //connectADBWork.RunWorkerCompleted += connectADBWork_DoWork_RunWorkerCompleted;
            //connectADBWork.RunWorkerAsync();
        }

        private void connectADBWork_DoWork(object sender, DoWorkEventArgs e)
        {
            
            connectADB();
        }

        private void connectADBWork_ProgressChange(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void connectADBWork_DoWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("cmd end");
            
        }

        private void connectADB() {
            string str = "ipconfig";
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
            Console.WriteLine(output);
        }
    }

}
