using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAI : MonoBehaviour
{
    public Rigidbody2D rb;
    public float startY;
    public float speed;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        startY = this.GetComponent<Transform>().position.y;
        this.rb.velocity = new Vector2(0,2);
        speed = this.gameObject.tag == "sarga" ? 2 : 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(this.GetComponent<Transform>().position.y > startY + 1)
        {
            
            this.rb.velocity = new Vector2(0f, -1*speed);
        } else if(this.GetComponent<Transform>().position.y < startY - 1)
        {
            this.rb.velocity = new Vector2(0f, 1*speed);
        }
    }
}
