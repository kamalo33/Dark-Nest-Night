using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class saveGame : MonoBehaviour {
    //create a class save where you pass the parameters to save dude
    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        save.currentLevel = 0;
        save.LevelCheckpoint = 0;
        return save;
    }
    //function to save file. it creates a class save acording to the one declared in this same class and saves a class of it whener it should be
    public void SaveGame()
    {
        Save save = CreateSaveGameObject();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
        print("Game Saved");
    }
    //function to load file
    public void LoadGame()
    {
        // first sees if there's a saved data
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            //loads the save and unbinari it
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            //here you should equalize the bars to the gamemanager vars like:
            // GM.currentLevel = save.currentLevel;

            print("Game Loaded");
        }
        else
        {
            print("No game saved!");
        }
    }
}
