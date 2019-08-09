using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    [SerializeField]
    float speed = 1f, timeAlive, bombDamage = 10, torque = 10;
    public BomberStats bomber;
    public Animator explosion;
    public PlayerStats player;
    public Rigidbody2D bombWeight;

    // Start is called before the first frame update
    void Start()
    {
        bombWeight.gravityScale = 5;
        bombWeight.angularDrag = 25;
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        timeAlive = 5;
        player = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    private void Update()
    {
        TimeAlive();
        bombWeight.AddTorque(torque);
    }

    void TimeAlive()
    {

        if(timeAlive <= 0)
        {
            explosion.SetBool("isDead", true);
            Destroy(gameObject);
        }

        if (timeAlive >= 0)
        {
            timeAlive -= Time.deltaTime;
        }
        else
        {
            explosion.SetBool("isDead", true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D bombCollider)
    {
        if(bombCollider.gameObject.tag == "Player" && bombCollider.gameObject.tag != "Enemy Bomber")
        {
            //bombCollider.GetComponent<PlayerStats>();
            player.playerCurrentHealth -= bombDamage;
            player.TakeDamage();
            explosion.SetBool("isDead", true);
            Destroy(gameObject);
        }
        else
        {
            explosion.SetBool("isDead", true);
            Destroy(gameObject);
        }
    }
}
