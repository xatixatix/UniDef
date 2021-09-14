using UnityEngine;

public class Laser : MonoBehaviour
{
    private float speed = Screen.height / (3 / 1);
    private float speedx;
    private float speedy;
    private float rotationZ;
    private Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //rotation
        Vector3 difference = Input.mousePosition - transform.position;
        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        //speed
        if (rotationZ >= 90)
        {
            speedx = -((rotationZ / 90) - 1) * speed;
            speedy = speed - Mathf.Abs(speedx);
        }
        else
        {
            speedx = (1 - (rotationZ / 90)) * speed;
            speedy = speed - Mathf.Abs(speedx);
        }

        rb.velocity = new Vector2(speedx, speedy);
        //if wanting to shoot backwards...
        if (speedy < 0)
        {
            PlayerScript.instance.timer = PlayerScript.instance.nextAttack;
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        if (transform.position.x > Screen.width * 1.1 || transform.position.y > Screen.height * 1.1 || transform.position.y < Screen.height * 1.1 * -1)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}