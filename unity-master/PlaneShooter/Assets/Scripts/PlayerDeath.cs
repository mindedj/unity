using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private HealthSystem hs;
    private void Start()
    {
        hs = this.gameObject.GetComponent<HealthSystem>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.SetActive(false);
            hs.DealDamage(1);
            if(hs.health <= 0)
            {

                GameObject.FindGameObjectWithTag("GameController").GetComponent<RespawnController>().respawn();
            }
            
        } else if (col.gameObject.tag == "spikyObj")
        {

            this.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<RespawnController>().respawn();
            
        }
    }
}
