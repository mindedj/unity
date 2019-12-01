using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Heart : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] heart;
    public Sprite fullHeart;
    public Sprite emptyHeart;
   

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < numOfHearts; i++)
        {
            if(i < GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>().health)
            {
                heart[i].sprite = fullHeart;
            } else
            {
                heart[i].sprite = emptyHeart;
            }
        }
    }
}
