using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication2
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void temeljToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            button1.Visible = true;
        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            double n,d=0, w, l, visina, sirina , vU, vS, vTemelja;
            double ks,kc,cenaBetona,cenaCementa,cenaSodera;
            char[] spliters ={ ' ', ',', '.', ':', '\t', '\n' };
            string[] duzine = richTextBox1.Text.Split(spliters);
            try
            {
                for (int i = 0; i < duzine.Length; i++)
                {
                    n = Convert.ToDouble(duzine[i]);
                    d += n;

                }
                visina = Convert.ToDouble(textBox2.Text);
                sirina = Convert.ToDouble(textBox3.Text);
                w = Convert.ToDouble(textBox11.Text);
                l = Convert.ToDouble(textBox12.Text);
                if (visina < 0 || sirina < 0 || w < 0 || l < 0 || d < 0) MessageBox.Show("Neispravan unos podataka!");
                vU = d * sirina * visina;
                vS = 0.1 * w * l;
                vTemelja = vU + vS;
                textBox5.Text = Convert.ToString(vTemelja);
                cenaBetona = vTemelja * 55;
                textBox6.Text = Convert.ToString(cenaBetona);
                kc = vTemelja * 300;
                textBox7.Text = Convert.ToString(kc);
                cenaCementa = kc * 14 / 123;
                textBox8.Text = Convert.ToString(cenaCementa);
                ks = vTemelja * 1.2;
                textBox9.Text = Convert.ToString(ks);
                cenaSodera = 2200 / 123 * ks;
                textBox10.Text = Convert.ToString(cenaSodera);
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                label1.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Neispravan unos podataka!");
            }
            catch (System.DivideByZeroException)
            {
                MessageBox.Show("Nemoguce deljenje nulom(proverite vas unos)");
            }       

        }

        private void zidoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            listBox1.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            textBox1.Visible = true;
            richTextBox2.Visible = true;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            char[] spliters ={ ' ', ',', '.', ':', '\t', '\n' };
            string[] duzine = richTextBox2.Text.Split(spliters);
            double cenaG,cenaT,cenaY,brBlokovaG=1,brBlokovaT=1,brBlokovaY=1,visina,duzina=0,n,zGiter,zTermo,zYtong;
            label18.Visible = true;
            label19.Visible = true;    
            textBox4.Visible = true;
            textBox13.Visible = true;
            try
            {
                visina = Convert.ToDouble(textBox1.Text);
                for (int i = 0; i < duzine.Length; i++)
                {
                    n = Convert.ToDouble(duzine[i]);
                    duzina += n;

                }
                Blok giter = new Blok();
                Blok termo = new Blok();
                Blok ytong = new Blok();
                giter.setWidth(0.19);
                giter.setHeight(0.19);
                giter.setLength(0.25);
                giter.setCena(0.292);
                termo.setWidth(0.19);
                termo.setHeight(0.19);
                termo.setLength(0.25);
                termo.setCena(0.325);
                ytong.setWidth(0.25);
                ytong.setHeight(0.2);
                ytong.setLength(0.625);
                ytong.setCena(2.22);
                zGiter = giter.getLength() * giter.getHeight() * giter.getWidth();
                zTermo = termo.getLength() * termo.getHeight() * termo.getWidth();
                zYtong = ytong.getLength() * ytong.getHeight() * ytong.getWidth();

                if (listBox1.SelectedItem.Equals("GITER") == true)
                {
                    brBlokovaG = duzina * visina * giter.getWidth() / zGiter;
                    textBox4.Text = Convert.ToString(brBlokovaG);
                    cenaG = brBlokovaG * giter.getCena();
                    textBox13.Text = Convert.ToString(cenaG);
                }
                if (listBox1.SelectedItem.Equals("TERMO") == true)
                {
                    brBlokovaT = duzina * visina * termo.getWidth() / zTermo;
                    textBox4.Text = Convert.ToString(brBlokovaT);
                    cenaT = brBlokovaT * termo.getCena();
                    textBox13.Text = Convert.ToString(cenaT);
                }
                if (listBox1.SelectedItem.Equals("YTONG") == true)
                {
                    brBlokovaY = duzina * visina * ytong.getWidth() / zYtong;
                    textBox4.Text = Convert.ToString(brBlokovaY);
                    cenaY = brBlokovaY * ytong.getCena();
                    textBox13.Text = Convert.ToString(cenaY);
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Neispravan unos podataka");
            }
            catch (System.DivideByZeroException)
            {
                MessageBox.Show("Neispravan unos podataka");
            }

            

        }  

    }
    public class Blok
    {
        private double width, height, length, cena;
        public Blok()
        {
            this.width = this.height = this.length;
        }
        public Blok(double w, double h, double l)
        {
            this.width = w;
            this.height = h;
            this.length = l;
        }
        public void setWidth(double w)
        {
            this.width = w;
        }
        public double getWidth()
        {
            return this.width;
        }
        public void setHeight(double h)
        {
            this.height = h;
        }
        public double getHeight()
        {
            return this.height;
        }
        public void setLength(double l)
        {
            this.length = l;
        }
        public double getLength()
        {
            return this.length;
        }
        public void setCena(double c)
        {
            this.cena = c;
        }
        public double getCena()
        {
            return cena;
        }
    }
}