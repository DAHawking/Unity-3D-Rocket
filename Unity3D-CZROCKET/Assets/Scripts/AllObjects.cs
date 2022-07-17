using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllObjects : MonoBehaviour
{
    public static GameObject ROCKETCZ7;
    public static GameObject CZ7;
    public static GameObject Fairing;
    public static GameObject Fairing1;
    public static GameObject Fairing2;
    public static GameObject Fairing_Group;
    public static GameObject Second_And_Third;
    public static GameObject Camera_1And2;
    public static GameObject TZ1;
    public static GameObject TZ1_SolarPanel;
    public static GameObject TZ1_Body;
    public static GameObject Camera_RocketFlow;
    public static GameObject Camera_RocketFlow_Move;


    public static GameObject Earth;
    public static GameObject Camera_Earth;

    public static GameObject Drawline;
    public static GameObject LINE1;
    public static GameObject LINE2;
    public static GameObject LINE3;
    public static GameObject LINE4;

    public static GameObject UDP;
    public static GameObject UDP_G;
    public static GameObject UDP_H;

    public static GameObject FunctionImage;
    public static GameObject CameraFunctionImage;
    public static GameObject Funtion_x;
    public static GameObject Funtion_y;
    public static GameObject FuncitonPoint_x;
    public static GameObject FuncitonPoint_y;
    public static GameObject FuncitonPoint_z;
    public static GameObject FuncitonPoint_vx;
    public static GameObject FuncitonPoint_vy;
    public static GameObject FuncitonPoint_vz;
    public static GameObject FuncitonPoint_Pitch;
    public static GameObject FuncitonPoint_Yaw;
    public static GameObject FuncitonPoint_Mass;





    // Start is called before the first frame update
    void Awake()
    {
        ROCKETCZ7 = GameObject.Find("ROCKETCZ7");
        CZ7 = GameObject.Find("ROCKETCZ7/CZ7");
        Fairing = GameObject.Find("ROCKETCZ7/CZ7/Fairing");
        Fairing1 = GameObject.Find("ROCKETCZ7/CZ7/Fairing/Fairing1");
        Fairing2 = GameObject.Find("ROCKETCZ7/CZ7/Fairing/Fairing2");
        Fairing_Group = GameObject.Find("ROCKETCZ7/CZ7/Fairing/Fairing_Group");
        Second_And_Third = GameObject.Find("ROCKETCZ7/CZ7/Second_And_Third");
        TZ1 = GameObject.Find("ROCKETCZ7/TZ1");
        TZ1_SolarPanel = GameObject.Find("ROCKETCZ7/TZ1/TZ1_SolarPanel");
        TZ1_Body = GameObject.Find("ROCKETCZ7/TZ1/TZ1_Body");
        Camera_1And2 = GameObject.Find("ROCKETCZ7/Camera_1And2");
        Camera_RocketFlow = GameObject.Find("ROCKETCZ7/Camera_1And2/Camera_RocketFlow");
        Camera_RocketFlow_Move = GameObject.Find("ROCKETCZ7/Camera_1And2/Camera_RocketFlow_Move");

        Earth = GameObject.Find("Earth");

        Camera_Earth = GameObject.Find("Camera_Earth");

        Drawline = GameObject.Find("Drawline");
        LINE1 = GameObject.Find("Drawline/LINE1");
        LINE2 = GameObject.Find("Drawline/LINE2");
        LINE3 = GameObject.Find("Drawline/LINE3");
        LINE4 = GameObject.Find("Drawline/LINE4");

        UDP = GameObject.Find("UDP");
        UDP_G = GameObject.Find("UDP/UDP_G");
        UDP_H = GameObject.Find("UDP/UDP_H");

        FunctionImage = GameObject.Find("FunctionImage");
        CameraFunctionImage = GameObject.Find("FunctionImage/CameraFunctionImage");
        Funtion_x = GameObject.Find("FunctionImage/Funtion_x");
        Funtion_y = GameObject.Find("FunctionImage/Funtion_y");
        FuncitonPoint_x = GameObject.Find("FunctionImage/FuncitonPoint_x");
        FuncitonPoint_y = GameObject.Find("FunctionImage/FuncitonPoint_y");
        FuncitonPoint_z = GameObject.Find("FunctionImage/FuncitonPoint_z");
        FuncitonPoint_vx = GameObject.Find("FunctionImage/FuncitonPoint_vx");
        FuncitonPoint_vy = GameObject.Find("FunctionImage/FuncitonPoint_vy");
        FuncitonPoint_vz = GameObject.Find("FunctionImage/FuncitonPoint_vz");
        FuncitonPoint_Pitch = GameObject.Find("FunctionImage/FuncitonPoint_Pitch");
        FuncitonPoint_Yaw = GameObject.Find("FunctionImage/FuncitonPoint_Yaw");
        FuncitonPoint_Mass = GameObject.Find("FunctionImage/FuncitonPoint_Mass");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
