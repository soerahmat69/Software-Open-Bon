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
    public partial class Form3 : Form
    {

        string strkoneksi = "server=localhost;uid=root;pwd=;database=openbon;";
        public Form3()
        {
            InitializeComponent();
        }

        string mase;
        string name;
        string nami;
        public Form3(string nama) : this()
        {
            output.Text = nama;
            name = nama;




            MySqlConnection conn = new MySqlConnection(strkoneksi);

            string selectQuery = "SELECT id_user FROM user where username IN('" + nama + "') ";
            conn.Open();

            MySqlCommand command = new MySqlCommand(selectQuery, conn);

            MySqlDataReader r = command.ExecuteReader();



            while (r.Read())
            {

                mase = r.GetString("id_user");


            }

            r.Close();

            nami = mase;




            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("select id_bon,nama_bon,tanggal_bon,total_bon,deskripsi_bon from databon where id_user = " + mase + ";", conn);
            DataSet DS = new DataSet();

            mySqlDataAdapter.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            dataGridView1.Columns[0].HeaderText = "id_bon";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].Width = 90;
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].HeaderText = "nama_bon";
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].HeaderText = "tanggal_bon";
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].HeaderText = "total_bon";
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[3].Width = 155;
            dataGridView1.Columns[4].HeaderText = "deskripsi_bon";
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[4].Width = 358;
            conn.Close();

            this.dataGridView1.Refresh();



        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sewa_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
        }

        private void Input_Click(object sender, EventArgs e)
        {

            Form5 frm5 = new Form5(nami);
            frm5.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Close();




        }

        private void button1_Click(object sender, EventArgs e)
        {



            MySqlConnection conn = new MySqlConnection(strkoneksi);

            string selectQuery = "SELECT id_user FROM user where username IN('" + name + "') ";
            conn.Open();

            MySqlCommand command = new MySqlCommand(selectQuery, conn);

            MySqlDataReader r = command.ExecuteReader();



            if (r.Read())
            {

                mase = r.GetString("id_user");


            }

            r.Close();

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("select id_bon,nama_bon,tanggal_bon,total_bon,deskripsi_bon from databon where id_user = " + mase + ";", conn);
            DataSet DS = new DataSet();


            mySqlDataAdapter.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            dataGridView1.Columns[0].HeaderText = "id_bon";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].Width = 90;
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].HeaderText = "nama_bon";
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].HeaderText = "tanggal_bon";
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].HeaderText = "total_bon";
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[3].Width = 155;
            dataGridView1.Columns[4].HeaderText = "deskripsi_bon";
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[4].Width = 358;
            conn.Close();

            this.dataGridView1.Refresh();
            this.dataGridView1.Refresh();



        }

      

        string idb;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                 idb = dataGridView1.Rows[e.RowIndex].Cells["id_bon"].FormattedValue.ToString();

                MessageBox.Show("kalau udah klik bisa milih delet dan edit oke");
            }else
            {
                MessageBox.Show("jangn dikluk terus");
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
        
            if (idb != "")
            {
                Class1 bukaFungsi = new Class1();
                string cmdsave = "Delete from databon where id_bon=" + idb + ";";
                bukaFungsi.DeleteData(cmdsave);
            }
            else
            {
                MessageBox.Show("klik dulu kolumnya barubisa kelik ");
            }
           

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (idb != "")
            {
                Form6 frm6 = new Form6(nami, idb);
                frm6.Show();
            }else
            {
                MessageBox.Show("klik dulu kolumnya barubisa kelik");
            }
        }

    }
    }

