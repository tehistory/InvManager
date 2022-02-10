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
        DataHandler myDataHandler;
        public Form1()
        {
            myDataHandler = new DataHandler();
            InitializeComponent();
            comboBox1.Items.AddRange(myDataHandler.getContainers());
        }

    //    //Load File Button
    //    string file = textBox1.Text;

    //        if (myDataHandler.loadFile(file))
    //        {
    //            comboBox1.Items.Clear();
    //            String[] tempArray = myDataHandler.getContainers();
    //            for (int i = 0; i<tempArray.Length; i++)
    //            {
    //                comboBox1.Items.Add(tempArray[i]);
    //            }

    //            comboBox1.Update();
    //            string tempText = label1.Text;
    //            label1.Text = tempText + file;
    //        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                listBox1.DataSource = myDataHandler.getItems(comboBox1.SelectedItem.ToString());

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
                myDataHandler.createContainer(popUp.textBox1.Text);
                comboBox1.Items.Add(popUp.textBox1.Text);
                comboBox1.Update();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Add Item Button
            Form2 popUp = new Form2();

            popUp.label1.Text = "ADD ITEM: Container: " + comboBox1.SelectedItem.ToString() + " Item Name: ";

            if (popUp.ShowDialog() == DialogResult.OK)
            {
                myDataHandler.addItem(comboBox1.SelectedItem.ToString(), popUp.textBox1.Text);
                comboBox1.Update();
                comboBox1_SelectedIndexChanged(this, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Search button
            listBox1.DataSource = myDataHandler.searchItem(textBox2.Text);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Delete Item button
            DeleteWin popUp = new DeleteWin();

            //popUp.label1.Text = "DELETE ITEM: Container: " + comboBox1.SelectedItem.ToString() + " Item Name: ";

            popUp.comboBox1.Items.AddRange(myDataHandler.getItems(comboBox1.SelectedItem.ToString()));

            if (popUp.ShowDialog() == DialogResult.OK)
            {
                myDataHandler.subItem(comboBox1.SelectedItem.ToString(), popUp.comboBox1.SelectedItem.ToString());
                comboBox1.Update();
                comboBox1_SelectedIndexChanged(this, e);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Sort All List Items Button
            myDataHandler.SortArrays();
            comboBox1.Update();
            comboBox1_SelectedIndexChanged(this, e);
        }

    }
}
