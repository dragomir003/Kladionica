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

namespace Kladionica
{
    public partial class Form2 : Form
    {

        public double balans = 500.00;

        DataTable kvote;
        SqlConnection veza;
        int id;

        public Form2()
        {
            InitializeComponent();
        }

        public void AddData(string utakmica, int id, SqlConnection veza)
        {
            label1.Text = utakmica;
            this.veza = veza;
            this.id = id;

            SqlDataAdapter adapter = new SqlDataAdapter("select Kvota.opis, UtakmicaKvota.kvota from UtakmicaKvota join Kvota on UtakmicaKvota.kvotaId = Kvota.id where utakmicaId = " + id.ToString() + ";", veza);

            kvote = new DataTable();
            adapter.Fill(kvote);

            for (int i = 0; i < kvote.Rows.Count; ++i)
            {
                checkedListBox1.Items.Add(kvote.Rows[i][0].ToString() + " - " + kvote.Rows[i][1].ToString());
            }
        }

        private static double uzmiKvotu(string s)
        {
            return Double.Parse(s.Split('-')[1]);
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            double ukupnaKvota = 1;
            for (int i = 0; i < checkedListBox1.Items.Count; ++i)
            {
                if (!checkedListBox1.GetItemChecked(i))
                {
                    continue;
                }

                ukupnaKvota *= uzmiKvotu(checkedListBox1.Items[i].ToString());
            }

            if (e.CurrentValue == CheckState.Checked)
            {
                ukupnaKvota /= uzmiKvotu(checkedListBox1.Items[e.Index].ToString());
            }
            else
            {
                ukupnaKvota *= uzmiKvotu(checkedListBox1.Items[e.Index].ToString());
            }



            label2.Text = "Ukupna Kvota: " + Math.Round(ukupnaKvota, 2).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double uplata;
            try
            {
                uplata = Double.Parse(textBox1.Text);
            } catch
            {
                MessageBox.Show("Unesite validan broj za uplatu.");
                return;
            }

            if (uplata > balans)
            {
                MessageBox.Show("Nemate dovoljno kredita. Molimo Vas da unesete manji iznos ili uplatite novac na racun.");
                return;
            }

            balans -= uplata;

            MessageBox.Show("Uplata je uspesno izvrsena");

            this.Visible = false;
        }

        private void Form2_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                return;
            }
            id = -1;
            checkedListBox1.Items.Clear();
            textBox1.Text = "";
            label2.Text = "Ukupna Kvota: 1.00";
            label1.Text = "";
        }
    }
}