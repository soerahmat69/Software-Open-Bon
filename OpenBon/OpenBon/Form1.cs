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
    public partial class Form1 : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SendMessage(username.Handle, EM_SETCUEBANNER, 0, "Isikan Username");
            SendMessage(password.Handle, EM_SETCUEBANNER, 0, "Isikan Password");

        }

        private void login_Click(object sender, EventArgs e)
        {

            
            if (username.Text == "" || password.Text == "")
            {
                MessageBox.Show("Harap masukkan username dan password anda..");
            }
            else
            {
                Class1 bukaFungsi = new Class1();
                DataTable dt = new DataTable();
                string query = "select username,password from user where username='{0}'and password='{1}'";
                query = string.Format(query, username.Text, password.Text);
                dt = bukaFungsi.BukaTable(query);
                if (dt.Rows.Count > 0)
                {

                    this.Hide();
                    String nama;
               
                    nama = username.Text;
                 
                  
                    Form3 frm3 = new Form3(nama);
                  
                    MessageBox.Show("Login berhasil.. ");
                    frm3.Show();
                  
                    
               
                }
                else
                {
                    MessageBox.Show("Username atau password anda salah..");
                }
            }
        }

       
        private void registrasi_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
