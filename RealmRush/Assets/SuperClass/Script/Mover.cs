using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    //these variables change our movement
    float xValue, yValue, zValue=0;
    float MoveSpeed=10;

    void Start()
    {
        
    }
    void Update()
    {
        xValue = Input.GetAxis("Horizontal")*Time.deltaTime*MoveSpeed;
        zValue = Input.GetAxis("Vertical")*Time.deltaTime*MoveSpeed;
        transform.Translate(xValue, yValue, zValue);
    }
}
