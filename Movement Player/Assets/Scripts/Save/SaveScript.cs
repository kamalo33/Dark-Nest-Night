using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public static SaveFile save = new SaveFile();//Class to save

    //Saves the saves
    private static void saveGame()
    {
        //initializes necesari classes
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        //save the file in binary end coses it
        bf.Serialize(file, SaveScript.save);
        file.Close();
    }

    //load the saves
    private static void loadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))//Sees if there's any saved file
        {
            //initializes necesari classes
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            //loads the file in from binary to normal and coses it
            SaveScript.save = (SaveFile) bf.Deserialize(file);
            file.Close();
        }
        else
        {
            Debug.Log("No save game");
        }
    }
    //To call the other static functions
    public void Save()
    {
        saveGame();
    }
    public void Load()
    {
        loadGame();
    }

    //Setters and getters of the class to save
    public void setIntData(int par)
    {
        save.intData = par;
    }
    public int getIntData()
    {
        return save.intData;
    }
    public void setStringData(string par)
    {
        save.stringData = par;
    }
    public string getStringdata()
    {
        return save.stringData;
    }

    //Singleton
    public static SaveScript instance = null;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
            //if not, set instance to this
            instance = this;
        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
}
