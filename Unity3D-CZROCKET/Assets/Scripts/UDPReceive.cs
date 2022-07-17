using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class UDPReceive : MonoBehaviour
{
    private bool getNew = false;
    //定义服务端通信插口
    Socket socket_s;
    public int selfConnectPoint = 8001;
    // [Header("本机ip自动获取")]
    public string selfAddress = "192.168.8.123";
    //本机服务端所监听的ip端口对
    EndPoint selfListenEnd, selfListenEnd1 = new IPEndPoint(0, 0);
    //监听线程
    Thread connectThread;
    public string recvStr;
    public double[] trajectory;
    public static List<Vector3> TrajectoryStandardPositionsTemp = new List<Vector3>(), OrbitStandardPositionsTemp = new List<Vector3>(), 
        TrajectoryRebuildPositionsTemp = new List<Vector3>(), OrbitRebuildPositionsTemp = new List<Vector3>(), RealTimePositionsTemp = new List<Vector3>();
    public static List<Vector3> TrajectoryStandardPositionsUI = new List<Vector3>(), OrbitStandardPositionsUI = new List<Vector3>(),
    TrajectoryRebuildPositionsUI = new List<Vector3>(), OrbitRebuildPositionsUI = new List<Vector3>(), RealTimePositionsUI = new List<Vector3>();
    public static List<Vector3> OrbitStandardVelocity = new List<Vector3>(), OrbitRebuildVelocity = new List<Vector3>(), RealTimeVelocity = new List<Vector3>(), 
        RealTimeAttitude = new List<Vector3>();
    //定义接受byte数组的长度
    int recvLen = 0;
    //接收到的byte数据
    byte[] recvData = new byte[19200];
    int num = 0;
    public static bool rocketmoverun = false;
    int realtime_info_num = 0;

    void Awake()
    {
        InitSocket();
    }

    void InitSocket()
    {

        //作为服务端    
        //本机服务器监听的ip端口对
        selfListenEnd = new IPEndPoint(IPAddress.Parse(selfAddress), selfConnectPoint);
        //selfListenEnd = new IPEndPoint(IPAddress.Any, selfConnectPoint);
        socket_s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        socket_s.Bind(selfListenEnd);
        //开启本机服务器监听线程
        connectThread = new Thread(new ThreadStart(SocketReceive));
        connectThread.Start();
    }

    //本机服务器监听
    void SocketReceive()
    {
        while (true)
        {
            recvData = new byte[19200];
            recvLen = socket_s.ReceiveFrom(recvData, ref selfListenEnd1);
            //recvStr = Encoding.Default.GetString(recvData, 0, recvLen);
            //recvStr = Encoding.Default.GetString(recvData);
            //Debug.Log("信息来自" + selfListenEnd1.ToString() + ":" + recvStr);
            //Debug.Log("data" + recvData);
            //Debug.Log("len" + recvLen);
            int size = Marshal.SizeOf(recvData[0]) * recvData.Length;
            IntPtr pnt = Marshal.AllocHGlobal(size);
            Marshal.Copy(recvData, 0, pnt, recvData.Length);
            double[] managedArray2 = new double[recvData.Length / 8];

            Marshal.Copy(pnt, managedArray2, 0, recvData.Length / 8);
            trajectory = managedArray2;
            //for (int i = 0; i < managedArray2.Length; i++)
            //{
            //    Debug.Log("i: " + i +", managedArray2: " + managedArray2[i]);
            //}
            if (selfConnectPoint == 8001 && num == 0)
            {
                CalculateRun.CalOrbit(managedArray2[2184], managedArray2[2185], managedArray2[2186], managedArray2[2187], managedArray2[2188], managedArray2[2189]);
                RocketMove.PointToArrayList(managedArray2, TrajectoryStandardPositionsTemp, 6, 0, 2, 1, 365 * 6);
                RocketMove.PointToArrayList(managedArray2, TrajectoryStandardPositionsUI, 6, 0, 1, 2, 365 * 6);
                //RocketMove.PointToArrayList(managedArray2, RocketMove.TrajectorySpeed, 6, 3, 4, 5);
                RocketMove.PointToArrayList(CalculateRun.orbitPosition.ToArray(), OrbitStandardPositionsTemp, 6, 0, 2, 1, CalculateRun.Integral_num * 6);
                RocketMove.PointToArrayList(CalculateRun.orbitPosition.ToArray(), OrbitStandardPositionsUI, 6, 0, 1, 2, CalculateRun.Integral_num * 6);
                RocketMove.PointToArrayList(CalculateRun.orbitPosition.ToArray(), OrbitStandardVelocity, 6, 3, 4, 5, CalculateRun.Integral_num * 6);
                CalculateRun.orbitPosition.Clear();
                //for (int i = 0; i < OrbitStandardPositionsTemp.Count; i++)
                //{
                //    Debug.Log("i : " + i + ", OrbitStandardPositionsTemp : " + OrbitStandardPositionsTemp[i]);
                //}
                //for (int i = 0; i < OrbitStandardVelocity.Count; i++)
                //{
                //    Debug.Log("i : " + i + ", OrbitStandardVelocity : " + OrbitStandardVelocity[i]);
                //}
                //for (int i = 0; i < TrajectoryStandardPositionsTemp.Count; i++)
                //{
                //    Debug.Log("i: " + i + ", TrajectoryStandardPositionsTemp: " + TrajectoryStandardPositionsTemp[i]);
                //}
                //RocketMove.PointToArrayList(CalculateRun.orbitPosition.ToArray(), RocketMove.TrajectorySpeed, 6, 3, 4, 5);
                num++;

            }
            else if (selfConnectPoint == 8001 && num == 1)
            {
                CalculateRun.CalOrbit(managedArray2[120], managedArray2[121], managedArray2[122], managedArray2[123], managedArray2[124], managedArray2[125]);
                RocketMove.PointToArrayList(managedArray2, TrajectoryRebuildPositionsTemp, 6, 0, 2, 1, 21 * 6);
                RocketMove.PointToArrayList(managedArray2, TrajectoryRebuildPositionsUI, 6, 0, 1, 2, 21 * 6);
                RocketMove.PointToArrayList(CalculateRun.orbitPosition.ToArray(), OrbitRebuildPositionsTemp, 6, 0, 2, 1, CalculateRun.Integral_num * 6);
                RocketMove.PointToArrayList(CalculateRun.orbitPosition.ToArray(), OrbitRebuildPositionsUI, 6, 0, 1, 2, CalculateRun.Integral_num * 6);
                RocketMove.PointToArrayList(CalculateRun.orbitPosition.ToArray(), OrbitRebuildVelocity, 6, 3, 4, 5, CalculateRun.Integral_num * 6);
                //for (int i = 0; i < OrbitRebuildPositionsTemp.Count; i++)
                //{
                //    Debug.Log("i : " + i + ", OrbitRebuildPositionsTemp : " + OrbitRebuildPositionsTemp[i]);
                //}
                num++;
            }
            else if (selfConnectPoint == 8002 && (realtime_info_num++) % 100 == 0)
            {
                RealTimePositionsTemp.Add(new Vector3((float)managedArray2[0], (float)managedArray2[2], (float)managedArray2[1]) / RocketMove.Shrink);
                RealTimePositionsUI.Add(new Vector3((float)managedArray2[0], (float)managedArray2[1], (float)managedArray2[2]) / RocketMove.Shrink);
                RealTimeVelocity.Add(new Vector3((float)managedArray2[3], (float)managedArray2[4], (float)managedArray2[5]));
                RealTimeAttitude.Add(new Vector3((float)managedArray2[6], (float)managedArray2[7], (float)managedArray2[8]));
                //Debug.Log("realtime_info_num : " + realtime_info_num);
                //Debug.Log("Count : " + (RealTimePositionsTemp.Count - 1) + " : " + RealTimePositionsTemp[RealTimePositionsTemp.Count - 1]);
                //for (int i = 0; i < RocketMove.RealTimePositions.Count; i++)
                //{
                //    Debug.Log(RocketMove.RealTimePositions);
                //}
                rocketmoverun = true;
            }
            getNew = true;
        }

    }

    //连接关闭
    void SocketQuit()
    {
        //关闭线程
        if (connectThread != null)
        {
            connectThread.Interrupt();
            connectThread.Abort();
        }
        //最后关闭socket
        //if (socket_c != null)
        //    socket_c.Close();
        if (socket_s != null)
            socket_s.Close();

        StopAllCoroutines();


    }
    void OnApplicationQuit()
    {
        SocketQuit();
    }

    void Update()
    {
        if (getNew == true)
        {
            getNew = false;
            //执行接收文本事件
        }
    }

}
