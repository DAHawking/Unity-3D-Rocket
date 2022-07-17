using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (RocketMove.num0 > 0 && RocketMove.num1 <= 0)
        {
            DynamicImage(GameObject.Find("FunctionImage/FuncitonPoint_x"), RocketMove.num0, UDPReceive.RealTimePositionsUI[RocketMove.num0].x / 1000);
            DynamicImage(GameObject.Find("FunctionImage/FuncitonPoint_y"), RocketMove.num0, UDPReceive.RealTimePositionsUI[RocketMove.num0].y / 1000);
            DynamicImage(GameObject.Find("FunctionImage/FuncitonPoint_z"), RocketMove.num0, UDPReceive.RealTimePositionsUI[RocketMove.num0].z / 1000);
            DynamicImage(GameObject.Find("FunctionImage/FuncitonPoint_vx"), RocketMove.num0, UDPReceive.RealTimeVelocity[RocketMove.num0].x / 1000);
            DynamicImage(GameObject.Find("FunctionImage/FuncitonPoint_vy"), RocketMove.num0, UDPReceive.RealTimeVelocity[RocketMove.num0].y / 1000);
            DynamicImage(GameObject.Find("FunctionImage/FuncitonPoint_vz"), RocketMove.num0, UDPReceive.RealTimeVelocity[RocketMove.num0].z / 1000);
            DynamicImage(GameObject.Find("FunctionImage/FuncitonPoint_Pitch"), RocketMove.num0, UDPReceive.RealTimeAttitude[RocketMove.num0].x / 1000);
            DynamicImage(GameObject.Find("FunctionImage/FuncitonPoint_Yaw"), RocketMove.num0, UDPReceive.RealTimeAttitude[RocketMove.num0].y / 1000);
            DynamicImage(GameObject.Find("FunctionImage/FuncitonPoint_Mass"), RocketMove.num0, UDPReceive.RealTimeAttitude[RocketMove.num0].z / 1000);
        }
        else if(RocketMove.num1 > 0)
        {
            DynamicImage(GameObject.Find("FunctionImage/FuncitonPoint_x"), (RocketMove.num0 + RocketMove.num1), UDPReceive.OrbitRebuildPositionsUI[RocketMove.num1].x / 1000);
            DynamicImage(GameObject.Find("FunctionImage/FuncitonPoint_y"), (RocketMove.num0 + RocketMove.num1), UDPReceive.OrbitRebuildPositionsUI[RocketMove.num1].y / 1000);
            DynamicImage(GameObject.Find("FunctionImage/FuncitonPoint_z"), (RocketMove.num0 + RocketMove.num1), UDPReceive.OrbitRebuildPositionsUI[RocketMove.num1].z / 1000);
            DynamicImage(GameObject.Find("FunctionImage/FuncitonPoint_vx"), (RocketMove.num0 + RocketMove.num1), UDPReceive.OrbitRebuildVelocity[RocketMove.num1].x / 1000);
            DynamicImage(GameObject.Find("FunctionImage/FuncitonPoint_vy"), (RocketMove.num0 + RocketMove.num1), UDPReceive.OrbitRebuildVelocity[RocketMove.num1].y / 1000);
            DynamicImage(GameObject.Find("FunctionImage/FuncitonPoint_vz"), (RocketMove.num0 + RocketMove.num1), UDPReceive.OrbitRebuildVelocity[RocketMove.num1].z / 1000);
        }
    }
    //FuncitonPoint_x是绘制函数图像的点的横坐标；FuncitonPoint_y是纵坐标,显示数据信息；
    public void DynamicImage(GameObject FuncitonPoint, int FuncitonPoint_x, float FuncitonPoint_y)
    {
            FuncitonPoint.transform.position = new Vector3(0.005f * FuncitonPoint_x, FuncitonPoint_y + 5000f, 0);
    }
}
