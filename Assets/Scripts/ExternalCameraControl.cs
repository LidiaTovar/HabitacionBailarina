using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalCameraControl : MonoBehaviour
{
    public Transform target;

    public float zoomSpeed;
    public float panSpeed;
    public float orbitSpeed;
    SliderController _sliderController;
    Vector3 camaraOriginalPos;
    Quaternion camaraOriginalRotation;


    private void Awake()
    {
        _sliderController = FindObjectOfType<SliderController>();    
    }

    void Start()
    {
        if (target != null) transform.LookAt(target);

        camaraOriginalPos = transform.position;
        camaraOriginalRotation = transform.rotation;
    }

    void Update()
    {
        float zoom = Input.GetAxis("Mouse ScrollWheel");
        float mousex = Input.GetAxis("Mouse X");
        float mousey = Input.GetAxis("Mouse Y");


        //Orbit Camera
        if (Input.GetMouseButton(0))
        {
            if (!_sliderController.isSetting())
            {
                if (target != null) transform.RotateAround(target.position, Vector3.up, mousex * orbitSpeed);
                if (target != null) transform.RotateAround(target.position, transform.right, -mousey * orbitSpeed);
            }
        }


        //Pan Camera
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetMouseButton(1) || Input.GetMouseButton(2))
            {
                Vector3 movement = transform.right * -mousex * panSpeed + transform.up * -mousey * panSpeed;
                transform.position += movement;
            }
        }

        //Zoom Camera
        transform.position += transform.forward * zoom * zoomSpeed;
    }
}
