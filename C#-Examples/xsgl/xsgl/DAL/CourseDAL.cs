using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using xsgl.Model;


namespace xsgl.DAL
{
    public class CourseDAL
    {
        public int addCourse(Course course) {
            string sql = String.Format("insert into xsgl_course(course_name) values ('{0}')", course.courseName);
            return SqlHelper.ExecuteNonQuery(sql);
        }
        public int editCourse(Course course) {
            string sql = String.Format("update xsgl_course set course_name='{0}' where course_no={1}", course.courseName, course.CourseNo);
            return SqlHelper.ExecuteNonQuery(sql);
        }
        public int deleteCourse(int courseNo) {
            string sql = String.Format("delete from xsgl_course where course_no={0}", courseNo);
            return SqlHelper.ExecuteNonQuery(sql);
        }
        public Course findCourse(int courseNo) {
            Course course = null;
            string sql = String.Format("select * from xsgl_course where course_no={0}", courseNo);
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
            if (sdr.Read()) {
                course = new Course();
                course.CourseNo = sdr.GetInt32(0);
                course.courseName = sdr.GetString(1);
            }
            sdr.Close();
            return course;
        }
        public IList<Course> findCourses() {
            IList<Course> list = new List<Course>();
            string sql = "select * from xsgl_course";
            DataTable dt = SqlHelper.ExecuteQuery(sql);
            if (dt!=null) {
                Course course = null;
                foreach (DataRow row in dt.Rows) {
                    course = new Course();
                    course.CourseNo = (int)row[0];
                    course.courseName = row[1].ToString();
                    list.Add(course);
                }
            }
            return list;
        }
    }
}
