using UnityEngine;
public class SkyRoatate : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotateSky();
    }
    /// <summary>
    /// ��պ���ת
    /// </summary>
    public void RotateSky()
    {
        //��ǰ�� �������ǩΪMainCamera��
        float num = Camera.main.GetComponent<Skybox>().material.GetFloat("_Rotation");
        Camera.main.GetComponent<Skybox>().material.SetFloat("_Rotation", num + 0.02f);
    }
}

