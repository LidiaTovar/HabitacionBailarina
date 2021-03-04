using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternalCameraControl : MonoBehaviour
{
    public Transform target;

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
    }

    public void ResetCamera()
    {
        transform.position = camaraOriginalPos;
        transform.rotation = camaraOriginalRotation;
    }
}
