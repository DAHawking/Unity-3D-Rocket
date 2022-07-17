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
        //GameObject ui = GameObject.Find("Canvas/Text");
        //ui.guiText.text = " ";

        if (RocketMove.num3 >= 1 && RocketMove.num4 < 90)
        {
            GameObject.Find("Canvas/Text").GetComponent<Text>().text = "Position (m)    (x, y, z) = " + RocketMove.InjectPositions[RocketMove.num3] * 2000 + 
                "    L = " + Vector3.Magnitude(RocketMove.InjectPositions[RocketMove.num3]) * 2000;
            GameObject.Find("Canvas/Text1").GetComponent<Text>().text = "Speed (m/s)    (Vx, Vy, Vz) = " + RocketMove.InjectSpeed[RocketMove.num3] * 2000 +
                "    V = " + Vector3.Magnitude(RocketMove.InjectSpeed[RocketMove.num3]) * 2000;
            GameObject.Find("Canvas/Text2").GetComponent<Text>().text = "Gesture (Pitch£¬Yaw£¬Mass) = " + RocketMove.InjectGesture[RocketMove.num3] * 2000;
        }
        else if (RocketMove.num4 >= 90 && RocketMove.num4 <= RocketMove.InjectSpeed.Count - 2)
        {
            GameObject.Find("Canvas/Text").GetComponent<Text>().text = "Position (m)    (x, y, z) = " + RocketMove.InjectPositions[RocketMove.num4] * 2000 +
                "    L = " + Vector3.Magnitude(RocketMove.InjectPositions[RocketMove.num4]) * 2000;
            GameObject.Find("Canvas/Text1").GetComponent<Text>().text = "Speed (m/s)    (Vx, Vy, Vz) = " + RocketMove.InjectSpeed[RocketMove.num4] * 2000 +
                "    V = " + Vector3.Magnitude(RocketMove.InjectSpeed[RocketMove.num4]) * 2000;
            GameObject.Find("Canvas/Text2").GetComponent<Text>().text = "Gesture    (Pitch£¬Yaw£¬Mass) = " + RocketMove.InjectGesture[RocketMove.num4] * 2000;
        }
        else if (RocketMove.num5 < RocketMove.OrbitPositions.Count - 1)
        {
            GameObject.Find("Canvas/Text").GetComponent<Text>().text = "Position (m)    (x, y, z) = " + RocketMove.OrbitPositions[RocketMove.num5] * 2000 +
                "    L = " + Vector3.Magnitude(RocketMove.OrbitPositions[RocketMove.num5]) * 2000; 
            GameObject.Find("Canvas/Text1").GetComponent<Text>().text = "Speed (m/s)    (Vx, Vy, Vz) = " + RocketMove.OrbitSpeed[RocketMove.num5] * 2000 +
                "    V = " + Vector3.Magnitude(RocketMove.OrbitSpeed[RocketMove.num5]) * 2000;
            GameObject.Find("Canvas/Text2").GetComponent<Text>().text = " ";
        }
    }
}
