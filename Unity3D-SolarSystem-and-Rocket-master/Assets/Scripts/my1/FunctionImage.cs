using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionImage : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public GameObject Points;
    // Start is called before the first frame update
    void Awake()
    {
        x = Points.transform.position.x;
        y = Points.transform.position.y;
        z = Points.transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
