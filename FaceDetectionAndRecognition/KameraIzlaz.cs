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
    public partial class KameraIzlaz : Form
    {
        private FaceDetectionAndRecognition faceRec;
        private Home home;
        private Dictionary<string, int> detectionCounts = new Dictionary<string, int>();
        public KameraIzlaz(FaceDetectionAndRecognition faceRec, Home home)
        {
            InitializeComponent();
            this.faceRec = faceRec;
            this.home = home;
            faceRec.FaceRecognized += FaceDetectedHandler;
            faceRec.open_camera(pictureBox1);
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            faceRec.FaceRecognized -= FaceDetectedHandler;
            faceRec.close_camera();
            this.Close();
        }

        private void FaceDetectedHandler(string ime)
        {
            if (!detectionCounts.ContainsKey(ime))
                detectionCounts[ime] = 0;

            foreach (var key in detectionCounts.Keys.ToList())
            {
                if (key != ime)
                    detectionCounts[key] = 0;
            }

            detectionCounts[ime]++;

            if (detectionCounts[ime] < 3)
            {
                return;
            }
            else 
            {
                home.removeCurrentFaces(ime);
                faceRec.FaceRecognized-= FaceDetectedHandler;
                faceRec.close_camera();
                this.Close();
            }           
        }
    }
}
