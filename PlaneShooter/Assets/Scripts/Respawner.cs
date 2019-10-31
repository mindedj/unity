using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    private Vector3 startPos;
    private bool startActive;
    private Vector3 startScale;
    private int startHealth;
    private HealthSystem hs;
   

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<RespawnController>()
                .register(this);
        startPos = transform.position;
        startActive = gameObject.activeSelf;
        startScale = transform.localScale;
        startHealth = this.GetComponent<HealthSystem>() != null ? this.GetComponent<HealthSystem>().health : 0;
    }

    public void respawn()
    {
        transform.position = startPos;
        gameObject.SetActive(startActive);
        transform.localScale = startScale;
        if(this.GetComponent<HealthSystem>() != null)
        {
            this.GetComponent<HealthSystem>().health = startHealth;
        }
         
        
    }
}
