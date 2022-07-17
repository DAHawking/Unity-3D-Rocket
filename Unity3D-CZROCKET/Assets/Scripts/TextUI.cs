using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (RocketMove.num0 > 0 && RocketMove.num1 <= 0)
        {
            GameObject.Find("Canvas/Text_Position").GetComponent<Text>().text = "Position (m)   (x, y, z) = " + UDPReceive.RealTimePositionsUI[RocketMove.num0] * RocketMove.Shrink;
            GameObject.Find("Canvas/Text_Velocity").GetComponent<Text>().text = "Velocity (m/s)   (vx, vy, vz) = " + UDPReceive.RealTimeVelocity[RocketMove.num0];
            GameObject.Find("Canvas/Text_Attitude").GetComponent<Text>().text = "Attitude   (Pitch£¬Yaw£¬Mass) = " + UDPReceive.RealTimeAttitude[RocketMove.num0];
        }
        else if (RocketMove.num1 > 0)
        {
            GameObject.Find("Canvas/Text_Position").GetComponent<Text>().text = "Position (m)   (x, y, z) = " + UDPReceive.OrbitRebuildPositionsUI[RocketMove.num1] * RocketMove.Shrink;
            GameObject.Find("Canvas/Text_Velocity").GetComponent<Text>().text = "Velocity (m/s)   (vx, vy, vz) = " + UDPReceive.OrbitRebuildVelocity[RocketMove.num1] * RocketMove.Shrink;
            GameObject.Find("Canvas/Text_Attitude").GetComponent<Text>().text = " ";
        }
    }
}
