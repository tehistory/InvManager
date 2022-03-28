using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InvManager.wwwroot
{
    public class InventoryControllerClass
    {
        InvManagerEntities myData = new InvManagerEntities();


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

            var conN = from e in myData.ConTables select e.ConName;

            foreach (var c in conN)
            {
                if (c == conName)
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                ConTable temp = new ConTable();
                temp.ConName = conName;
                myData.ConTables.Add(temp);
                myData.SaveChanges();
            }
            else
            {
                MessageBox.Show("Container already exists");
            }
        }

        /**
        * Pulls container names from the container list.
        * 
        * @return  String[]
        */
        public String[] getContainers()
        {
            String[] outL = (from e in myData.ConTables select e.ConName).ToArray();

            return outL;
        }

        /**
         * Pulls item data from the container file.
         * 
         * @param  conName   the name of the container being accessed.
         * @return  String[]
         */
        public String[] getItems(string conName)
        {
            String[] outL = (from e in myData.ConTables join f in myData.ItemTables on e.ConID equals f.ConID where e.ConName == conName orderby f.ItemName select f.ItemName).ToArray();

            return outL;
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
            //adds item to table under container conName
            bool success = false;

            try
            {
                List<int> id = (from e in myData.ConTables where e.ConName == conName select e.ConID).ToList();

                ItemTable temp = new ItemTable();
                temp.ItemName = itemName;
                temp.ConID = id[0];
                myData.ItemTables.Add(temp);
                myData.SaveChanges();
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            if (!success)
            {
                MessageBox.Show("Item was not added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            try
            {
                List<int> PKey = (from e in myData.ConTables join f in myData.ItemTables on e.ConID equals f.ConID where f.ItemName == itemName && e.ConName == conName select f.ItemID).ToList();
                var item = myData.ItemTables.Find(PKey[0]);
                myData.ItemTables.Remove(item);
                myData.SaveChanges();
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
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
        public List<string> searchItem(string itemName)
        {
            //loop through the item names for each container and call returnItem for each match
            List<string> outArray = new List<string>();
            //string tempStr = "";

            //foreach (String[] array in conTable)
            //{
            //    foreach (String item in array)
            //    {
            //        if (item.Contains(itemName))
            //        {
            //            tempStr = tempStr + "," + item + " - " + array[0];
            //        }
            //    }
            //}
            //outArray = tempStr.Split(',');


            String[] itemArr = (from e in myData.ItemTables select e.ItemName).ToArray<string>();

            foreach (string item in itemArr)
            {
                string lowStr = item.ToLower();
                if (lowStr.Contains(itemName.ToLower()))
                {
                    List<string> str1 = (from e in myData.ItemTables where e.ItemName == item select e.ItemName).ToList();
                    List<string> str2 = (from e in myData.ConTables join f in myData.ItemTables on e.ConID equals f.ConID where f.ItemName == item select e.ConName).ToList();

                    outArray.Add(str1[0] + "   " + str2[0]);
                }
            }

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
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (i == array.Length - 1)
                        {
                            sWriter.Write(array[i]);
                        }
                        else
                        {
                            sWriter.Write(array[i] + ',');
                        }
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

        /**
         * Sorts all of the item arrays in the conTable
         * 
         * @return void
         */
        public void SortArrays()
        {

            try
            {
                foreach (String[] array in conTable)
                {
                    String[] sortedArray = new String[array.Length - 1];

                    for (int i = 0; i < sortedArray.Length; i++)
                    {
                        sortedArray[i] = array[i + 1];
                    }

                    for (int i = 0; i < sortedArray.Length; i++)
                    {
                        for (int j = 0; j < sortedArray.Length - 1; j++)
                        {
                            string tempStr1 = sortedArray[j];
                            string tempStr2 = sortedArray[j + 1];
                            if (tempStr1[0] > tempStr2[0])
                            {
                                sortedArray[j] = tempStr2;
                                sortedArray[j + 1] = tempStr1;
                            }
                        }
                    }

                    for (int i = 0; i < sortedArray.Length; i++)
                    {
                        array[i + 1] = sortedArray[i];
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
    }
}
