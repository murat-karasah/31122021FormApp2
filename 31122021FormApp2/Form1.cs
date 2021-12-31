using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _31122021FormApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Sehir> slist = new List<Sehir>();
        List<Ogrenci> olist = new List<Ogrenci>();

        private void btn_Gonder_Click(object sender, EventArgs e)
        {
            int ogrencisayisi = Convert.ToInt32(txtOgrencisayisi.Text);
            for (int i = 1; i <= 81; i++)
            {
                Sehir s = new Sehir();
                s.sehirID =i;
                s.sehirAd = FakeData.PlaceData.GetCity();
                slist.Add(s);
            }
            for (int i = 1; i <= ogrencisayisi; i++)
            {
                Ogrenci o = new Ogrenci();
                o.ogrenciId = i;
                o.ogrenciAd = FakeData.NameData.GetFirstName();
                o.ogrenciMaas = FakeData.NumberData.GetNumber(550, 1450);
                o.ogrenciSehirId = FakeData.NumberData.GetNumber(1, 81);
                olist.Add(o);
                
            }
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView1.DataSource = olist;
            dataGridView2.DataSource = slist;

            Func<Ogrenci, int> selector = x => x.ogrenciMaas;
            txtToplamMaas.Text = olist.Sum(selector).ToString();
        }


        int secilenid;
        int secilenSehirId;

        Ogrenci secileno;
        Sehir secilensehir;
       

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            secilenid = (int)dataGridView1.CurrentRow.Cells[0].Value;
            secileno = olist.Find(x => secilenid == x.ogrenciId);
             secilensehir = slist.Find(x => secileno.ogrenciSehirId == x.sehirID);
            txtOgrenciId.Text = secileno.ogrenciId.ToString();
            txtOgrenciAd.Text = secileno.ogrenciAd;
            txtOgrenciMaas.Text = secileno.ogrenciMaas.ToString();
            txtOgrenciSehir.Text = secilensehir.sehirAd;

        }
    }
}
