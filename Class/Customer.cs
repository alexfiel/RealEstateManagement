using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstateManagement.Class
{
    public class Customer:Person
    {
        public string Bldgno { get; set; }
        public string Barangay { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string  Country { get; set; }
        public int ZipCode { get; set; }
        public string SpouseFname { get; set; }
        public string SpouseLname { get; set; }
        public string SpouseMname { get; set; }
        public DateTime SBday { get; set; }
        public string SourceofIncome { get; set; }
        public string AverageIncome { get; set; }
        public string Employement { get; set; }
        public int LengthofStay { get; set; }
        public string TypeofOwnership { get; set; }
        public string PicUrl { get; set; }
        public string IdUrl { get; set; }
        public string  SCitizen { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string CompanyAdd { get; set; }
        public String CompanyContact { get; set; }

        //read properties
        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        connection con = new connection();

        public void AddCostumer()
        {
            con.connectDB.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                MySqlTransaction myTrans;
                //start mysql transaction
                myTrans = con.connectDB.BeginTransaction();
                cmd.Transaction = myTrans;
                try
                {
                    cmd.CommandText = "Insert into `rems`.`customer`(`objid`,`lname`,`fname`,`mname`,`dateofbirth`,`slname`," +
                        "`sfname`,`smname`,`sdateofbirth`,`sex`,`civilstatus`,`citizenship`,`scitizenship`,`mobileno`,`email`," +
                        "`phone`,`lengthofstay`,`typeofownership`,`address`,`barangay`,`city`,`province`,`country`,`zipcode`,`employement`," +
                        "`averageincome`,`companyname`,`comp_add`,`comp_contact`) " +
                        "VALUES(@robjid,@lname,@fname,@mname,@birthday,@slname,@sfname,@smname,@sbday,@sex,@civil,@citizen,@scitizen," +
                        "@mobile,@email,@phone,@length,@typeown,@address,@barangay,@city,@province,@country,@zip,@employement,@income,@company,@cadd,@ccontact)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con.connectDB;
                     
                    cmd.Parameters.Add("@robjid", MySqlDbType.VarChar).Value =PersonID;
                    cmd.Parameters.Add("@lname", MySqlDbType.VarChar).Value =Lname;
                    cmd.Parameters.Add("@fname", MySqlDbType.VarChar).Value = Fname;
                    cmd.Parameters.Add("@mname", MySqlDbType.VarChar).Value = Middle;
                    cmd.Parameters.Add("@birthday", MySqlDbType.DateTime).Value =Bday;
                    cmd.Parameters.Add("@slname", MySqlDbType.VarChar).Value = SpouseLname;
                    cmd.Parameters.Add("@sfname", MySqlDbType.VarChar).Value = SpouseFname;
                    cmd.Parameters.Add("@smname", MySqlDbType.VarChar).Value = SpouseMname;
                    cmd.Parameters.Add("@sbday", MySqlDbType.DateTime).Value = SBday;
                    cmd.Parameters.Add("@sex", MySqlDbType.VarChar).Value = Sex;
                    cmd.Parameters.Add("@civil", MySqlDbType.VarChar).Value = CivilStatus;
                    cmd.Parameters.Add("@citizen", MySqlDbType.VarChar).Value = Citizen;
                    cmd.Parameters.Add("@scitizen", MySqlDbType.VarChar).Value = SCitizen;
                    cmd.Parameters.Add("@mobile", MySqlDbType.VarChar).Value = Mobile;
                    cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = Email;
                    cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = Phone;
                    cmd.Parameters.Add("@length", MySqlDbType.Int16).Value = LengthofStay;
                    cmd.Parameters.Add("@typeown", MySqlDbType.VarChar).Value = TypeofOwnership;
                    cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = Bldgno;
                    cmd.Parameters.Add("@barangay", MySqlDbType.VarChar).Value = Barangay;
                    cmd.Parameters.Add("@city", MySqlDbType.VarChar).Value = City;
                    cmd.Parameters.Add("@province", MySqlDbType.VarChar).Value = Province;
                    cmd.Parameters.Add("@country", MySqlDbType.VarChar).Value = Country;
                    cmd.Parameters.Add("@zip", MySqlDbType.VarChar).Value = ZipCode;
                    cmd.Parameters.Add("@employement", MySqlDbType.VarChar).Value = Employement;
                    cmd.Parameters.Add("@income", MySqlDbType.VarChar).Value = AverageIncome;
                    cmd.Parameters.Add("@company", MySqlDbType.VarChar).Value = Company;
                    cmd.Parameters.Add("@ccadd", MySqlDbType.VarChar).Value = CompanyAdd;
                    cmd.Parameters.Add("@ccontact", MySqlDbType.VarChar).Value = CompanyContact;
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
        public void UpdateCostumer()
        {
            con.connectDB.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                MySqlTransaction myTrans;
                //start mysql transaction
                myTrans = con.connectDB.BeginTransaction();
                cmd.Transaction = myTrans;
                try
                {
                    cmd.CommandText = "Update `rems`.`customer`set `lname`=@lname,`fname`=@fname,`mname`=@mname,`dateofbirth`=@birthday,`slname`=@slname," +
                        "`sfname`=@sfname,`smname`=@smname,`sdateofbirth`=@sbday,`sex`=@sex,`civilstatus`=@civil,`citizenship`=@citizen,`scitizenship`=@scitizen,`mobileno`=@mobile,`email`=@email," +
                        "`phone`=@phone,`lengthofstay`=@length,`typeofownership`=@typeown,`address`=@address,`barangay`=@barangay,`city`=@city,`province`=@province,`country`=@country,`zipcode`=@zip,`employement`=@employement," +
                        "`averageincome`=@income,`companyname`=@company,`comp_add`=@cadd,`comp_contact`=@ccontact where `objid`=@robjid";
                       
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con.connectDB;

                    cmd.Parameters.Add("@robjid", MySqlDbType.VarChar).Value = PersonID;
                    cmd.Parameters.Add("@lname", MySqlDbType.VarChar).Value = Lname;
                    cmd.Parameters.Add("@fname", MySqlDbType.VarChar).Value = Fname;
                    cmd.Parameters.Add("@mname", MySqlDbType.VarChar).Value = Middle;
                    cmd.Parameters.Add("@birthday", MySqlDbType.DateTime).Value = Bday;
                    cmd.Parameters.Add("@slname", MySqlDbType.VarChar).Value = SpouseLname;
                    cmd.Parameters.Add("@sfname", MySqlDbType.VarChar).Value = SpouseFname;
                    cmd.Parameters.Add("@smname", MySqlDbType.VarChar).Value = SpouseMname;
                    cmd.Parameters.Add("@sbday", MySqlDbType.DateTime).Value = SBday;
                    cmd.Parameters.Add("@sex", MySqlDbType.VarChar).Value = Sex;
                    cmd.Parameters.Add("@civil", MySqlDbType.VarChar).Value = CivilStatus;
                    cmd.Parameters.Add("@citizen", MySqlDbType.VarChar).Value = Citizen;
                    cmd.Parameters.Add("@scitizen", MySqlDbType.VarChar).Value = SCitizen;
                    cmd.Parameters.Add("@mobile", MySqlDbType.VarChar).Value = Mobile;
                    cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = Email;
                    cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = Phone;
                    cmd.Parameters.Add("@length", MySqlDbType.Int16).Value = LengthofStay;
                    cmd.Parameters.Add("@typeown", MySqlDbType.VarChar).Value = TypeofOwnership;
                    cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = Bldgno;
                    cmd.Parameters.Add("@barangay", MySqlDbType.VarChar).Value = Barangay;
                    cmd.Parameters.Add("@city", MySqlDbType.VarChar).Value = City;
                    cmd.Parameters.Add("@province", MySqlDbType.VarChar).Value = Province;
                    cmd.Parameters.Add("@country", MySqlDbType.VarChar).Value = Country;
                    cmd.Parameters.Add("@zip", MySqlDbType.VarChar).Value = ZipCode;
                    cmd.Parameters.Add("@employement", MySqlDbType.VarChar).Value = Employement;
                    cmd.Parameters.Add("@income", MySqlDbType.VarChar).Value = AverageIncome;
                    cmd.Parameters.Add("@company", MySqlDbType.VarChar).Value = Company;
                    cmd.Parameters.Add("@ccadd", MySqlDbType.VarChar).Value = CompanyAdd;
                    cmd.Parameters.Add("@ccontact", MySqlDbType.VarChar).Value = CompanyContact;
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
        public void DeleteCostumer()
        {
            con.connectDB.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                MySqlTransaction myTrans;
                //start mysql transaction
                myTrans = con.connectDB.BeginTransaction();
                cmd.Transaction = myTrans;
                try
                {
                    cmd.CommandText = "Delete from `rems`.`Customer`where objid=@robjid";

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con.connectDB;

                    cmd.Parameters.Add("@robjid", MySqlDbType.VarChar).Value = PersonID;
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
        public void ReadCostumer()
        {
            dt.Clear();
            string query = "Select * from `rems`.`realty`";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con.connectDB);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }

    }
}
