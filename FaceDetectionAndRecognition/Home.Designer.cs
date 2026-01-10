namespace FaceDetectionAndRecognition
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.button_kamera_ulaz = new System.Windows.Forms.Button();
            this.button_camera_izlaz = new System.Windows.Forms.Button();
            this.button_dodaj_lice = new System.Windows.Forms.Button();
            this.button_spisak_lica = new System.Windows.Forms.Button();
            this.button_izlaz = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_kamera_ulaz
            // 
            this.button_kamera_ulaz.BackColor = System.Drawing.SystemColors.Control;
            this.button_kamera_ulaz.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_kamera_ulaz.Location = new System.Drawing.Point(12, 21);
            this.button_kamera_ulaz.Name = "button_kamera_ulaz";
            this.button_kamera_ulaz.Size = new System.Drawing.Size(160, 60);
            this.button_kamera_ulaz.TabIndex = 0;
            this.button_kamera_ulaz.Text = "Kamera na ulazu";
            this.button_kamera_ulaz.UseVisualStyleBackColor = false;
            this.button_kamera_ulaz.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_camera_izlaz
            // 
            this.button_camera_izlaz.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_camera_izlaz.Location = new System.Drawing.Point(12, 111);
            this.button_camera_izlaz.Name = "button_camera_izlaz";
            this.button_camera_izlaz.Size = new System.Drawing.Size(160, 60);
            this.button_camera_izlaz.TabIndex = 1;
            this.button_camera_izlaz.Text = "Kamera na izlazu";
            this.button_camera_izlaz.UseVisualStyleBackColor = true;
            this.button_camera_izlaz.Click += new System.EventHandler(this.button_camera_izlaz_Click);
            // 
            // button_dodaj_lice
            // 
            this.button_dodaj_lice.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_dodaj_lice.Location = new System.Drawing.Point(12, 201);
            this.button_dodaj_lice.Name = "button_dodaj_lice";
            this.button_dodaj_lice.Size = new System.Drawing.Size(160, 60);
            this.button_dodaj_lice.TabIndex = 2;
            this.button_dodaj_lice.Text = "Dodaj lice u sistem";
            this.button_dodaj_lice.UseVisualStyleBackColor = true;
            this.button_dodaj_lice.Click += new System.EventHandler(this.button_dodaj_lice_Click);
            // 
            // button_spisak_lica
            // 
            this.button_spisak_lica.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_spisak_lica.Location = new System.Drawing.Point(12, 291);
            this.button_spisak_lica.Name = "button_spisak_lica";
            this.button_spisak_lica.Size = new System.Drawing.Size(160, 60);
            this.button_spisak_lica.TabIndex = 3;
            this.button_spisak_lica.Text = "Spisak svih lica";
            this.button_spisak_lica.UseVisualStyleBackColor = true;
            this.button_spisak_lica.Click += new System.EventHandler(this.button_spisak_lica_Click);
            // 
            // button_izlaz
            // 
            this.button_izlaz.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_izlaz.Location = new System.Drawing.Point(12, 573);
            this.button_izlaz.Name = "button_izlaz";
            this.button_izlaz.Size = new System.Drawing.Size(160, 60);
            this.button_izlaz.TabIndex = 4;
            this.button_izlaz.Text = "Izlaz";
            this.button_izlaz.UseVisualStyleBackColor = true;
            this.button_izlaz.Click += new System.EventHandler(this.button_izlaz_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Control;
            this.listBox1.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(632, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(234, 310);
            this.listBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(628, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Trenutno se u sistemu nalaze: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(880, 611);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.SystemColors.Control;
            this.listBox2.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 15;
            this.listBox2.Location = new System.Drawing.Point(632, 388);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(323, 154);
            this.listBox2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(628, 364);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Evidencija dolazaka/odlzaka";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button_izlaz);
            this.Controls.Add(this.button_spisak_lica);
            this.Controls.Add(this.button_dodaj_lice);
            this.Controls.Add(this.button_camera_izlaz);
            this.Controls.Add(this.button_kamera_ulaz);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_kamera_ulaz;
        private System.Windows.Forms.Button button_camera_izlaz;
        private System.Windows.Forms.Button button_dodaj_lice;
        private System.Windows.Forms.Button button_spisak_lica;
        private System.Windows.Forms.Button button_izlaz;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label3;
    }
}

