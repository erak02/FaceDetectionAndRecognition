using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceDetectionAndRecognition
{
    public partial class SpisakLica : Form
    {
        private FaceDetectionAndRecognition faceRec;
        public SpisakLica(FaceDetectionAndRecognition faceRec)
        {
            InitializeComponent();
            this.faceRec = faceRec;
            refreshFaceList();
            listBox1.Items.Clear();
            var names = faceRec.getAllFaces();
            foreach(var name in names)
            {
                listBox1.Items.Add(name);
            }                        
        }

        private void refreshFaceList()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(faceRec.getAllFaces().ToArray());                                     
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_delete_face_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Izaberite lice koje želite da obrišete!");
                return;
            }
            else
            {
                string selectedFace = listBox1.SelectedItem.ToString();
                var confirm = MessageBox.Show($"Da li ste sigurni da želite da obrišete '{selectedFace}'?", "Potvrdite brisanje", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    faceRec.delete_face(selectedFace);
                    refreshFaceList();
                }
            }
        }
    }
}
