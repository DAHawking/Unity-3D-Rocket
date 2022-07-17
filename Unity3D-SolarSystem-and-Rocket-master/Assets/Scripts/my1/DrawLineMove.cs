using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineMove : MonoBehaviour
{

    //游戏对象，这里是线段对象
    [Serializable]
    public class Line
    {
        public GameObject LineGameObject;
        public LineRenderer linerenderer;
        public GameObject PositionsGameObject;
        //public string PositionsName;
    }

    public Line[] LineSet = new Line[0];
    private List<Vector3> Positions = new List<Vector3>();

    [Obsolete]
    void Start()
    {
        for(int i = 0; i < LineSet.Length; i++)
        {
            LineSet[i].linerenderer = LineSet[i].LineGameObject.GetComponent<LineRenderer>();
        }

        //for (int i = 0; i < LineSet.Length; i++)
        //{
        //    LineSet[i].linerenderer = LineSet[i].LineGameObject.GetComponent<LineRenderer>();

        //    if (LineSet[i].PositionsName == "InjectPositions")
        //    {
        //        Positions = RocketMove.InjectPositions;
        //    }
        //    else
        //    {
        //        Positions = RocketMove.OrbitPositions;
        //    }

        //    LineSet.linerenderer.SetColors(Color.blue, Color.red);//设置颜色  
        //    LineSet.linerenderer.SetWidth(0.2f, 0.1f);//设置宽度  

        //    LineSet[i].linerenderer.SetVertexCount(Positions.Count);//设置顶点数
        //    for (int j = 0; j < Positions.Count; j++)
        //    {
        //        LineSet[i].linerenderer.SetPosition(j, Positions[j]);//设置顶点位置   
        //    }
        //}



    }

    private int num=0;
    [Obsolete]
    void FixedUpdate()
    {
        for (int i = 0; i < LineSet.Length; i++)
        {
            LineSet[i].linerenderer.SetVertexCount(num + 1);//设置顶点数
            LineSet[i].linerenderer.SetPosition(num, LineSet[i].PositionsGameObject.GetComponent<Transform>().position);//设置顶点位置   
        }
        num++;
    }
}
