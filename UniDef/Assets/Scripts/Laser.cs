using UnityEngine;

public class Laser : MonoBehaviour
{
    float speed = Screen.height / (3 / 1);
    public float speedx;
    public float speedy;
    public float rotationZ;
    private Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //rotation
        Vector3 difference = Input.mousePosition - transform.position;
        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        //speed
        speedy = (rotationZ / 90) * speed;
        speedx = speed - Mathf.Abs(speedy);
        rb.velocity = new Vector2(speedx, speedy);
    }
    void Update()
    {
        if (transform.position.x > Screen.width * 1.1 || transform.position.y > Screen.height * 1.2 || transform.position.y < Screen.height * 1.2 * -1)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            Destroy(this.gameObject);
        }
    }
}