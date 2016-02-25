using System;
using System.Collections;
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
        public MainWindow()
        {
            InitializeComponent();
            CreateGridRows();
            CreateRowTitles();
            
            ArrayList courses = CreateCourses();
            
            foreach(Course c in courses)
            {
                AddCourseToGrid(c);
            }
        }

        private ArrayList CreateCourses()
        {
            ArrayList courses = new ArrayList();

            Course capstone = new Course()
            {
                Name = "Capstone Design",
                CourseCode = "EGR 401",
                StartTime = 17.0f,
                EndTime = 20.0f,
                Color = Brushes.SkyBlue
            };
            capstone.MeetDays.Add(Course.Day.Mon);
            courses.Add(capstone);

            Course report = new Course()
            {
                Name = "Internship Report",
                CourseCode = "EGR 405",
                StartTime = 15.75f,
                EndTime = 16.75f,
                Color = Brushes.CornflowerBlue
            };
            report.MeetDays.Add(Course.Day.Wed);
            courses.Add(report);

            Course swProjMan = new Course()
            {
                Name = "Software Project Management",
                CourseCode = "EGR 427",
                StartTime = 10.5f,
                EndTime = 12.0f,
                Color = Brushes.LightBlue
            };
            swProjMan.MeetDays.Add(Course.Day.Tues);
            swProjMan.MeetDays.Add(Course.Day.Thur);
            courses.Add(swProjMan);

            Course mobileAppDev = new Course()
            {
                Name = "Mobile Application Development",
                CourseCode = "EGR 423",
                StartTime = 9.5f,
                EndTime = 10.5f,
                Color = Brushes.LightCyan
            };
            mobileAppDev.MeetDays.Add(Course.Day.Mon);
            mobileAppDev.MeetDays.Add(Course.Day.Wed);
            mobileAppDev.MeetDays.Add(Course.Day.Fri);
            courses.Add(mobileAppDev);

            Course infoSec = new Course()
            {
                Name = "Information Security",
                CourseCode = "CSC 413",
                StartTime = 8.25f,
                EndTime = 9.25f,
                Color = Brushes.LightSteelBlue
            };
            infoSec.MeetDays.Add(Course.Day.Mon);
            infoSec.MeetDays.Add(Course.Day.Wed);
            infoSec.MeetDays.Add(Course.Day.Fri);
            courses.Add(infoSec);

            Course marketStrat = new Course()
            {
                Name = "Marketplace Strategy for Global Advancement",
                CourseCode = "ICS 405",
                StartTime = 8.75f,
                EndTime = 10.25f,
                Color = Brushes.LightSkyBlue
            };
            marketStrat.MeetDays.Add(Course.Day.Tues);
            marketStrat.MeetDays.Add(Course.Day.Thur);
            courses.Add(marketStrat);

            return courses;
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
                txtBlock.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(txtBlock, i);
                MainGrid.Children.Add(txtBlock);
                hour = (hour += 1) % 12;
                if (hour == 0)
                    hour = 12;
            }
        }

        private void AddCourseToGrid(Course c)
        {
            foreach (Course.Day day in c.MeetDays)
            {
                TextBlock txtBlock = new TextBlock();
                string startTime = TimeSpan.FromHours(c.StartTime).ToString("h\\:mm");
                string endTime = TimeSpan.FromHours(c.EndTime).ToString("h\\:mm");
                txtBlock.Text = startTime + " - " + endTime + "\n" + c.Name + "\n" + c.CourseCode;
                txtBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
                txtBlock.VerticalAlignment = VerticalAlignment.Stretch;
                txtBlock.TextAlignment = TextAlignment.Center;
                txtBlock.FontSize = 12;
                txtBlock.TextWrapping = TextWrapping.Wrap;
                txtBlock.Background = c.Color;

                int numRows = (int) ((c.EndTime - c.StartTime) * 4);
                int startRow = (int) ((c.StartTime - 8) * 4 + 1);

                Grid.SetRowSpan(txtBlock, numRows);
                Grid.SetRow(txtBlock, startRow);
                Grid.SetColumn(txtBlock, (int)day);

                MainGrid.Children.Add(txtBlock);
            }
        }
    }
}
