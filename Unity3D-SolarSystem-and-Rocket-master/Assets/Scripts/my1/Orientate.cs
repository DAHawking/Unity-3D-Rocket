using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientate : MonoBehaviour
{
    public GameObject rocket;
    public float TurnSpeed;
    // Start is called before the first frame update
    void Awake()
    {

        //rocket.transform.Rotate(90, 0, 0);
        //GameObject.Find("CZ5/cz5").GetComponent<Transform>().Rotate(0, 0, 0);


    }

    // Update is called once per frame
    void Update()
    {
        //Quaternion q = Quaternion.LookRotation(new Vector3(100, 0, 0) - rocket.transform.position);
        //Quaternion.RotateTowards(rocket.transform.rotation, q, TurnSpeed * Time.fixedDeltaTime);
        //rocket.transform.LookAt(new Vector3(0, 0, 1000));
        Quaternion q = Quaternion.LookRotation(new Vector3(100, 0, 100) - rocket.transform.position);
        rocket.transform.rotation = Quaternion.RotateTowards(rocket.transform.rotation, q, TurnSpeed * Time.deltaTime);
        //Quaternion.Slerp(rocket.transform.rotation, q, TurnSpeed * Time.deltaTime);


    }
}
