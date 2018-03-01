using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using xsgl.DAL;

namespace xsgl.DAL
{
    public class UserDAL
    {
        public bool validate(string UserName,string UserPwd) {
            bool flag = false;
            string sql = String.Format("select * from xsgl_user where user_name='{0}' and user_pwd='{1}'", UserName, UserPwd);
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
            if (sdr.Read())
            {
                flag = true;
            }
            return flag;
        }
    }
}
