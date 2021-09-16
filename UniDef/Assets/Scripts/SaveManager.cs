using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    private string SavePath;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        SavePath = Application.persistentDataPath + "/textme.nthg";
        CheckForSave();
    }

    private void CheckForSave()
    {
        if (File.Exists(SavePath) == false)
        {
            CreateSave();
        }
        else
        {
            LoadSave();
        }
    }

    private void CreateSave()
    {
        BinaryFormatter binaryformatter = new BinaryFormatter();
        FileStream fileStream = File.Open(SavePath, FileMode.Create);

        SaveData newSaveData = new SaveData
        {
            highScore = 0
        };

        binaryformatter.Serialize(fileStream, newSaveData);
        fileStream.Close();
        LoadSave();
    }

    private void LoadSave()
    {
        BinaryFormatter binaryformatter = new BinaryFormatter();
        FileStream fileStream = File.Open(SavePath, FileMode.Open);
        SaveData saveData = (SaveData)binaryformatter.Deserialize(fileStream);

        DataHolder.instance.highScore = saveData.highScore;

        fileStream.Close();
    }

    public void JustSave()
    {
        BinaryFormatter binaryformatter = new BinaryFormatter();
        FileStream fileStream = File.Open(SavePath, FileMode.Open);

        SaveData newData = new SaveData()
        {
            highScore = DataHolder.instance.highScore
        };

        binaryformatter.Serialize(fileStream, newData);
        fileStream.Close();
    }
}

//playerData
[Serializable]
public class SaveData
{
    public static SaveData instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public int highScore;
}