using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    public GameObject Rocket;
    //public string TrajectoryStandardPath;
    //public string OrbitStandardPath;
    //public string TrajectoryRebuildPath;
    //public string OrbitRebuildPath;
    public float MoveTime;   //数据两点之间的运行时间
    private float TimeTemp;
    public static float Shrink = 2000;   //放缩倍数
    public Vector3 Speed;
    public float TurnSpeed;
    private List<string> al = new List<string>();   //ReadToArrayList()的中间变量
    public static List<Vector3> TrajectoryRebuildPositions = new List<Vector3>();
    public static List<Vector3> OrbitRebuildPositions = new List<Vector3>();//存坐标点
    public static List<Vector3> TrajectoryStandardPositions = new List<Vector3>();
    public static List<Vector3> OrbitStandardPositions = new List<Vector3>();//存坐标点
    public static List<Vector3> TrajectorySpeed = new List<Vector3>();
    public static List<Vector3> OrbitSpeed = new List<Vector3>();
    public static List<Vector3> TrajectoryGesture = new List<Vector3>();
    public static List<Vector3> RealTimePositions = new List<Vector3>();
    private Vector3 nextposition;
    bool Is_Init_Rocket_Position = false;
    bool Is_Init_Rocket_OrbitPosition = false;
    bool Is_Draw_Standard=false;
    bool Is_Draw_Rebuild=false;

    public static int num0 = 0, num1 = 0, num2 = 0, num3 = 0, num4 = 0, num5 = 0;
    public static int Traj_TO_Orbit = 0;
    public static bool drawlinerun = false;

    // Start is called before the first frame update
    void Start()
    {
        TimeTemp = MoveTime;
    }


    // Update is called once per frame
    [Obsolete]
    void FixedUpdate()
    {
        if (UDPReceive.rocketmoverun)
        {
            TrajectoryStandardPositions = UDPReceive.TrajectoryStandardPositionsTemp;
            OrbitStandardPositions = UDPReceive.OrbitStandardPositionsTemp;
            TrajectoryRebuildPositions = UDPReceive.TrajectoryRebuildPositionsTemp;
            OrbitRebuildPositions = UDPReceive.OrbitRebuildPositionsTemp;
            Traj_TO_Orbit = RealTimePositions.Count;
            RealTimePositions = UDPReceive.RealTimePositionsTemp;
            //更新实时位置
            if(RealTimePositions.Count > 1 && ((num0 + 1) < RealTimePositions.Count)) 
            {
                if (!Is_Init_Rocket_Position)
                {
                    Rocket.transform.position = RealTimePositions[0];
                    nextposition = RealTimePositions[0];
                    Is_Init_Rocket_Position = true;
                }
                UpdatePosition(RealTimePositions, ref num0);
            }
            //入轨切换在轨飞行
            else if(OrbitRebuildPositions.Count > 0 && ((num0 + 1) >= RealTimePositions.Count))
            {
                if (!Is_Init_Rocket_OrbitPosition)
                {
                    Rocket.transform.position = OrbitRebuildPositions[0];
                    nextposition = OrbitRebuildPositions[0];
                    Is_Init_Rocket_OrbitPosition = true;
                }
                UpdatePosition(OrbitRebuildPositions, ref num1);
                num1 = num1 % CalculateRun.Integral_num; //设定飞完数据点后，重复在轨飞行
            }
            //绘制线条
            if (TrajectoryStandardPositions.Count > 0 && OrbitStandardPositions.Count > 0 && !Is_Draw_Standard)
            {
                GameObject.Find("DrawLine/LINE1").GetComponent<LineRenderer>().SetVertexCount(TrajectoryStandardPositions.Count);  //设置顶点数
                for (int j = 0; j < TrajectoryStandardPositions.Count; j++)
                {
                    //Debug.Log("j : " + j + " GameObject of TrajectoryStandardPositions : " + TrajectoryStandardPositions[j]);
                    GameObject.Find("DrawLine/LINE1").GetComponent<LineRenderer>().SetPosition(j, TrajectoryStandardPositions[j]);  //设置顶点位置
                }
                GameObject.Find("DrawLine/LINE2").GetComponent<LineRenderer>().SetVertexCount(OrbitStandardPositions.Count);  //设置顶点数
                for (int j = 0; j < OrbitStandardPositions.Count; j++)
                {
                    GameObject.Find("DrawLine/LINE2").GetComponent<LineRenderer>().SetPosition(j, OrbitStandardPositions[j]);  //设置顶点位置
                }
                Is_Draw_Standard = true;
            }
            if (TrajectoryRebuildPositions.Count > 0 && OrbitRebuildPositions.Count > 0 && !Is_Draw_Rebuild)
            {
                GameObject.Find("DrawLine/LINE3").GetComponent<LineRenderer>().SetVertexCount(TrajectoryRebuildPositions.Count);  //设置顶点数
                for (int j = 0; j < TrajectoryRebuildPositions.Count; j++)
                {
                    GameObject.Find("DrawLine/LINE3").GetComponent<LineRenderer>().SetPosition(j, TrajectoryRebuildPositions[j]);  //设置顶点位置
                }
                GameObject.Find("DrawLine/LINE4").GetComponent<LineRenderer>().SetVertexCount(OrbitRebuildPositions.Count);  //设置顶点数
                for (int j = 0; j < OrbitRebuildPositions.Count; j++)
                {
                    GameObject.Find("DrawLine/LINE4").GetComponent<LineRenderer>().SetPosition(j, OrbitRebuildPositions[j]);  //设置顶点位置
                }
                Is_Draw_Rebuild = true;
            }
        }

            //画故障点


        //Quaternion q = Quaternion.LookRotation(Rocket.transform.position - preposition);
        //Quaternion.RotateTowards(Rocket.transform.rotation, q, TurnSpeed * Time.fixedDeltaTime);
        //Rocket.transform.LookAt(preposition);


    }

    // path：路径。          Positions：空的三维向量数组，存需要的数据。
    // ColNumber：文本一行有多少列。    C1, C2, C3：表示需要获取的数据所在的列。
    //public void ReadToArrayList(string path, List<Vector3> Positions, int ColNumber, int C1, int C2, int C3)
    //{
    //    string txtPath = path;
    //    StreamReader sr = new StreamReader(txtPath, Encoding.Default);   //StreamReader(Stream, Encoding)I/O流读取文本
    //    string line;
    //    while ((line = sr.ReadLine()) != null)      //将读取的数据按行读取
    //    {
    //        string[] str = line.Split(' ');      //用空格字符划分数据
    //        for (int i = 0; i < str.Length; i++)
    //        {
    //            al.Add(str[i]);
    //        }
    //    }
    //    for (int i = 0; i < al.Count; i += ColNumber)     //取出文本中指定列的数据并存为Unity中的三维向量
    //    {
    //        Positions.Add(new Vector3((float)Convert.ToDouble(al[i + C1].ToString()),
    //            (float)Convert.ToDouble(al[i + C2].ToString()),
    //            (float)Convert.ToDouble(al[i + C3].ToString())) / Shrink);
    //    }
    //    al.Clear();
    //}
    //更新火箭位置
    public void UpdatePosition(List<Vector3> Positions, ref int CalPointsNumber )
    {
        Speed = (Positions[CalPointsNumber + 1] - Rocket.transform.position) / MoveTime;   //点1到2的速度=点1指向点2的距离向量/运动时间
        nextposition += Speed * Time.fixedDeltaTime;   //运载火箭下一帧的位置=当前位置+速度*每一帧的时间
        Quaternion q = Quaternion.LookRotation(nextposition - Rocket.transform.position);     //控制运载火箭头部指向下一个点
        Rocket.transform.rotation = Quaternion.Slerp(Rocket.transform.rotation, q, TurnSpeed * Time.fixedDeltaTime);
        Rocket.transform.position = nextposition;
        TimeTemp -= Time.fixedDeltaTime;   //当运载火箭走到下一个点后，更新两点的信息，重复执行运动过程
        if (TimeTemp <= 0)
        {
            CalPointsNumber++ ;
            TimeTemp = MoveTime;
        }
    }
    //数据矩阵转为Unity三维向量
    public static void PointToArrayList(double[] al, List<Vector3> Positions, int ColNumber, int C1, int C2, int C3, int a1_length)
    {
        for (int i = 0; i < a1_length; i += ColNumber)     //取出文本中指定列的数据并存为Unity中的三维向量
        {
            Positions.Add(new Vector3((float)al[i + C1], (float)al[i + C2], (float)al[i + C3]) /Shrink );
        }
    }
}

