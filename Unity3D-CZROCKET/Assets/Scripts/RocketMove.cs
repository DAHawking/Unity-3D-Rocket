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
    public float MoveTime;   //��������֮�������ʱ��
    private float TimeTemp;
    public static float Shrink = 2000;   //��������
    public Vector3 Speed;
    public float TurnSpeed;
    private List<string> al = new List<string>();   //ReadToArrayList()���м����
    public static List<Vector3> TrajectoryRebuildPositions = new List<Vector3>();
    public static List<Vector3> OrbitRebuildPositions = new List<Vector3>();//�������
    public static List<Vector3> TrajectoryStandardPositions = new List<Vector3>();
    public static List<Vector3> OrbitStandardPositions = new List<Vector3>();//�������
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
            //����ʵʱλ��
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
            //����л��ڹ����
            else if(OrbitRebuildPositions.Count > 0 && ((num0 + 1) >= RealTimePositions.Count))
            {
                if (!Is_Init_Rocket_OrbitPosition)
                {
                    Rocket.transform.position = OrbitRebuildPositions[0];
                    nextposition = OrbitRebuildPositions[0];
                    Is_Init_Rocket_OrbitPosition = true;
                }
                UpdatePosition(OrbitRebuildPositions, ref num1);
                num1 = num1 % CalculateRun.Integral_num; //�趨�������ݵ���ظ��ڹ����
            }
            //��������
            if (TrajectoryStandardPositions.Count > 0 && OrbitStandardPositions.Count > 0 && !Is_Draw_Standard)
            {
                GameObject.Find("DrawLine/LINE1").GetComponent<LineRenderer>().SetVertexCount(TrajectoryStandardPositions.Count);  //���ö�����
                for (int j = 0; j < TrajectoryStandardPositions.Count; j++)
                {
                    //Debug.Log("j : " + j + " GameObject of TrajectoryStandardPositions : " + TrajectoryStandardPositions[j]);
                    GameObject.Find("DrawLine/LINE1").GetComponent<LineRenderer>().SetPosition(j, TrajectoryStandardPositions[j]);  //���ö���λ��
                }
                GameObject.Find("DrawLine/LINE2").GetComponent<LineRenderer>().SetVertexCount(OrbitStandardPositions.Count);  //���ö�����
                for (int j = 0; j < OrbitStandardPositions.Count; j++)
                {
                    GameObject.Find("DrawLine/LINE2").GetComponent<LineRenderer>().SetPosition(j, OrbitStandardPositions[j]);  //���ö���λ��
                }
                Is_Draw_Standard = true;
            }
            if (TrajectoryRebuildPositions.Count > 0 && OrbitRebuildPositions.Count > 0 && !Is_Draw_Rebuild)
            {
                GameObject.Find("DrawLine/LINE3").GetComponent<LineRenderer>().SetVertexCount(TrajectoryRebuildPositions.Count);  //���ö�����
                for (int j = 0; j < TrajectoryRebuildPositions.Count; j++)
                {
                    GameObject.Find("DrawLine/LINE3").GetComponent<LineRenderer>().SetPosition(j, TrajectoryRebuildPositions[j]);  //���ö���λ��
                }
                GameObject.Find("DrawLine/LINE4").GetComponent<LineRenderer>().SetVertexCount(OrbitRebuildPositions.Count);  //���ö�����
                for (int j = 0; j < OrbitRebuildPositions.Count; j++)
                {
                    GameObject.Find("DrawLine/LINE4").GetComponent<LineRenderer>().SetPosition(j, OrbitRebuildPositions[j]);  //���ö���λ��
                }
                Is_Draw_Rebuild = true;
            }
        }

            //�����ϵ�


        //Quaternion q = Quaternion.LookRotation(Rocket.transform.position - preposition);
        //Quaternion.RotateTowards(Rocket.transform.rotation, q, TurnSpeed * Time.fixedDeltaTime);
        //Rocket.transform.LookAt(preposition);


    }

    // path��·����          Positions���յ���ά�������飬����Ҫ�����ݡ�
    // ColNumber���ı�һ���ж����С�    C1, C2, C3����ʾ��Ҫ��ȡ���������ڵ��С�
    //public void ReadToArrayList(string path, List<Vector3> Positions, int ColNumber, int C1, int C2, int C3)
    //{
    //    string txtPath = path;
    //    StreamReader sr = new StreamReader(txtPath, Encoding.Default);   //StreamReader(Stream, Encoding)I/O����ȡ�ı�
    //    string line;
    //    while ((line = sr.ReadLine()) != null)      //����ȡ�����ݰ��ж�ȡ
    //    {
    //        string[] str = line.Split(' ');      //�ÿո��ַ���������
    //        for (int i = 0; i < str.Length; i++)
    //        {
    //            al.Add(str[i]);
    //        }
    //    }
    //    for (int i = 0; i < al.Count; i += ColNumber)     //ȡ���ı���ָ���е����ݲ���ΪUnity�е���ά����
    //    {
    //        Positions.Add(new Vector3((float)Convert.ToDouble(al[i + C1].ToString()),
    //            (float)Convert.ToDouble(al[i + C2].ToString()),
    //            (float)Convert.ToDouble(al[i + C3].ToString())) / Shrink);
    //    }
    //    al.Clear();
    //}
    //���»��λ��
    public void UpdatePosition(List<Vector3> Positions, ref int CalPointsNumber )
    {
        Speed = (Positions[CalPointsNumber + 1] - Rocket.transform.position) / MoveTime;   //��1��2���ٶ�=��1ָ���2�ľ�������/�˶�ʱ��
        nextposition += Speed * Time.fixedDeltaTime;   //���ػ����һ֡��λ��=��ǰλ��+�ٶ�*ÿһ֡��ʱ��
        Quaternion q = Quaternion.LookRotation(nextposition - Rocket.transform.position);     //�������ػ��ͷ��ָ����һ����
        Rocket.transform.rotation = Quaternion.Slerp(Rocket.transform.rotation, q, TurnSpeed * Time.fixedDeltaTime);
        Rocket.transform.position = nextposition;
        TimeTemp -= Time.fixedDeltaTime;   //�����ػ���ߵ���һ����󣬸����������Ϣ���ظ�ִ���˶�����
        if (TimeTemp <= 0)
        {
            CalPointsNumber++ ;
            TimeTemp = MoveTime;
        }
    }
    //���ݾ���תΪUnity��ά����
    public static void PointToArrayList(double[] al, List<Vector3> Positions, int ColNumber, int C1, int C2, int C3, int a1_length)
    {
        for (int i = 0; i < a1_length; i += ColNumber)     //ȡ���ı���ָ���е����ݲ���ΪUnity�е���ά����
        {
            Positions.Add(new Vector3((float)al[i + C1], (float)al[i + C2], (float)al[i + C3]) /Shrink );
        }
    }
}

