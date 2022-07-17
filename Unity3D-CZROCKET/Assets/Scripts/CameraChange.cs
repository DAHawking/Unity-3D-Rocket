using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public static GameObject CameraTrajectory1, CameraTrajectory2;
    // Start is called before the first frame update
    void Start()
    {
        CameraTrajectory1 = GameObject.Find("ROCKETCZ5/Camera/CameraTrajectory1");
        CameraTrajectory2 = GameObject.Find("ROCKETCZ5/Camera/CameraTrajectory2");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Alpha0))
        {
            CameraTrajectory1.GetComponent<Camera>().depth = 0;
            CameraTrajectory1.GetComponent<Camera>().rect = new Rect(0f,0f,0.5f,0.5f);
        }
        else if (Input.GetKey(KeyCode.Alpha1))
        {
            CameraTrajectory1.GetComponent<Camera>().depth = 1;
            CameraTrajectory1.GetComponent<Camera>().rect = new Rect(0f, 0f, 1f, 1f);
        }
    }
}
