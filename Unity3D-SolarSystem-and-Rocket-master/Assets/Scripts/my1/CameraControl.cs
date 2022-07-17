using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

	private GameObject Cam1;    //第一视角摄像机
	private GameObject Cam2;    //第三人称摄像机

	bool flag = false;          //fCam启用为true

	private void Awake()
	{
		//获取相机
		Cam1 = GameObject.Find("ROCKETCZ5/Camera1");   //获取第一视角相机
		Cam2 = GameObject.Find("ROCKETCZ5/Camera2");   //获取第三视角相机
		Cam1.SetActive(false);      //禁用第一视角相机，第三视角作为主相机
	}

	private void FixedUpdate()
	{
		//空格键Space作为切换触发
		//每按下一次发生切换
		if (Input.GetKeyDown(KeyCode.Space))
		{
			flag = !flag;       //状态反转
			Cam1.SetActive(flag);
			Cam2.SetActive(!flag);  //两个相机状态互斥
		}
	}
}
