using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonplay : MonoBehaviour
{
    public bool animation_bool =true;

    //Start is blablabla
    void Start()
    {

    }

    //Update is called blablabla
    void Update()
    {
       
    }
    public void playAnimation()
    {
        if (animation_bool == true)
        {
            // gameObject.GetComponent<Animator>().Play("cubo");
            gameObject.GetComponent<Animator>().speed = 0;
            animation_bool = false;

        }
        else
        {
            // gameObject.GetComponent<Animator>().Play("Idle");
            animation_bool = true;

        }
    }

}