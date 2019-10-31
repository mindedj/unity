using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private HealthSystem hs;
    private void Start()
    {
        hs = this.gameObject.GetComponent<HealthSystem>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Missile")
        {
            col.gameObject.SetActive(false);
            hs.DealDamage(1);
            if(hs.health <= 0)
            {
                this.gameObject.SetActive(false);
            }
        } else if(col.gameObject.tag == "Missile2")
        {
            col.gameObject.GetComponent<Renderer>().enabled = false;
            hs.DealDamage(2);
            if (hs.health <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
        
    }
}
