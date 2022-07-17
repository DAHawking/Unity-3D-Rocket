using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineMove : MonoBehaviour
{

    //��Ϸ�����������߶ζ���
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

        //    LineSet.linerenderer.SetColors(Color.blue, Color.red);//������ɫ  
        //    LineSet.linerenderer.SetWidth(0.2f, 0.1f);//���ÿ��  

        //    LineSet[i].linerenderer.SetVertexCount(Positions.Count);//���ö�����
        //    for (int j = 0; j < Positions.Count; j++)
        //    {
        //        LineSet[i].linerenderer.SetPosition(j, Positions[j]);//���ö���λ��   
        //    }
        //}



    }

    private int num=0;
    [Obsolete]
    void FixedUpdate()
    {
        for (int i = 0; i < LineSet.Length; i++)
        {
            LineSet[i].linerenderer.SetVertexCount(num + 1);//���ö�����
            LineSet[i].linerenderer.SetPosition(num, LineSet[i].PositionsGameObject.GetComponent<Transform>().position);//���ö���λ��   
        }
        num++;
    }
}
