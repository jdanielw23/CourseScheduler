using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CourseSchedule
{
    class Course
    {
        public enum Day { Mon = 1, Tues, Wed, Thur, Fri };

        public string Name;
        public string CourseCode;
        public ArrayList MeetDays;
        public float StartTime;
        public float EndTime;
        public SolidColorBrush Color;

        public Course()
        {
            MeetDays = new ArrayList();
        }
    }
}
