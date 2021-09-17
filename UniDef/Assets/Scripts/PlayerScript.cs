using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public Transform player;
    public GameObject laserPrefab;

    //attributes
    public float timer;
    public float nextAttack = 1;
    public Vector3 playerPosition;
    void Start()
    {
        playerPosition = player.transform.position;
    }
    void Update()
    {
        if (GameplayManager.instance.isStarted)
        {
            nextAttack = (1 / DataHolder.instance.attackSpeed) - timer;
            timer += Time.deltaTime;
            if (Input.GetMouseButton(0))
            {
                if (nextAttack <= 0)
                {
                    Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                    shootArrow();
                    nextAttack = 1 / DataHolder.instance.attackSpeed;
                    timer = 0;
                }
            }
            Vector3 difference = Input.mousePosition - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ); 
        }
    }
    public void shootArrow()
    {
        GameObject laser = Instantiate(laserPrefab, GameObject.FindGameObjectWithTag("GameCanvas").transform) as GameObject;
        laser.transform.position = playerPosition;
    }
}