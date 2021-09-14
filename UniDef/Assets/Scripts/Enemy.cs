using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    float health;
    public Slider healthBar;
    public int enemySpeed;
    public int enemyType;
    Rigidbody2D rb;
    void Start()
    {
        health = GameplayManager.instance.enemyHealth;
        rb = this.GetComponent<Rigidbody2D>();
        if (enemyType == 0)
        {
            rb.velocity = new Vector2(0, -Screen.height / (15 / enemySpeed));
        }
        healthBar.maxValue = health;
        healthBar.value = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            health -= PlayerScript.instance.dmg;
            healthBar.value = health;
            if (health <= 0)
            {
                GameplayManager.instance.score += 1;
                GameplayManager.instance.scoreText.text = "Score: " + GameplayManager.instance.score;
                Destroy(this.gameObject);
            }
        }
    }
}
