using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaMaterial : MonoBehaviour
{
    Material material1;
    MeshRenderer mesh;
    public Material material2;
    public bool original = true;

    // Start is called before the first frame update
    void Start()
    {
         mesh = gameObject.GetComponent<MeshRenderer>();
        if(mesh!=null)
            material1 =mesh.material;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cambia(Material matnuevo)
    {
        
        if (original)
        {
            if (mesh != null) gameObject.GetComponent<MeshRenderer>().material = matnuevo;
            Debug.Log("Nombre:" + transform.name);
        }
        else
        {
            if (mesh != null) gameObject.GetComponent<MeshRenderer>().material = material1;
        }

        original = !original;
        
    }

    public void CambiaHijos()
    {
        foreach(CambiaMaterial c in gameObject.GetComponentsInChildren<CambiaMaterial>())
        {
            c.Cambia(material2);
        }
    }

   
}
