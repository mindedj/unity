using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : HealthSystem
{
    public int maxHealth;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public int currHealth;
    
    private void Start()
    {
        maxHealth = this.gameObject.GetComponent<HealthSystem>().health;
        
    }
    // Update is called once per frame
    void Update()
    {
        currHealth = this.gameObject.GetComponent<HealthSystem>().health;
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < currHealth)
            {
                hearts[i].sprite = fullHeart;
                hearts[i].transform.position = new Vector3(-10f + i * 0.2f, 1.44f,0f);
            } else
            {
                hearts[i].sprite = emptyHeart;
                hearts[i].transform.position = new Vector3(-3.2f + i * 0.2f, 1.44f,0f);
            }
        }

    }
}
