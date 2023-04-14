using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public static Data data = new Data();

    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string directory = Path.Combine(Application.persistentDataPath, "NetDreamsChallenge");

        Directory.CreateDirectory(directory);

        string path = directory + "/saves5.dat";

        FileStream file = File.Create(path);

        formatter.Serialize(file, data);

        file.Close();
    }

    public static void Load()
    {
        string directory = Path.Combine(Application.persistentDataPath, "NetDreamsChallenge");

        string path = directory + "/saves5.dat";

        if (!File.Exists(path))
        {
            Save();
            return;
        }

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream file = File.Open(path, FileMode.Open);

        data = (Data)formatter.Deserialize(file);

        file.Close();

        Debug.Log("Settings Loaded");
    }
}