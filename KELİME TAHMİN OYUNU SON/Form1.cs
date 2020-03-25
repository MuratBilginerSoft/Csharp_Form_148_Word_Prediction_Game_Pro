using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

namespace KELİME_TAHMİN_OYUNU_SON
{
    public partial class Form1 : Form
    {
        #region DLL Import

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
                int nLeftRect,
                int nTopRect,
                int nRightRect,
                int nBottomRect,
                int nWidthEllipse,
                int nHeightEllipse
         );

        #endregion

        #region Metotlarım

        private string ara(string gelen)
        {
            try
            {
                string dosya = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KELİMELER1.accdb";

                OleDbConnection baglanti = new OleDbConnection(dosya);
                baglanti.Open();
                string sorgu = "select COUNT(" + gelen + ") from " + textBox3.Text;
                OleDbCommand komut = new OleDbCommand(sorgu, baglanti);

                int rast = r.Next(1, (int)komut.ExecuteScalar() + 1);
                OleDbCommand getir = new OleDbCommand("select " + gelen + " from " + textBox3.Text + " where Kimlik=" + rast);
                getir.Connection = baglanti;

                OleDbDataReader reader = getir.ExecuteReader();


                while (reader.Read())
                {
                    k = reader[gelen].ToString();

                }
                baglanti.Close();



            }
            catch
            { };

            return k;
        }


        private void klavye()
        {
            flowLayoutPanel1.Controls.Clear();
            string[] dizi = { "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZQWX" };



            foreach (char b in dizi[0])
            {
                //btn.Name = "btn_" + harf;
                Button btn = new Button();
                btn.Size = new Size(30, 30);
                btn.Name = "btn_" + b;
                btn.Text = b.ToString();
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Click += new EventHandler(btn_Click);
                flowLayoutPanel1.Controls.Add(btn);
            }

        }

        private void yenioyun()
        {
            comboBox1.Items.Clear();
            {
                comboBox1.Items.Add("Kategori Seçiniz");
                comboBox1.Items.Add("ARABALAR");
                comboBox1.Items.Add("İNTERNET");
                comboBox1.Items.Add("MEYVE");
                comboBox1.Items.Add("SARKICI");
                comboBox1.Items.Add("SEBZE");
                comboBox1.Items.Add("SEHİRLER");
                comboBox1.Items.Add("TEKNOLOJİ");
                comboBox1.Items.Add("ULKELER");
            }
            { // KULLANILACAK OLAN NESNELERİN AKTİF VEYA İNAKTİF OLDUĞU BLOK
                groupBox4.Visible = false;
                groupBox5.Visible = false;
                groupBox8.Visible = false;
                label7.Visible = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                pictureBox1.Image = null;
            }

            textBox3.Clear();
            flowLayoutPanel2.Controls.Clear();

            klavye();

            // OLACAK OLAYLAR
            {
                timer1.Stop();
                a1 = 1;
                b1 = 00;
                c1 = 00;

                label2.Text = a1.ToString() + ":0" + b1.ToString() + ":0" + c1.ToString();
                label5.Text = puan.ToString();
                label9.Text = @"1.Sonuç bölümü altındaki textboxlara oyuncu
isimlerini giriniz.
2.Oyuna başlamak için bir kategori seçin.
Ve kelime getir butonunu tıklayınız";

                comboBox1.Text = "Kategori Seçiniz";
            }

            puan = 100;
            label5.Text = puan.ToString();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
            sn1 = 0;
            sn2 = 0;
            label1.Text = "";
            groupBox8.Visible = false;


        }

        void adamas()
        {


            if (puan == 90)
            {
                g1 = 40;
                g2 = 180;
                g3 = 70;
                g4 = 150;

                resim1();


            }

            else if (90 > puan && puan > 80)
            {
                g1 = 40;
                g2 = 180;
                g3 = 70;
                g4 = 150;

                resim1();

                g1 = 70;
                g2 = 150;
                g3 = 100;
                g4 = 180;

                resim1();

            }

            else if (puan == 80)
            {
                g1 = 70;
                g2 = 150;
                g3 = 100;
                g4 = 180;

                resim1();

            }

            else if (80 > puan && puan > 70)
            {

                g1 = 70;
                g2 = 150;
                g3 = 100;
                g4 = 180;

                resim1();

                g1 = 70;
                g2 = 150;
                g3 = 70;
                g4 = 100;
                resim1();

            }

            else if (puan == 70)
            {
                g1 = 70;
                g2 = 150;
                g3 = 70;
                g4 = 100;
                resim1();


            }

            else if (70 > puan && puan > 60)
            {

                g1 = 70;
                g2 = 150;
                g3 = 70;
                g4 = 100;

                resim1();

                g1 = 70;
                g2 = 100;
                g3 = 40;
                g4 = 130;

                resim1();
            }

            else if (puan == 60)
            {
                g1 = 70;
                g2 = 100;
                g3 = 40;
                g4 = 130;

                resim1();


            }

            else if (60 > puan && puan > 50)
            {
                g1 = 70;
                g2 = 100;
                g3 = 40;
                g4 = 130;

                resim1();

                g1 = 70;
                g2 = 100;
                g3 = 100;
                g4 = 130;

                resim1();

            }

            else if (puan == 50)
            {
                g1 = 70;
                g2 = 100;
                g3 = 100;
                g4 = 130;

                resim1();


            }

            else if (50 > puan && puan > 40)
            {

                g1 = 70;
                g2 = 100;
                g3 = 100;
                g4 = 130;

                resim1();

                g1 = 35;
                g2 = 50;
                g3 = 70;
                g4 = 50;

                resim2();
            }

            else if (puan == 40)
            {
                g1 = 35;
                g2 = 50;
                g3 = 70;
                g4 = 50;

                resim2();

            }

            else if (40 > puan && puan > 30)
            {
                g1 = 35;
                g2 = 50;
                g3 = 70;
                g4 = 50;

                resim2();

                g1 = 70;
                g2 = 100;
                g3 = 110;
                g4 = 100;

                resim1();

            }

            else if (puan == 30)
            {

                g1 = 70;
                g2 = 100;
                g3 = 110;
                g4 = 100;

                resim1();


            }

            else if (30 > puan && puan > 20)
            {

                g1 = 70;
                g2 = 100;
                g3 = 110;
                g4 = 100;

                resim1();


                g1 = 110;
                g2 = 100;
                g3 = 110;
                g4 = 45;

                resim1();

            }

            else if (puan == 20)
            {

                g1 = 110;
                g2 = 100;
                g3 = 110;
                g4 = 45;

                resim1();

            }

            else if (20 > puan && puan > 10)
            {

                g1 = 110;
                g2 = 100;
                g3 = 110;
                g4 = 45;

                resim1();
                g1 = 110;
                g2 = 45;
                g3 = 70;
                g4 = 45;
                resim1();


            }
            else if (puan == 10)
            {
                resim1();
                g1 = 110;
                g2 = 45;
                g3 = 70;
                g4 = 45;
                resim1();

            }

            else if (puan > 0 && 10 > puan)
            {
                resim1();
                g1 = 110;
                g2 = 45;
                g3 = 70;
                g4 = 45;
                resim1();


            }

            else if (puan <= 0)
            {
                g1 = 70;
                g2 = 45;
                g3 = 70;
                g4 = 20;
                resim1();

            }
        }
        //**************************************************************************************************************
        // ÇİZİM METODLARI

        void resim1()
        {
            n1 = new Point(g1, g2);
            n2 = new Point(g3, g4);
            cizim = pictureBox1.CreateGraphics();
            cizim.DrawLine(kalem, n1, n2);
            cizim.Dispose();



        }

        void resim2()
        {

            cizim = pictureBox1.CreateGraphics();
            cizim.DrawEllipse(kalem, g1, g2, g3, g4);
            cizim.Dispose();

        }

        #endregion

        #region Tanımlamalar

        Random r = new Random();
        Button btn = new Button();
        ArrayList isim = new ArrayList();
        string[] kura = { "YAZI", "TURA" };
        ArrayList zaman1d = new ArrayList();
        ArrayList zaman1s = new ArrayList();
        ArrayList zaman2d = new ArrayList();
        ArrayList zaman2s = new ArrayList();
        ArrayList puan1 = new ArrayList();
        ArrayList puan2 = new ArrayList();
        Graphics cizim;


        Pen kalem = new Pen(Color.Blue, 2);
        Point n1;
        Point n2;


        #endregion

        #region Değişkenler

        int bulunansay = 0;

        // İNTEGER DEĞİŞKENLER

        // *Bu değişkenler kronometre için tanımlandı

        int a1, b1, c1;

        // *Bu değişkenler jokeri seçtirmek için tanımlandı

        int x1 = 0;

        // *BİLİNMİYOR

        int xx;

        int puan = 100;
        // KURADA SAYIYI TUTTU
        int d1;

        // OYUNCU SAYISINI KONTROL İÇİN

        int o1 = 1;

        // SONUÇLARI TUTACAK

        int sn1 = 0, sn2 = 0;

        // OYUNUN TUR SAYISINI KONTROL EDECEK

        int tur = 0;

        // HARF AL BUTONUNDA ÇALIŞIYOR 

        int kl = 0;

        // HARF AL BUTONUNDA ÇALIŞIYOR

        int tt = 0;

        //

        int g1, g2, g3, g4;
        //***********************************************************************************************************
        // STİRNG DEĞİŞKENLER

        //*Seçilen kelimeyi tutuyor.

        string k;

        //*İpucu harfi tutacak

        string ipucu;

        // İPUCUNU TUTACAK

        string ipucu2;
        //**************************************************************************************************************


        #endregion


        public Form1()
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 1026, 640, 15, 15));
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Name = "KELİME TAHMİN OYUNU";
            this.Text = "KELİME TAHMİN OYUNU";
            { // KULLANILACAK OLAN NESNELERİN AKTİF VEYA İNAKTİF OLDUĞU BLOK
                groupBox4.Visible = false;
                groupBox5.Visible = false;
                groupBox8.Visible = false;
                label7.Visible = false;
                //.Visible label6= false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                label6.Text = DateTime.Now.ToLongTimeString();
                timer2.Start();
            }



            klavye();

            // OLACAK OLAYLAR
            {
                a1 = 1;
                b1 = 00;
                c1 = 00;

                label2.Text = a1.ToString() + ":0" + b1.ToString() + ":0" + c1.ToString();
                label5.Text = puan.ToString();
                label9.Text = @"1.Sonuç bölümü altındaki textboxlara oyuncu
isimlerini giriniz.
2.Oyuna başlamak için bir kategori seçin.
Ve kelime getir butonunu tıklayınız";

                comboBox1.Text = "Kategori Seçiniz";
            }


        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btnd = sender as Button;
            try
            {
                if (comboBox1.Text == "Kategori Seçiniz")
                {
                    MessageBox.Show("Lütfen bir kategori seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {

                    btnd.Enabled = false;
                    string harf = btnd.Text;
                    int xy = 0;
                    int index = -1;

                    try
                    {
                        while ((index = k.IndexOf(harf, index + 1)) != -1)
                        {
                            flowLayoutPanel2.Controls[index].Text = harf;

                            if (button3.Enabled == true)
                            {
                                bulunansay++;
                                xy++;
                            }

                            else if (button3.Enabled == false && ipucu != harf)
                            {
                                bulunansay++;
                                xy++;

                            }

                            else
                                xy++;


                        }

                        if (xy == 0)
                        {
                            puan -= 10;
                            label5.Text = puan.ToString();
                            {
                                adamas();
                            }
                            if (puan <= 0)
                            {
                                puan = 0;
                                timer1.Stop();
                                label7.Text = "=" + k;
                                flowLayoutPanel2.Controls.Clear();
                                label9.Text = "Ne yazık ki bilemediniz!!!";
                                label7.Visible = true;
                                label7.Text = ":" + k;

                                if (o1 % 2 != 0)
                                {
                                    listBox1.Items.Add(puan);
                                    label4.Text = label2.Text;
                                    zaman1d.Add(b1);
                                    zaman1s.Add(c1);
                                    puan1.Add(puan);
                                    o1++;
                                    textBox3.Clear();

                                }


                                else if (o1 % 2 == 0 && groupBox5.Visible == true)
                                {

                                    listBox2.Items.Add(puan);
                                    label10.Text = label2.Text;
                                    zaman2d.Add(b1);
                                    zaman2s.Add(c1);
                                    puan2.Add(puan);
                                    o1++;
                                    textBox3.Clear();


                                    if ((int)zaman1d[tur] > (int)zaman2d[tur])
                                    {
                                        listBox1.Items.Add((int)puan1[tur] / 2);

                                    }

                                    else if ((int)zaman1d[tur] == (int)zaman2d[tur])
                                    {
                                        if ((int)zaman1s[tur] > (int)zaman2s[tur])
                                        {
                                            listBox1.Items.Add((int)puan1[tur] / 2);


                                        }

                                        else
                                        {
                                            listBox2.Items.Add((int)puan2[tur] / 2);
                                        }
                                    }

                                    else
                                    {
                                        listBox2.Items.Add((int)puan2[tur] / 2);

                                    }

                                    tur++;
                                }

                                else
                                {
                                    listBox1.Items.Add(puan);
                                    label4.Text = label2.Text;
                                    zaman1d.Add(b1);
                                    zaman1s.Add(c1);
                                    o1++;
                                    textBox3.Clear();

                                }


                            }




                        }
                        if (bulunansay == k.Length)
                        {
                            timer1.Stop();
                            label7.Visible = true;
                            label7.Text = "=" + k;
                            label9.Text = "TEBRİKLER!!!";
                            flowLayoutPanel2.Controls.Clear();

                            if (o1 % 2 != 0)
                            {
                                listBox1.Items.Add(puan);
                                label4.Text = label2.Text;
                                zaman1d.Add(b1);
                                zaman1s.Add(c1);
                                puan1.Add(puan);
                                o1++;
                                textBox3.Clear();

                            }


                            else if (o1 % 2 == 0 && groupBox5.Visible == true)
                            {

                                listBox2.Items.Add(puan);
                                label10.Text = label2.Text;
                                zaman2d.Add(b1);
                                zaman2s.Add(c1);
                                puan2.Add(puan);
                                o1++;
                                textBox3.Clear();


                                if ((int)zaman1d[tur] > (int)zaman2d[tur])
                                {
                                    listBox1.Items.Add((int)puan1[tur] / 2);

                                }

                                else if ((int)zaman1d[tur] == (int)zaman2d[tur])
                                {
                                    if ((int)zaman1s[tur] > (int)zaman2s[tur])
                                    {
                                        listBox1.Items.Add((int)puan1[tur] / 2);


                                    }

                                    else
                                    {
                                        listBox2.Items.Add((int)puan2[tur] / 2);
                                    }
                                }

                                else
                                {
                                    listBox2.Items.Add((int)puan2[tur] / 2);

                                }

                                tur++;
                            }

                            else
                            {
                                listBox1.Items.Add(puan);
                                label4.Text = label2.Text;
                                zaman1d.Add(b1);
                                zaman1s.Add(c1);
                                o1++;
                                textBox3.Clear();

                            }




                        }

                    }

                    catch
                    { };

                }

            }

            catch
            { };

        }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 10;

            if (c1 == 0)
            {

                if (b1 == 0)
                {
                    b1 = 59;
                    a1--;

                }

                else
                    b1--;

                c1 = 99;
            }

            else
            {
                c1--;



            }

            if (a1 == 0 && b1 == 0 && c1 == 0)
            {
                puan = 0;
                timer1.Stop();
                label7.Text = "=" + k;
                flowLayoutPanel2.Controls.Clear();
                label9.Text = "Süreniz doldu!!!Ne yazık ki bilemediniz!!!";
                label5.Text = puan.ToString();
                label7.Visible = true;
                label7.Text = ":" + k;

                if (o1 % 2 != 0)
                {
                    listBox1.Items.Add(puan);
                    o1++;
                    label4.Text = label2.Text;
                }
                //label2.Text = a1.ToString() + ":0" + b1.ToString() + ":0" + c1.ToString();

                else if (o1 % 2 == 0 && textBox2.Text != " ")
                {

                    listBox2.Items.Add(puan);
                    o1++;
                    label4.Text = label2.Text;


                }

                else
                {
                    listBox1.Items.Add(puan);
                    o1++;
                    label4.Text = label2.Text;

                }

            }
            label2.Text = a1.ToString() + ":" + b1.ToString() + ":" + c1.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // VERİ TABANI BAĞLANTISINI KURACAĞIM

            string dosya = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KELİMELER1.accdb";

            OleDbConnection baglanti = new OleDbConnection(dosya);
            baglanti.Open();

            try
            {
                if  (comboBox1.Text == "Kategori Seçiniz")
                {
                    MessageBox.Show("Lütfen bir kategori seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    g1 = 20;
                    g2 = 20;
                    g3 = 120;
                    g4 = 20;
                    resim1();

                    { 
                        button4.Enabled = true;
                        button3.Enabled = true;
                        button5.Visible = false;
                        button6.Visible = true;
                        label7.Visible = false;
                       
                        label9.Visible = true;
                        label11.Visible = false;
                        groupBox8.Visible = false;
                        flowLayoutPanel2.Controls.Clear();
                        label5.Text = puan.ToString();
                        bulunansay = 0;

                    }
                    klavye();

                    { // AKTİF VE İNAKTİF OLAN TUŞLAR

                        a1 = 1;
                        b1 = 00;
                        c1 = 00;
                        button2.Enabled = true;
                        button3.Enabled = true;
                        button4.Enabled = true;
                        timer1.Start();
                        puan = 100;
                        label5.Text = puan.ToString();
                        textBox3.Text = comboBox1.Text;
                        comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
                        comboBox1.Text = "KategoriSeçiniz";

                    }

                    // AÇIKLAMA

                    label9.Text = @"1.Seçilen kelimeler ingilizce olabilir.
2.İngilizce dil kurallarını dikkate alınız.
(Büyük i harfi olmadığı gibi!!!)
3.İpucu al jokeriniz aktifse kelimeyle ilgili 
bir ipucu verecektir.
4.Harf al jokerini kullanırsanız bilgisayarın 
seçmiş olduğu bir harf panoda yanacaktır.
5.Ama açtırmış olduğunuz bir harfte olabilir.
Bu jokerin zamanlamasına dikkat ediniz.
6.Süre dursun jokeri kullandığınız taktirde 
süreniz durur ve sürenizden 10 sn ye düşer.
7.Kullanılan her jokerin karşılığı 15 puandır.
8.O tur süre olarak daha çabuk yapan oyuncunun,
o tur aldığı puanın yarısı toplam puanına eklenir.";



                    switch (textBox3.Text)
                    {
                        case "ARABALAR":
                            {
                                button2.Enabled = true;
                                xx = r.Next(1, 7);

                                switch (xx)
                                {
                                    case 1: { ipucu2 = "ARABANIN MARKASI RENAULT"; k = ara("RENAULT"); break; }
                                    case 2: { ipucu2 = "ARABANIN MARKASI WOLKSVAGEN"; k = ara("WOLKSVAGEN"); break; }
                                    case 3: { ipucu2 = "ARABANIN MARKASI FORD"; k = ara("FORD"); break; }
                                    case 4: { ipucu2 = "ARABANIN MARKASI FIAT"; k = ara("FIAT"); break; }
                                    case 5: { ipucu2 = "ARABANIN MARKASI AUDI"; k = ara("AUDI"); break; }
                                    case 6: { ipucu2 = "ARABANIN MARKASI CHEVROLET"; k = ara("CHEVROLET"); break; }

                                }
                                break;
                            }

                        case "SARKICI":
                            {
                                button2.Enabled = true;
                                xx = r.Next(1, 9);


                                switch (xx)
                                {
                                    case 1: { ipucu2 = "YERLİ ERKEK ŞARKICI"; k = ara("YES"); break; }
                                    case 2: { ipucu2 = "YERLİ ERKEK ŞARKICI"; k = ara("YES1"); break; }
                                    case 3: { ipucu2 = "YABANCI ERKEK ŞARKICI"; k = ara("YYES"); break; }
                                    case 4: { ipucu2 = "YABANCI ERKEK ŞARKICI"; k = ara("YYES1"); break; }
                                    case 5: { ipucu2 = "YABANCI BAYAN ŞARKICI"; k = ara("YYBS"); break; }
                                    case 6: { ipucu2 = "YABANCI BAYAN ŞARKICI"; k = ara("YYBS1"); break; }
                                    case 7: { ipucu2 = "YERLİ BAYAN ŞARKICI"; k = ara("YBS"); break; }
                                    case 8: { ipucu2 = "YERLİ BAYAN ŞARKICI"; k = ara("YBS1"); break; }

                                }
                                break;


                            }


                        case "SEHİRLER":
                            {
                                button2.Enabled = true;
                                xx = r.Next(1, 12);

                                switch (xx)
                                {
                                    case 1: { ipucu2 = "BİZİM ŞEHİRLERDEN"; k = ara("S1"); break; }
                                    case 2: { ipucu2 = "BİZİM ŞEHİRLERDEN"; k = ara("S2"); break; }
                                    case 3: { ipucu2 = "BİZİM ŞEHİRLERDEN"; k = ara("S3"); break; }
                                    case 4: { ipucu2 = "BİZİM ŞEHİRLERDEN"; k = ara("S4"); break; }
                                    case 5: { ipucu2 = "BİZİM ŞEHİRLERDEN"; k = ara("S5"); break; }
                                    case 6: { ipucu2 = "BİZİM ŞEHİRLERDEN"; k = ara("S6"); break; }
                                    case 7: { ipucu2 = "BİZİM ŞEHİRLERDEN"; k = ara("S7"); break; }
                                    case 8: { ipucu2 = "BİZİM ŞEHİRLERDEN"; k = ara("S8"); break; }
                                    case 9: { ipucu2 = "YABANCI ŞEHİR"; k = ara("S9"); break; }
                                    case 10: { ipucu2 = "YABANCI ŞEHİR"; k = ara("S10"); break; }
                                    case 11: { ipucu2 = "YABANCI ŞEHİR"; k = ara("S11"); break; }



                                }
                                break;
                            }


                        case "İNTERNET": { button2.Enabled = false; ara("İNTERNET"); break; }

                        case "MEYVE":
                            {
                                button2.Enabled = false;
                                xx = r.Next(1, 3);

                                switch (xx)
                                {
                                    case 1: { ara("MEY1"); break; }
                                    case 2: { ara("MEY2"); break; }
                                }
                                break;
                            }

                        case "SEBZE":
                            {
                                button2.Enabled = false;
                                xx = r.Next(1, 3);

                                switch (xx)
                                {
                                    case 1: { ara("SEB1"); break; }
                                    case 2: { ara("SEB2"); break; }

                                }

                                break;
                            }

                        case "TEKNOLOJİ": { button2.Enabled = false; ara("TEK1"); break; }


                        case "ULKELER":
                            {
                                button2.Enabled = false;
                                xx = r.Next(1, 3);

                                switch (xx)
                                {
                                    case 1: { ara("UL1"); break; }
                                    case 2: { ara("UL2"); break; }

                                }

                                break;
                            }

                    }

                } // VERİ TABANI BAĞLANTIM BİTTİ


             
                foreach (char d in k)
                {


                    if (d == ' ')
                    {
                        isim.Add(d);
                        Label lbl = new Label();
                        lbl.Name = "lbl";
                        bulunansay++;
                        lbl.Text = "/";
                        lbl.BackColor = Color.White;
                        lbl.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
                        lbl.Size = new Size(20, 24);
                        lbl.BorderStyle = BorderStyle.FixedSingle;
                        flowLayoutPanel2.Controls.Add(lbl);




                    }

                    else
                    {
                        isim.Add(d);
                        Label lbl = new Label();
                        lbl.Name = "lbl";
                        lbl.Text = " ";
                        lbl.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
                        lbl.BackColor = Color.AntiqueWhite;
                        lbl.Size = new Size(20, 24);
                        lbl.BorderStyle = BorderStyle.FixedSingle;
                        flowLayoutPanel2.Controls.Add(lbl);


                    }
                }

                do
                {
                    xx = r.Next(k.Length);
                    ipucu = k[xx].ToString();

                    //textBox4.Text = ipucu;
                }
                while (ipucu == "");

                baglanti.Close();

            }
            catch { };
        }

        private void button5_Click(object sender, EventArgs e)
        {
            d1 = r.Next(2);
            if (d1 == 0)
                label11.Text = kura[d1];
            else
                label11.Text = kura[1];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
            button6.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (puan < 15)
                {
                    MessageBox.Show("Bu jokeri kullanacak kadar puanınız yok :(", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {

                    puan -= 15;
                    label5.Text = puan.ToString();
                    button3.Enabled = false;
                    {
                        adamas();
                    }
                    int xy = 0;
                    int index = -1;


                    try
                    {
                        while ((index = k.IndexOf(ipucu, index + 1)) != -1)
                        {




                            for (int i = 0; i < k.Length; i++)
                            {
                                if (ipucu != flowLayoutPanel2.Controls[i].Text)
                                {
                                    kl++;
                                    tt++;
                                }

                                else
                                {
                                    int yyyy = 0;
                                    yyyy++;
                                }
                            }

                            if (kl == k.Length)
                            {
                                flowLayoutPanel2.Controls[index].Text = ipucu;
                                bulunansay++;
                                xy++;
                                kl = 0;
                            }

                            else if (kl != k.Length && kl == tt / 2)
                            {
                                flowLayoutPanel2.Controls[index].Text = ipucu;
                                bulunansay++;
                                xy++;
                                tt = kl;
                                kl = 0;
                            }

                            else
                                xy++;
                        }


                        if (xy == 0)
                        {
                            puan -= 10;
                            label5.Text = puan.ToString();

                            if (puan <= 0)
                            {
                                timer1.Stop();
                                label7.Text = "=" + k;
                                flowLayoutPanel2.Controls.Clear();
                                label9.Text = "Ne yazık ki bilemediniz!!!";
                                label7.Visible = true;
                                label7.Text = ":" + k;
                                listBox1.Items.Add(puan);
                            }

                        }

                        if (bulunansay == k.Length)
                        {
                            timer1.Stop();
                            label7.Text = "=" + k;
                            label9.Text = "TEBRİKLER!!!";
                            flowLayoutPanel2.Controls.Clear();
                            listBox1.Items.Add(puan);
                            label4.Text = label2.Text;
                        }
                    }

                    catch

                    { };

                }
            }

            catch

            { };
        }

        private void button4_Click_2(object sender, EventArgs e)
        {

            try
            {

                if (puan < 15)
                {
                    MessageBox.Show("Bu jokeri kullanacak kadar puanınız yok :(", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    adamas();

                    if (b1 > 10)
                    {
                        button4.Enabled = false;
                        puan -= 15;
                        adamas();
                        label5.Text = puan.ToString();
                        b1 -= 10;
                        timer1.Stop();
                        label2.Text = a1.ToString() + ":" + b1.ToString() + ":" + c1.ToString();

                    }

                    else
                    {
                        button4.Enabled = false;
                        puan -= 15;
                        adamas();
                        label5.Text = puan.ToString();
                        a1 = 0;
                        b1 = 0;
                        c1 = 0;
                        timer1.Stop();
                        label2.Text = a1.ToString() + ":" + b1.ToString() + ":" + c1.ToString();

                    }

                }


            }

            catch
            { };
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count == 1)
            {
                if (textBox2.Text == "")
                {
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        sn1 += (int)listBox1.Items[i];
                    }

                    MessageBox.Show(textBox1.Text + "\n" + sn1 + " Puan aldın.", "SONUÇ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                }

                else
                {
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        sn1 += (int)listBox1.Items[i];
                    }

                    for (int i = 0; i < listBox2.Items.Count; i++)
                    {
                        sn2 += (int)listBox2.Items[i];
                    }

                    try
                    {
                        if (sn1 > sn2)
                        {
                            MessageBox.Show(textBox1.Text + "=" + sn1 + "\n" + textBox2.Text + "=" + sn2 + "\n" + textBox1.Text + " KAZANDI.\nTEBRİKLER", "SONUÇ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }

                        else if (sn1 == sn2)
                        {
                            MessageBox.Show(textBox1.Text + "=" + sn1 + "\n" + textBox2.Text + "=" + sn2 + "\n" + "BERABERE KALDINIZ", "SONUÇ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }

                        else
                        {
                            MessageBox.Show(textBox1.Text + "=" + sn1 + "\n" + textBox2.Text + "=" + sn2 + "\n" + textBox2.Text + " KAZANDI.\nTEBRİKLER", "SONUÇ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    catch
                    { };
                }
            }
            else
            {

                try
                {
                    if (comboBox1.Items.Count != 1)
                    {
                        if (textBox2.Text == "")
                        {
                            for (int i = 0; i < listBox1.Items.Count; i++)
                            {
                                sn1 += (int)listBox1.Items[i];
                            }

                            DialogResult m = MessageBox.Show("Oyun daha bitmedi.Şuan puanın\n" + textBox1.Text + "=" + sn1, "SONUÇ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                            if (m == DialogResult.Cancel)
                            {
                                this.Close();

                            }



                        }
                        else
                        {
                            for (int i = 0; i < listBox1.Items.Count; i++)
                            {
                                sn1 += (int)listBox1.Items[i];
                            }

                            for (int i = 0; i < listBox2.Items.Count; i++)
                            {
                                sn2 += (int)listBox2.Items[i];
                            }

                            try
                            {
                                DialogResult m = MessageBox.Show("Oyun daha bitmedi.Şu an puanınız\n" + textBox1.Text + "=" + sn1 + "\n" + textBox2.Text + "=" + sn2, "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                                if (m == DialogResult.Cancel)
                                {
                                    this.Close();

                                }



                            }
                            catch
                            { };
                        }

                    }
                }

                catch
                { };

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                groupBox4.Visible = false;

            }

            else
            {
                groupBox4.Visible = true;
                groupBox4.Text = textBox1.Text;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                groupBox5.Visible = false;

            }

            else
            {
                groupBox5.Visible = true;
                groupBox5.Text = textBox2.Text;
            }
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button6.Visible = true;
           
            label9.Visible = true;
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button6.Visible = false;
           
            label9.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            groupBox8.Visible = true;
            button2.Enabled = false;
            label1.Text = ipucu2;
            puan -= 15;
            adamas();
            label5.Text = puan.ToString();
        }

        private void yeniOyunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yenioyun();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinizden Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox9.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
          
        }

        private void açToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            groupBox9.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            

            

        }
       
        private void kapatToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            groupBox9.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
         
        }

        private void arkaPlanRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = colorDialog1.Color;
                textBox2.BackColor = colorDialog1.Color;
                comboBox1.BackColor = colorDialog1.Color;
                textBox3.BackColor = colorDialog1.Color;
                listBox1.BackColor = colorDialog1.Color;
                listBox2.BackColor = colorDialog1.Color;
                this.BackColor = colorDialog1.Color;
            }
       }

        private void yazıTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog1.Color;
                textBox2.ForeColor = colorDialog1.Color;
                comboBox1.ForeColor = colorDialog1.Color;
                textBox3.ForeColor = colorDialog1.Color;
                listBox1.ForeColor = colorDialog1.Color;
                listBox2.ForeColor = colorDialog1.Color;
                this.ForeColor = colorDialog1.Color;
                groupBox1.ForeColor = colorDialog1.Color;
                groupBox2.ForeColor = colorDialog1.Color;
                groupBox3.ForeColor = colorDialog1.Color;
                groupBox4.ForeColor = colorDialog1.Color;
                groupBox5.ForeColor = colorDialog1.Color;
                groupBox6.ForeColor = colorDialog1.Color;
                groupBox7.ForeColor = colorDialog1.Color;
                groupBox8.ForeColor = colorDialog1.Color;
                groupBox9.ForeColor = colorDialog1.Color;
                label1.ForeColor = colorDialog1.Color;
                label2.ForeColor = colorDialog1.Color;
                label3.ForeColor = colorDialog1.Color;
                label4.ForeColor = colorDialog1.Color;
                label5.ForeColor = colorDialog1.Color;
                label11.ForeColor = colorDialog1.Color;
                label7.ForeColor = colorDialog1.Color;
                
                label9.ForeColor = colorDialog1.Color;
                label10.ForeColor = colorDialog1.Color;
                

               

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToLongTimeString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 
    }
}