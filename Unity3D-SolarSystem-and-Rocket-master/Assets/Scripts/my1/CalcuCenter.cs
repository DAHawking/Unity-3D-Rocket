using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcuCenter : MonoBehaviour
{

	public GameObject gameObjectMeshRender;
	// Use this for initialization
	void Start()
	{
		//���ľ���һ�仰
		Debug.Log("����������������������ϵλ�ã�" + gameObjectMeshRender.GetComponent<MeshRenderer>().bounds.center.ToString("f4"));
	}
}
