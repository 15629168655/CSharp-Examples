using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using xsgl.Model;
using xsgl.DAL;
using System.Data.SqlClient;

namespace xsgl.DAL
{
    public class StudentDAL
    {
        public int AddStudent(Student student) {
            string sql = "insert into xsgl_student(stud_no,stud_name,stud_sex,stud_birthDate,stud_major,stud_isMember,stud_pic) values(@studNo,@studName,@studSex,@studBirthDate,@studMajor,@studIsMember,@studPic)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("studNo",System.Data.SqlDbType.VarChar,8),
                new SqlParameter("studName",System.Data.SqlDbType.NVarChar,30),
                new SqlParameter("studSex",System.Data.SqlDbType.NChar,2),
                new SqlParameter("studBirthDate",System.Data.SqlDbType.DateTime),
                new SqlParameter("studMajor",System.Data.SqlDbType.NVarChar,30),
                new SqlParameter("studIsMember",System.Data.SqlDbType.Bit),
                new SqlParameter("studPic",System.Data.SqlDbType.Image)};
            parameters[0].Value = student.StudNo;
            parameters[1].Value = student.StudName;
            parameters[2].Value = student.StudSex;
            parameters[3].Value = student.StudBirthDate;
            parameters[4].Value = student.StudMajor;
            parameters[5].Value = student.StudIsMember?1:0;
            parameters[6].Value = student.StudPic;
            return SqlHelper.ExecuteNonQuery(sql,parameters);
        }

        public int EditStudent(Student student) {
            string sql = "update xsgl_student set stud_name=@studName,stud_sex=@studSex,stud_birthDate=@studBirthDate,stud_major=@studMajor,stud_isMember=@studIsMember,stud_pic=@studPic where stud_no=@studNo";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("studName",System.Data.SqlDbType.NVarChar,30),
                new SqlParameter("studSex",System.Data.SqlDbType.NChar,2),
                new SqlParameter("studBirthDate",System.Data.SqlDbType.DateTime),
                new SqlParameter("studMajor",System.Data.SqlDbType.NVarChar,30),
                new SqlParameter("studIsMember",System.Data.SqlDbType.Bit),
                new SqlParameter("studPic",System.Data.SqlDbType.Image),
                new SqlParameter("studNo",System.Data.SqlDbType.VarChar,8)};
            parameters[0].Value = student.StudName;
            parameters[1].Value = student.StudSex;
            parameters[2].Value = student.StudBirthDate;
            parameters[3].Value = student.StudMajor;
            parameters[4].Value = student.StudIsMember?1:0;
            parameters[5].Value = student.StudPic;
            parameters[6].Value = student.StudNo;
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }

        public int DeleteStudent(string studNo) {
            string sql = String.Format("delete from xsgl_student where stud_no='{0}'", studNo);
            return SqlHelper.ExecuteNonQuery(sql);
        }

        public Student FindStudent(string studNo)
        {
            Student student = null;
            string sql = String.Format("select * from xsgl_student where stud_no='{0}'", studNo);
            SqlDataReader dr = SqlHelper.ExecuteReader(sql);
            if (dr.Read())
            {
                student = new Student();
                student.StudNo = dr.GetString(0);
                student.StudName = dr.GetString(1);
                student.StudSex = dr.GetString(2).ToCharArray()[0];
                student.StudBirthDate = dr.GetDateTime(3);
                student.StudMajor = dr.GetString(4);
                student.StudIsMember = dr.GetBoolean(5);
                object obj = dr.GetValue(6);
                if (!(obj is System.DBNull)) student.StudPic = (byte[])obj;
            }
            dr.Close();
            return student;
        }

        public IList<Student> FindStudents(string studName)
        {
            IList<Student> list = new List<Student>();
            string sql = String.Format("select * from xsgl_student where stud_name like '%{0}%'", studName);
            DataTable table = SqlHelper.ExecuteQuery(sql);
            if (table != null)
            {
                Student student;
                foreach (DataRow row in table.Rows)
                {
                    student = new Student();
                    student.StudNo = row[0].ToString();
                    student.StudName = row[1].ToString();
                    student.StudSex = row[2].ToString().ToCharArray()[0];
                    student.StudBirthDate = (DateTime)row[3];
                    student.StudMajor = row[4].ToString();
                    student.StudIsMember = (bool)row[5];
                    if (!(row[6] is System.DBNull)) student.StudPic = (byte[])row[6];
                    list.Add(student);
                }
            }
            return list;
        }
    }
}
