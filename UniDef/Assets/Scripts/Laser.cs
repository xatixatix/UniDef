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
        float addxy = System.Math.Abs(difference.x) + System.Math.Abs(difference.y);
        speedx = (System.Math.Abs(difference.x) / addxy) * speed;
        if (difference.x < 0)
        {
            speedx = -((System.Math.Abs(difference.x) / addxy) * speed);
        }
        else
        {
            speedx = (System.Math.Abs(difference.x) / addxy) * speed;
        }
        if (difference.y < 0)
        {
            speedy = -((System.Math.Abs(difference.y) / addxy) * speed);
        }
        else
        {
            speedy = (System.Math.Abs(difference.y) / addxy) * speed;
        }

        rb.velocity = new Vector2(speedx, speedy);
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