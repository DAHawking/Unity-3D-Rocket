using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObjects : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        AllObjects.Earth.SetActive(false);
        AllObjects.CameraEarth.SetActive(false);
        AllObjects.CameraCanvas.SetActive(false);
        AllObjects.CameraAxisDistance.SetActive(false);
        AllObjects.CameraAxisVelocity.SetActive(false);
        AllObjects.Canvas.SetActive(false);
        AllObjects.TrailFrameFirst.SetActive(false);
        AllObjects.TrailFrameBooster.SetActive(false);
        AllObjects.LineX1.SetActive(false);
        AllObjects.LineX2.SetActive(false);
        AllObjects.CameraGround1.SetActive(true);
        AllObjects.CameraPlatform2.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (RocketMove.num0 == 1)
        {
            AllObjects.TrailFrameBooster.SetActive(true);
            AllObjects.TrailFrameFirst.SetActive(true);
        }
        else if (RocketMove.num0 == 41)
        {
            AllObjects.CameraLift2.SetActive(true);
            AllObjects.CameraPlatform2.SetActive(false);
        }

        else if (RocketMove.num0 == RocketMove.LiftPositions.Count - 2)
        {
            AllObjects.CameraMakeATurn1.SetActive(true);
            AllObjects.CameraMakeATurn2.SetActive(true);
            AllObjects.CameraGround1.SetActive(false);
            AllObjects.CameraPlatform2.SetActive(false);
            AllObjects.CameraGround1.SetActive(false);
            AllObjects.CameraLift2.SetActive(false);
            AllObjects.Ground.SetActive(false);
            AllObjects.WindZone.SetActive(false);
            AllObjects.platform.SetActive(false);
            Debug.Log(RocketMove.num0);

        }
        else if (RocketMove.num1 == RocketMove.MakeATurnPositions.Count - 2)
        {
            AllObjects.CameraSeparate1.SetActive(true);
            AllObjects.CameraSeparate2.SetActive(true);
            AllObjects.CameraSeparate3.SetActive(true);
            AllObjects.CameraMakeATurn1.SetActive(false);
            AllObjects.CameraMakeATurn2.SetActive(false);
        }
        else if (RocketMove.num2 == 15)
        {
            AllObjects.Booster1.AddComponent<Rigidbody>();
            AllObjects.Booster2.AddComponent<Rigidbody>();
            AllObjects.Booster3.AddComponent<Rigidbody>();
            AllObjects.Booster4.AddComponent<Rigidbody>();
            AllObjects.TrailFrameBooster.SetActive(false);

        }
        else if (RocketMove.num2 == 50)
        {
            AllObjects.First.AddComponent<Rigidbody>();
            AllObjects.TrailFrameFirst.SetActive(false);
        }

        else if (RocketMove.num2 == 88)
        {
            AllObjects.Booster.SetActive(false);
            AllObjects.First.SetActive(false);
        }
        else if (RocketMove.num2 == RocketMove.SeparatePositions.Count - 2)
        {

        }
        else if (RocketMove.num3 == 1)
        {
            AllObjects.CameraInject1.SetActive(true);
            AllObjects.CameraInject2.SetActive(true);
            AllObjects.Earth.SetActive(true);
            AllObjects.CameraEarth.SetActive(true);
            AllObjects.CameraSeparate1.SetActive(false);
            AllObjects.CameraSeparate2.SetActive(false);
            AllObjects.CameraSeparate3.SetActive(false);
            AllObjects.LineX1.SetActive(true);
            AllObjects.ROCKETCZ5.GetComponent<TrailRenderer>().enabled = true;
            AllObjects.CameraCanvas.SetActive(true);
            AllObjects.CameraAxisDistance.SetActive(true);
            AllObjects.CameraAxisVelocity.SetActive(true);
            AllObjects.Canvas.SetActive(true);
        }
        else if (RocketMove.num4 == 99)
        {
            AllObjects.LineX2.SetActive(true);
        }
        else if (RocketMove.num3 >= 1 && RocketMove.num4 < 90)
        {
            FunctionImage(AllObjects.PointDistance, RocketMove.num3, RocketMove.InjectPositions, 0.125f, 0.0039f, -415f);
            FunctionImage(AllObjects.PointVelocity, RocketMove.num3, RocketMove.InjectSpeed, 30f, 0.004f, -60f);
            AllObjects.PointDistance.GetComponent<TrailRenderer>().enabled = true;
            AllObjects.PointVelocity.GetComponent<TrailRenderer>().enabled = true;
        }
        else if (RocketMove.num4 >= 90 && RocketMove.num4 <= RocketMove.InjectSpeed.Count - 2)
        {
            FunctionImage(AllObjects.PointDistance, RocketMove.num4, RocketMove.InjectPositions, 0.125f, 0.0039f, -415f);
            FunctionImage(AllObjects.PointVelocity, RocketMove.num4, RocketMove.InjectSpeed, 30f, 0.004f, -60f);
        }
        else if (RocketMove.num5 >= 1 && RocketMove.num5 <= RocketMove.OrbitSpeed.Count - 2)
        {
            FunctionImage(AllObjects.PointDistance, RocketMove.num5, RocketMove.OrbitPositions, 0.125f, 0.0035f, -415f);
            FunctionImage(AllObjects.PointVelocity, RocketMove.num5, RocketMove.OrbitSpeed, 30f, 0.002f, -60f);
        }
    }
    public void FunctionImage(GameObject Points, int num, List<Vector3> vectors, float times, float step, float InitialValue)
    {
        float x = Points.transform.position.x;
        float y = Points.transform.position.y;
        float z = Points.transform.position.z;
        Points.transform.position = new Vector3((float)(x + step), -100000f + Vector3.Magnitude(vectors[num]) * times + InitialValue, z);
    }
}
