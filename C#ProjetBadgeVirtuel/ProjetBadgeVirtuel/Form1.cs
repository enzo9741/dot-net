using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjetBadgeVirtuel
{
    public partial class Form1 : Form
    {
        TcpSocket tcpSocket = new TcpSocket();
        int size = 16;
        int columns = 44;
        int rows = 11;
        PictureBox[] tabLed;
        Color backgroundColor = Color.White;
        Color selectedColor = Color.Red;
        int[] ledValue;
        string folderName = @"C:\LedtagsData";

        public Form1()
        {
            InitializeComponent();
            tabLed = new PictureBox[rows * columns];
            ledValue = new int[rows * columns];
            for (int iIndex = 0; iIndex < tabLed.Length; iIndex++)
            {
                ledValue[iIndex] = 0;
                tabLed[iIndex] = new PictureBox();
                tabLed[iIndex].Name = iIndex.ToString();
                tabLed[iIndex].Location = new Point(6 + (iIndex * size % (columns * size)), 6 + size * (iIndex * size / (columns * size)));
                tabLed[iIndex].Size = new Size(size, size);
                tabLed[iIndex].BackColor = backgroundColor;
                tabLed[iIndex].BorderStyle = BorderStyle.Fixed3D;
                tabLed[iIndex].MouseClick += new MouseEventHandler(pictureBox_MouseClick);
                panelLed.Controls.Add(tabLed[iIndex]);
            }

            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            foreach (string file in Directory.GetFiles(folderName))
            {
                listFiles.Items.Add(Path.GetFileName(file));
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            string data = "";
            foreach (int value in ledValue)
            {
                data += value.ToString();
            }

            tcpSocket.SetHost(textHost.Text);
            tcpSocket.SetPort(int.Parse(textPort.Text));
            tcpSocket.SendMessage(data);
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            PictureBox picutreBox = (PictureBox)sender;
            if(ledValue[Array.IndexOf(tabLed, picutreBox)] == 0)
            {
                picutreBox.BackColor = selectedColor;
                ledValue[Array.IndexOf(tabLed, picutreBox)] = 1;
            }
            else
            {
                picutreBox.BackColor = backgroundColor;
                ledValue[Array.IndexOf(tabLed, picutreBox)] = 0;
            }
        }

        public void SaveData()
        {

        }

        public void LoadData()
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string fileName = folderName + @"\" + textFileName.Text + ".data";
            string data = "";
            foreach (int value in ledValue)
            {
                data += value.ToString();
            }

            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, data);
                listFiles.Items.Add(Path.GetFileName(fileName));
            }
            else
            {
               ErrorMessage("File Already Exist");
            }
        }

        public void ErrorMessage(string message)
        {
            textError.Text = message;
            Console.WriteLine(message);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            string fileName = folderName + @"\" + listFiles.GetItemText(listFiles.SelectedItem);

            Console.WriteLine(fileName);
            if (File.Exists(fileName)) {
                File.Delete(fileName);
                listFiles.Items.Remove(listFiles.SelectedItem);
            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            string fileName = folderName + @"\" + listFiles.GetItemText(listFiles.SelectedItem);
            if (File.Exists(fileName))
            {
                string data = File.ReadAllText(fileName);
                for (int i = 0; i < data.Length; i++)
                {
                    int value = int.Parse(data[i].ToString());
                    PictureBox picutreBox = tabLed[i];
                    
                    if (value == 1)
                    {
                        picutreBox.BackColor = selectedColor;
                        ledValue[i] = 1;
                    }
                    else
                    {
                        picutreBox.BackColor = backgroundColor;
                        ledValue[i] = 0;
                    }
                }
            }
        }
    }
}
