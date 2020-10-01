using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA201001
{
    public partial class FrmMain : Form
    {
        SqlConnection conn;

        public FrmMain()
        {
            conn = new SqlConnection(
                @"Data Source=(localdb)\MSSQLLocalDB;" +
                "Initial Catalog=proba;");

            var list = new List<string>()
            {
                "dfgtdfh",
                "gfsdrghdtrgh",
            };


            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            conn.Open();

            var cmd = new SqlCommand("SELECT * FROM emberek;", conn);
            var r = cmd.ExecuteReader();

            while (r.Read())
            {
                dgvNevek.Rows.Add(r[0], r[1]);
            }
            conn.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            conn.Open();
            var adapter = new SqlDataAdapter()
            {
                InsertCommand = new SqlCommand(
                $"INSERT INTO emberek (nev) VALUES ('{tbNevInput.Text}');", conn),
            };
            adapter.InsertCommand.ExecuteNonQuery();
            conn.Close();
        }
    }
}
