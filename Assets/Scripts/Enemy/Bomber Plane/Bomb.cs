using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    [SerializeField]
    float speed = 1f, timeAlive, bombDamage = 10f, rotationSpeed = 10f;
    public BomberStats bomber;
    public Animator explosion;
    public PlayerStats player;
    public Rigidbody2D bombWeight;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        bombWeight.gravityScale = 5;
        bombWeight.angularDrag = 25;
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    private void Update()
    {
        TimeAlive();

        Vector3 targetDir = target.transform.position - transform.position;

        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.red);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void TimeAlive()
    {
        timeAlive = 5f;

        if(timeAlive <= 0f)
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
        if(bombCollider.gameObject.tag == "player")
        {
            bombCollider.GetComponent<PlayerStats>();
            player.playerCurrentHealth -= bombDamage;
        }
    }
}
