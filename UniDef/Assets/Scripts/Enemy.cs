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
    private void Update()
    {
        if (!GameplayManager.instance.isStarted)
        {
            rb.velocity = new Vector2(0,0);
        }
        else
        {
            rb.velocity = new Vector2(0, -Screen.height / (15 / enemySpeed));
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            health -= DataHolder.instance.dmg;
            healthBar.value = health;
            if (health <= 0)
            {
                GameplayManager.instance.score += 1;
                GameplayManager.instance.scoreText.text = "Score: " + GameplayManager.instance.score;
                GameplayManager.instance.checkIfEnd();
                Destroy(this.gameObject);
            }
        }
        else if (other.tag == "Wall")
        {
            transform.position = new Vector2(transform.position.x,transform.position.y + this.GetComponent<RectTransform>().rect.height * 2);
        }
    }
}
