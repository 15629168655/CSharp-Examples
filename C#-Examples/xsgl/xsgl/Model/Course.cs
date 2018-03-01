using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xsgl.Model
{
    public class Course
    {
        private int _courseNo;
        private string _courseName;
        public int CourseNo {
            get { return _courseNo; }
            set { _courseNo = value; }
        }
        public string courseName {
            get { return _courseName; }
            set { _courseName = value; }
        }
    }
}
