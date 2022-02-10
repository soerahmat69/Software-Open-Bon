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
    public partial class Form2 : Form
    {

        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public Form2()
        {
            InitializeComponent();
        }

        
        private void login_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SendMessage(username.Handle, EM_SETCUEBANNER, 0, "Isikan Username");
            SendMessage(email.Handle, EM_SETCUEBANNER, 0, "Isikan Email");
            SendMessage(retry.Handle, EM_SETCUEBANNER, 0, "Isikan ulang password");
            SendMessage(password.Handle, EM_SETCUEBANNER, 0, "Isikan Password");
    }

        private void registrasi_Click(object sender, EventArgs e)
        {
            string pass;
            pass = password.Text;
            String ret;
            ret = retry.Text;

            if (pass != ret || pass == "" || ret ==""|| username.Text == "" || email.Text =="")
            {

                if (pass != ret)
                    {
                     
                        MessageBox.Show("Ga sama tuh passwordnya, ulangi ya");
               
                } 

                switch (ret)
                {
                    case  "" :
                        MessageBox.Show("masa confirm passwordnya kosong");
                        break;
                }
                switch (username.Text)
                {
                    case "":
                        MessageBox.Show("masa usernamenya kosong");
                        break;
                }
                switch (email.Text)
                {
                    case "":
                        MessageBox.Show("masa email kosong");
                        break;
                }
                switch (pass)
                {
                    case "":
                        MessageBox.Show("masa passwordnya kosong");
                        break;
                }


            }
            else
            {
                Class1 bukaFungsi = new Class1();
                string cmdsave = "insert into user values(' ','" + username.Text + "','" + email.Text + "','" + pass + "')";
                bukaFungsi.inputData(cmdsave);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    
}
