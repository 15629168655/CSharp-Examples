using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xsgl.Model
{
    public class User
    {
        private int userId;
        private string userName;
        private string userPwd;
        public int UserId{ 
            get{
                return userId;
            }
            set{
                userId= value;
            }
        }
        public string UserName {
            get {
                return userName;
            }
            set {
                userName = value;
            }
        }
        public string UserPwd
        {
            get {
                return userPwd;
            }
            set {
                userPwd = value;
            }
        }

    }
}
