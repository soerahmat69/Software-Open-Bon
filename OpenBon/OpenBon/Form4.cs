using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenBon
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }



        string name;
        string harga;
        string nomor;
        MySqlConnection connection = new MySqlConnection("server=localhost;Database=openbon;username=root;password=;");
        private void Form4_Load(object sender, EventArgs e)
        {
        
            string selectQuery = "SELECT nama_dcl,harga_dcl,nomor_dcl FROM dcl";
            connection.Open();

            MySqlCommand command = new MySqlCommand(selectQuery, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString("nama_dcl"));
                harga = reader.GetString("harga_dcl");
                nomor = reader.GetString("nomor_dcl");
                //  nama.Text = reader.GetString("nama_dcl");
                //   label2.Text = reader.GetString("harga_dcl");
                // label4.Text = reader.GetString("nomor_dcl");
            }
            
            connection.Close();

            name = comboBox1.Text;


        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            //  textBox1.Text = comboBox1.Text;
            //    string dcl;
            //  dcl = textBox1.Text;

            //      string selectQuery = "SELECT * FROM dcl where nama_dcl IN('"+ dcl + "') ";
            //   connection.Open();

            //MySqlCommand command = new MySqlCommand(selectQuery, connection);

            // MySqlDataReader r = command.ExecuteReader();

            //while (r.Read())
            //{
            // label2.Text = r.GetString("harga_dcl");
            //label4.Text = r.GetString("nomor_dcl");

            //  }
            //r.Close();

          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string selectQuery1 = "SELECT harga_dcl,nomor_dcl FROM dcl where nama_dcl IN('" + comboBox1.Text + "')";
            connection.Open();

            MySqlCommand command = new MySqlCommand(selectQuery1, connection);

            MySqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {

                //  harga = read.GetString("harga_dcl");
                //  nomor = read.GetString("nomor_dcl");
                //  nama.Text = reader.GetString("nama_dcl");
                label2.Text = "Rp " + read.GetString("harga_dcl");
                label4.Text = read.GetString("nomor_dcl");
            }

            connection.Close();
        }

        private void nama_Click(object sender, EventArgs e)
        {

        }
    }
}
   