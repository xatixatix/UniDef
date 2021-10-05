using UnityEngine;
using UnityEngine.UI;
using System;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public Text laserUText;
    public Text speedUText;
    public Text fireRateUText;

    public Text laserUButtonText;
    public Text speedUButtonText;
    public Text fireRateUButtonText;

    int laserUCost;
    int speedUCost;
    int fireRateUCost;

    double doubleBuff;
    public void RefreshUpgrades()
    {
        //z = x.^ 1.3;
        //y = z * 5 * 0.8;

        doubleBuff = Math.Pow(DataHolder.instance.laserU, 1.3);
        DataHolder.instance.dmg = Convert.ToInt32(doubleBuff * 5 * 0.8);
        laserUCost = Convert.ToInt32(DataHolder.instance.laserU * 10 * 1.1);

        DataHolder.instance.laserSpeed = 1 + 0.05f * DataHolder.instance.speedU;
        speedUCost = Convert.ToInt32(10 + 5 * DataHolder.instance.speedU * 1.3);

        DataHolder.instance.attackSpeed = 1 + 0.05f * DataHolder.instance.fireRateU;
        fireRateUCost = Convert.ToInt32(10 + 5 * DataHolder.instance.fireRateU * 1.1);

        laserUText.text = "Lvl: " + DataHolder.instance.laserU + "\nDamage: " + DataHolder.instance.dmg;
        laserUButtonText.text = "UPGRADE\n" + laserUCost + " coins";

        speedUText.text = "Lvl: " + DataHolder.instance.speedU + "\nLaser Speed: " + DataHolder.instance.laserSpeed;
        speedUButtonText.text = "UPGRADE\n" + speedUCost + " coins";

        fireRateUText.text = "Lvl: " + DataHolder.instance.fireRateU + "\nAttack Speed: " + DataHolder.instance.attackSpeed;
        fireRateUButtonText.text = "UPGRADE\n" + fireRateUCost + " coins";
    }

    public void UpgradeLaser()
    {
        if (DataHolder.instance.coins >= laserUCost)
        {
            DataHolder.instance.laserU++;
            DataHolder.instance.coins -= laserUCost;
            RefreshUpgrades();
            SaveManager.instance.JustSave();
        }
    }
    public void UpgradeSpeed()
    {
        if (DataHolder.instance.coins >= speedUCost)
        {
            DataHolder.instance.speedU++;
            DataHolder.instance.coins -= speedUCost;
            RefreshUpgrades();
            SaveManager.instance.JustSave();
        }
    }
    public void UpgradeFireRate()
    {
        if (DataHolder.instance.coins >= fireRateUCost)
        {
            DataHolder.instance.fireRateU++;
            DataHolder.instance.coins -= fireRateUCost;
            RefreshUpgrades();
            SaveManager.instance.JustSave();
        }
    }
}