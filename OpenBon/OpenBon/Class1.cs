using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace OpenBon
{
    public class Class1
    {
        MySqlConnection conn = null;
        string strkoneksi = "server=localhost;uid=root;pwd=;database=openbon;";
        MySqlDataReader dr = null;
        MySqlCommand cmd = null;

        public DataTable BukaTable(string op)
        {
            conn = new MySqlConnection(strkoneksi);
            try
            {
                conn.Open();
                cmd = new MySqlCommand(op, conn);
                dr = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            conn.Close();
            return dt;
        }

        public void inputData(string cmd)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(strkoneksi);
                conn.Open();

                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = cmd;
                command.ExecuteNonQuery();
                MessageBox.Show("Registrasi berhasil njo login", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        public void InputDataBon(string cmd)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(strkoneksi);
                conn.Open();

                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = cmd;
                command.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Di tambahkan", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ulang ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        public void DeleteData(string cmd)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(strkoneksi);
                conn.Open();

                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = cmd;
                command.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Terhapus", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ulang ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        public void UpdateDataBon(string cmd)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(strkoneksi);
                conn.Open();

                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = cmd;
                command.ExecuteNonQuery();
                MessageBox.Show("Data berhasil terupdate", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ulang ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
    }
}
