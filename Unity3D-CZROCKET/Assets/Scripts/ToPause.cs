using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToPause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("1/1.1/1.1.1").transform.SetParent(GameObject.Find("2").transform);
    }
}
