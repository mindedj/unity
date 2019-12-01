using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject missileProto;
    public GameObject upgradedMissileProto;
    public bool isUpgraded = true;

    public Transform firePoint;



    public float speed = 10.0f;

    public float coolDownTime = 0.3f;
    public float coolDown = 0;

    private Transform tr;

    public int missilePoolSize = 5;
    public int upgradedPoolSize = 10;
    private GameObject[] missilePool;
    private GameObject[] upgradedPool;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();

        missilePool = new GameObject[missilePoolSize];
        upgradedPool = new GameObject[upgradedPoolSize];
        for(int i=0; i<missilePoolSize; i++)
        {
            GameObject newMissile = Instantiate(missileProto);
            newMissile.SetActive(false);
            missilePool[i] = newMissile;
        }
        for(int i = 0; i < upgradedPoolSize; i++)
        {
            GameObject newMissile = Instantiate(upgradedMissileProto);
            newMissile.SetActive(false);
            upgradedPool[i] = newMissile;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(coolDown <=0)
            {
                if (isUpgraded == false)
                {
                    
                    Fire();
                    coolDown = coolDownTime;
                } else
                {
                    
                    FireUpgraded();
                    
                    coolDown = coolDownTime;
                }
                
            }
            
        }
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }

    }

    void Fire()
    {
        GameObject newMissile = getInactiveBullet();
        if(newMissile == null)
        {
            return;
        }
        newMissile.GetComponent<Transform>().position = firePoint.position;
        this.gameObject.GetComponent<AudioSource>().Play();
        newMissile.SetActive(true);       

        newMissile.GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);
        newMissile.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 270);
    }
    void FireUpgraded()
    {
        GameObject newMissile = getUpgradedBullet();
        if (newMissile == null)
        {

            isUpgraded = false;
            for(int i = 0; i < upgradedPoolSize; i++)
            {
                upgradedPool[i].gameObject.SetActive(false);
            }
            return;
        }
        this.gameObject.GetComponent<AudioSource>().Play();
        newMissile.GetComponent<Transform>().position = firePoint.position;
        newMissile.SetActive(true);
        newMissile.GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);
        newMissile.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 270);
    }
    
    GameObject getInactiveBullet()
    {
        for(int i=0;i<missilePoolSize;i++)
        {
            if(missilePool[i].activeSelf == false)
            {
                return missilePool[i];
            }
        }

        return null;
    }
    GameObject getUpgradedBullet()
    {
        for (int i = 0; i < upgradedPoolSize; i++)
        {
            if (upgradedPool[i].activeSelf == false)
            {
                return upgradedPool[i];
            }
        }
        return null;
    }
    [HideInInspector]
    public void ReloadUpgraded()
    {
        for(int i = 0; i < upgradedPoolSize; i++)
        {
            if (upgradedPool[i].activeSelf)
            {
                if (!upgradedPool[i].GetComponent<Renderer>().enabled)
                {
                    upgradedPool[i].GetComponent<Renderer>().enabled = true;
                }
                upgradedPool[i].SetActive(false);
            }
        }
    }
}
