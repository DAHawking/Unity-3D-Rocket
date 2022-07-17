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
    //������Ϣ
    void ReceiveMsg()
    {
        while (true)
        {
            client = new UdpClient(port);

            byte[] receiveData = client.Receive(ref remotePoint);//��������
            receiveString = Encoding.UTF8.GetString(receiveData);
            Debug.Log(receiveString);
            client.Close();
        }
    }
    //������Ϣ
    void SendMsg(IPAddress ip, string _msg)
    {
        IPEndPoint remotePoint = new IPEndPoint(ip, port);//ʵ����һ��Զ�̶˵�

        if (_msg != null)
        {
            byte[] sendData = Encoding.Default.GetBytes(_msg);
            UdpClient client = new UdpClient();
            client.Send(sendData, sendData.Length, remotePoint);//�����ݷ��͵�Զ�̶˵�
            client.Close();//�ر�����
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if (!string.IsNullOrEmpty(receiveString))
        //{

        //    //��Ϣ����
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