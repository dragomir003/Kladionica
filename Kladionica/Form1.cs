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

namespace Kladionica
{
    public partial class Form1 : Form
    {
        SqlConnection veza;

        DataTable utakmice;

        Form2 form2 = new Form2();

        public Form1()
        {
            InitializeComponent();
        }

        public void IspisiBalans()
        {
            label2.Text = "Balans: " + form2.balans + " rsd";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string CS = @"Data Source=DESKTOP-DVS4TKU; Initial Catalog=Kladionica; Integrated Security=True";

            veza = new SqlConnection(CS);

            SqlDataAdapter adapter = new SqlDataAdapter("select * from Utakmica;", veza);

            utakmice = new DataTable();
            adapter.Fill(utakmice);

            dataGridView1.DataSource = utakmice;
            dataGridView1.Columns["id"].Visible = false;

            IspisiBalans();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int red = e.RowIndex;

            int id = (int)dataGridView1.Rows[red].Cells["id"].Value;

            string utakmica = dataGridView1.Rows[red].Cells["domaci"].Value.ToString() + " - " + dataGridView1.Rows[red].Cells["gosti"].Value.ToString();

            form2.AddData(utakmica, id, veza);

            form2.ShowDialog();

            IspisiBalans();
        }
    }
}
