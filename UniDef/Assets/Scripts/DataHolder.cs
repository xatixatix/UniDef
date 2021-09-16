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

    public int wallMaxHealth;
    public int enemyDmg;
    public int highScore;
}
