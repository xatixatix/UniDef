using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour
{
    public static Wall instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public int wallHealth;
    public Text wallHealthText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            wallHealth -= DataHolder.instance.enemyDmg;
            wallHealthText.text = wallHealth + "/" + DataHolder.instance.wallMaxHealth;
            if (wallHealth <= 0)
            {
                GameplayManager.instance.endOfRun();
            }
        }
    }
}