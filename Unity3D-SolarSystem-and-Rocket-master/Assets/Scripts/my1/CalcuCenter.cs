using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcuCenter : MonoBehaviour
{

	public GameObject gameObjectMeshRender;
	// Use this for initialization
	void Start()
	{
		//核心就这一句话
		Debug.Log("对象网格中心在世界坐标系位置：" + gameObjectMeshRender.GetComponent<MeshRenderer>().bounds.center.ToString("f4"));
	}
}
