using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenBon
{
    public partial class Form6 : Form
    {


        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public Form6()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SendMessage(nama.Handle, EM_SETCUEBANNER, 0, "Isikan Nama");
            SendMessage(tanggal.Handle, EM_SETCUEBANNER, 0, "Isikan Tanggal");
            SendMessage(total.Handle, EM_SETCUEBANNER, 0, "Isikan Password");
            SendMessage(deksripsi.Handle, EM_SETCUEBANNER, 0, "Isikan Password");

        }

        MySqlConnection connection = new MySqlConnection("server=localhost;Database=openbon;username=root;password=;");

        int id;
        int idbon;
        public Form6(String nami,String idb) : this()
        {
            id = Convert.ToInt16(nami);
            idbon = Convert.ToInt16(idb);

        }
        string result;
        string hasil2;

        int final;
        //  String hasill;
        int hasil;
        int result2;
        private void label6_Click(object sender, EventArgs e)
        {

        }


        private void Form6_Load(object sender, EventArgs e)
        {

            string selectQuery1 = "SELECT * FROM databon where id_bon =" + idbon + ";";
            connection.Open();

            MySqlCommand command = new MySqlCommand(selectQuery1, connection);

            MySqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                nama.Text = read.GetString("nama_bon");
                tanggal.Text = read.GetString("tanggal_bon");
                total.Text = read.GetString("total_bon");
                result = read.GetString("total_bon");
                deksripsi.Text = read.GetString("deskripsi_bon");
            }
            connection.Close();

            SendMessage(nama.Handle, EM_SETCUEBANNER, 0, "Isikan Nama");
            SendMessage(tanggal.Handle, EM_SETCUEBANNER, 0, "Isikan Tanggal");
            SendMessage(total.Handle, EM_SETCUEBANNER, 0, "Isikan Password");
            SendMessage(deksripsi.Handle, EM_SETCUEBANNER, 0, "Isikan Password");



        }



        private void kurang_Click(object sender, EventArgs e)
        {

            hasil2 = total.Text;

            hasil = Convert.ToInt32(hasil2);
            result2 = Convert.ToInt16(result);

            if (hasil >= result2)
                {
                    final = hasil - result2;
                    total.Text = final.ToString();
                }
                else
                {
                    final = result2 - hasil;
                total.Text = final.ToString();
            }
            

        }

        private void tambah_Click(object sender, EventArgs e)
        {
            hasil2 = total.Text;

            hasil = Convert.ToInt32(hasil2);
            result2 = Convert.ToInt16(result);
            // total.Clear();
            final = hasil +  result2;
            total.Text = final.ToString();
        }
       
       
        private void button1_Click(object sender, EventArgs e)
        {
            // hasill =  total.Text ;
            MessageBox.Show("yakin mau di update?");

            if (final != 0)
            {
                Class1 bukaFungsi = new Class1();
                string cmdsave = "update databon set id_user =" + id + ", nama_bon ='" + nama.Text + "',tanggal_bon ='" + tanggal.Text.ToString() + "',total_bon ='" + final + "',deskripsi_bon ='" + deksripsi.Text + "' where id_bon=" + idbon + ";";
                bukaFungsi.UpdateDataBon(cmdsave);
            }
            else
            {
                Class1 bukaFungsi = new Class1();
                string cmdsave = "update databon set id_user =" + id + ", nama_bon ='" + nama.Text + "',tanggal_bon ='" + tanggal.Text.ToString() + "',total_bon ='" + total.Text + "',deskripsi_bon ='" + deksripsi.Text + "' where id_bon=" + idbon + ";";
                bukaFungsi.UpdateDataBon(cmdsave);
            }
        }

        private void total_Click(object sender, EventArgs e)
        {
            total.Clear();

        }




        //style

    }
}
