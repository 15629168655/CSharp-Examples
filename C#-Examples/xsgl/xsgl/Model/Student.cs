using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xsgl.Model
{
    public class Student
    {
        public string StudNo { get; set; }
        public string StudName { get; set; }
        public char StudSex { get; set; }
        public DateTime StudBirthDate { get; set; }
        public string StudMajor { get; set; }
        public bool StudIsMember { get; set; }
        public byte[] StudPic { get; set; }
    }
}
