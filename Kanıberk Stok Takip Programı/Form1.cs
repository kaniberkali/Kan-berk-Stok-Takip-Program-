using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading;
using System.Diagnostics;

namespace Kanıberk_Stok_Takip_Programı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        OleDbConnection baglantı = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Kanıberk Veritabanı.mdb'");//;Persist Security Info=True;Jet OLEDB:Database Password=hk381971
        private void pnl_sürükle_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;
        Thread th;
        private void pnl_sürükle_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }
        private void pnl_sürükle_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }
        private void tümpanellerigizle()
        {
            foreach (var control in this.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    ((TextBox)control).Text = "";
                }
            }
            button16.Visible = false;
            button17.Visible = false;
            button19.Visible = false;
            button18.Visible = false;
            pnl_Satıs_Yap.Visible = false;
            pnl_Kayıtlar.Visible = false;
            pnl_Müşteriler.Visible = false;
            pnl_Stoklar.Visible = false;

        }
        private void button5_Click(object sender, EventArgs e)
        {
            bekletsatısyap();
        }
        private void bekletsatısyap()
        {
            tümpanellerigizle();
            pnl_Satıs_Yap.Visible = true;
            button16.Visible = true;
            verilerigörüntüle_satis_yap_musteriler();
            verilerigörüntüle_satis_yap_stoklar();
            label1.Text = "Kanıberk Stok Takip - Satış Yap";
            this.Text = "Kanıberk Stok Takip - Satış Yap";
        }
        private void verilerigörüntüle_satis_yap_musteriler()
        {
            listView2.Items.Clear();
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglantı;
            komut.CommandText = ("Select * From Musteriler");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["tarih"].ToString();
                ekle.SubItems.Add(oku["isim_soyisim"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                listView2.Items.Add(ekle);
            }
            baglantı.Close();
        }
        private void verilerigörüntüle_satis_yap_stoklar()
        {
            listView3.Items.Clear();
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglantı;
            komut.CommandText = ("Select * From Stoklar");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["tarih"].ToString();
                ekle.SubItems.Add(oku["urun_ismi"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["stok"].ToString());
                listView3.Items.Add(ekle);
            }
            baglantı.Close();
        }
        private void verilerigörüntüle_satislar()
        {
            listView5.Items.Clear();
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglantı;
            komut.CommandText = ("Select * From Satislar");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["tarih"].ToString();
                ekle.SubItems.Add(oku["musteri"].ToString());
                ekle.SubItems.Add(oku["urun_ismi"].ToString());
                ekle.SubItems.Add(oku["adet"].ToString());
                ekle.SubItems.Add(oku["birim_fiyati"].ToString());
                ekle.SubItems.Add(oku["tutar"].ToString());
                listView5.Items.Add(ekle);
            }
            baglantı.Close();
        }
        private void verilerigörüntüle_stoklar()
        {
            listView4.Items.Clear();
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglantı;
            komut.CommandText = ("Select * From Stoklar");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["tarih"].ToString();
                ekle.SubItems.Add(oku["urun_ismi"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["stok"].ToString());
                listView4.Items.Add(ekle);
            }
            baglantı.Close();
        }
        private void verilerigörüntüle_musteriler()
        {
            listView1.Items.Clear();
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglantı;
            komut.CommandText = ("Select * From Musteriler");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["tarih"].ToString();
                ekle.SubItems.Add(oku["isim_soyisim"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                listView1.Items.Add(ekle);
            }
            baglantı.Close();
        }
        private void verilerigörüntüle_musteriler_deterjanlar()
        {
            listView6.Items.Clear();
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglantı;
            komut.CommandText = ("Select * From Satislar");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["tarih"].ToString();
                if (oku["musteri"].ToString() == listView1.SelectedItems[0].SubItems[1].Text)
                {
                    ekle.SubItems.Add(oku["urun_ismi"].ToString());
                    ekle.SubItems.Add(oku["adet"].ToString());
                    ekle.SubItems.Add(oku["birim_fiyati"].ToString());
                    ekle.SubItems.Add(oku["tutar"].ToString());
                    listView6.Items.Add(ekle);
                }
            }
            baglantı.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button5.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bekletstoklar();
           
        }
        private void bekletstoklar()
        {
            tümpanellerigizle();
            pnl_Stoklar.Visible = true;
            button18.Visible = true;
            verilerigörüntüle_stoklar();
            label1.Text = "Kanıberk Stok Takip - Stoklar";
            this.Text = "Kanıberk Stok Takip - Stoklar";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bekletmusteriler();
        }
        private void bekletmusteriler()
        {
            listView6.Items.Clear();
            tümpanellerigizle();
            pnl_Müşteriler.Visible = true;
            button19.Visible = true;
            verilerigörüntüle_musteriler();
            label1.Text = "Kanıberk Stok Takip - Müşteriler";
            this.Text = "Kanıberk Stok Takip - Müşteriler";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bekletsatıslar();

        }
        private void bekletsatıslar()
        {
            tümpanellerigizle();
            pnl_Kayıtlar.Visible = true;
            button17.Visible = true;
            verilerigörüntüle_satislar();
            label1.Text = "Kanıberk Stok Takip - Satışlar";
            this.Text = "Kanıberk Stok Takip - Satışlar";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.WindowState = FormWindowState.Minimized;
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                TopMost = true;
                timer1.Enabled = false;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox17.Text = listView1.SelectedItems[0].SubItems[1].Text;
                textBox6.Text = listView1.SelectedItems[0].SubItems[2].Text;
                verilerigörüntüle_musteriler_deterjanlar();
                textBox6.Focus();
            }
            catch
            {

            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            bool kontrol = false;
            if (textBox17.Text != "" && textBox6.Text != "")
            {
                if (textBox6.Text.Length == 11)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (listView1.Items[i].SubItems[1].Text == textBox17.Text)
                        {
                            kontrol = true;
                            break;
                        }
                    }
                    if (kontrol == true)
                        MessageBox.Show("Sakin ol! Bu müşteriyi zaten ekledim.", "@kaniberkali");
                    else
                    {
                        baglantı.Open();
                        OleDbCommand komut = new OleDbCommand("insert into Musteriler (tarih,isim_soyisim,telefon) values ('" + DateTime.Now + "','" + textBox17.Text + "','" + textBox6.Text + "')", baglantı);
                        komut.ExecuteNonQuery();
                        baglantı.Close();
                        verilerigörüntüle_musteriler();
                        listView6.Items.Clear();
                    }
                    textBox17.Text = "";
                    textBox6.Text = "";
                    textBox11.Text = "";
                }
                else
                    MessageBox.Show("DİKKAT! Yanlış telefon numarası.", "@kaniberkali");
            }
            else
                MessageBox.Show("İsim soyisim veya telefon boş bırakılamaz", "@kaniberkali");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand("delete from Musteriler where isim_soyisim = '"+textBox17.Text+"'", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
            textBox17.Text = "";
            textBox6.Text = "";
            textBox11.Text = "";
            verilerigörüntüle_musteriler();
            listView6.Items.Clear();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listView1.SelectedIndices.Count; i++)
            {
                this.listView1.Items[this.listView1.SelectedIndices[i]].Selected = false;
            }
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[1].ToString().ToLower().Contains(textBox11.Text.ToLower()) == true)
                {
                    listView1.Items[i].Selected = true;
                    listView1.Select();
                    break;
                }
            }
            textBox11.Focus();
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool kontrol = false;
            if (textBox4.Text != "" && textBox5.Text != "" && textBox7.Text != "")
            {
                    for (int i = 0; i < listView4.Items.Count; i++)
                    {
                        if (listView4.Items[i].SubItems[1].Text == textBox5.Text)
                        {
                            kontrol = true;
                            break;
                        }
                    }
                if (kontrol == true)
                    MessageBox.Show("Sakin ol! Bu müşteriyi zaten ekledim.", "@kaniberkali");
                else
                {
                    baglantı.Open();
                    OleDbCommand komut = new OleDbCommand("insert into Stoklar (tarih,urun_ismi,fiyat,stok) values ('" + DateTime.Now + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox7.Text + "')", baglantı);
                    komut.ExecuteNonQuery();
                    baglantı.Close();
                    verilerigörüntüle_stoklar();
                }
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
            }
            else
                MessageBox.Show("Deterjan isim,fiyat ve stok boş bırakılamaz", "@kaniberkali");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand("delete from Stoklar where urun_ismi = '" + textBox5.Text + "'", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
            verilerigörüntüle_stoklar();
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "" && textBox4.Text != "" && textBox7.Text != "" && textBox9.Text != "" && textBox8.Text != "" && textBox10.Text!="")
            {
                for (int i = 0; i < listView4.Items.Count; i++)
                {
                    if (listView4.Items[i].SubItems[1].Text == textBox5.Text)
                    {
                        baglantı.Open();
                        OleDbCommand komut = new OleDbCommand("delete from Stoklar where urun_ismi = '" + textBox5.Text + "'", baglantı);
                        komut.ExecuteNonQuery();
                        komut = new OleDbCommand("insert into Stoklar (tarih,urun_ismi,fiyat,stok) values ('" + DateTime.Now + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox9.Text + "')", baglantı);
                        komut.ExecuteNonQuery();
                        baglantı.Close();
                        verilerigörüntüle_stoklar();
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox7.Text = "";
                        textBox9.Text = "";
                        textBox10.Text = "";
                        textBox8.Text = "";
                        break;
                    }
                }
            }
            else
                MessageBox.Show("Hiçbir alan boş bırakılamaz.", "@kaniberkali");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "" && textBox4.Text != "" && textBox7.Text != "" && textBox9.Text != "" && textBox10.Text != ""&& textBox8.Text != "")
            {
                for (int i = 0; i < listView4.Items.Count; i++)
                {
                    if (listView4.Items[i].SubItems[1].Text == textBox5.Text)
                    {
                        baglantı.Open();
                        OleDbCommand komut = new OleDbCommand("delete from Stoklar where urun_ismi = '" + textBox5.Text + "'", baglantı);
                        komut.ExecuteNonQuery();
                        komut = new OleDbCommand("insert into Stoklar (tarih,urun_ismi,fiyat,stok) values ('" + DateTime.Now + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox10.Text + "')", baglantı);
                        komut.ExecuteNonQuery();
                        baglantı.Close();
                        verilerigörüntüle_stoklar();
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox7.Text = "";
                        textBox9.Text = "";
                        textBox10.Text = "";
                        textBox8.Text = "";
                        break;
                    }
                }
            }
            else
                MessageBox.Show("Hiçbir alan boş bırakılamaz.", "@kaniberkali");
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox5.Text = listView4.SelectedItems[0].SubItems[1].Text;
                textBox4.Text = listView4.SelectedItems[0].SubItems[2].Text;
                textBox7.Text = listView4.SelectedItems[0].SubItems[3].Text;
                textBox8.Focus();
            }
            catch
            {

            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox9.Text = Convert.ToString(Convert.ToInt32(textBox7.Text) + Convert.ToInt32(textBox8.Text));
                textBox10.Text = Convert.ToString(Convert.ToInt32(textBox7.Text) - Convert.ToInt32(textBox8.Text));
                if (Convert.ToInt32(textBox10.Text) < 0)
                    textBox8.Text = textBox7.Text;
            }
            catch { }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox15.Text != "" && textBox16.Text != "" && textBox22.Text != "")
            {
                baglantı.Open();
                OleDbCommand komut = new OleDbCommand("delete from Satislar where tarih = '" + textBox16.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                baglantı.Open();
                komut = new OleDbCommand("select * from Stoklar where urun_ismi = '" + textBox15.Text + "'", baglantı);
                OleDbDataReader oku = komut.ExecuteReader();
                int stok = 0;
                int fiyat = 0;
                while (oku.Read())
                {
                    fiyat = Convert.ToInt32(oku["fiyat"].ToString());
                    stok = Convert.ToInt32(oku["stok"].ToString());
                }
                if (stok != 0 && fiyat != 0)
                {
                    komut = new OleDbCommand("delete from Stoklar where urun_ismi = '" + textBox15.Text + "'", baglantı);
                    komut.ExecuteNonQuery();
                    baglantı.Close();
                    baglantı.Open();
                    komut = new OleDbCommand("insert into Stoklar (tarih,urun_ismi,fiyat,stok) values ('" + DateTime.Now + "','" + textBox15.Text + "','" + fiyat.ToString() + "','" + Convert.ToString(stok + Convert.ToInt32(textBox22.Text)) + "')", baglantı);
                    komut.ExecuteNonQuery();
                    baglantı.Close();
                }
                textBox14.Text = "";
                textBox15.Text = "";
                textBox21.Text = "";
                textBox22.Text = "";
                textBox16.Text = "";
            }
            else
                MessageBox.Show("Lütfen silmek istediğiniz satışı seçiniz.");
            verilerigörüntüle_stoklar();
            verilerigörüntüle_satislar();
        }

        private void listView5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox16.Text = listView5.SelectedItems[0].SubItems[0].Text;
                textBox14.Text = listView5.SelectedItems[0].SubItems[1].Text;
                textBox15.Text = listView5.SelectedItems[0].SubItems[2].Text;
                textBox22.Text = listView5.SelectedItems[0].SubItems[3].Text;
                button15.Focus();
            }
            catch
            {

            }
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listView2.SelectedIndices.Count; i++)
            {
                this.listView2.Items[this.listView2.SelectedIndices[i]].Selected = false;
            }
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                if (listView2.Items[i].SubItems[1].ToString().ToLower().Contains(textBox18.Text.ToLower()) == true)
                {
                    listView2.Items[i].Selected = true;
                    listView2.Select();
                    break;
                }
            }
            textBox18.Focus();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = listView2.SelectedItems[0].SubItems[1].Text;
                textBox19.Focus();
            }
            catch
            {

            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listView3.SelectedIndices.Count; i++)
            {
                this.listView3.Items[this.listView3.SelectedIndices[i]].Selected = false;
            }
            for (int i = 0; i < listView3.Items.Count; i++)
            {
                if (listView3.Items[i].SubItems[1].ToString().ToLower().Contains(textBox19.Text.ToLower()) == true)
                {
                    listView3.Items[i].Selected = true;
                    listView3.Select();
                    break;
                }
            }
            textBox19.Focus();
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listView4.SelectedIndices.Count; i++)
            {
                this.listView4.Items[this.listView4.SelectedIndices[i]].Selected = false;
            }
            for (int i = 0; i < listView4.Items.Count; i++)
            {
                if (listView4.Items[i].SubItems[1].ToString().ToLower().Contains(textBox20.Text.ToLower()) == true)
                {
                    listView4.Items[i].Selected = true;
                    listView4.Select();
                    break;
                }
            }
            textBox20.Focus();
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listView5.SelectedIndices.Count; i++)
            {
                this.listView5.Items[this.listView5.SelectedIndices[i]].Selected = false;
            }
            for (int i = 0; i < listView5.Items.Count; i++)
            {
                if (listView5.Items[i].SubItems[1].ToString().ToLower().Contains(textBox21.Text.ToLower()) == true)
                {
                    listView5.Items[i].Selected = true;
                    listView5.Select();
                    break;
                }
            }
            textBox21.Focus();
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = listView3.SelectedItems[0].SubItems[1].Text;
                textBox12.Text = listView3.SelectedItems[0].SubItems[2].Text;
                textBox13.Text = listView3.SelectedItems[0].SubItems[3].Text;
                numericUpDown1.Maximum = Convert.ToInt32(textBox13.Text);
                textBox3.Text = Convert.ToString(Convert.ToInt32(numericUpDown1.Value) * Convert.ToInt32(textBox12.Text));
                numericUpDown1.Focus();
            }
            catch
            {

            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = Convert.ToString(Convert.ToInt32(numericUpDown1.Value) * Convert.ToInt32(textBox12.Text));
            }
            catch { }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox12.Text != ""&& Convert.ToInt32(numericUpDown1.Value)>0 && Convert.ToDouble(textBox3.Text) > 0)
            {
                baglantı.Open();
                OleDbCommand komut = new OleDbCommand("delete from Stoklar where urun_ismi = '" + textBox2.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                komut = new OleDbCommand("insert into Stoklar (tarih,urun_ismi,fiyat,stok) values ('" + DateTime.Now + "','" + textBox2.Text + "','" + textBox12.Text + "','" + Convert.ToString(Convert.ToInt32(textBox13.Text) - Convert.ToInt32(numericUpDown1.Value)) + "')", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                baglantı.Open();
                 komut = new OleDbCommand("insert into Satislar (tarih,musteri,urun_ismi,adet,birim_fiyati,tutar) values ('" + DateTime.Now + "','" + textBox1.Text + "','" + textBox2.Text + "','" + numericUpDown1.Value + "','" + textBox12.Text + "','" + textBox3.Text+ "')", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox12.Text = "";
                textBox18.Text = "";
                textBox19.Text = "";
                textBox13.Text = "";
                numericUpDown1.Value = 1;
                button6.PerformClick();
            }
            else
                MessageBox.Show("Deterjan veya müşteri seçilmedi.", "@kaniberkali");
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.Start("https://kodzamani.weebly.com");
        }

        private void textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox6.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox19.Focus();
            }
        }

        private void textBox19_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                numericUpDown1.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button11.PerformClick();
            }
        }

        private void textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox8.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox7.Focus();
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button7.PerformClick();
            }
            if (e.KeyData == Keys.Delete)
            {
                button8.PerformClick();
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button9.PerformClick();
            }
            if (e.KeyData == Keys.Delete)
            {
                button10.PerformClick();
            }
        }

        private void textBox21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                button15.PerformClick();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button12.PerformClick();
            }
            if (e.KeyData == Keys.Delete)
            {
                button13.PerformClick();
            }
        }
    }
}
