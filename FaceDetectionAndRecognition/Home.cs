using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceDetectionAndRecognition
{
    public partial class Home : Form
    {
        public FaceDetectionAndRecognition FaceRec = new FaceDetectionAndRecognition();
        public Home home;
        public Home()        
        {
            InitializeComponent();
            FaceRec.TrainRecognizer();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KameraUlaz kameraUlaz = new KameraUlaz(FaceRec, this);
            kameraUlaz.ShowDialog();
        }

        private void button_dodaj_lice_Click(object sender, EventArgs e)
        {
            DodavanjeLica dodavanje = new DodavanjeLica(FaceRec);
            dodavanje.ShowDialog();
        }

        private void button_spisak_lica_Click(object sender, EventArgs e)
        {
            SpisakLica spisakLica = new SpisakLica(FaceRec);
            spisakLica.ShowDialog();
        }

        private void button_izlaz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void addCurrentFaces(string ime)
        {           
            if(!listBox1.Items.Contains(ime))
            {
                listBox1.Items.Add(ime);
                listBox2.Items.Add($"{DateTime.Now.ToString("HH:mm:ss")}   {ime} je ušao u sistem.");                
            }
        }

        public void removeCurrentFaces(string ime)
        {
            if(listBox1.Items.Contains(ime))
            {
                listBox1.Items.Remove(ime); 
                listBox2.Items.Add($"{DateTime.Now.ToString("HH:mm:ss")}   {ime} je izašao iz sistema.");
            }
        }

        private void button_camera_izlaz_Click(object sender, EventArgs e)
        {
            KameraIzlaz kameraIzlaz = new KameraIzlaz(FaceRec, this);
            kameraIzlaz.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
