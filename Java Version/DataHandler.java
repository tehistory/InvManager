
/**
 * DataHandler: takes input from the interface and either passes through an output or adds to an inventory.
 * using a txt file for data storage, the containers are listed in the top of the file, 
 * the items are listed under the container name farther down in the file.
 * 
 * @author Frank Egelhoff 
 * @version 20211214
 */

import java.util.ArrayList;
public class DataHandler
{
    private ArrayList<String> conTable = new ArrayList<String>();
    private String itemArray[];

    /**
     * Constructor for objects of class DataHandler
     * Pulls information from file, creates new file
     * initiates the conTable ArrayList
     * 
     * @param file the address of the save file to access
     */
    public DataHandler(String file)
    {
        //takes file input string and pulls up an arraylist of containers
        //if empty, creates a new file
    }

    /**
     * Creates new containers.
     * 
     * @param conName the name of the container to add.
     * @return void
     */
    public void createContainer(String conName){
        //adds new container to the file
    }
    
    /**
     * Pulls item data from the container file.
     * 
     * @param  conName   the name of the container being accessed.
     * @return  void
     */
    public void getItems(String conName)
    {
        //returns items in container through returnItem
    }
    
    /**
     * Adds an item to a container by adding to file
     * 
     * @param conName the name of the container to add the item to
     * @param itemName the name of the item
     * @return void
     */
    public void addItem(String conName, String itemName){
        //adds item to file under container
    }
    
    /**
     * Subtracts an item from a container by deleting from file
     * 
     * @param conName the name of the container to subtract the item from
     * @param itemName the name of the item
     * @return void
     */
    public void subItem(String conName, String itemName){
        //subtracts item from file under container
    }
    
    /**
     * Searches for an item by calling getItems while going through the conTable list, comparing each item to the input,
     * and return the item and container for matching items.
     * 
     * @param itemName the name of the item to search for
     * @return void
     */
    public void searchItem(String itemName){
        //loop through the item names for each container and call returnItem for each match
    }
    
    /**
     * Edits an Array in the GUI for outputs
     * 
     * @param inputString inputed String
     * @return void
     */
    public void returnItem(String inputString){
        //edits output array in gui with multiple inputed Strings via mulitple instances of the method
    }
}
