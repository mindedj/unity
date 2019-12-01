using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Achies : MonoBehaviour
{
    public Image[] images = new Image[3];

    // Update is called once per frame
    private void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            images[i].fillAmount = 0;
        }
    }
    void Update()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            images[0].fillAmount = Mathf.Min(1.0f,  (float)PlayerPrefs.GetInt("Score")/10f);
            images[1].fillAmount = Mathf.Min(1.0f,  (float)PlayerPrefs.GetInt("Score")/25f);
        }    
        if (PlayerPrefs.HasKey("Boss")) {
            if(PlayerPrefs.GetString("Boss") == "Killed")
            {
                images[2].fillAmount = 1;
            }
        }
    }
}
