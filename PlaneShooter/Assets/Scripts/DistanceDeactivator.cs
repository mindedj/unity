using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDeactivator : MonoBehaviour
{
    private Vector3 startPosition;
    public float MaxDistance = 3.5f;

    void OnEnable()
    {
        startPosition = GetComponent<Transform>().position;
    }

    void Update()
    {
        Vector3 currentPos = GetComponent<Transform>().position;
        Vector3 movement = currentPos - startPosition;
        float distance = movement.magnitude;

        if (distance > MaxDistance)
        {
            this.gameObject.SetActive(false);
        }
    }
}
