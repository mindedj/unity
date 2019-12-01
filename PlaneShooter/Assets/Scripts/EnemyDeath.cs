using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private HealthSystem hs;
    private PointSystem ps;
    private void Start()
    {
        hs = this.gameObject.GetComponent<HealthSystem>();
        ps = GameObject.FindGameObjectWithTag("GameController").GetComponent<PointSystem>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Missile")
        {
            col.gameObject.SetActive(false);
            hs.DealDamage(1);
            if(hs.health <= 0)
            {
                if (this.gameObject.tag == "repuloCucc")
                {
                    ps.AddPoints(2);
                    
                }
                else if (this.gameObject.tag == "sarga")
                {
                    
                    ps.AddPoints(4);
                    
                }
                else if (this.gameObject.tag == "piros")
                {
                    ps.AddPoints(5);
                    
                }
                else if (this.gameObject.tag == "Enemy")
                {
                    ps.AddPoints(1);
                    
                }
                else if (this.gameObject.tag == "Boss")
                {
                    ps.AddPoints(25);
                    
                }
                this.gameObject.SetActive(false);
            }

        } else if(col.gameObject.tag == "Missile2")
        {
            col.gameObject.GetComponent<Renderer>().enabled = false;
            hs.DealDamage(2);
            if (hs.health <= 0)
            {
                if (this.gameObject.tag == "repuloCucc")
                {
                    ps.AddPoints(2);

                }
                else if (this.gameObject.tag == "sarga")
                {

                    ps.AddPoints(4);

                }
                else if (this.gameObject.tag == "piros")
                {
                    ps.AddPoints(5);

                }
                else if (this.gameObject.tag == "Enemy")
                {
                    ps.AddPoints(1);

                }
                else if (this.gameObject.tag == "Boss")
                {
                    ps.AddPoints(25);
                    PlayerPrefs.SetString("Boss", "Killed");
                }
                this.gameObject.SetActive(false);

            }
        }
        
    }
}
