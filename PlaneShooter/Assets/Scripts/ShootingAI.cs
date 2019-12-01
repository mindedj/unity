using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAI : MonoBehaviour
{
    public GameObject missileProto;
    public Transform[] firePoint = new Transform[4];
    public GameObject[] missilePool;
    public int missilePoolSize;
    public float speed = 10.0f;
    public float coolDownTime = 1f;
    public float coolDown = 0;
    public float targetCD = 2f;
    public float cd = 0;
    public Vector3 goingRightSpeed = new Vector3(0.003f, 0, 0);

    [HideInInspector]
    public bool once = true;
    [HideInInspector]
    public Vector3 player;
    [HideInInspector]
    public Vector3 enemy;
    [HideInInspector]
    public Rigidbody2D rb;

    void Start()
    {
        
        missilePoolSize = 32;
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
        if(cd <= 0)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
            cd = targetCD;
        }
        else
        {
            cd -= Time.deltaTime;
        }
        
        if (distance(player.x, player.y, enemy.x, enemy.y) < 6){
            this.gameObject.GetComponent<Rigidbody2D>().velocity = goingRightSpeed;
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

    void Fire()
    {
        
        for(int i = 0; i < firePoint.Length; i++)
        {
            GameObject newMissile = getInactiveBullet();
            if (newMissile == null)
            {
                return;
            }
            newMissile.GetComponent<Transform>().position = firePoint[i].position;

            newMissile.SetActive(true);

            newMissile.GetComponent<Rigidbody2D>().velocity = new Vector3((player.x-enemy.x)/2, player.y-enemy.y, 0);
            //newMissile.GetComponent<Transform>().rotation = Quaternion.Euler(player.x-enemy.x, player.y-enemy.y, 0);
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
    float distance(float x, float y, float x2, float y2)
    {
        return Mathf.Sqrt((x - x2) * (x - x2) + (y - y2) * (y - y2));
    }
}
