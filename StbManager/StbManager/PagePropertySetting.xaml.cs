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
            propertiesList.Add(new PropertyEntity { Name = "a", Value = "b", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "b", Value = "f", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "c", Value = "f", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "d", Value = "g", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            propertiesList.Add(new PropertyEntity { Name = "e", Value = "bl", CanModify = true });
            lv_propertyInfo.ItemsSource = propertiesList;

        }

        private void Lv_propertyInfo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PropertyEntity book = ((ListViewItem)sender).Content as PropertyEntity;
            Console.WriteLine(book.Name);
        }
    }

    public class PropertyEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool CanModify { get; set; }
    }
}
