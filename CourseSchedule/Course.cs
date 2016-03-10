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
        private string name;
        private string courseCode;
        private ArrayList meetTimes;
        
        public ArrayList MeetTimes
        {
            get
            {
                return meetTimes;
            }
        }

        public Course(string code, string n)
        {
            meetTimes = new ArrayList();
            courseCode = code;
            name = n;
        }

        public void AddMeetTime(MeetTime.Day d, int startHour, int startMinute, float duration)
        {
            meetTimes.Add(new MeetTime(d, startHour, startMinute, duration));
        }

        public void AddMeetTime(ArrayList days, int startHour, int startMinute, float duration)
        {
            meetTimes.Add(new MeetTime(days, startHour, startMinute, duration));
        }

        override
        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(courseCode);
            sb.AppendLine(name);
            foreach(MeetTime t in meetTimes)
            {
                sb.AppendLine(t.ToString());
            }

            return sb.ToString();
        }
    }
}
