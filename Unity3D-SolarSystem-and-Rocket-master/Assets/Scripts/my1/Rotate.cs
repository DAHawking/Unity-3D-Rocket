using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Rotate : MonoBehaviour
{

	public Transform origin;    //�����幫ת��Բ��
	public float gspeed;        //��ת�ٶ�
	public float zspeed;        //��ת�ٶ�
	public float ry, rz;        //ͨ��y�ᡢz�������ת��ƫ���ʣ�ʹ�䲻��ͬһƽ�湫ת

	void Start()
	{

	}

	void FixedUpdate()
	{
		Vector3 axis = new Vector3(0, ry, rz);      //��ת��
		this.transform.RotateAround(origin.position, axis, gspeed * Time.deltaTime);    //��ת
		this.transform.Rotate(Vector3.up * zspeed * Time.deltaTime);        //��ת
	}
}
