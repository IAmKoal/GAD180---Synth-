using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{

    public Transform playerTarget;
    public Animator explosion;
    public Rigidbody2D rb;
    public PlayerStats player;

    [SerializeField]
    float thrust = 30f, rotateSpeed = 200f, missileDamage = 10f, timeAlive, movementSpeed;
    [SerializeField]
    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        timeAlive = 4f;
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.Find("Player").GetComponent<PlayerStats>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (timeAlive >= 0)
        {
            timeAlive -= Time.deltaTime;
        }
        else
        {
            isAlive = false;
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if(isAlive == true)
        {
            Vector2 direction = (Vector2)playerTarget.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.right).z;
            rb.angularVelocity = -rotateSpeed * rotateAmount;
            rb.velocity = transform.right * movementSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D missileCollider)
    {
        if(missileCollider.gameObject.tag == "Player")
        {
            explosion.SetBool("Hit", true);
            player.playerCurrentHealth -= missileDamage;
            player.TakeDamage();
            Debug.Log(player.playerCurrentHealth + "player hit by missile");
            rb.velocity = new Vector2(0, 0);
            isAlive = false;
            Destroy(gameObject);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            isAlive = false;
            explosion.SetBool("Hit", true);
            Destroy(gameObject);
        }
    }
}
