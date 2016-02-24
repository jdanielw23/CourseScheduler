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

namespace CourseSchedule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum Days { MON = 1, TUES, WED, THUR, FRI };

        public MainWindow()
        {
            InitializeComponent();
            CreateGridRows();
            CreateRowTitles();
        }

        private void CreateGridRows()
        {
            for(int i = 0; i < 52; i++)
            {
                RowDefinition row = new RowDefinition();
                MainGrid.RowDefinitions.Add(row);
            }
        }

        private void CreateRowTitles()
        {
            int hour = 8;
            for(int i = 1; i < 52; i+=4)
            {
                TextBlock txtBlock = new TextBlock();
                txtBlock.Text = hour.ToString() + ":00";
                txtBlock.FontSize = 10;
                txtBlock.HorizontalAlignment = HorizontalAlignment.Right;
                Grid.SetRow(txtBlock, i);
                MainGrid.Children.Add(txtBlock);
                hour = (hour += 1) % 12;
                if (hour == 0)
                    hour = 12;
            }
        }

        private void AddCourse(Course c)
        {
            TextBlock txtBlock = new TextBlock();
            txtBlock.Text = c.
        }
    }
}
