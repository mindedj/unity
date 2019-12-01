using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public Text txt;
    private void Update()
    {
        txt.text = this.GetComponent<PointSystem>().points.ToString();
    }
}
