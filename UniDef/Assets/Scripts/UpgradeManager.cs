using UnityEngine;
using UnityEngine.UI;

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
    public void RefreshUpgrades()
    {
        switch (DataHolder.instance.laserU)
        {
            case 1:
                {
                    DataHolder.instance.dmg = 10;
                    laserUCost = 10;
                    break;
                }
            case 2:
                {
                    DataHolder.instance.dmg = 12;
                    laserUCost = 12;
                    break;
                }
            case 3:
                {
                    DataHolder.instance.dmg = 14;
                    laserUCost = 14;
                    break;
                }
            case 4:
                {
                    DataHolder.instance.dmg = 16;
                    laserUCost = 16;
                    break;
                }
            case 5:
                {
                    DataHolder.instance.dmg = 18;
                    laserUCost = 18;
                    break;
                }
            case 6:
                {
                    DataHolder.instance.dmg = 20;
                    laserUCost = 20;
                    break;
                }
            case 7:
                {
                    DataHolder.instance.dmg = 24;
                    laserUCost = 24;
                    break;
                }
            case 8:
                {
                    DataHolder.instance.dmg = 28;
                    laserUCost = 28;
                    break;
                }
            case 9:
                {
                    DataHolder.instance.dmg = 35;
                    laserUCost = 35;
                    break;
                }
            case 10:
                {
                    DataHolder.instance.dmg = 42;
                    laserUCost = 42;
                    break;
                }
            default:
                {
                    DataHolder.instance.dmg = 10;
                    laserUCost = 10;
                    break;
                }
        }
        switch (DataHolder.instance.speedU)
        {
            case 1:
                {
                    DataHolder.instance.laserSpeed = 1;
                    speedUCost = 10;
                    break;
                }
            case 2:
                {
                    DataHolder.instance.laserSpeed = 1.05f;
                    speedUCost = 15;
                    break;
                }
            case 3:
                {
                    DataHolder.instance.laserSpeed = 1.1f;
                    speedUCost = 20;
                    break;
                }
            case 4:
                {
                    DataHolder.instance.laserSpeed = 1.15f;
                    speedUCost = 25;
                    break;
                }
            case 5:
                {
                    DataHolder.instance.laserSpeed = 1.2f;
                    speedUCost = 30;
                    break;
                }
            case 6:
                {
                    DataHolder.instance.laserSpeed = 1.25f;
                    speedUCost = 35;
                    break;
                }
            case 7:
                {
                    DataHolder.instance.laserSpeed = 1.3f;
                    speedUCost = 40;
                    break;
                }
            case 8:
                {
                    DataHolder.instance.laserSpeed = 1.35f;
                    speedUCost = 45;
                    break;
                }
            case 9:
                {
                    DataHolder.instance.laserSpeed = 1.4f;
                    speedUCost = 50;
                    break;
                }
            case 10:
                {
                    DataHolder.instance.laserSpeed = 1.45f;
                    speedUCost = 55;
                    break;
                }
            default:
                {
                    DataHolder.instance.laserSpeed = 1;
                    speedUCost = 10;
                    break;
                }
        }
        switch (DataHolder.instance.fireRateU)
        {
            case 1:
                {
                    DataHolder.instance.attackSpeed = 1;
                    fireRateUCost = 10;
                    break;
                }
            case 2:
                {
                    DataHolder.instance.attackSpeed = 1.05f;
                    fireRateUCost = 15;
                    break;
                }
            case 3:
                {
                    DataHolder.instance.attackSpeed = 1.1f;
                    fireRateUCost = 20;
                    break;
                }
            case 4:
                {
                    DataHolder.instance.attackSpeed = 1.15f;
                    fireRateUCost = 25;
                    break;
                }
            case 5:
                {
                    DataHolder.instance.attackSpeed = 1.2f;
                    fireRateUCost = 30;
                    break;
                }
            case 6:
                {
                    DataHolder.instance.attackSpeed = 1.25f;
                    fireRateUCost = 35;
                    break;
                }
            case 7:
                {
                    DataHolder.instance.attackSpeed = 1.3f;
                    fireRateUCost = 40;
                    break;
                }
            case 8:
                {
                    DataHolder.instance.attackSpeed = 1.35f;
                    fireRateUCost = 45;
                    break;
                }
            case 9:
                {
                    DataHolder.instance.attackSpeed = 1.4f;
                    fireRateUCost = 50;
                    break;
                }
            case 10:
                {
                    DataHolder.instance.attackSpeed = 1.45f;
                    fireRateUCost = 55;
                    break;
                }
            default:
                {
                    DataHolder.instance.attackSpeed = 1;
                    fireRateUCost = 10;
                    break;
                }
        }
        
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