/*
    SL FastMotion - A program that creates Time Lapse videos from your webcam or your Windows desktop.
    Copyright (C) 2014 Santiago Villafuerte <san.link@yahoo.com.mx> <http://migsantiago.com>
    
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
    
    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
    
    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WebCamLib; //Captura imagen desde alguna cámara
using System.Drawing.Imaging; // Para trabajar con imágenes
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace SL_FastMotion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /////////////////////////////////////////////////////////////////////////////
        //Variables globales de form1
        int cuadros_max;
        int cuadros_act;
        String ruta_inicial;
        String ver = "1.0.beta";
        FileStream archivo;
        StreamWriter escribir;
        String temp_folder_name = "temp_photos";
        String app_name = "SL_FastMotion";
        /////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////
        //Arranque de la aplicación
        private void Form1_Load(object sender, EventArgs e)
        {
            Device[] devices = DeviceManager.GetAllDevices();
            foreach (Device d in devices)
                cmbCamaras.Items.Add(d.Name);
            if (devices.Length > 0)
                cmbCamaras.SelectedIndex = 0;

            ruta_inicial = Application.StartupPath;
            this.Text = "SL FastMotion " + ver;

            AcercaDe();

            // Crea el directorio temp_photos y su contenido
            if (!Directory.Exists(ruta_inicial + "\\" + temp_folder_name))
            {
                try
                {
                    Directory.CreateDirectory(ruta_inicial + "\\" + temp_folder_name);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                }
            }

            Copia_Recurso("mencoder.exe");
            Copia_Recurso("pthreadGC2.dll");
        }
        /////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////
        //Copia un recurso al disco duro
        private void Copia_Recurso(string resourceName)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(app_name + "." + resourceName);
            FileStream fileStream = new FileStream(ruta_inicial + "\\" + temp_folder_name + "\\" + resourceName, FileMode.OpenOrCreate);
            for (int i = 0; i < stream.Length; i++)
                fileStream.WriteByte((byte)stream.ReadByte());
            fileStream.Close();
        }
        /////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////
        //Vista previa de la cámara
        private void btnVista_Click(object sender, EventArgs e)
        {
            try
            {
                Device d = DeviceManager.GetDevice(cmbCamaras.SelectedIndex);
                d.Stop();
                d.ShowWindow(this.pctVista);
            }
            catch
            {
                MessageBox.Show("Verifica que tu cámara esté bien instalada");
            }
        }
        /////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////
        //Inicio de la grabación
        private void btnInicia_Click(object sender, EventArgs e)
        {
            //Pregunta si debe borrar los archivos JPG y AVI existentes
            DialogResult p = MessageBox.Show(
                "Se eliminarán todos los archivos JPG, TXT y AVI\n"
                + "existentes en la carpeta " + temp_folder_name + ".\n"
                + "¿Desea continuar?", "Eliminar archivos previos",
                MessageBoxButtons.OKCancel);
            if (p == DialogResult.Cancel)
                return;

            //Elimina archivos JPG, TXT y AVI previos
            LimpiarTemp();

            //Inicia vista previa de la webcam solo si fue elegida
            if (rdWebcam.Checked == true)
            {
                //Selecciona la cámara y la muestra
                try
                {
                    Device d = DeviceManager.GetDevice(cmbCamaras.SelectedIndex);
                    d.Stop();
                    d.ShowWindow(this.pctVista);
                }
                catch
                {
                    MessageBox.Show("Verifica que tu cámara esté bien instalada");
                    return;
                }
            }

            //Verifica que los strings estén bien
            if (!VerificaFloat(txtTvideo.Text)) return;
            if (!VerificaFloat(txtTgraba.Text)) return;
            if (!VerificaFloat(txtTgrabaMin.Text)) return;

            //Cuadros máximos = segundos del video x 29.97
            cuadros_max = (int) (float.Parse(txtTvideo.Text) * 29.97F);
            cuadros_act = 0;

            //Calcula el tiempo entre cuadro y cuadro
            tmrEspera.Interval= (int)
                ( ((float.Parse(txtTgraba.Text)*3600F)
                  + (float.Parse(txtTgrabaMin.Text)*60F))
                / (float)cuadros_max * 1000F );
            lblDatos.Text = "Progreso: " +cuadros_act+ " de " +cuadros_max+ " cuadros";
            lblDatos2.Text= "Tiempo entre cuadros: "+((float)tmrEspera.Interval/1000F)+"s";
            lblDatos3.Text= "Fin: " +
                (DateTime.Now + new TimeSpan(0,0,0,0,tmrEspera.Interval*cuadros_max));
            lblDatos4.Text ="Velocidad: "
                + (((float.Parse(txtTgraba.Text)*3600F)+(float.Parse(txtTgrabaMin.Text)*60F)) 
                / float.Parse(txtTvideo.Text)) +"x";

            //Verificar que periodo de muestreo no sea menor a 1s
            if (tmrEspera.Interval < 1000)
            {
                DialogResult q = MessageBox.Show("El periodo de muestreo es menor a 1s.\n"
                    +"¿Ejecutar aún así?", "Advertencia", MessageBoxButtons.OKCancel);
                if (q == DialogResult.Cancel)
                    return;
            }

            //Inicializa timer y contadores
            cuadros_act = 0;
            tmrEspera.Enabled = true;
            rdWebcam.Enabled = false;
            rdPrintscreen.Enabled = false;
            cmbCamaras.Enabled = false;
            btnVista.Enabled = false;
            btnInicia.Enabled = false;
            btnDetiene.Enabled = true;
            btnAcercaDe.Enabled = false;
            txtTgraba.Enabled = false;
            txtTgrabaMin.Enabled = false;
            txtTvideo.Enabled = false;
            btnLimpiar.Enabled = false;
            btnCalculadora.Enabled = false;

            //Crea lista del orden de los JPG
            archivo = new FileStream(ruta_inicial + "\\" + temp_folder_name + "\\list.txt",
                FileMode.OpenOrCreate, FileAccess.Write);
            escribir = new StreamWriter(archivo);
        }
        /////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////
        //Verifica que un texto pueda convertirse a float
        //true: el str está bien
        bool VerificaFloat(String str)
        {
            try
            {
                float.Parse(str);
            }
            catch
            {
                MessageBox.Show("Capture un número real, error en: " + str);
                return false;
            }
            return true;
        }
        /////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////
        //Elimina archivos JPG, TXT y AVI previos
        void LimpiarTemp()
        {
            string[] files = System.IO.Directory.GetFiles(ruta_inicial + "\\" + temp_folder_name);
            FileInfo fi;
            foreach (string s in files)
            {
                fi = new FileInfo(s);
                if ((fi.Extension == ".jpg") || (fi.Extension == ".avi"))
                    File.Delete(s);
            }
            //Elimina lista de orden
            if (File.Exists(ruta_inicial + "\\" + temp_folder_name + "\\list.txt"))
                File.Delete(ruta_inicial + "\\" + temp_folder_name + "\\list.txt");
        }
        /////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////
        //Termina grabación
        private void btnDetiene_Click(object sender, EventArgs e)
        {
            tmrEspera.Enabled = false;
            if (rdWebcam.Checked == true)
            {
                cmbCamaras.Enabled = true;
                btnVista.Enabled = true;
            }
            rdWebcam.Enabled = true;
            rdPrintscreen.Enabled = true;
            btnInicia.Enabled = true;
            btnDetiene.Enabled = false;
            btnAcercaDe.Enabled = true;
            txtTgraba.Enabled = true;
            txtTgrabaMin.Enabled = true;
            txtTvideo.Enabled = true;
            btnLimpiar.Enabled = true;
            btnCalculadora.Enabled = true;
            cuadros_act = 0;
            escribir.Close();
            archivo.Close();
        }
        /////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////
        //Aquí llega cada que hay que tomar una fotografía
        private void tmrEspera_Tick(object sender, EventArgs e)
        {
            Image temp;

            if (rdWebcam.Checked == true)
            {
                Device d = DeviceManager.GetDevice(cmbCamaras.SelectedIndex);
                //Captura la imagen
                Device.SendMessage(d.deviceHandle, Device.WM_CAP_GET_FRAME, 0, 0);
                //La copia al portapeles
                Device.SendMessage(d.deviceHandle, Device.WM_CAP_COPY, 0, 0);
                temp = Clipboard.GetImage();
                Device.EmptyClipboard(); //Vacía el portapapeles
            }
            else
            {
                int y = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                int x = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                temp = new Bitmap(x, y);
                Graphics g = Graphics.FromImage(temp);
                g.CopyFromScreen(0, 0, 0, 0, temp.Size);
                //Muestra la vista previa del escritorio
                pctVista.Image = temp;
            }

            //Agrega fecha y detalles a la foto
            Graphics tempg = Graphics.FromImage(temp);
            tempg.FillRectangle(new SolidBrush(Color.Black), 0, 0, 200, 36);
            tempg.DrawString(DateTime.Now.ToString(), new Font("Arial", 12F),
                new SolidBrush(Color.White), new PointF(0, 0));
            tempg.DrawString("SL FastMotion " + ver, new Font("Arial", 12F),
                new SolidBrush(Color.White), new PointF(0, 18));

            temp.Save(ruta_inicial + "\\" + "\\" + temp_folder_name  + "\\imagen" + cuadros_act + ".jpg",
                ImageFormat.Jpeg);
            //Agrega JPG a la lista
            escribir.WriteLine("imagen" + cuadros_act + ".jpg");
            ++cuadros_act;
            lblDatos.Text = "Progreso " + cuadros_act + " de " + cuadros_max + " cuadros";

            //Si ya se capturaron todos los cuadros
            if (cuadros_act == cuadros_max)
            {
                tmrEspera.Enabled = false;
                if (rdWebcam.Checked == true)
                {
                    cmbCamaras.Enabled = true;
                    btnVista.Enabled = true;
                }
                rdWebcam.Enabled = true;
                rdPrintscreen.Enabled = true;
                btnInicia.Enabled = true;
                btnDetiene.Enabled = false;
                btnAcercaDe.Enabled = true;
                txtTgraba.Enabled = true;
                txtTgrabaMin.Enabled = true;
                txtTvideo.Enabled = true;
                btnLimpiar.Enabled = true;
                btnCalculadora.Enabled = true;

                //Termina lista de JPG
                escribir.Close();
                archivo.Close();

                //Arranca mencoder para generar video
                Process proc = new Process();
                proc.StartInfo.FileName = ruta_inicial + "\\" + temp_folder_name + "\\mencoder.exe";
                proc.StartInfo.WorkingDirectory = ruta_inicial + "\\" + temp_folder_name;
                String arg =
                    " mf://@list.txt -mf fps=29.97:type=jpg "
                    + "-ovc lavc -lavcopts vcodec=mpeg4"
                    + ":vbitrate=8192"
                    + ":mbd=2:trell"
                    + " -oac copy -o ";

                String filename_avi =
                    "slfm_" 
                    + DateTime.Now.ToString("yyyyMMdd_HHmmss")
                    + ".avi";

                arg += filename_avi + " -vf";
                //Si es video webcam la escala será 640*480
                if (rdWebcam.Checked == true)
                    arg = arg + " scale=640:480";
                //Si es impresión de pantalla la resolución será la del desktop
                else
                {
                    int y = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                    int x = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                    arg = arg + " scale=" + x + ":" + y;
                }
                proc.StartInfo.Arguments = arg;
                Boolean result = proc.Start();
                proc.WaitForExit();

                //Reproduce audio para notificar fin de grabación
                System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
                myPlayer.SoundLocation = ruta_inicial + "\\notify.wav";
                myPlayer.Play();

                //Abre video si el usuario así lo quiso
                if(chkAbrir.Checked==true)
                    Process.Start(ruta_inicial + "\\" + temp_folder_name + "\\" + filename_avi);
            }
        }
        /////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////
        //Botón Acerca de
        private void btnAcercaDe_Click(object sender, EventArgs e)
        {
            AcercaDe();
        }
        /////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////
        //Función acerca de
        private void AcercaDe()
        {
            MessageBox.Show(
"SL FastMotion v." + ver + "\n\n"
+
@"Copyright (C) 2014 Santiago Villafuerte <san.link@yahoo.com.mx>
http://www.migsantiago.com

Liberado con GNU GPL, ver detalles al final.

SL FastMotion - Un programa que crea videos
en cámara rápida a partir de una cámara web
o del escritorio de Windows.

Basado en:
WebCamLib.dll - Source?
MEncoder.exe - http://www.mplayerhq.hu/design7/dload.html

El uso de este software es bajo única
responsabilidad del usuario final.

"
+ 
@"SL FastMotion - A program that creates Time Lapse videos from your webcam or your Windows desktop.
Copyright (C) 2014 Santiago Villafuerte <san.link@yahoo.com.mx>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>."

                , "Acerca de y Disclaimer");
        }
        /////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////
        private void lblLink_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.migsantiago.com");
        }
        /////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////
        //Selección del origen de video
        private void rdPrintscreen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPrintscreen.Checked == true)
            {
                cmbCamaras.Enabled = false;
                btnVista.Enabled = false;
                Device d = DeviceManager.GetDevice(cmbCamaras.SelectedIndex);
                d.Stop();
            }
            else
            {
                cmbCamaras.Enabled = true;
                btnVista.Enabled = true;
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPrintscreen.Checked == true)
            {
                cmbCamaras.Enabled = false;
                btnVista.Enabled = false;
                Device d = DeviceManager.GetDevice(cmbCamaras.SelectedIndex);
                d.Stop();
            }
            else
            {
                cmbCamaras.Enabled = true;
                btnVista.Enabled = true;
            }
        }
        /////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("¿Desea eliminar los archivos temporales\n"
                + "de la carpeta " + temp_folder_name + "?", "Limpiar carpeta",
                MessageBoxButtons.OKCancel);
            if(r==DialogResult.OK)
                LimpiarTemp();
        }
        /////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////
        //Pre-calcula los tiempos y velocidades del video
        private void btnCalculadora_Click(object sender, EventArgs e)
        {
            int espera, cmax;
            String c1, c2, c3, c4;

            //Verifica que los strings estén bien
            if (!VerificaFloat(txtTvideo.Text)) return;
            if (!VerificaFloat(txtTgraba.Text)) return;
            if (!VerificaFloat(txtTgrabaMin.Text)) return;

            //Cuadros máximos = segundos del video x 29.97
            cmax = (int)(float.Parse(txtTvideo.Text) * 29.97F);
            //Tiempo entre cuadros (ms) = Tgrabación / cuadros_max * 1000
            espera = (int)
                (((float.Parse(txtTgraba.Text) * 3600F)
                  + (float.Parse(txtTgrabaMin.Text) * 60F))
                / (float)cmax * 1000F);
            c1 = cmax + " cuadros a grabar.\n";
            c2 = "Tiempo entre cuadros: " + ((float)espera / 1000F) + "s\n";
            c3 = "Fin aprox.: " + (DateTime.Now + new TimeSpan(0, 0, 0, 0, espera * cmax)) + "\n";
            c4 = "Velocidad: "
                + (((float.Parse(txtTgraba.Text) * 3600F) + (float.Parse(txtTgrabaMin.Text) * 60F))
                / float.Parse(txtTvideo.Text)) + "x\n";

            MessageBox.Show(c1 + c2 + c3 + c4, "Cálculos previos");
        }
        /////////////////////////////////////////////////////////////////////////////
    }
}
