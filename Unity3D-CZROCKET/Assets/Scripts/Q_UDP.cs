using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class Q_UDP : MonoBehaviour
{


    private bool getNew = false;


    ////����ͻ���ͨ�Ų��
    //Socket socket_c;
    //[Header("---------------------�ͻ���--------------------")]
    //public string biji = "����������д�ʼ�";
    //[Header("��ŶԷ��Ľ���ip")]
    //public string oppositeIP = "192.168.8.2";
    //[Header("��ŶԷ��Ľ��ն˿�")]
    //public int oppositePort = 25001;
    ////�Է������ip�˿ڶ�
    //IPEndPoint oppositeIpEnd;
    ////�㲥������ip
    //List<string> allIPv4 = new List<string>();



    //��������ͨ�Ų��
    Socket socket_s;
    [Header("---------------------�����--------------------")]
    [Header("�������ŵĶ˿�")]
    public int selfConnectPoint = 7001;
    // [Header("����ip�Զ���ȡ")]
    public static string selfAddress = "192.168.8.123";
    //public static string selfAddress = "";
    //�����������������ip�˿ڶ�
    EndPoint selfListenEnd,selfListenEnd1= new IPEndPoint(0,0);
    //�����߳�
    Thread connectThread;

    [Header("------------------��վ���ַ���---------------")]
    public string recvStr;


    //�������byte����ĳ���
    int recvLen = 0;
    //���յ���byte����
    byte[] recvData = new byte[1024];
    //Ҫ���͵ĵ�byte����
    byte[] sendData = new byte[1024];


    void Start()
    {

        ////ȥ��ip ǰ��ո�
        //oppositeIP = oppositeIP.Trim();
        ////���屾����������ip�Ͷ˿ڶ�
        //if (selfAddress == "")
        //{
        //    selfAddress = GetLocalIP();
        //}
        //selfAddress = selfAddress.Trim();
        //GetBroadcastIP(selfAddress);
        //��ʼ��
        InitSocket();
    }
    void InitSocket()
    {
        ////��Ϊ�ͻ���
        ////����Է���ip�Ͷ˿ڶ�
        //oppositeIpEnd = new IPEndPoint(IPAddress.Parse(oppositeIP), oppositePort);
        //socket_c = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        //��Ϊ�����    
        //����������������ip�˿ڶ�
        selfListenEnd = new IPEndPoint(IPAddress.Parse(selfAddress), selfConnectPoint);
        //selfListenEnd = new IPEndPoint(IPAddress.Any, selfConnectPoint);
        socket_s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        socket_s.Bind(selfListenEnd);
        //�������������������߳�
        connectThread = new Thread(new ThreadStart(SocketReceive));
        connectThread.Start();


        //��Ŀ�����˷������ݲ���
        //SocketSendCustom("123", "192.168.8.10", 8010);
        //print("�Է��ӵ���ʾ���ӳɹ�");
    }




    //��������������
    void SocketReceive()
    {
        while (true)
        {
            SocketSendCustom("1234", "192.168.8.10", 8010);
            
            recvData = new byte[1024];
            recvLen = socket_s.ReceiveFrom(recvData, ref selfListenEnd1);
            recvStr = Encoding.UTF8.GetString(recvData, 0, recvLen);
            Debug.Log("��Ϣ����" + selfListenEnd1.ToString() + ":" + recvStr);
            Debug.Log(selfConnectPoint.ToString());
            getNew = true;
        }
    }

    ////Ĭ��ip�˿ڷ���
    //public void SocketSendDefault(string sendStr)
    //{
    //    //���
    //    sendData = new byte[1024];
    //    //����ת��
    //    sendData = Encoding.UTF8.GetBytes(sendStr);
    //    //���͸�ָ�������
    //    socket_c.SendTo(sendData, sendData.Length, SocketFlags.None, oppositeIpEnd);
    //}

    //�Զ���ip�˿ڷ���
    public void SocketSendCustom(string sendStr, string ip, int port)
    {
        //���
        sendData = new byte[1024];
        //����ת��
        sendData = Encoding.UTF8.GetBytes(sendStr);
        IPEndPoint aimIpEnd;

        aimIpEnd = new IPEndPoint(IPAddress.Parse(ip), port);
        ////���͸�ָ�������
        //socket_c.SendTo(sendData, sendData.Length, SocketFlags.None, aimIpEnd);

    }

    ////Ĭ��ip�˿�Ⱥ��
    //public void SendToAllDefault(string sendMsg)
    //{
    //    StartCoroutine(SocketBroadcastSend(sendMsg, oppositePort));


    //}

    ////�Զ���ip�˿�Ⱥ��
    //public void SendToAllCustom(string sendMsg, int port)
    //{
    //    StartCoroutine(SocketBroadcastSend(sendMsg, port));
    //}
    //IEnumerator SocketBroadcastSend(string sendStr, int port)
    //{
    //    //���
    //    byte[] sendData_thread = new byte[1024];
    //    //����ת��
    //    sendData_thread = Encoding.UTF8.GetBytes(sendStr);
    //    IPEndPoint aimIpEnd;

    //    foreach (string ip in allIPv4)
    //    {
    //        Debug.Log(ip);
    //        aimIpEnd = new IPEndPoint(IPAddress.Parse(ip), port);

    //        socket_c.SendTo(sendData_thread, sendData_thread.Length, SocketFlags.None, aimIpEnd);
    //    }
    //    yield return null;
    //}




    //���ӹر�
    void SocketQuit()
    {
        //�ر��߳�
        if (connectThread != null)
        {
            connectThread.Interrupt();
            connectThread.Abort();
        }
        //���ر�socket
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
            //ִ�н����ı��¼�
        }
    }



    //public static string GetLocalIP()
    //{
    //    try
    //    {
    //        string HostName = Dns.GetHostName(); //�õ�������
    //        IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
    //        for (int i = 0; i < IpEntry.AddressList.Length; i++)
    //        {
    //            //��IP��ַ�б���ɸѡ��IPv4���͵�IP��ַ
    //            //AddressFamily.InterNetwork��ʾ��IPΪIPv4,
    //            //AddressFamily.InterNetworkV6��ʾ�˵�ַΪIPv6����
    //            if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
    //            {
    //                Debug.Log(IpEntry.AddressList[i].ToString());
    //                return IpEntry.AddressList[i].ToString();
    //            }
    //        }
    //        return "noIp";
    //    }
    //    catch
    //    {
    //        Debug.Log("ipGetFailed");
    //        return ("ipGetFailed");
    //    }

    //}


    //public void GetBroadcastIP(string ip)
    //{
    //    string[] nums = ip.Split('.');
    //    string head = nums[0] + "." + nums[1] + "." + nums[2] + ".";
    //    for (int i = 1; i < 255; i++)
    //    {

    //        allIPv4.Add(head + i.ToString());
    //    }


    //}

    //public static bool IsCorrectIP(string ip)
    //{
    //    return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
    //}



    //[ContextMenu("���Ե���Ч��")]
    //private void SendToOne()
    //{
    //    SocketSendDefault("�������Գɹ�");
    //}



}
