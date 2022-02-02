using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace InvManager
{
    public class DataHandler
    {
        private List<String[]> conTable = new List<String[]>();
        private string[] itemArray;
        private string _fileName = "";

        /**
         * Constructor for objects of class DataHandler
         * 
         */
        public DataHandler()
        {

        }

        /**
         * Loads a file.
         * 
         * @param fileName is the name of the file to be loaded.
         * @return bool
         */
        public bool loadFile(string fileName)
        {
            try
            {
                StreamReader sReader = new StreamReader(@"..\" + fileName + ".txt");
                while (!sReader.EndOfStream)
                {
                    string line = sReader.ReadLine();

                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        itemArray = line.Split(',');

                        conTable.Add(itemArray);
                    }
                }
                sReader.Close();
                _fileName = fileName;
                return true;
            }
            catch (FileNotFoundException fnfe)
            {
                MessageBox.Show(fnfe.Message, "File Not Found");
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                return false;
            }
        }

        /**
         * Creates a new file.
         * 
         * @param fileName is the name of the file to be created.
         * @return void
         */
        public void createFile(string fileName)
        {
            if (!File.Exists(@"..\" + fileName + ".txt")) 
            { 
                File.Create(@"..\" + fileName + ".txt");
            }
            else
            {
                MessageBox.Show("File already exists");
            }
        }

        /**
         * Creates new containers.
         * 
         * @param conName the name of the container to add.
         * @return void
         */
        public void createContainer(string conName)
        {
            bool exists = false;

            foreach (String[] array in conTable)
            {
                if (array[0] == conName)
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                string[] tempArray = new string[] { conName };
                conTable.Add(tempArray);
            }
        }

        /**
        * Pulls container names from the container list.
        * 
        * @return  String[]
        */
        public String[] getContainers()
        {
            String[] tempArray;
            String[] outArray = new String[conTable.Count];

            for (int i = 0; i < conTable.Count; i++)
            {
                tempArray = conTable[i];
                outArray[i] = tempArray[0];
            }

            return outArray;
        }

        /**
         * Pulls item data from the container file.
         * 
         * @param  conName   the name of the container being accessed.
         * @return  String[]
         */
        public String[] getItems(string conName)
        {
            //returns items in container in a string Array, use displayArray method to output Array
            foreach (String[] array in conTable)
            {
                if (array[0] == conName)
                {
                    return array;
                }
            }
            //MessageBox.Show("Container not found");
            return null;
        }

        /**
         * Adds an item to a container by adding to file
         * 
         * @param conName the name of the container to add the item to
         * @param itemName the name of the item
         * @return void
         */
        public void addItem(string conName, string itemName)
        {
            //adds item to array under container conName
            bool success = false;
            
            String[] array = getItems(conName);
            if (array != null)
            {
                try
                {
                    int index = conTable.IndexOf(array);
                    String[] tempArray = new String[array.Length + 1];
                    for (int i = 0; i < array.Length; i++)
                    {
                        tempArray[i] = array[i];
                    }
                    tempArray[array.Length] = itemName;
                    conTable.RemoveAt(index);
                    conTable.Insert(index, tempArray);
                    success = true;
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            if (!success)
            {
                MessageBox.Show("Container was not found, item was not added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**
         * Subtracts an item from a container by deleting from file
         * 
         * @param conName the name of the container to subtract the item from
         * @param itemName the name of the item
         * @return void
         */
        public void subItem(string conName, string itemName)
        {
            //subtracts item from file under container
            bool success = false;
            string tempStr = "";

            String[] array = getItems(conName);
            if (array != null)
            {
                try { 
                    int index = conTable.IndexOf(array);
                    String[] newArray = new String[array.Length - 1];
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] != itemName)
                        {
                            tempStr = tempStr + "," + array[i];
                        }
                    }
                    newArray = tempStr.Split(',');
                    conTable.RemoveAt(index);
                    conTable.Insert(index, newArray);
                    success = true;
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            if (!success)
            {
                MessageBox.Show("Item or Container was not found, item was not deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**
         * Searches for an item by calling getItems while going through the conTable list, comparing each item to the input,
         * and return the item and container for matching items.
         * 
         * @param itemName the name of the item to search for
         * @return String[]
         */
        public String[] searchItem(string itemName)
        {
            //loop through the item names for each container and call returnItem for each match
            String[] outArray;
            string tempStr = "";
            
            foreach (String[] array in conTable)
            {
                foreach (String item in array)
                {
                    if (item.Contains(itemName))
                    {
                        tempStr = tempStr + "," + item + " - " + array[0];
                    }
                }
            }
            outArray = tempStr.Split(',');
            return outArray;
        }

        /**
         * Saves to File
         * 
         * @return void
         */
        public void SaveToFile()
        {
            try
            {
                File.Delete(@"..\" + _fileName + ".txt");
                StreamWriter sWriter = new StreamWriter(File.OpenWrite(@"..\" + _fileName + ".txt"));
                foreach (String[] array in conTable)
                {
                    foreach (String item in array)
                    {
                        sWriter.Write(item+',');
                    }
                    sWriter.WriteLine();
                }
                MessageBox.Show("File Saved Successfully", _fileName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                sWriter.Flush();
                sWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
