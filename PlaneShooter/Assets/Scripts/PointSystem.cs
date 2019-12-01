using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PointSystem : MonoBehaviour
{
    
    public int points = 0;
    public void AddPoints(int point)
    {
        this.points += point;
        PlayerPrefs.SetInt("Score", points);
    }
    public void Reset()
    {
        this.points = 0;
    }

}
