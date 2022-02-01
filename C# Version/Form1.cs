using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvManager
{
    public partial class Form1 : Form
    {
        DataHandler myData;
        public Form1()
        {
            myData = new DataHandler();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create File Button
            myData.createFile(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Load File Button
            string file = textBox1.Text;

            if(myData.loadFile(file))
            {
                comboBox1.DataSource = myData.getContainers();
                string tempText = label1.Text;
                label1.Text = tempText + file;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            myData.SaveToFile();
        }
    }
}
