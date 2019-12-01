using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PlayerDeath : MonoBehaviour
{
    private HealthSystem hs;
    ParticleSystem ps;
    CharacterMovemenetController cmc;
    public bool isDead = false;
    private void Start()
    {
        cmc = this.GetComponent<CharacterMovemenetController>();
        ps = GetComponentInChildren<ParticleSystem>();
        hs = this.gameObject.GetComponent<HealthSystem>();
    }
    public IEnumerator respawnAfter2Sec()
    {
        yield return new WaitForSeconds(2f);
        cmc.enabled = !cmc.enabled;
        this.gameObject.GetComponent<Renderer>().enabled = true;
        isDead = false;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<RespawnController>().respawn();
    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.SetActive(false);
            hs.DealDamage(1);
            if (hs.health <= 0)
            {
                if (!isDead)
                {
                    isDead = true;
                    this.gameObject.GetComponent<Renderer>().enabled = false;
                    cmc.enabled = !cmc.enabled;
                    ps.Play();
                    StartCoroutine(respawnAfter2Sec());
                }
                
            }
        }
        else if(col.gameObject.tag == "repuloCucc")
        {
            col.gameObject.SetActive(false);
            hs.DealDamage(1);
            if (hs.health <= 0)
            {
                if (!isDead)
                {
                    isDead = true;
                    this.gameObject.GetComponent<Renderer>().enabled = false;
                    cmc.enabled = !cmc.enabled;
                    ps.Play();
                    StartCoroutine(respawnAfter2Sec());
                }
            }
        }
        else if (col.gameObject.tag == "sarga")
        {
            col.gameObject.SetActive(false);
            hs.DealDamage(2);
            if (hs.health <= 0)
            {
                if (!isDead)
                {
                    isDead = true;
                    this.gameObject.GetComponent<Renderer>().enabled = false;
                    cmc.enabled = !cmc.enabled;
                    ps.Play();
                    StartCoroutine(respawnAfter2Sec());
                }
            }
        }
        else if (col.gameObject.tag == "piros")
        {
            col.gameObject.SetActive(false);
            hs.DealDamage(2);
            if (hs.health <= 0)
            {
                if (!isDead)
                {
                    isDead = true;
                    this.gameObject.GetComponent<Renderer>().enabled = false;
                    cmc.enabled = !cmc.enabled;
                    ps.Play();
                    StartCoroutine(respawnAfter2Sec());
                }
            }
        }
        else if (col.gameObject.tag == "spikyObj" || col.gameObject.tag == "Boss")
        {
            if (!isDead)
            {
                isDead = true;
                this.gameObject.GetComponent<Renderer>().enabled = false;
                cmc.enabled = !cmc.enabled;
                ps.Play();
                StartCoroutine(respawnAfter2Sec());
            }

        }
        else if (col.gameObject.tag == "EnemyMissile")
        {
            col.gameObject.SetActive(false);
            hs.DealDamage(1);
            if (hs.health <= 0)
            {
                if (!isDead)
                {
                    isDead = true;
                    this.gameObject.GetComponent<Renderer>().enabled = false;
                    cmc.enabled = !cmc.enabled;
                    ps.Play();
                    StartCoroutine(respawnAfter2Sec());
                }
            }

        }
              
    }
}

