using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject WhichCamera;
    public float RotateSpeed, RotateLerp, MoveSpeed, ZoomSpeed = 2, KeyMoveSpeed;
    private const float min_angle_y = -89f, max_angle_y = 89f;
    // ������ת
    private Quaternion TargetRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dx = Input.GetAxis("Mouse X");
        float dy = Input.GetAxis("Mouse Y");
        if (Mathf.Abs(dx) > 5f || Mathf.Abs(dy) > 5f)
        {
            return;
        }
        //������
        if (Input.GetMouseButton(0))
        {
            dx *= MoveSpeed;
            dy *= MoveSpeed;
            WhichCamera.transform.position -= transform.up * dy + transform.right * dx;
        }
        // ����Ҽ���ת
        if (Input.GetMouseButton(1))
        {
            dx *= RotateSpeed;
            dy *= RotateSpeed;
            if (Mathf.Abs(dx) > 0 || Mathf.Abs(dy) > 0)
            {
                // ��ȡ�����ŷ����
                Vector3 angles = WhichCamera.transform.rotation.eulerAngles;
                // ŷ���Ǳ�ʾ��������˳����ת������angles.x=30����ʾ��x����ת30�㣬dy�ı�����x��ı仯
                angles.x = Mathf.Repeat(angles.x + 180f, 360f) - 180f;
                angles.y += dx;
                angles.x -= dy;
                angles.x = ClampAngle(angles.x, min_angle_y, max_angle_y);
                // ��������ͷ��ת
                TargetRotation.eulerAngles = new Vector3(angles.x, angles.y, 0);
                WhichCamera.transform.rotation = Quaternion.Slerp(WhichCamera.transform.rotation, TargetRotation, RotateLerp);
            }
        }
        // ����������
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            WhichCamera.GetComponent<Camera>().fieldOfView += ZoomSpeed;
            WhichCamera.GetComponent<Camera>().orthographicSize += 0.5f;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            WhichCamera.GetComponent<Camera>().fieldOfView -= ZoomSpeed;
            WhichCamera.GetComponent<Camera>().orthographicSize -= 0.5f;
        }
        // ���̿��ƣ�����ǰ������
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.E))
        {
            WhichCamera.transform.position -= transform.up * KeyMoveSpeed;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Q))
        {
            WhichCamera.transform.position += transform.up * KeyMoveSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            WhichCamera.transform.position += transform.forward * KeyMoveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            WhichCamera.transform.position -= transform.forward * KeyMoveSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            WhichCamera.transform.position += transform.right * KeyMoveSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            WhichCamera.transform.position -= transform.right * KeyMoveSpeed;
        }

    }
    float ClampAngle(float angle, float min, float max)
    {
        // ������ת�ǶȲ�����360
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}
