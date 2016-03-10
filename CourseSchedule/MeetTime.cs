using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule
{
    class MeetTime
    {
        public enum Day { Mon = 1, Tues, Wed, Thur, Fri };

        private ArrayList meetDays;
        private Time startTime;
        private Time endTime;

        public ArrayList MeetDays
        {
            get
            {
                return meetDays;
            }
        }
        public Time StartTime
        {
            get
            {
                return startTime;
            }
        }
        public Time EndTime
        {
            get
            {
                return endTime;
            }
        }


        public MeetTime()
        {
            meetDays = new ArrayList();
            startTime = new Time(8);
            endTime = new Time(9);
        }

        public MeetTime(Day d, int startHour, int startMinute, float duration)
        {
            meetDays = new ArrayList();
            meetDays.Add(d);
            startTime = new Time(startHour, startMinute);
            if (duration > 0)
                endTime = new Time(startTime.GetDecimalValue() + duration);
            else
                endTime = new Time(startTime.GetDecimalValue() + 1);
        }

        public MeetTime(ArrayList days, int startHour, int startMinute, float duration)
        {
            meetDays = new ArrayList(days);
            startTime = new Time(startHour, startMinute);
            if (duration > 0f)
                endTime = new Time(startTime.GetDecimalValue() + duration);
            else
                endTime = new Time(startTime.GetDecimalValue() + 1);
        }

        public float GetDuration()
        {
            return (endTime.GetDecimalValue() - startTime.GetDecimalValue());
        }

        public void AddMeetDay(Day d)
        {
            meetDays.Add(d);
        }

        override
        public string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Day d in meetDays)
            {
                switch (d)
                {
                    case Day.Mon: sb.Append("M"); break;
                    case Day.Tues: sb.Append("T"); break;
                    case Day.Wed: sb.Append("W"); break;
                    case Day.Thur: sb.Append("R"); break;
                    case Day.Fri: sb.Append("F"); break;
                    default: break;
                }
            }
            sb.Append("\t" + startTime + " - " + endTime);

            return sb.ToString();
        }
    }

    class Time
    {
        private int hour, minute;

        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                if (value >= 0 && value <= 24)
                    hour = value;
            }
        }

        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                if (value >= 0 && value <= 60)
                    minute = value;
            }
        }

        public Time(int h)
        {
            hour = h;
            minute = 0;
        }

        public Time(int h, int m)
        {
            hour = h;
            minute = m;
        }

        public Time(float decTime)
        {
            hour = (int)decTime;
            minute = (int) ((decTime - (float)hour) * 60);
        }

        public float GetDecimalValue()
        {
            float result = (float)hour + (float)( (float)minute / 60f);
            return result;
        }

        override
        public string ToString()
        {
            string sHour = hour.ToString();
            string sMinute = minute.ToString();
            if (hour > 12)
                sHour = (hour - 12).ToString();
            if (minute < 10)
                sMinute = "0" + minute.ToString();

            return sHour + ":" + sMinute;
        }
    }
}
