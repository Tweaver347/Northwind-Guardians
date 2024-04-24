using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AimStateManager : MonoBehaviour
{
    [SerializeField] float sensitivity = 1.0f;
    float xAxis, yAxis;
    [SerializeField] Transform camFollowPos;



    void Start()
    {

    }

    void Update()
    {
        xAxis = Input.GetAxisRaw("Mouse X") * sensitivity;
        yAxis = Input.GetAxisRaw("Mouse Y") * sensitivity;
        yAxis = Mathf.Clamp(yAxis, -80, 80);
    }

    void LateUpdate()
    {
        camFollowPos.localEulerAngles = new Vector3(yAxis, camFollowPos.localEulerAngles.y, camFollowPos.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.localEulerAngles.z);
    }
}
