using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float xAngle = 1;
    [SerializeField] float yAngle = 1;
    [SerializeField] float zAngle = 1;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xAngle, yAngle, zAngle);
    }
}