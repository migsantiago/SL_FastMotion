namespace SL_FastMotion
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCamaras = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pctVista = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTvideo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTgraba = new System.Windows.Forms.TextBox();
            this.btnInicia = new System.Windows.Forms.Button();
            this.btnDetiene = new System.Windows.Forms.Button();
            this.btnVista = new System.Windows.Forms.Button();
            this.tmrEspera = new System.Windows.Forms.Timer(this.components);
            this.lblDatos = new System.Windows.Forms.Label();
            this.lblDatos2 = new System.Windows.Forms.Label();
            this.lblDatos3 = new System.Windows.Forms.Label();
            this.btnAcercaDe = new System.Windows.Forms.Button();
            this.lblDatos4 = new System.Windows.Forms.Label();
            this.lblLink = new System.Windows.Forms.Label();
            this.chkAbrir = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTgrabaMin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.grpBox1 = new System.Windows.Forms.GroupBox();
            this.rdWebcam = new System.Windows.Forms.RadioButton();
            this.rdPrintscreen = new System.Windows.Forms.RadioButton();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCalculadora = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctVista)).BeginInit();
            this.grpBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(15, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Creación de videos en cámara rápida";
            // 
            // cmbCamaras
            // 
            this.cmbCamaras.Enabled = false;
            this.cmbCamaras.FormattingEnabled = true;
            this.cmbCamaras.Location = new System.Drawing.Point(6, 65);
            this.cmbCamaras.Name = "cmbCamaras";
            this.cmbCamaras.Size = new System.Drawing.Size(228, 21);
            this.cmbCamaras.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Duración del video final:";
            // 
            // pctVista
            // 
            this.pctVista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pctVista.Location = new System.Drawing.Point(307, 30);
            this.pctVista.Name = "pctVista";
            this.pctVista.Size = new System.Drawing.Size(192, 144);
            this.pctVista.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctVista.TabIndex = 2;
            this.pctVista.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Vista previa";
            // 
            // txtTvideo
            // 
            this.txtTvideo.Location = new System.Drawing.Point(142, 158);
            this.txtTvideo.Name = "txtTvideo";
            this.txtTvideo.Size = new System.Drawing.Size(43, 20);
            this.txtTvideo.TabIndex = 0;
            this.txtTvideo.Text = "10";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Duración de la grabación:";
            // 
            // txtTgraba
            // 
            this.txtTgraba.Location = new System.Drawing.Point(150, 180);
            this.txtTgraba.Name = "txtTgraba";
            this.txtTgraba.Size = new System.Drawing.Size(26, 20);
            this.txtTgraba.TabIndex = 1;
            this.txtTgraba.Text = "1";
            // 
            // btnInicia
            // 
            this.btnInicia.Location = new System.Drawing.Point(18, 232);
            this.btnInicia.Name = "btnInicia";
            this.btnInicia.Size = new System.Drawing.Size(107, 27);
            this.btnInicia.TabIndex = 4;
            this.btnInicia.Text = "Iniciar grabación";
            this.btnInicia.UseVisualStyleBackColor = true;
            this.btnInicia.Click += new System.EventHandler(this.btnInicia_Click);
            // 
            // btnDetiene
            // 
            this.btnDetiene.Enabled = false;
            this.btnDetiene.Location = new System.Drawing.Point(138, 232);
            this.btnDetiene.Name = "btnDetiene";
            this.btnDetiene.Size = new System.Drawing.Size(107, 27);
            this.btnDetiene.TabIndex = 5;
            this.btnDetiene.Text = "Detener grabación";
            this.btnDetiene.UseVisualStyleBackColor = true;
            this.btnDetiene.Click += new System.EventHandler(this.btnDetiene_Click);
            // 
            // btnVista
            // 
            this.btnVista.Enabled = false;
            this.btnVista.Image = ((System.Drawing.Image)(resources.GetObject("btnVista.Image")));
            this.btnVista.Location = new System.Drawing.Point(240, 59);
            this.btnVista.Name = "btnVista";
            this.btnVista.Size = new System.Drawing.Size(27, 27);
            this.btnVista.TabIndex = 3;
            this.btnVista.UseVisualStyleBackColor = true;
            this.btnVista.Click += new System.EventHandler(this.btnVista_Click);
            // 
            // tmrEspera
            // 
            this.tmrEspera.Tick += new System.EventHandler(this.tmrEspera_Tick);
            // 
            // lblDatos
            // 
            this.lblDatos.AutoSize = true;
            this.lblDatos.Location = new System.Drawing.Point(304, 187);
            this.lblDatos.MaximumSize = new System.Drawing.Size(160, 30);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(46, 13);
            this.lblDatos.TabIndex = 6;
            this.lblDatos.Text = "Cuadros";
            // 
            // lblDatos2
            // 
            this.lblDatos2.AutoSize = true;
            this.lblDatos2.Location = new System.Drawing.Point(304, 201);
            this.lblDatos2.MaximumSize = new System.Drawing.Size(160, 30);
            this.lblDatos2.Name = "lblDatos2";
            this.lblDatos2.Size = new System.Drawing.Size(43, 13);
            this.lblDatos2.TabIndex = 6;
            this.lblDatos2.Text = "Periodo";
            // 
            // lblDatos3
            // 
            this.lblDatos3.AutoSize = true;
            this.lblDatos3.Location = new System.Drawing.Point(304, 215);
            this.lblDatos3.MaximumSize = new System.Drawing.Size(160, 30);
            this.lblDatos3.Name = "lblDatos3";
            this.lblDatos3.Size = new System.Drawing.Size(21, 13);
            this.lblDatos3.TabIndex = 6;
            this.lblDatos3.Text = "Fin";
            // 
            // btnAcercaDe
            // 
            this.btnAcercaDe.Image = ((System.Drawing.Image)(resources.GetObject("btnAcercaDe.Image")));
            this.btnAcercaDe.Location = new System.Drawing.Point(259, 14);
            this.btnAcercaDe.Name = "btnAcercaDe";
            this.btnAcercaDe.Size = new System.Drawing.Size(27, 27);
            this.btnAcercaDe.TabIndex = 7;
            this.btnAcercaDe.UseVisualStyleBackColor = true;
            this.btnAcercaDe.Click += new System.EventHandler(this.btnAcercaDe_Click);
            // 
            // lblDatos4
            // 
            this.lblDatos4.AutoSize = true;
            this.lblDatos4.Location = new System.Drawing.Point(304, 229);
            this.lblDatos4.MaximumSize = new System.Drawing.Size(160, 30);
            this.lblDatos4.Name = "lblDatos4";
            this.lblDatos4.Size = new System.Drawing.Size(54, 13);
            this.lblDatos4.TabIndex = 6;
            this.lblDatos4.Text = "Velocidad";
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLink.ForeColor = System.Drawing.Color.Blue;
            this.lblLink.Location = new System.Drawing.Point(15, 27);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(170, 13);
            this.lblLink.TabIndex = 0;
            this.lblLink.Text = "http://www.migsantiago.com";
            this.lblLink.Click += new System.EventHandler(this.lblLink_Click);
            // 
            // chkAbrir
            // 
            this.chkAbrir.AutoSize = true;
            this.chkAbrir.Checked = true;
            this.chkAbrir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAbrir.Location = new System.Drawing.Point(18, 202);
            this.chkAbrir.Name = "chkAbrir";
            this.chkAbrir.Size = new System.Drawing.Size(125, 17);
            this.chkAbrir.TabIndex = 4;
            this.chkAbrir.Text = "Abrir video al finalizar";
            this.chkAbrir.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "h";
            // 
            // txtTgrabaMin
            // 
            this.txtTgrabaMin.Location = new System.Drawing.Point(195, 180);
            this.txtTgrabaMin.Name = "txtTgrabaMin";
            this.txtTgrabaMin.Size = new System.Drawing.Size(26, 20);
            this.txtTgrabaMin.TabIndex = 2;
            this.txtTgrabaMin.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(223, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "min";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(191, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "seg";
            // 
            // grpBox1
            // 
            this.grpBox1.Controls.Add(this.rdWebcam);
            this.grpBox1.Controls.Add(this.rdPrintscreen);
            this.grpBox1.Controls.Add(this.cmbCamaras);
            this.grpBox1.Controls.Add(this.btnVista);
            this.grpBox1.Location = new System.Drawing.Point(19, 53);
            this.grpBox1.Name = "grpBox1";
            this.grpBox1.Size = new System.Drawing.Size(275, 100);
            this.grpBox1.TabIndex = 8;
            this.grpBox1.TabStop = false;
            this.grpBox1.Text = "Seleccionar origen de las imágenes";
            // 
            // rdWebcam
            // 
            this.rdWebcam.AutoSize = true;
            this.rdWebcam.Location = new System.Drawing.Point(6, 42);
            this.rdWebcam.Name = "rdWebcam";
            this.rdWebcam.Size = new System.Drawing.Size(198, 17);
            this.rdWebcam.TabIndex = 1;
            this.rdWebcam.Text = "Grabar desde dispositivo de captura:";
            this.rdWebcam.UseVisualStyleBackColor = true;
            this.rdWebcam.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdPrintscreen
            // 
            this.rdPrintscreen.AutoSize = true;
            this.rdPrintscreen.Checked = true;
            this.rdPrintscreen.Location = new System.Drawing.Point(6, 19);
            this.rdPrintscreen.Name = "rdPrintscreen";
            this.rdPrintscreen.Size = new System.Drawing.Size(164, 17);
            this.rdPrintscreen.TabIndex = 0;
            this.rdPrintscreen.TabStop = true;
            this.rdPrintscreen.Text = "Grabar escritorio de Windows";
            this.rdPrintscreen.UseVisualStyleBackColor = true;
            this.rdPrintscreen.CheckedChanged += new System.EventHandler(this.rdPrintscreen_CheckedChanged);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(259, 232);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(27, 27);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCalculadora
            // 
            this.btnCalculadora.Image = ((System.Drawing.Image)(resources.GetObject("btnCalculadora.Image")));
            this.btnCalculadora.Location = new System.Drawing.Point(259, 173);
            this.btnCalculadora.Name = "btnCalculadora";
            this.btnCalculadora.Size = new System.Drawing.Size(27, 27);
            this.btnCalculadora.TabIndex = 3;
            this.btnCalculadora.UseVisualStyleBackColor = true;
            this.btnCalculadora.Click += new System.EventHandler(this.btnCalculadora_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 268);
            this.Controls.Add(this.btnCalculadora);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.grpBox1);
            this.Controls.Add(this.chkAbrir);
            this.Controls.Add(this.btnAcercaDe);
            this.Controls.Add(this.lblDatos4);
            this.Controls.Add(this.lblDatos3);
            this.Controls.Add(this.lblDatos2);
            this.Controls.Add(this.lblDatos);
            this.Controls.Add(this.btnDetiene);
            this.Controls.Add(this.btnInicia);
            this.Controls.Add(this.txtTgrabaMin);
            this.Controls.Add(this.txtTgraba);
            this.Controls.Add(this.txtTvideo);
            this.Controls.Add(this.pctVista);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(565, 306);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SL FastMotion";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctVista)).EndInit();
            this.grpBox1.ResumeLayout(false);
            this.grpBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCamaras;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pctVista;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTvideo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTgraba;
        private System.Windows.Forms.Button btnInicia;
        private System.Windows.Forms.Button btnDetiene;
        private System.Windows.Forms.Button btnVista;
        private System.Windows.Forms.Timer tmrEspera;
        private System.Windows.Forms.Label lblDatos;
        private System.Windows.Forms.Label lblDatos2;
        private System.Windows.Forms.Label lblDatos3;
        private System.Windows.Forms.Button btnAcercaDe;
        private System.Windows.Forms.Label lblDatos4;
        private System.Windows.Forms.Label lblLink;
        private System.Windows.Forms.CheckBox chkAbrir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTgrabaMin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox grpBox1;
        private System.Windows.Forms.RadioButton rdWebcam;
        private System.Windows.Forms.RadioButton rdPrintscreen;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCalculadora;
    }
}

