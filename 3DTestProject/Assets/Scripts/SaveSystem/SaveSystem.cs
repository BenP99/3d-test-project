using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using System;

public static class SaveSystem
{
    public static void SaveData(float time, int score, int lvl, int shapesInteracted)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/ScoreSaveData.json";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(time, score, lvl, shapesInteracted);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadData()
    {
        string path = Application.persistentDataPath + "/ScoreSaveData.json";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        } else
        {
            Debug.LogError("Save file not found in: " + path);
            return null;
        }

    }

    public static void DeleteFile()
    {
        string path = Application.persistentDataPath + "/ScoreSaveData.json";

        if (File.Exists(path))
        { 
            File.Delete(path);
        }       
    }

    public static bool CheckFile()
    {
        bool result = false;
        string path = Application.persistentDataPath + "/ScoreSaveData.json";

        if (File.Exists(path))
        {
            result = true;
        }

        return result;
    }

}
