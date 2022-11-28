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

namespace WindowsFormsAppGyumolcsok
{
    public partial class GyumolcsokUpdate : Form
    {
        public GyumolcsokUpdate()
        {
            InitializeComponent();
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Nincs kijelölve gyümölcs!");
                return;
            }
            cmd.Parameters.Clear();
            gyumolcsok kivalasztott_gyumolcs = (gyumolcsok)listBox1.SelectedItem;
            cmd.CommandText = "UPDATE `gyumolcsok` SET `nev`= @nev,`egysegar`= @egysegar,`mennyiseg`= @mennyiseg WHERE `id` = @id";
            cmd.Parameters.AddWithValue("@id", textBoxId.Text);
            cmd.Parameters.AddWithValue("@nev", textBoxNev.Text);
            cmd.Parameters.AddWithValue("@egysegar", numericUpDownEgysegar.Value);
            cmd.Parameters.AddWithValue("@mennyiseg", numericUpDownMennyiseg.Value);
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Módosítás sikeres votl!");
                gyumolcsokLB_update();
                gyumolcsok_update();
            }
            else
            {
                MessageBox.Show("Az adatok módosítása sikertelen!");
            }
            gyumolcsokLB_update();
            gyumolcsok_update();
        }
        MySqlConnection conn = null;
        MySqlCommand cmd = null;
        private void gyumolcsokLB_update()
        {
            listBox1.Items.Clear();
            cmd.CommandText = "SELECT `id`, `nev`, `egysegar`, `mennyiseg` FROM `gyumolcsok` WHERE 1";
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    gyumolcsok uj = new gyumolcsok(dr.GetInt32("id"), dr.GetString("nev"), dr.GetInt32("egysegar"), dr.GetInt32("mennyiseg"));
                    listBox1.Items.Add(uj);
                }
            }
        }
        private void gyumolcsok_update()
        {
            Program.gyumolcsok.listBox1.Items.Clear();
            cmd.CommandText = "SELECT `id`, `nev`, `egysegar`, `mennyiseg` FROM `gyumolcsok` WHERE 1";
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    gyumolcsok uj = new gyumolcsok(dr.GetInt32("id"), dr.GetString("nev"), dr.GetInt32("egysegar"), dr.GetInt32("mennyiseg"));
                    Program.gyumolcsok.listBox1.Items.Add(uj);
                }
            }
        }

        private void GyumolcsokUpdate_Load(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "gyumolcsok";
            conn = new MySqlConnection(builder.ConnectionString);
            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "A program leáll!");
                Environment.Exit(0);
                throw;
            }
            gyumolcsokLB_update();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                return;
            }
            gyumolcsok gyumolcsok = (gyumolcsok)listBox1.SelectedItem;
            textBoxId.Text = gyumolcsok.Id.ToString();
            textBoxNev.Text = gyumolcsok.Nev;
            numericUpDownEgysegar.Value = gyumolcsok.Egysegar;
            numericUpDownMennyiseg.Value = gyumolcsok.Mennyiseg;
        }
    }
}
