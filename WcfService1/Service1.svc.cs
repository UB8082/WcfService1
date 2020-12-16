using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string Insert(InsertUser user)
        {
            string msg;
            SqlConnection con = new SqlConnection("Server=DESKTOP-OLFSSOV;Database=WCFTutorial2;User Id=sa;Password=123;Trusted_Connection=True;MultipleActiveResultSets=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into UserTab (Name,Email) values (@Name,@Email)",con);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            int g = cmd.ExecuteNonQuery();
            if(g == 1)
            {
                msg = "Succesfully Inserted";
            }
            else
            {
                msg = "Failed to insert";
            }
            return msg;
        }

        public gettesdata GetInfo()
        {
            SqlConnection con = new SqlConnection("Server=DESKTOP-OLFSSOV;Database=WCFTutorial2;User Id=sa;Password=123;Trusted_Connection=True;MultipleActiveResultSets=true");
            con.Open();
            gettesdata g = new gettesdata();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from UserTab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("UserTab");
            da.Fill(dt);
            g.usertab = dt;
            cmd.ExecuteNonQuery();
            con.Close();
            return g;
        }

        public string Update(UpdateUser u)
        {
            string Message = "";
            SqlConnection con = new SqlConnection("Server=DESKTOP-OLFSSOV;Database=WCFTutorial2;User Id=sa;Password=123;Trusted_Connection=True;MultipleActiveResultSets=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update UserTab set Name = @Name, Email = @Email, Where User ID = @UserID",con);
            cmd.Parameters.AddWithValue("@UserID", u.UID);
            cmd.Parameters.AddWithValue("@Name", u.Name);
            cmd.Parameters.AddWithValue("@EMail", u.Email);
            int res = cmd.ExecuteNonQuery();
            if (res == 1)
            {
                Message = "Succesfully Updated";
            }
            else
            {
                Message = "Failed to Updatte";
            }
            return Message;
        }

        public string Delete(DeleteUser d)
        {
            string msg = "";
            SqlConnection con = new SqlConnection("Server=DESKTOP-OLFSSOV;Database=WCFTutorial2;User Id=sa;Password=123;Trusted_Connection=True;MultipleActiveResultSets=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete UserTab where UserID = @UserID", con);
            cmd.Parameters.AddWithValue("@UserID", d.UID);
            int res = cmd.ExecuteNonQuery();
            if (res == 1)
            {
                msg = "Succesfully deleted";
            }
            else
            {
                msg = "Failed to delete";
            }
            return msg;
        }

    }
}
