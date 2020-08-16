using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RealEstateManagement.Class;

namespace RealEstateManagement
{
    public partial class Realty : Form
    {
        RealtyFirm _rf = new RealtyFirm();
        
        public Realty()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //GENERATE RANDOM STRING
        private void RandomCharacter()

        {
            int length = 8;
            System.Random numRandom = new System.Random();

            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);

            }

            txtRealtyID.Text = "RF-" + str_build.ToString() + numRandom.Next(500);

        }

        private void ClearAll()
        {
            txtRealtyID.Text = "";
            txtRealtyName.Text = "";
            txtRealtyAddress.Text = "";
            txtRealtyContact.Text = "";
            txtRealtyEmail.Text = "";
            txtRealtyMobile.Text = "";
            txtBrokerFirst.Text = "";
            txtBrokerLast.Text = "";
            txtPRC.Text = "";
            dtValidity.Value = DateTime.Today;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {

            ClearAll();
            RandomCharacter();

        }
        private void AddRealtyFIrm()

        {
                      
            _rf.RealtyId = txtRealtyID.Text;
            _rf.RealtyName = txtRealtyName.Text;
            _rf.RealtyEmail = txtRealtyEmail.Text;
            _rf.RealtyAddress = txtRealtyAddress.Text;
            _rf.RealtyContact = txtRealtyContact.Text;
            _rf.RealtyMobile =txtRealtyMobile.Text;
            _rf.Lname = txtBrokerLast.Text;
            _rf.Fname = txtBrokerFirst.Text;
            _rf.PRCNo = txtPRC.Text;
            _rf.ValidUntil = dtValidity.Value;
            _rf.AddRealty();
            ClearAll();
            
        }
        private void UpdateRealtyFirm()
        {
            _rf.RealtyId = txtRealtyID.Text;
            _rf.RealtyName = txtRealtyName.Text;
            _rf.RealtyEmail = txtRealtyEmail.Text;
            _rf.RealtyAddress = txtRealtyAddress.Text;
            _rf.RealtyContact = txtRealtyContact.Text;
            _rf.RealtyMobile = txtRealtyMobile.Text;
            _rf.Lname = txtBrokerLast.Text;
            _rf.Fname = txtBrokerFirst.Text;
            _rf.PRCNo = txtPRC.Text;
            _rf.ValidUntil = dtValidity.Value;
            _rf.UpdateRealty();
            ClearAll();
        }
        private void DeleteRealtyFirm()
        {
            _rf.RealtyId = txtRealtyID.Text;
            _rf.DeleteRealty();
            ClearAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            AddRealtyFIrm();
            LoadTables();
        }
        private void LoadTables()
        {
            dataGridView1.DataSource = null;
            _rf.ReadRealtyFirm();
            dataGridView1.DataSource = _rf.dt;
        }

        private void Realty_Load(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UpdateRealtyFirm();
            LoadTables();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                
                txtRealtyID.Text = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtRealtyName.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                txtRealtyAddress.Text = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                txtRealtyContact.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                txtRealtyMobile.Text = (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                txtRealtyEmail.Text = (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                txtBrokerLast.Text = (dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                txtBrokerFirst.Text = (dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
                txtPRC.Text = (dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString());
                dtValidity.Text = (dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString());



            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRealtyFirm();
            LoadTables();
        }

        private void ShowListbox()
        {
            lsb_search.DataSource = null;
            _rf.search_list = txtSearch.Text;
            _rf.LOAD_LISTBOX();

            lsb_search.DataSource = _rf.datafill;
            lsb_search.Visible = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                lsb_search.ClearSelected();

            }
            else
            {
                lsb_search.ClearSelected();
                ShowListbox();
            }
        }
        private void txtSearch_MouseDown(object sender, MouseEventArgs e)
        {
            lsb_search.DataSource = null;
            lsb_search.ClearSelected();
            txtSearch.Text = "";
        }

        private void lsb_search_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (lsb_search.SelectedItem==null)
                {
                    MessageBox.Show("Cannot Select a null value");
                    lsb_search.Visible = false;
                }
                else
                {
                    txtSearch.Text = lsb_search.SelectedItem.ToString();
                    lsb_search.ClearSelected();
                    lsb_search.Visible = false;
                    lsb_search.DataSource = null;
                }
                
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void lsb_search_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lsb_search.DataSource = null;
                lsb_search.ClearSelected();
                txtSearch.Text = "";
            }
            
        }
   

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                LoadTables();
            }
            else
            {
                dataGridView1.DataSource = null;
                _rf.search_text = txtSearch.Text;
                _rf.SearchRealtyFirm();
                dataGridView1.DataSource = _rf.dt;
            }
        }

        private void lsb_search_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
