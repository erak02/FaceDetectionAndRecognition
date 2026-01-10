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
    public partial class DodavanjeLica : Form
    {
        private FaceDetectionAndRecognition faceRec;
        int counter=1;
        public DodavanjeLica(FaceDetectionAndRecognition faceRec)
        {
            InitializeComponent();
            this.faceRec = faceRec;
            faceRec.open_camera(pictureBox1);
            label3.Text = "0";
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            faceRec.close_camera();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            string name = textBox1.Text.Trim();            
            faceRec.save_face(name);
            counter = faceRec.images_counter(name);
            label3.Text = $"{counter}";
        }    
    }
}
