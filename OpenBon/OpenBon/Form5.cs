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
    public partial class Form5 : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public Form5()
        {
            InitializeComponent();
        }

       


        int id;
        public Form5(string nami) : this()
        {

            id = Convert.ToInt16(nami);
            
         
        }

       
        private void button1_Click(object sender, EventArgs e)
        {   
            if(total.Text == "" || nama.Text == "" || deksripsi.Text =="" )
            {
                switch (total.Text)
                {
                    case "":
                        MessageBox.Show("total belum di isi");
                        break;
                }
                switch (nama.Text)
                {
                    case "":
                        MessageBox.Show("nama belum di isi");
                        break;
                }
                switch (deksripsi.Text)
                {
                    case "":
                        MessageBox.Show("deskripsi belum di isi");
                        break;
                }
            }
            else
            {
                Class1 bukaFungsi = new Class1();
                string cmdsave = "insert into databon values(' '," + id + ",'" + nama.Text + "','" + tanggal.Text.ToString() + "','" + total.Text + "','" + deksripsi.Text + "')";
                bukaFungsi.InputDataBon(cmdsave);
            }


           
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            SendMessage(nama.Handle, EM_SETCUEBANNER, 0, "Isikan Nama");
            SendMessage(tanggal.Handle, EM_SETCUEBANNER, 0, "Isikan Tanggal");
            SendMessage(total.Handle, EM_SETCUEBANNER, 0, "Isikan Password");
            SendMessage(deksripsi.Handle, EM_SETCUEBANNER, 0, "Isikan Password");

        }

    }
}
