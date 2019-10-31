using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrader : MonoBehaviour
{
    private Rigidbody2D rb;
    public float horizontalSpeed, verticalSpeed;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.rb.velocity = new Vector2(horizontalSpeed, verticalSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<FireBullet>().isUpgraded = true;
            this.gameObject.SetActive(false);
        }
    }
}
