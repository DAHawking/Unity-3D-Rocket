using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    public GameObject rocket;
    public string LiftPath;
    public string MakeATurnPath;
    public string SeparatePath;
    public string InjectPath;
    public string OrbitPath;
    public string InjectStandardPath;
    public string OrbitStandardPath;
    public float MoveTime;   //数据两点之间的运行时间
    private float TimeTemp;
    public  float Shrink;   //放缩倍数
    public Vector3 Speed;
    public float TurnSpeed;
    private List<string> al = new List<string>();   //ReadToArrayList()的中间变量
    public static List<Vector3> LiftPositions = new List<Vector3>();
    public static List<Vector3> MakeATurnPositions = new List<Vector3>();
    public static List<Vector3> SeparatePositions = new List<Vector3>();
    public static List<Vector3> InjectPositions = new List<Vector3>();
    public static List<Vector3> OrbitPositions = new List<Vector3>();//存坐标点
    public static List<Vector3> InjectStandardPositions = new List<Vector3>();
    public static List<Vector3> OrbitStandardPositions = new List<Vector3>();//存坐标点
    public static List<Vector3> InjectSpeed = new List<Vector3>();
    public static List<Vector3> OrbitSpeed = new List<Vector3>();
    public static List<Vector3> InjectGesture = new List<Vector3>();



    // Start is called before the first frame update
    void Awake()
    {
        ReadToArrayList(LiftPath, LiftPositions, 4, 1 ,2 ,3);
        ReadToArrayList(MakeATurnPath, MakeATurnPositions, 4, 1, 2, 3);
        ReadToArrayList(SeparatePath, SeparatePositions, 4, 1, 2, 3);
        ReadToArrayList(InjectPath, InjectPositions, 10, 1, 2, 3);
        ReadToArrayList(OrbitPath, OrbitPositions, 7, 1, 2, 3);
        ReadToArrayList(InjectStandardPath, InjectStandardPositions, 10, 1, 2, 3);
        ReadToArrayList(OrbitStandardPath, OrbitStandardPositions, 7, 1, 2, 3);
        ReadToArrayList(InjectPath, InjectSpeed, 10, 4, 5, 6);
        ReadToArrayList(OrbitPath, OrbitSpeed, 7, 4, 5, 6);
        ReadToArrayList(InjectPath, InjectGesture, 10, 7, 8, 9);
        rocket.transform.position = LiftPositions[0];
        TimeTemp = MoveTime;

    }
    public static int num0 = 0, num1 = 0, num2 = 0, num3=0, num4=0, num5=0;
    private Vector3 nextposition;

    // Update is called once per frame
    [Obsolete]
    void FixedUpdate()
    {
        nextposition = rocket.transform.position;
        if (num0 < LiftPositions.Count - 1)
        {
            UpdatePosition(LiftPositions, ref num0);
            if (num0 == LiftPositions.Count - 1)
            {
                rocket.transform.position = MakeATurnPositions[0];
                //Debug.Log(num0);
            }
        }
        else if (num1 < MakeATurnPositions.Count - 1)
        {
            UpdatePosition(MakeATurnPositions, ref num1);
            if (num1 == MakeATurnPositions.Count - 1)
            {
                rocket.transform.position = SeparatePositions[0];
            }
        }
        else if (num2 < SeparatePositions.Count - 1)
        {
            UpdatePosition(SeparatePositions, ref num2);
            if (num2 == SeparatePositions.Count - 1)
            {
                rocket.transform.position = InjectStandardPositions[0];
            }
        }
        else if (num3 < 90)
        {
            UpdatePosition(InjectStandardPositions, ref num3);
            if (num3 == 90)
            {
                rocket.transform.position = InjectPositions[89];
                num4 = 89;
                this.GetComponent<LineRenderer>().SetVertexCount(15);//设置顶点数
                for(int i = 0; i < 15; i++)
                {
                    this.GetComponent<LineRenderer>().SetPosition(i, InjectPositions[89+i]);//设置顶点位置
                }
            }
        }
        else if (num4 < InjectPositions.Count - 1)
        {
            UpdatePosition(InjectPositions, ref num4);
        }
        else if (num5 < OrbitPositions.Count - 1)
        {
            UpdatePosition(OrbitPositions, ref num5);
        }

        //Quaternion q = Quaternion.LookRotation(rocket.transform.position - preposition);
        //Quaternion.RotateTowards(rocket.transform.rotation, q, TurnSpeed * Time.fixedDeltaTime);
        //rocket.transform.LookAt(preposition);


    }

    // path：路径。          Positions：空的三维向量数组，存需要的数据。
    // ColNumber：文本一行有多少列。    C1, C2, C3：表示需要获取的数据所在的列。
    public void ReadToArrayList(string path, List<Vector3> Positions, int ColNumber, int C1, int C2, int C3)
    {
        string txtPath = path;
        StreamReader sr = new StreamReader(txtPath, Encoding.Default);   //StreamReader(Stream, Encoding)I/O流读取文本
        string line;
        while ((line = sr.ReadLine()) != null)      //将读取的数据按行读取
        {
            string[] str = line.Split(' ');      //用空格字符划分数据
            for (int i = 0; i < str.Length; i++)
            {
                al.Add(str[i]);
            }
        }
        for (int i = 0; i < al.Count; i += ColNumber)     //取出文本中指定列的数据并存为Unity中的三维向量
        {
            Positions.Add(new Vector3((float)Convert.ToDouble(al[i + C1].ToString()),
                (float)Convert.ToDouble(al[i + C2].ToString()),
                (float)Convert.ToDouble(al[i + C3].ToString())) / Shrink);
        }
        al.Clear();
    }
    public void UpdatePosition(List<Vector3> Positions, ref int CalPointsNumber )
    {
        Speed = (Positions[CalPointsNumber + 1] - Positions[CalPointsNumber]) / MoveTime;   //点1到2的速度=点1指向点2的距离向量/运动时间
        nextposition += Speed * Time.fixedDeltaTime;   //运载火箭下一帧的位置=当前位置+速度*每一帧的时间
        Quaternion q = Quaternion.LookRotation(nextposition - rocket.transform.position);     //控制运载火箭头部指向下一个点
        rocket.transform.rotation = Quaternion.Slerp(rocket.transform.rotation, q, TurnSpeed * Time.fixedDeltaTime);
        rocket.transform.position = nextposition;
        TimeTemp -= Time.fixedDeltaTime;   //当运载火箭走到下一个点后，更新两点的信息，重复执行运动过程
        if (TimeTemp <= 0)
        {
            CalPointsNumber++ ;
            TimeTemp = MoveTime;
            Debug.Log(rocket.transform.position);
        }
    }
}

