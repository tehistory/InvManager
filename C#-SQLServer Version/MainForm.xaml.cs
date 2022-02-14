using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InvManager
{
    /// <summary>
    /// Interaction logic for MainForm.xaml
    /// </summary>
    public partial class MainForm : System.Windows.Controls.UserControl
    {
        DataHandler myDataHandler;
        public MainForm()
        {
            myDataHandler = new DataHandler();
            InitializeComponent();
            ConBox.ItemsSource = myDataHandler.getContainers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Search Button
            DisplayBox.ItemsSource = myDataHandler.searchItem(SearchText.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Create Container Button
            Form2 popUp = new Form2();

            if (popUp.ShowDialog() == DialogResult.OK)
            {
                myDataHandler.createContainer(popUp.textBox1.Text);
                ConBox.Items.Add(popUp.textBox1.Text);
                
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Add Item Button
            Form2 popUp = new Form2();

            popUp.label1.Text = "ADD ITEM: Container: " + ConBox.SelectedItem.ToString() + " Item Name: ";

            if (popUp.ShowDialog() == DialogResult.OK)
            {
                myDataHandler.addItem(ConBox.SelectedItem.ToString(), popUp.textBox1.Text);

                ListUpdate();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Delete Button
            DeleteWin popUp = new DeleteWin();

            popUp.comboBox1.Items.AddRange(myDataHandler.getItems(ConBox.SelectedItem.ToString()));

            if (popUp.ShowDialog() == DialogResult.OK)
            {
                myDataHandler.subItem(ConBox.SelectedItem.ToString(), popUp.comboBox1.SelectedItem.ToString());

                ListUpdate();
            }
        }

        private void ConBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListUpdate();
        }

        public void ListUpdate()
        {
            try
            {
                DisplayBox.ItemsSource = myDataHandler.getItems(ConBox.SelectedItem.ToString());

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "load fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
