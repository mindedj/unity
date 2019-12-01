using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShipAI : MonoBehaviour
{
    public GameObject missileProto;
    public Transform firePoint;
    public GameObject[] missilePool;
    public int missilePoolSize;
    public float speed = 10f;
    public float coolDownTime = 1f;
    public float coolDown = 0;

    [HideInInspector]
    public bool once = true;
    [HideInInspector]
    public Vector3 player;
    [HideInInspector]
    public Vector3 enemy;
    [HideInInspector]
    public Rigidbody2D rb;
    public float eSpeed = 2f;
    public Transform start;
    public int fel = 1;
    public int hatotav;


    void Start()
    {
        hatotav = this.gameObject.tag == "sarga" ? 6 : 7;
        coolDownTime = this.gameObject.tag == "sarga" ? 1f : 0.8f;
        missilePoolSize = 10;
        missilePool = new GameObject[missilePoolSize];
        for (int i = 0; i < missilePoolSize; i++)
        {
            GameObject newMissile = Instantiate(missileProto);
            newMissile.SetActive(false);
            missilePool[i] = newMissile;
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        enemy = this.GetComponent<Transform>().position;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        if (distance(player.x, player.y, enemy.x, enemy.y) < hatotav)
        {
            if (coolDown <= 0)
            {
                Fire();
                coolDown = coolDownTime;
            }
            else
            {
                coolDown -= Time.deltaTime;
            }
        }
    }

    GameObject getInactiveBullet()
    {
        for (int i = 0; i < missilePoolSize; i++)
        {
            if (missilePool[i].activeSelf == false)
            {
                return missilePool[i];
            }
        }
        return null;
    }
    void Fire()
    {
        
        GameObject newMissile = getInactiveBullet();
        if (newMissile == null)
        {
            return;
        }
        newMissile.GetComponent<Transform>().position = firePoint.position;

        newMissile.SetActive(true);

        newMissile.GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, 0, 0);
        newMissile.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 270);
    }
    float distance(float x, float y, float x2, float y2)
    {
        return Mathf.Sqrt((x - x2) * (x - x2) + (y - y2) * (y - y2));
    }
}
