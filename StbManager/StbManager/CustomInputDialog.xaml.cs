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
using System.Windows.Shapes;

namespace StbManager
{
    /// <summary>
    /// Interaction logic for CustomInputDialog.xaml
    /// </summary>
    public partial class CustomInputDialog : Window
    {
        public CustomInputDialog(string question, string defalutAnswer ="")
        {
            InitializeComponent();
            lbCustomDialogTitle.Content = question;
            tbCustomDialogContent.Text = defalutAnswer;
        }

        private void BtnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            tbCustomDialogContent.SelectAll();
            tbCustomDialogContent.Focus();
        }

        public string Value
        {
            get { return tbCustomDialogContent.Text; }
        }
    }
}
