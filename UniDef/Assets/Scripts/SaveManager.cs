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
        UpgradeManager.instance.RefreshUpgrades();
    }

    private void CreateSave()
    {
        BinaryFormatter binaryformatter = new BinaryFormatter();
        FileStream fileStream = File.Open(SavePath, FileMode.Create);

        SaveData newSaveData = new SaveData
        {
            highScore = 0,
            coins = 0,
            laserU = 1,
            speedU = 1,
            fireRateU = 1,
            level = 1
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
        DataHolder.instance.coins = saveData.coins;
        DataHolder.instance.laserU = saveData.laserU;
        DataHolder.instance.speedU = saveData.speedU;
        DataHolder.instance.fireRateU = saveData.fireRateU;
        DataHolder.instance.level = saveData.level;

        fileStream.Close();
    }

    public void JustSave()
    {
        BinaryFormatter binaryformatter = new BinaryFormatter();
        FileStream fileStream = File.Open(SavePath, FileMode.Open);

        SaveData newData = new SaveData()
        {
            highScore = DataHolder.instance.highScore,
            coins = DataHolder.instance.coins,
            laserU = DataHolder.instance.laserU,
            speedU = DataHolder.instance.speedU,
            fireRateU = DataHolder.instance.fireRateU,
            level = DataHolder.instance.level
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

    #region Upgrades
    public int laserU;
    public int speedU;
    public int fireRateU;
    #endregion

    public int highScore;
    public int coins;
    public int level;
}