using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDrop : MonoBehaviour
{
    private Vector3 Speed;
    public float MoveTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Speed = (new Vector3(0, 0, 0) - this.transform.position) / MoveTime;
        this.transform.position += Speed * Time.fixedDeltaTime;
    }
}
