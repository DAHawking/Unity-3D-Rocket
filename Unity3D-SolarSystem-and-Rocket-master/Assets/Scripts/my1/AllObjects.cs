using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllObjects : MonoBehaviour
{
    public static GameObject ROCKETCZ5;
    public static GameObject cz5;
    public static GameObject Booster;
    public static GameObject Booster1;
    public static GameObject Booster2;
    public static GameObject Booster3;
    public static GameObject Booster4;
    public static GameObject First;
    public static GameObject TrailFrameBooster;
    public static GameObject TrailFrameFirst;
    public static GameObject TrailFrameSecond;

    public static GameObject Ground;
    public static GameObject TERRAIN;
    public static GameObject WindZone;
    public static GameObject platform;

    public static GameObject Earth;

    public static GameObject LineX1;
    public static GameObject LineX2;

    public static GameObject Canvas;

    public static GameObject CameraPlatform2;
    public static GameObject CameraEarth;
    public static GameObject CameraCanvas;
    public static GameObject CameraAxisDistance;
    public static GameObject CameraAxisVelocity;
    public static GameObject Camera;
    public static GameObject CameraGround1;
    public static GameObject CameraLift1;
    public static GameObject CameraLift2;
    public static GameObject CameraMakeATurn1;
    public static GameObject CameraMakeATurn2;
    public static GameObject CameraSeparate1;
    public static GameObject CameraSeparate2;
    public static GameObject CameraSeparate3;
    public static GameObject CameraInject1;
    public static GameObject CameraInject2;

    public static GameObject PointDistance;
    public static GameObject PointVelocity;




    // Start is called before the first frame update
    void Awake()
    {
        ROCKETCZ5 = GameObject.Find("ROCKETCZ5");
        cz5 = GameObject.Find("ROCKETCZ5/cz5");
        Booster = GameObject.Find("ROCKETCZ5/cz5/Booster");
        Booster1 = GameObject.Find("ROCKETCZ5/cz5/Booster/Booster1");
        Booster2 = GameObject.Find("ROCKETCZ5/cz5/Booster/Booster2");
        Booster3 = GameObject.Find("ROCKETCZ5/cz5/Booster/Booster3");
        Booster4 = GameObject.Find("ROCKETCZ5/cz5/Booster/Booster4");
        First = GameObject.Find("ROCKETCZ5/cz5/First");
        TrailFrameBooster = GameObject.Find("ROCKETCZ5/TrailFrameBooster");
        TrailFrameFirst = GameObject.Find("ROCKETCZ5/TrailFrameFirst");
        TrailFrameSecond = GameObject.Find("ROCKETCZ5/TrailFrameSecond");
        Ground = GameObject.Find("Ground/TERRAIN");
        WindZone = GameObject.Find("Ground/WindZone");
        platform = GameObject.Find("Ground/platform");
        Earth = GameObject.Find("Earth");
        LineX1 = GameObject.Find("LineX1");
        LineX2 = GameObject.Find("LineX2");
        Canvas = GameObject.Find("Canvas");
        CameraPlatform2 = GameObject.Find("CameraPlatform2");
        CameraEarth = GameObject.Find("CameraEarth");
        CameraCanvas = GameObject.Find("CameraCanvas");
        Camera = GameObject.Find("ROCKETCZ5/Camera");
        CameraGround1 = GameObject.Find("ROCKETCZ5/Camera/CameraGround1");
        CameraLift1 = GameObject.Find("ROCKETCZ5/Camera/CameraLift1");
        CameraLift2 = GameObject.Find("ROCKETCZ5/Camera/CameraLift2");
        CameraMakeATurn1 = GameObject.Find("ROCKETCZ5/Camera/CameraMakeATurn1");
        CameraMakeATurn2 = GameObject.Find("ROCKETCZ5/Camera/CameraMakeATurn2");
        CameraSeparate1 = GameObject.Find("ROCKETCZ5/Camera/CameraSeparate1");
        CameraSeparate2 = GameObject.Find("ROCKETCZ5/Camera/CameraSeparate2");
        CameraSeparate3 = GameObject.Find("ROCKETCZ5/Camera/CameraSeparate3");
        CameraInject1 = GameObject.Find("ROCKETCZ5/Camera/CameraInject1");
        CameraInject2 = GameObject.Find("ROCKETCZ5/Camera/CameraInject2");
        CameraAxisDistance = GameObject.Find("AxisDistance/CameraAxisDistance");
        CameraAxisVelocity = GameObject.Find("AxisVelocity/CameraAxisVelocity");
        PointDistance = GameObject.Find("PointDistance");
        PointVelocity = GameObject.Find("PointVelocity");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
