using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static DataHolder instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #region PlayerSkills
    public float dmg;
    public float laserSpeed;
    public float attackSpeed;
    #endregion
    #region Upgrades
    public int laserU;
    public int speedU;
    public int fireRateU;
    #endregion

    public int level;
    public int coins;
    public int wallMaxHealth;
    public int enemyDmg;
    public int highScore;
}
