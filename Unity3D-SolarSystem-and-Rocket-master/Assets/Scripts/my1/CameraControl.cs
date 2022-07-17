using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

	private GameObject Cam1;    //��һ�ӽ������
	private GameObject Cam2;    //�����˳������

	bool flag = false;          //fCam����Ϊtrue

	private void Awake()
	{
		//��ȡ���
		Cam1 = GameObject.Find("ROCKETCZ5/Camera1");   //��ȡ��һ�ӽ����
		Cam2 = GameObject.Find("ROCKETCZ5/Camera2");   //��ȡ�����ӽ����
		Cam1.SetActive(false);      //���õ�һ�ӽ�����������ӽ���Ϊ�����
	}

	private void FixedUpdate()
	{
		//�ո��Space��Ϊ�л�����
		//ÿ����һ�η����л�
		if (Input.GetKeyDown(KeyCode.Space))
		{
			flag = !flag;       //״̬��ת
			Cam1.SetActive(flag);
			Cam2.SetActive(!flag);  //�������״̬����
		}
	}
}
