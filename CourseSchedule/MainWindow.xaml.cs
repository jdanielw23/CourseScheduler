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
        const int DAY_START = 7;
        const int DAY_HOURS = 14;
        ArrayList courses;

        public MainWindow()
        {
            InitializeComponent();
            CreateGridRows();
            CreateRowTitles();

            courses = CreateCourses();
            
            foreach(Course c in courses)
            {
                AddCourseToGrid(c);
            }            
        }

        private ArrayList CreateCourses()
        {
            ArrayList MWF = new ArrayList();
            MWF.Add(MeetTime.Day.Mon);
            MWF.Add(MeetTime.Day.Wed);
            MWF.Add(MeetTime.Day.Fri);

            ArrayList TR = new ArrayList();
            TR.Add(MeetTime.Day.Tues);
            TR.Add(MeetTime.Day.Thur);

            ArrayList courses = new ArrayList();

            Course capstone = new Course("EGR 401", "Capstone Design");
            capstone.AddMeetTime(MeetTime.Day.Mon, 17, 0, 3f);
            courses.Add(capstone);

            Course report = new Course("EGR 405", "Internship Report");
            report.AddMeetTime(MeetTime.Day.Wed, 17,0,1f);
            courses.Add(report);

            Course swProjMan = new Course("EGR 427", "Software Project Management");
            swProjMan.AddMeetTime(TR, 10, 30, 1.5f);
            courses.Add(swProjMan);

            Course mobileAppDev = new Course("EGR 423", "Mobile Application Development");
            mobileAppDev.AddMeetTime(MWF, 9, 30, 1f);
            courses.Add(mobileAppDev);

            Course infoSec = new Course("CSC 413", "Information Security");
            infoSec.AddMeetTime(MWF, 8, 15, 1f);
            courses.Add(infoSec);

            Course chem = new Course("CHE 115", "Chemistry");
            chem.AddMeetTime(MWF, 10, 45, 1f);
            chem.AddMeetTime(MeetTime.Day.Tues, 7, 30, 2.75f);
            courses.Add(chem);
            
            return courses;
        }

        private void CreateGridRows()
        {
            for(int i = 0; i < DAY_HOURS * 4; i++)
            {
                RowDefinition row = new RowDefinition();
                MainGrid.RowDefinitions.Add(row);
            }
        }

        private void CreateRowTitles()
        {
            int hour = DAY_START;
            for(int i = 1; i < DAY_HOURS * 4; i+=4)
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
            foreach (MeetTime t in c.MeetTimes)
            {
                foreach (MeetTime.Day day in t.MeetDays)
                {
                    TextBlock txtBlock = new TextBlock();
                    txtBlock.Text = c.ToString();
                    txtBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
                    txtBlock.VerticalAlignment = VerticalAlignment.Stretch;
                    txtBlock.TextAlignment = TextAlignment.Center;
                    txtBlock.FontSize = 12;
                    txtBlock.TextWrapping = TextWrapping.Wrap;
                    txtBlock.Background = Brushes.LightCyan;

                    int numRows = (int)((t.GetDuration()) * 4);
                    int startRow = (int)((t.StartTime.GetDecimalValue() - DAY_START) * 4 + 1);

                    Grid.SetRowSpan(txtBlock, numRows);
                    Grid.SetRow(txtBlock, startRow);
                    Grid.SetColumn(txtBlock, (int)day);

                    MainGrid.Children.Add(txtBlock);
                }                
            }
        }
    }
}
