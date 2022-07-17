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
    int Is_DrawLine = 0;

    [System.Obsolete]
    void Start ()
    {



    }


    [System.Obsolete]
    void FixedUpdate()
    {
            for (int i = 0; i < LineSet.Length; i++)
            {
                if (LineSet[i].PositionsName == "TrajectoryStandardPositions" && RocketMove.TrajectoryStandardPositions.Count > 0 && Is_DrawLine == 0)
                {
                    Positions = RocketMove.TrajectoryStandardPositions;
                    Is_DrawLine++;
                }
                else if (LineSet[i].PositionsName == "OrbitStandardPositions" && RocketMove.OrbitStandardPositions.Count > 0 && Is_DrawLine == 1)
                {
                    Positions = RocketMove.OrbitStandardPositions;
                    Is_DrawLine++;
                }
                else if (LineSet[i].PositionsName == "TrajectoryRebuildPositions" && RocketMove.TrajectoryRebuildPositions.Count > 0 && Is_DrawLine == 2)
                {
                    Positions = RocketMove.TrajectoryRebuildPositions;
                    Is_DrawLine++;
                }
                //if (LineSet[i].PositionsName == "OrbitRebuildPositions")
                else if (LineSet[i].PositionsName == "OrbitRebuildPositions" && RocketMove.OrbitRebuildPositions.Count > 0 && Is_DrawLine == 3)
                {
                    Positions = RocketMove.OrbitRebuildPositions;
                    Is_DrawLine++;
                }
                else
                {
                    continue;
                }

                //LineSet.linerenderer.SetColors(Color.blue, Color.red);//设置颜色  
                //LineSet.linerenderer.SetWidth(0.2f, 0.1f);//设置宽度  

                LineSet[i].linerenderer = LineSet[i].LineGameObject.GetComponent<LineRenderer>();
                LineSet[i].linerenderer.SetVertexCount(Positions.Count);  //设置顶点数
                //int Init_PositionLine_Number = Positions.Count - 200;
                for (int j = 0; j < Positions.Count; j++)
                {
                    LineSet[i].linerenderer.SetPosition(j, Positions[j]);  //设置顶点位置
                }
            }
    }
}
