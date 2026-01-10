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
    public partial class KameraUlaz : Form
    {
        private FaceDetectionAndRecognition faceRec;
        private Home home;
        private Dictionary<string, int> detectionCounts = new Dictionary<string, int>();

        public KameraUlaz(FaceDetectionAndRecognition faceRec, Home home)
        {
            InitializeComponent();
            this.faceRec = faceRec;
            /* kada se dogodi faceRecognized u faceRec, pozovi faceDetectedHandler
             ne poziva metodu nego joj prosledjuje referencu */
            faceRec.FaceRecognized += FaceDetectedHandler;
            this.home = home;
            faceRec.open_camera(pictureBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* uklanjam metodu kao event handler, kada se dogodi FaceRecognized, FaceDetectedHandler se nece izvrsavati vise */
            faceRec.FaceRecognized-=FaceDetectedHandler;
            faceRec.close_camera();
            this.Close();
        }

        private void FaceDetectedHandler(string ime)
        {
            /* proveravam da li vec pratim ovo lice, ako ne postoji u Dictionary onda je ContainsKey=false i dodajem ga u Dictionary */
            if (!detectionCounts.ContainsKey(ime))
                detectionCounts[ime] = 0;

           /* ako kamera vidi lice, brojaci za sva ostala lica se resetuju */
            foreach (var key in detectionCounts.Keys.ToList())
            {
                if (key != ime)
                    detectionCounts[key] = 0;
            }

            /* povecavam brojac za trenutno lice */
            detectionCounts[ime]++;

            /* ako lice nije prepoznato u 3 razlicita framea, nista ne radi */
            if (detectionCounts[ime] < 3)
            {
                return;
            }
            else
            {
                home.addCurrentFaces(ime);
                faceRec.FaceRecognized -= FaceDetectedHandler;
                faceRec.close_camera();
                this.Close();
            }           
        }      
    }
}
