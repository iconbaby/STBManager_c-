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
using System.IO;

namespace StbManager
{
    /// <summary>
    /// Interaction logic for PagePropertySetting.xaml
    /// </summary>
    public partial class PagePropertySetting : Page
    {
        private List<PropertyEntity> propertiesList = new List<PropertyEntity>();
        public PagePropertySetting()
        {
            InitializeComponent();
            Console.WriteLine("init");

            getStbProperties();
            lv_propertyInfo.ItemsSource = propertiesList;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(tb_search.Text))
                return true;
            else
                return ((item as PropertyEntity).Name.IndexOf(tb_search.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lv_propertyInfo.ItemsSource).Refresh();
        }


        private void getStbProperties()
        {
            BackgroundWorker connectADBWork = new BackgroundWorker();
            connectADBWork.WorkerReportsProgress = true;
            connectADBWork.DoWork += getStbProperties_DoWork;
            connectADBWork.ProgressChanged += getStbProperties_ProgressChange;
            connectADBWork.RunWorkerCompleted += getStbProperties_RunWorkerCompleted;
            connectADBWork.RunWorkerAsync();
        }

        private void getStbProperties_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lv_propertyInfo.ItemsSource);
            view.Filter = UserFilter;
        }

        private void getStbProperties_DoWork(object sender, DoWorkEventArgs e)
        {
            string allString = getStbPropertiesFromADB().Trim();
            int index = allString.IndexOf("adb shell getprop&exit");
            string allPropertyString = allString.Substring(index + 22);
            //Console.Write(allPropertyString);
            string[] listPropertiesArray = allPropertyString.Split(Environment.NewLine.ToCharArray());
            Console.WriteLine(listPropertiesArray.Length);
            foreach (string propertyLine in listPropertiesArray)
            {
                if (!string.IsNullOrEmpty(propertyLine))
                {
                    Console.WriteLine("++++++++++++++++++++++++++");
                    int colonIndex = propertyLine.IndexOf(":");
                    string key = propertyLine.Substring(1, colonIndex - 2);
                    string value = propertyLine.Substring(colonIndex + 3,propertyLine.Length-colonIndex-4);
                    propertiesList.Add(new PropertyEntity { Name = key, Value = value, CanModify = true });
                    Console.WriteLine(key);
                    Console.WriteLine(value);
                    Console.WriteLine("++++++++++++++++++++++++++");
                }

            }

            propertiesList.Add(new PropertyEntity { Name = "ffff", Value = "b", CanModify = true });


        }

        private void getStbProperties_ProgressChange(object sender, ProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

     

        private void Lv_propertyInfo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PropertyEntity propertyEntity = ((ListViewItem)sender).Content as PropertyEntity;
            Console.WriteLine(propertyEntity.Name);
            MessageBox.Show("更改", "修改属性", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private string getStbPropertiesFromADB()
        {
            Console.WriteLine("getStbPropertiesFromADB");
            string str = "adb shell getprop";
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
            //Console.WriteLine(output);

            //StreamReader reader = p.StandardOutput;
            //string line = reader.ReadLine();
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

    public class PropertyEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool CanModify { get; set; }
    }


}
