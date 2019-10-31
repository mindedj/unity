using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthSystem : MonoBehaviour
{

    public int health;
    public void DealDamage(int damage)
    {
        this.health -= damage;
    }
   

}
