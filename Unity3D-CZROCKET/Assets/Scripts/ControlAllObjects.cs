using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAllObjects : MonoBehaviour
{


    bool flag_RocketToSatellite = false, flag_FairingSeparate = false;
    // Start is called before the first frame update
    void Start()
    {
        AllObjects.Camera_RocketFlow.GetComponent<Camera>().depth = -1;
        AllObjects.Camera_RocketFlow_Move.GetComponent<Camera>().depth = -1;
        AllObjects.Camera_Earth.GetComponent<Camera>().depth = -1;
        AllObjects.CameraFunctionImage.GetComponent<Camera>().depth = -1;
        AllObjects.Camera_RocketFlow.GetComponent<Camera>().rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
        AllObjects.Camera_RocketFlow_Move.GetComponent<Camera>().rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        AllObjects.Camera_Earth.GetComponent<Camera>().rect = new Rect(0f, 0f, 0.5f, 0.5f);
        AllObjects.CameraFunctionImage.GetComponent<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
        AllObjects.CameraFunctionImage.GetComponent<Camera>().cullingMask = (1 << 5);
        AllObjects.CameraFunctionImage.transform.position = new Vector3(16.97f, 5006.36f, -10f);
        AllObjects.CameraFunctionImage.GetComponent<Camera>().orthographicSize = 10.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //¿ØÖÆÉãÏñ»úÏÔÊ¾
        if (Input.GetKey(KeyCode.Alpha0))
        {
            AllObjects.Camera_RocketFlow.GetComponent<Camera>().depth = -1;
            AllObjects.Camera_RocketFlow_Move.GetComponent<Camera>().depth = -1;
            AllObjects.Camera_Earth.GetComponent<Camera>().depth = -1;
            AllObjects.CameraFunctionImage.GetComponent<Camera>().depth = -1;
            AllObjects.Camera_RocketFlow.GetComponent<Camera>().rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
            AllObjects.Camera_RocketFlow_Move.GetComponent<Camera>().rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            AllObjects.Camera_Earth.GetComponent<Camera>().rect = new Rect(0f, 0f, 0.5f, 0.5f);
            AllObjects.CameraFunctionImage.GetComponent<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
            AllObjects.CameraFunctionImage.GetComponent<Camera>().cullingMask = (1 << 5);
            AllObjects.CameraFunctionImage.transform.position = new Vector3(16.97f, 5006.36f, -10f);
            AllObjects.CameraFunctionImage.GetComponent<Camera>().orthographicSize = 10.0f;
        }
        else if (Input.GetKey(KeyCode.Alpha1))
        {
            AllObjects.Camera_RocketFlow.GetComponent<Camera>().depth = 0;
            AllObjects.Camera_RocketFlow.GetComponent<Camera>().rect = new Rect(0f, 0f, 1f, 1f);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            AllObjects.Camera_RocketFlow_Move.GetComponent<Camera>().depth = 0;
            AllObjects.Camera_RocketFlow_Move.GetComponent<Camera>().rect = new Rect(0f, 0f, 1f, 1f);
        }
        else if(Input.GetKey(KeyCode.Alpha3))
        {
            AllObjects.Camera_Earth.GetComponent<Camera>().depth = 0;
            AllObjects.Camera_Earth.GetComponent<Camera>().rect = new Rect(0f, 0f, 1f, 1f);
        }
        else if(Input.GetKey(KeyCode.Alpha4))
        {
            AllObjects.CameraFunctionImage.GetComponent <Camera>().depth = 0;
            AllObjects.CameraFunctionImage.GetComponent<Camera>().cullingMask = (1 << 5);
            AllObjects.CameraFunctionImage.GetComponent<Camera>().rect = new Rect(0f, 0f, 1f, 1f);
        }
        // ¿ØÖÆº¯ÊýÍ¼Ïñ
        else if (Input.GetKey(KeyCode.Alpha7))   //x
        {
            AllObjects.CameraFunctionImage.GetComponent<Camera>().depth = 0;
            AllObjects.CameraFunctionImage.GetComponent<Camera>().cullingMask = (1 << 5) + (1 << 16) + (1 << 17);
        }
        else if (Input.GetKey(KeyCode.Alpha8))   //y
        {
            AllObjects.CameraFunctionImage.GetComponent<Camera>().depth = 0;
            AllObjects.CameraFunctionImage.GetComponent<Camera>().cullingMask = (1 << 5) + (1 << 16) + (1 << 18);
        }
        else if (Input.GetKey(KeyCode.Alpha9))   //z
        {
            AllObjects.CameraFunctionImage.GetComponent<Camera>().depth = 0;
            AllObjects.CameraFunctionImage.GetComponent<Camera>().cullingMask = (1 << 5) + (1 << 16) + (1 << 19);
        }
        else if (Input.GetKey(KeyCode.U))   //vx
        {
            AllObjects.CameraFunctionImage.GetComponent<Camera>().depth = 0;
            AllObjects.CameraFunctionImage.GetComponent<Camera>().cullingMask = (1 << 5) + (1 << 16) + (1 << 20);
        }
        else if (Input.GetKey(KeyCode.I))   //vy
        {
            AllObjects.CameraFunctionImage.GetComponent<Camera>().depth = 0;
            AllObjects.CameraFunctionImage.GetComponent<Camera>().cullingMask = (1 << 5) + (1 << 16) + (1 << 21);
        }
        else if (Input.GetKey(KeyCode.O))   //vz
        {
            AllObjects.CameraFunctionImage.GetComponent<Camera>().depth = 0;
            AllObjects.CameraFunctionImage.GetComponent<Camera>().cullingMask = (1 << 5) + (1 << 16) + (1 << 22);
        }
        else if (Input.GetKey(KeyCode.J))   //Pitch
        {
            AllObjects.CameraFunctionImage.GetComponent<Camera>().depth = 0;
            AllObjects.CameraFunctionImage.GetComponent<Camera>().cullingMask = (1 << 5) + (1 << 16) + (1 << 23);
        }
        else if (Input.GetKey(KeyCode.K))   //Yaw
        {
            AllObjects.CameraFunctionImage.GetComponent<Camera>().depth = 0;
            AllObjects.CameraFunctionImage.GetComponent<Camera>().cullingMask = (1 << 5) + (1 << 16) + (1 << 24);
        }
        else if (Input.GetKey(KeyCode.L))   //Mass
        {
            AllObjects.CameraFunctionImage.GetComponent<Camera>().depth = 0;
            AllObjects.CameraFunctionImage.GetComponent<Camera>().cullingMask = (1 << 5) + (1 << 16) + (1 << 25);
        }

        //¿ØÖÆ»ð¼ýµÄ·Ö¼¶£¬ÎÀÐÇÇÐ»»
        else if (RocketMove.num0 == 1)
        {
            AllObjects.ROCKETCZ7.GetComponent<TrailRenderer>().enabled = true;
        }
        //else if (RocketMove.num0 == 5)
        //{
        //    AllObjects.Fairing_Group.SetActive(false);
        //    AllObjects.TZ1_Body.SetActive(true);
        //    Quaternion targetRotation_Fairing1 = Quaternion.Euler(AllObjects.ROCKETCZ7.transform.rotation.x + 60, AllObjects.ROCKETCZ7.transform.rotation.y, AllObjects.ROCKETCZ7.transform.rotation.z);
        //    Quaternion targetRotation_Fairing2 = Quaternion.Euler(AllObjects.ROCKETCZ7.transform.rotation.x - 60, AllObjects.ROCKETCZ7.transform.rotation.y, AllObjects.ROCKETCZ7.transform.rotation.z);
        //    //Quaternion targetRotation_Fairing1 = Quaternion.Euler( 93+90, 84f, 0);
        //    //Quaternion targetRotation_Fairing2 = Quaternion.Euler( -87+90, 84f, 0);
        //    AllObjects.Fairing1.transform.rotation = Quaternion.Slerp(AllObjects.Fairing1.transform.rotation, targetRotation_Fairing1, Time.fixedDeltaTime * 0.1f);
        //    AllObjects.Fairing2.transform.rotation = Quaternion.Slerp(AllObjects.Fairing2.transform.rotation, targetRotation_Fairing2, Time.fixedDeltaTime * 0.1f);
        //    //AllObjects.Fairing.transform.SetParent(GameObject.Find("Pause").transform);
        //}
        //else if (RocketMove.num0 == 7)
        //{
        //    AllObjects.Fairing.SetActive(false);
        //}
        else if (RocketMove.num1 > 0)
        {
            if ( !flag_RocketToSatellite )
            {
                AllObjects.TZ1_Body.SetActive(true);
                AllObjects.TZ1_SolarPanel.SetActive(true);
                AllObjects.CZ7.SetActive(false);
                //AllObjects.Second_And_Third.transform.SetParent(GameObject.Find("Pause").transform);
                flag_RocketToSatellite = true;
            }
        }
    }

}
