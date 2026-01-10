using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;

namespace FaceDetectionAndRecognition
{
    public class FaceDetectionAndRecognition
    {        
        private Emgu.CV.Capture camera;
        private System.Windows.Forms.Timer timer;
        private PictureBox picture_box_live_camera;
        private CascadeClassifier face_cascade;
        /* u currentFrame smestam frame koji sam uslikao kada dodajem lice */
        private Image<Bgr, byte> currentFrame;
        /* pravim putanju do foldera, Path.Combine kombinuje dve putanje */
        string folder = Path.Combine(Application.StartupPath, "Faces");
        private LBPHFaceRecognizer recognizer;
        private bool model_trained = false;
        private int face_width = 200;
        private int face_height = 200;
        /* labelslist je lista imena osoba u sistemu */
        private List<string> labelslist = new List<string>();
        /* poziva se svaki put kada se prepozna lice kako bih pratio koliko puta se prepoznalo odredjeno lice */
        public event Action<string> FaceRecognized;
       
        public FaceDetectionAndRecognition()
        {            
            face_cascade = new CascadeClassifier("Haarcascade\\haarcascade_frontalface_alt.xml");
        }

        public void open_camera(PictureBox picture_box_camera)
        {            
            picture_box_live_camera = picture_box_camera;
            camera = new Emgu.CV.Capture(0);
            /* U slucaju da nije stigao da ocisti poslednji frejm prethodne sesije */
            /* for (int i = 0; i < 30; i++)
            {
                camera.QueryFrame();
                System.Threading.Thread.Sleep(30);
            } */
            camera.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, Convert.ToDouble(picture_box_camera.Width));
            camera.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, Convert.ToDouble(picture_box_camera.Height));            
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 33;
            /* timer.Tick je event koji se pokrece kada prodje interval koji sam postavio u timer.Interval */
            timer.Tick += Timer_tick;
            timer.Start();
        }

        private void Timer_tick(object sender, EventArgs e)
        {
            if (camera != null)
            {
                /* uzima jedan frame sa kamere, konvertuj ga da bude tipa Image<Bgr, byte>() i smesta ga u frame
                 pretvara ga u Image<BGR, byte>() jer je to Emgu.CV tip pogodan za crtanje i prikazivanje
                camera.QueryFrame() vraca Mat tip podataka */
                using (var frame = camera.QueryFrame().ToImage<Bgr, byte>())
                {                   
                    detect_face(frame);
                    /* ToBitmap() je metoda Emgu.CV klase koja se koristi za prikazivanje live slike */
                    picture_box_live_camera.Image = frame.ToBitmap();
                }
            }
        }

        /* saljem jedan frame sa kamere koja ce da izvrsi detekciju lica i prepoznavanje ako je model treniran */
        private void detect_face(Image<Bgr, byte> frame)
        {
            if (currentFrame != null)
            {
                currentFrame.Dispose();
            }
            currentFrame = frame.Clone();
            /* detekcija i LBPHFaceRecognizer rade nad grayscale slikom */
            using (var grayFrame = frame.Convert<Gray, byte>())
            {
                Rectangle[] faces = face_cascade.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty);

                foreach (var face in faces)
                {
                    if (model_trained)
                    {
                        var faceImg = grayFrame.GetSubRect(face).Resize(face_width, face_height, Inter.Cubic);
                        /* Predict vraca 2 vrednosti, vraca Label tj ID osobe za koju misli da je, i vraca distance tj slicnost sa tobom osobom */
                        var result = recognizer.Predict(faceImg);                        
                        if (result.Label >= 0 && result.Distance < 40)
                        {                            
                            string name = labelslist[result.Label];
                            frame.Draw(face, new Bgr(Color.Green), 1);
                            FaceRecognized?.Invoke(name);                           
                            //CvInvoke.PutText(frame, result.Distance.ToString(), new Point(face.X, face.Y - 30),
                               //FontFace.HersheyComplex, 1.0, new Bgr(Color.Blue).MCvScalar, 1);
                           // CvInvoke.PutText(frame, labelslist[result.Label].ToString(), new Point(face.X, face.Y - 10),
                                //FontFace.HersheyComplex, 1.0, new Bgr(Color.Blue).MCvScalar, 1);
                        }
                        else
                        {
                            frame.Draw(face, new Bgr(Color.Red), 1);
                            //CvInvoke.PutText(frame, result.Distance.ToString(), new Point(face.X, face.Y - 10), 
                                //FontFace.HersheyComplex, 1.0, new Bgr(Color.Red).MCvScalar, 1);
                        }
                    }
                    else
                    {
                        frame.Draw(face, new Bgr(Color.Blue), 1);
                    }
                }
            }
        }
        /* prolazi kroz svaki podfolder foldera Faces, ucitava slike lica, dodeljuje svakom folderu jedinstveni ID i priprema podatke za treniranje
         * LBPHFaceRecognizera  */
        public void TrainRecognizer()
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            /* niz podfoldera foldera Faces */
            string[] personFolders = Directory.GetDirectories(folder);
            if (personFolders.Length == 0)
            {
                model_trained = false;
                return;
            }
            /* u trainingImages se smestaju sve slike,grayscale, registrovanih lica u sistemu */
            List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
            /* labels je lista ID-jeva svake registrovane osobe */
            List<int> labels = new List<int>();
            labelslist.Clear();
            int labelIndex = 0;

            foreach (string personFolder in personFolders)
            {
                string personName = Path.GetFileName(personFolder);
                labelslist.Add(personName);

                string[] images = Directory.GetFiles(personFolder, "*.jpg");
                foreach (var imgPath in images)
                {
                    Image<Gray, byte> img = new Image<Gray, byte>(imgPath).Resize(face_width, face_height, Inter.Cubic);
                    trainingImages.Add(img);
                    labels.Add(labelIndex);
                }
                labelIndex++;
            }          
            recognizer = new LBPHFaceRecognizer(1, 8, 8, 8, 100);
            /* treniram recognizer i saljem mu niz slika i niz ID-jeva */
            recognizer.Train(trainingImages.ToArray(), labels.ToArray());
            model_trained = true;
        }
        /* prima ime osobe koju zelim da sacuvam, proverava da li je lice prikazano na kameru pomocu face_cascade.DetectMultiScale
         ako jeste prikazano lice, pravi novi folder koji se zove kao name koji sam prosledio i tu cuva sliku koju je kamera uslikala u trenutku kada
        sam pozvao save_face, sliku cuva pod jedinstvenim nazivom koji generise Guid.NewGuid */
        public void save_face(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Unesite ime osobe!");
                return;
            }
            else
            {
                using (var grayFrame = currentFrame.Convert<Gray, byte>())
                {
                    Rectangle[] faces = face_cascade.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty);
                    if (faces.Length > 1)
                    {
                        MessageBox.Show("Na kameri je prikazano više od jednog lica!");
                        return;
                    }
                    else if (faces.Length == 0)
                    {
                        MessageBox.Show("Na kameri ne postoji lice!");
                        return;
                    }
                    else
                    {
                        Image<Bgr, byte> faceImage = currentFrame.GetSubRect(faces[0]).Clone();
                        string personFolder = Path.Combine(folder, name);
                        if (!Directory.Exists(personFolder))
                        {
                            Directory.CreateDirectory(personFolder);
                        }
                        string filename = Path.Combine(personFolder, $"{Guid.NewGuid()}.jpg");
                        faceImage.Save(filename);                       
                        MessageBox.Show("Lice je uspešno sačuvano!");
                        TrainRecognizer();
                    }
                }
            }
        }

        public void delete_face(string name)
        {
            string personDir = Path.Combine(folder, name);

            if (Directory.Exists(personDir))
            {
                Directory.Delete(personDir, true);
                MessageBox.Show("Lice je uspešno obrisano.");
                TrainRecognizer();
            }
        }

        public void close_camera()
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Tick -= Timer_tick;
                timer = null;
            }
            if (camera != null)
            {
                camera.Dispose();
                camera = null;
            }
            if (picture_box_live_camera != null)
            {
                picture_box_live_camera.Image = null;
            }
        }

        public List<string> getAllFaces()
        {
            List<string> faceNames = new List<string>();
            string[] dirs = Directory.GetDirectories(folder);
            foreach (string dir in dirs)
            {
                string name = Path.GetFileName(dir);
                faceNames.Add(name);
            }
            return faceNames;
        }

        public int images_counter(string name)
        {
            int counter=0;
            string[] personFolders = Directory.GetDirectories(folder);
            foreach(string personFolder in personFolders)
            {
                if (Path.GetFileName(personFolder) == name)
                {
                    string[] images = Directory.GetFiles(personFolder, "*.jpg");
                    counter = images.Length;
                    break;
                }                                        
            }           
            return counter;
        }
    }
}
