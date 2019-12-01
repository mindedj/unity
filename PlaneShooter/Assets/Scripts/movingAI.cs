using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingAI : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public bool once = true;
    [HideInInspector]
    public Vector3 player;
    [HideInInspector]
    public Vector3 enemy;
    [HideInInspector]
    public Rigidbody2D rb;
    public int speed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        enemy = this.GetComponent<Transform>().position;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        enemy = this.GetComponent<Transform>().position;
        rb = this.GetComponent<Rigidbody2D>();
        if (distance(player.x, player.y, enemy.x, enemy.y) < 5 && once)
        {
            once = false;
            rb.AddForce(new Vector3(player.x - enemy.x, player.y - enemy.y, 0)*speed*this.GetComponent<Rigidbody2D>().mass);
        }
        if(enemy.x < (player.x - 5))
        {
            this.gameObject.SetActive(false);
        }
    }
    float distance(float x, float y, float x2, float y2)
    {
        return Mathf.Sqrt((x-x2)*(x-x2) + (y-y2)*(y-y2));
    }

}
