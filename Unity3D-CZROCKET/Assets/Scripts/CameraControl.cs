using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject WhichCamera;
    public float RotateSpeed, RotateLerp, MoveSpeed, ZoomSpeed = 2, KeyMoveSpeed;
    private const float min_angle_y = -89f, max_angle_y = 89f;
    // 计算旋转
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
        //鼠标左键
        if (Input.GetMouseButton(0))
        {
            dx *= MoveSpeed;
            dy *= MoveSpeed;
            WhichCamera.transform.position -= transform.up * dy + transform.right * dx;
        }
        // 鼠标右键旋转
        if (Input.GetMouseButton(1))
        {
            dx *= RotateSpeed;
            dy *= RotateSpeed;
            if (Mathf.Abs(dx) > 0 || Mathf.Abs(dy) > 0)
            {
                // 获取摄像机欧拉角
                Vector3 angles = WhichCamera.transform.rotation.eulerAngles;
                // 欧拉角表示按照坐标顺序旋转，比如angles.x=30，表示按x轴旋转30°，dy改变引起x轴的变化
                angles.x = Mathf.Repeat(angles.x + 180f, 360f) - 180f;
                angles.y += dx;
                angles.x -= dy;
                angles.x = ClampAngle(angles.x, min_angle_y, max_angle_y);
                // 计算摄像头旋转
                TargetRotation.eulerAngles = new Vector3(angles.x, angles.y, 0);
                WhichCamera.transform.rotation = Quaternion.Slerp(WhichCamera.transform.rotation, TargetRotation, RotateLerp);
            }
        }
        // 鼠标滚轮拉伸
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
        // 键盘控制，上下前后左右
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
        // 控制旋转角度不超过360
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}
