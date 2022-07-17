using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{

    //游戏对象，这里是线段对象
    [Serializable]
    public class Line
    {
        public GameObject LineGameObject;
        public LineRenderer linerenderer;
        public GameObject PositionsGameObject;
        public string PositionsName;
    }

    public Line[] LineSet = new Line[0];
    private List<Vector3> Positions = new List<Vector3>();

    [System.Obsolete]
    void Start ()
    {
        for (int i = 0; i < LineSet.Length; i++)
        {
            LineSet[i].linerenderer = LineSet[i].LineGameObject.GetComponent<LineRenderer>();

            if (LineSet[i].PositionsName == "InjectPositions")
            {
                Positions = RocketMove.InjectPositions;
            }
            //if (LineSet[i].PositionsName == "OrbitPositions")
            else if (LineSet[i].PositionsName == "OrbitPositions")
            {
                Positions = RocketMove.OrbitPositions;
            }
            else if (LineSet[i].PositionsName == "InjectStandardPositions")
            {
                Positions = RocketMove.InjectStandardPositions;
            }
            else if (LineSet[i].PositionsName == "OrbitStandardPositions")
            {
                Positions = RocketMove.OrbitStandardPositions;
            }

            //LineSet.linerenderer.SetColors(Color.blue, Color.red);//设置颜色  
            //LineSet.linerenderer.SetWidth(0.2f, 0.1f);//设置宽度  

            LineSet[i].linerenderer.SetVertexCount(Positions.Count);  //设置顶点数
            for (int j = 0; j < Positions.Count; j++)
            {
                LineSet[i].linerenderer.SetPosition(j, Positions[j]);  //设置顶点位置
            }
        }



    }


    [System.Obsolete]
    void FixedUpdate()
    {

    }
}
