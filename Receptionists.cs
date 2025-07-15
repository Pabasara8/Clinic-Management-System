using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ClinicMs
{
    public partial class Receptionists : Form
    {
        public Receptionists()
        {
            InitializeComponent();
            Displayrec();
        }
        SqlConnection conn = new SqlConnection("Data Source=pabasararavihar\\SQLEXPRESS ; Initial Catalog=Clinicdocdb ; Integrated security=True;");

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Customer");
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("delete from ReceptionistsTbl where RecepId=@key ", conn);
                    
                    cmd.Parameters.AddWithValue("@key", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Receptionist Deleted");
                    conn.Close();
                    Displayrec();
                    clear();
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }
        private void Displayrec()
        {
            string query = "select * from ReceptionistTbl";
            SqlDataAdapter sda= new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var dt = new DataSet();
            sda.Fill(dt);
            guna2DataGridView1.DataSource = dt.Tables[0];
            
            
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==" "|| textBox3.Text =="" || textBox5.Text=="" || textBox2.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try {
                    conn.Open();
                   
                    SqlCommand cmd = new SqlCommand("INSERT INTO ReceptionistTbl(RecepName,RecepPhone,RecepAdd,RecepPass)values(@RN,@RP,@RA,@RPA)", conn);
                    cmd.Parameters.AddWithValue("@RN",textBox1.Text);
                    cmd.Parameters.AddWithValue("@RP", textBox3.Text);
                    cmd.Parameters.AddWithValue("@RA", textBox5.Text);
                    cmd.Parameters.AddWithValue("@RPA", textBox2.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Receptionist Added");
                    conn.Close();
                    Displayrec();
                    clear();
                }
                
                catch(Exception ex) {
                
                MessageBox.Show(ex.Message);}
            }

        }
        int key = 0;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox5.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            if (textBox1.Text == "")
            {
                key = 0;
            }
            else {
                key = Convert.ToInt32(textBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox5.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE  ReceptionistTbl set RecepName=@RN,RecepPhone=@RP,RecepAdd=@RA,RecepPass=@RPA where RecepId=@Rkey", conn);
                    cmd.Parameters.AddWithValue("@RN", textBox1.Text);
                    cmd.Parameters.AddWithValue("@RP", textBox3.Text);
                    cmd.Parameters.AddWithValue("@RA", textBox5.Text);
                    cmd.Parameters.AddWithValue("@RPA", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Rkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Receptionist Updated");
                    conn.Close();
                    Displayrec();
                    clear();
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }
        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            key= 0;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label13_Click(object sender, EventArgs e)
        {
           Doctor obj = new Doctor();
            obj.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void Receptionists_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            Patients obj = new Patients();
            obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Lab_Tests obj = new Lab_Tests();
            obj.Show();
            this.Hide();
        }
    }
}
