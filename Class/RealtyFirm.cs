using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RealEstateManagement.Class
{
    public class RealtyFirm:Broker
    {
        connection con = new connection();
        public string RealtyId { get; set; }
        public string RealtyName { get; set; }
        public string RealtyAddress { get; set; }
        public string RealtyEmail { get; set; }
        public string RealtyContact { get; set; }
        public string RealtyMobile { get; set; }
        public string RealtyLogoUrl { get; set; }

        //use for the search
        public string search_list { set; get; }
        public string search_text { set; get; }
        public List<string> datafill = new List<string>();

        //read properties
        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        public void AddRealty()
        {
            con.connectDB.Open();
            using (MySqlCommand cmd = new MySqlCommand())

            {
                MySqlTransaction myTrans;
                //start a local transaction
                myTrans = con.connectDB.BeginTransaction();
                cmd.Transaction = myTrans;
                try
                {
                    cmd.CommandText = "Insert into `rems`.`realty`(`objid`,`realtyname`,`address`,`contact`,`mobile`,`email`,`brokerfname`,`brokerlname`,`prc`,`validuntil`) VALUES(@robjid,@rname,@add,@contact,@mobile,@email,@brokerl,@brokerf,@prc,@valid)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con.connectDB;

                    cmd.Parameters.Add("@robjid", MySqlDbType.VarChar).Value = RealtyId;
                    cmd.Parameters.Add("@rname", MySqlDbType.VarChar).Value = RealtyName;
                    cmd.Parameters.Add("@add", MySqlDbType.VarChar).Value = RealtyAddress;
                    cmd.Parameters.Add("@contact", MySqlDbType.VarChar).Value = RealtyContact;
                    cmd.Parameters.Add("@mobile", MySqlDbType.VarChar).Value = RealtyMobile;
                    cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = RealtyEmail;
                    cmd.Parameters.Add("@brokerl", MySqlDbType.VarChar).Value = Lname;
                    cmd.Parameters.Add("@brokerf", MySqlDbType.VarChar).Value = Fname;
                    cmd.Parameters.Add("@prc", MySqlDbType.VarChar).Value = PRCNo;
                    cmd.Parameters.Add("@valid", MySqlDbType.DateTime).Value = ValidUntil;
                    cmd.ExecuteNonQuery();
                    myTrans.Commit();
                    MessageBox.Show("Data Saved!");
                }
                catch (Exception e)
                {
                    myTrans.Rollback();
                    MessageBox.Show(e.Message);


                }
                finally
                {
                    con.connectDB.Close();
                }
            }

        }
        public void UpdateRealty()
        {
            con.connectDB.Open();
            using (MySqlCommand cmd = new MySqlCommand())

            {
                MySqlTransaction myTrans;
                //start a local transaction
                myTrans = con.connectDB.BeginTransaction();
                cmd.Transaction = myTrans;
                try
                {
                    
                    cmd.CommandText = "Update `rems`.`realty` set `realtyname`=@rname," +
                        "`address`=@add,`contact`=@contact,`mobile`=@mobile,`email`=@email," +
                        "`brokerlname`=@brokerl,`brokerfname`=@brokerf,`prc`=@prc,`validuntil`=@valid " +
                        "where `objid`=@robjid";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con.connectDB;

                    cmd.Parameters.Add("@robjid", MySqlDbType.VarChar).Value = RealtyId;
                    cmd.Parameters.Add("@rname", MySqlDbType.VarChar).Value = RealtyName;
                    cmd.Parameters.Add("@add", MySqlDbType.VarChar).Value = RealtyAddress;
                    cmd.Parameters.Add("@contact", MySqlDbType.VarChar).Value = RealtyContact;
                    cmd.Parameters.Add("@mobile", MySqlDbType.VarChar).Value = RealtyMobile;
                    cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = RealtyEmail;
                    cmd.Parameters.Add("@brokerl", MySqlDbType.VarChar).Value = Lname;
                    cmd.Parameters.Add("@brokerf", MySqlDbType.VarChar).Value = Fname;
                    cmd.Parameters.Add("@prc", MySqlDbType.VarChar).Value = PRCNo;
                    cmd.Parameters.Add("@valid", MySqlDbType.DateTime).Value = ValidUntil;
                    cmd.ExecuteNonQuery();
                    myTrans.Commit();
                    MessageBox.Show("Data Updated!");
                }
                catch (Exception e)
                {
                    myTrans.Rollback();
                    MessageBox.Show(e.Message);


                }
                finally
                {
                    con.connectDB.Close();
                }
            }

        }
        public void DeleteRealty()
        {
            con.connectDB.Open();
            using (MySqlCommand cmd = new MySqlCommand())

            {
                MySqlTransaction myTrans;
                //start a local transaction
                myTrans = con.connectDB.BeginTransaction();
                cmd.Transaction = myTrans;
                try
                {

                    cmd.CommandText = "DELETE from `rems`.`realty` where objid=@robjid";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con.connectDB;

                    cmd.Parameters.Add("@robjid", MySqlDbType.VarChar).Value = RealtyId;

                    cmd.ExecuteNonQuery();
                    myTrans.Commit();
                    MessageBox.Show("Data Deleted!");
                }
                catch (Exception e)
                {
                    myTrans.Rollback();
                    MessageBox.Show(e.Message);


                }
                finally
                {
                    con.connectDB.Close();
                }
            }

        }
        public void ReadRealtyFirm()
        {
            dt.Clear();
            string query = "Select * from `rems`.`realty`";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con.connectDB);
            MDA.Fill(ds);
            dt = ds.Tables[0];

        }

        public void LOAD_LISTBOX() //load in the searchListbox
        {
            datafill.Clear();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                con.connectDB.Open();
                cmd.CommandText = "Select * from  `rems`.`realty` where concat(realtyname,brokerlname,brokerfname) like '%" + search_list + "%'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con.connectDB;

                try
                {
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        datafill.Add(rd[1].ToString());
                    }
                    con.connectDB.Close();
                }
                catch
                {
                    MessageBox.Show("Search Error");
                }
            }
        }
        public void SearchRealtyFirm()
        {
            string query_filter = "Select * from  `rems`.`realty` where concat(realtyname,brokerlname,brokerfname) like '%" + search_list + "%'";
            dt.Clear();
            MySqlDataAdapter MDA = new MySqlDataAdapter(query_filter, con.connectDB);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }


    }
}
