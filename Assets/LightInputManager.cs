using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInputManager : MonoBehaviour
{
    public Transform pivot;
    Camera camara;
    bool savedInitialPos = false;
    float initialXPos;
    float recorrido;
    public float gradosTotales;
    Quaternion rotacionInicial;

    // Start is called before the first frame update
    void Awake()
    {
        camara = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButton(1))
        {
            if (!savedInitialPos)
            {
                //camara = Camera.main;
                rotacionInicial = pivot.rotation;
                initialXPos = camara.ScreenToViewportPoint(Input.mousePosition).x;
                savedInitialPos = true;
            }
        }

        if(Input.GetMouseButton(1) && savedInitialPos)
        {
            recorrido = camara.ScreenToViewportPoint(Input.mousePosition).x - initialXPos;
            pivot.transform.rotation = Quaternion.Euler(0, rotacionInicial.eulerAngles.y + (recorrido * gradosTotales), 0);
        }
        else
        {
            savedInitialPos = false;
        }
    }
}
