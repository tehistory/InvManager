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
                String[] tempArray = myData.getContainers();
                for (int i = 0; i < tempArray.Length; i++)
                {
                    comboBox1.Items.Add(tempArray[i]);
                }

                comboBox1.Update();
                string tempText = label1.Text;
                label1.Text = tempText + file;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Save File Button
            myData.SaveToFile();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tempText = "--------------------------------------------------------\n";
            try
            {
                String[] itemArray = myData.getItems(comboBox1.SelectedItem.ToString());

                if (itemArray == null)
                {
                    tempText = "Container doesn't Exist";
                }
                else
                {
                    for (int i = 1; i < itemArray.Length; i++)
                    {
                        tempText = tempText + itemArray[i] + '\n';
                    }
                }

                richTextBox1.Text = tempText;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "load fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Create Container button
            Form2 popUp = new Form2();

            if(popUp.ShowDialog() == DialogResult.OK)
            {
                myData.createContainer(popUp.textBox1.Text);
                comboBox1.Update();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Add Item Button
            Form2 popUp = new Form2();

            popUp.label1.Text = "Container: " + comboBox1.SelectedItem.ToString() + " Item Name: ";

            if (popUp.ShowDialog() == DialogResult.OK)
            {
                myData.addItem(comboBox1.SelectedItem.ToString(), popUp.textBox1.Text);
                comboBox1.Update();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Search button
            String[] itemArray = myData.searchItem(textBox2.Text);

            string tempText = "Results \n --------------------------------------------------------\n";

            for (int i = 1; i < itemArray.Length; i++)
            {
                tempText = tempText + itemArray[i] + '\n';
            }

            richTextBox1.Text = tempText;
        }
    }
}
