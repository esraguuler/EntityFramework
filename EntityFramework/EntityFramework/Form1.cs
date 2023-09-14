using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PersonelEntities ent = new PersonelEntities();

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ent.PerTable.ToList();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            PerTable perTable = new PerTable();
            perTable.PerAd = TxtAd.Text;
            perTable.PerSoyad = TxtSoyad.Text;
            perTable.PerSehir = TxtSehir.Text;
            perTable.PerMaas = Convert.ToInt16(TxtMaas.Text);
            perTable.PerDurum = Convert.ToBoolean (TxtDurum.Text);
            perTable.PerYas = TxtYas.Text;
            ent.PerTable.Add(perTable);
            ent.SaveChanges();
            MessageBox.Show("Personel Sisteme Kaydedildi");
            dataGridView1.DataSource = ent.PerTable.ToList();
                

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(TxtPersonelID.Text);

            PerTable perTable = ent.PerTable.First(f => f.Perid == id);
            ent.PerTable.Remove(perTable);
            ent.SaveChanges();
            MessageBox.Show("Personel Sistemden Silindi");
            dataGridView1.DataSource = ent.PerTable.ToList();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(TxtPersonelID.Text);

            PerTable perTable = ent.PerTable.First(f => f.Perid == id);
            perTable.PerAd = TxtAd.Text;
            perTable.PerSoyad = TxtSoyad.Text;
            perTable.PerSehir = TxtSehir.Text;
            perTable.PerMaas = Convert.ToInt16(TxtMaas.Text);
            perTable.PerDurum = Convert.ToBoolean(TxtDurum.Text);
            perTable.PerYas = TxtYas.Text;
            ent.PerTable.Add(perTable);
            ent.SaveChanges();
            MessageBox.Show("Personel Bilgisi Güncellendi");
            dataGridView1.DataSource = ent.PerTable.ToList();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}