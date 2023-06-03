using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LED
{
    public partial class FrmLed : Form
    {
        CNetWork MyNetWork;
        private bool connexion;
        private string _message;
        private Thread tListener;
        int sizeled = 10;
        int Colonnes = 44;
        int Lignes = 11;
        PictureBox[] tabLed ;
        public string message
        {
            set
            {
                _message = value;
            }
        }
        public FrmLed()
        {
            InitializeComponent();
            tabLed = new PictureBox[Lignes * Colonnes];
            for (int iIndex = 0; iIndex < tabLed.Length; iIndex++)
            {
                tabLed[iIndex] = new PictureBox();
                tabLed[iIndex].Name = iIndex.ToString();
                tabLed[iIndex].Location = new Point(6 + (iIndex * sizeled % (Colonnes * sizeled)), 6 + sizeled * (iIndex * sizeled / (Colonnes * sizeled)));
                tabLed[iIndex].Size = new Size(sizeled, sizeled);
                tabLed[iIndex].BackColor = Color.Gray;
                tabLed[iIndex].BorderStyle = BorderStyle.Fixed3D;
                tbLED.Controls.Add(tabLed[iIndex]);
            }
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            if (this.connexion)
            {
                MyNetWork = null;
                if (tListener.IsAlive)
                {
                    lstlog.Items.Add("Suppression du processus d'écoute");
                    MyNetWork = null;
                    tListener.Abort();
                }

            }
            MyNetWork = new CNetWork(int.Parse(txtPorts.Text));
            MyNetWork.SomethingHappened += logSomethingHappenedFromLed;
            MyNetWork.RecevedMessage += RecevedMessageFromLed;

            this.connexion = false;
            tListener = new Thread(new ThreadStart(MyNetWork.StartListener));
            try
            {
                tListener.Start();
                lstlog.Items.Add("Lancement du processus d'écoute réussi");
                this.connexion = true;
            }
            catch (Exception eStart)
            {
                lstlog.Items.Add("Lancement du processus d'écoute Ko : " + eStart.ToString());
                this.connexion = false;
            }


        }

        private void RecevedMessageFromLed(string Message)
        {
            PictureBox pictureBox;
            if (Message != null)
                for (int iIndex = 0; iIndex < Message.Length; iIndex++)
                {
                    pictureBox = (PictureBox)tbLED.Controls.Find(iIndex.ToString(), true)[0]; // Remplacez "monPictureBox" par le nom réel de votre PictureBox
                    if (Message.Substring(iIndex, 1) == "1")
                        pictureBox.BackColor = Color.Red;
                    else
                        pictureBox.BackColor = Color.Gray;
                }

        }

        private void logSomethingHappenedFromLed(string Message)
        {
            //Console.WriteLine(Message);
            lstlog.Invoke(new Action(() => lstlog.Items.Add(Message)));
        }
    }
}
