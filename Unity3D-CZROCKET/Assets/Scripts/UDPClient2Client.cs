using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using System;

public class UDPClient2Client : MonoBehaviour
{
    public static UDPClient2Client Instance = null;
    private UdpClient client;
    private Thread thread = null;
    private IPEndPoint remotePoint;
    //public string ip = "127.0.0.1";
    private int port = 7001;

    public Action<string> receiveMsg = null;

    private string receiveString = null;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start()
    {
        //  ip = IPManager.ipAddress;
        remotePoint = new IPEndPoint(IPAddress.Any, 0);
        thread = new Thread(ReceiveMsg);
        thread.Start();
    }
    //接受消息
    void ReceiveMsg()
    {
        while (true)
        {
            client = new UdpClient(port);

            byte[] receiveData = client.Receive(ref remotePoint);//接收数据
            receiveString = Encoding.UTF8.GetString(receiveData);
            Debug.Log(receiveString);
            client.Close();
        }
    }
    //发送消息
    void SendMsg(IPAddress ip, string _msg)
    {
        IPEndPoint remotePoint = new IPEndPoint(ip, port);//实例化一个远程端点

        if (_msg != null)
        {
            byte[] sendData = Encoding.Default.GetBytes(_msg);
            UdpClient client = new UdpClient();
            client.Send(sendData, sendData.Length, remotePoint);//将数据发送到远程端点
            client.Close();//关闭连接
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if (!string.IsNullOrEmpty(receiveString))
        //{

        //    //消息处理
        //    if (receiveMsg != null && remotePoint.Address.ToString() != ip)
        //    {
        //        Debug.Log(remotePoint.Address + ":" + remotePoint.Port + " ---> " + receiveString);
        //        receiveMsg.Invoke(receiveString);
        //        receiveString = null;

        //    }
        //}

    }

    void OnDestroy()
    {
        SocketQuit();
    }

    void OnApplicationQuit()
    {
        SocketQuit();
    }
    void SocketQuit()
    {
        thread.Abort();
        thread.Interrupt();
        client.Close();
    }

}