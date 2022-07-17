using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{

    //��Ϸ�����������߶ζ���
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

                //LineSet.linerenderer.SetColors(Color.blue, Color.red);//������ɫ  
                //LineSet.linerenderer.SetWidth(0.2f, 0.1f);//���ÿ��  

                LineSet[i].linerenderer = LineSet[i].LineGameObject.GetComponent<LineRenderer>();
                LineSet[i].linerenderer.SetVertexCount(Positions.Count);  //���ö�����
                //int Init_PositionLine_Number = Positions.Count - 200;
                for (int j = 0; j < Positions.Count; j++)
                {
                    LineSet[i].linerenderer.SetPosition(j, Positions[j]);  //���ö���λ��
                }
            }
    }
}
