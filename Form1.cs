using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ticari.stok' table. You can move, or remove it, as needed.
            this.stokTableAdapter.Fill(this.ticari.stok);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //DataRow r = ticari.stok.NewRow();
            //r["stok_id"]  r[0]
            Ticari.stokRow r = ticari.stok.NewstokRow();
            //r["stok_id"]  r[0]
            r.stok_name = "deneme";
            r.unit_price = 1250;
            r.cat_id = 1;
            ticari.stok.AddstokRow(r);
            stokTableAdapter.Update(r);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;


            Ticari.stokRow r = ticari.stok.FindBystok_id(id);
            r.unit_price = 1.1 * r.unit_price;
            r.stok_name = r.stok_name.ToUpper();
            stokTableAdapter.Update(r);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Ticari.stokRow r = ticari.stok.FindBystok_id(5);

            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;


            Ticari.stokRow r = ticari.stok.FindBystok_id(id);

            r.Delete();
            stokTableAdapter.Update(r);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (DataRow  r in ticari.stok.Rows )
            {
                r.Delete();
            }

            stokTableAdapter.Update(ticari.stok);
        }

        private void button9_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                int id = (int)item.Cells[0].Value;

                Ticari.stokRow r = ticari.stok.FindBystok_id(id);

                r.Delete();
            }
            stokTableAdapter.Update(ticari.stok);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stokBindingSource.MoveFirst();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stokBindingSource.MoveNext();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stokBindingSource.MovePrevious();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stokBindingSource.MoveLast();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int id = stokBindingSource.Find("stok_name", textBox1.Text);
                       
            stokBindingSource.Position = id;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string   selstr=" stok_name like'"+textBox1.Text+"%'";
                       
            // stokBindingSource.Filter = selstr;  //  bu kullanılırsa kayıtlar filtrelenir  aşağıdakilere gerek kalmaz 
            DataRow[] secilirows = ticari.stok.Select(selstr);
            if (secilirows.Length != 0)
                stokBindingSource.Position = stokBindingSource.Find("stok_name", secilirows[0]["stok_name"]);


            
        }
    }
}
