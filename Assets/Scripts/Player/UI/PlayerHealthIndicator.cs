using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthIndicator : MonoBehaviour
{

    PlayerStats ps;
    [SerializeField]
    float xSize, ySize, xOrigin, yOrigin;


    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.Find("Player").GetComponent<PlayerStats>();
        xSize = transform.lossyScale.x;
        ySize = transform.lossyScale.y;
        xOrigin = xSize;
        yOrigin = ySize;
    }

    // Update is called once per frame
    void Update()
    {
        if(ps != null)
        {
            transform.localScale = new Vector3(xSize, ySize, 0);
            xSize = xOrigin * ps.playerCurrentHealth;
            ySize = yOrigin * ps.playerCurrentHealth;
        }
    }
}
