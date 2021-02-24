using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour
{
    public Material _mainSkybox;
    public Material[] _skyboxes;
    public float _rotDuration = 0.25f;
    public float _rotationDegrees = 180f;
    public int _currentState = 0;
    bool _rotating;

    // Start is called before the first frame update
    void Start()
    {
        _mainSkybox = RenderSettings.skybox;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SwapSkyboxButton(0);
        }
    }

    public void SwapSkyboxButton(int estado)
    {
        if(estado != _currentState && !_rotating)
        {
            StartCoroutine(SwapSkybox(estado));
            _currentState = estado;
        }
    }

    IEnumerator SwapSkybox(int estado) //Mañana = 0; Tarde = 1; Noche = 2
    {
        float initialRot = _mainSkybox.GetFloat("_Rotation");
        float halfDuration = _rotDuration/2f;
        float halfDegrees = _rotationDegrees / 2f;
        _rotating = true;

        for (float i = 0; i< halfDuration; i+= Time.deltaTime)
        {
            _mainSkybox.SetFloat("_Rotation", (initialRot + halfDegrees * (i/ halfDuration))%360);
            _mainSkybox.SetFloat("_Exposure", 1 - (i/ halfDuration));
            yield return null;
        }
        _mainSkybox.SetFloat("_Rotation", (initialRot + halfDegrees) % 360);
        _mainSkybox.SetFloat("_Exposure", 0);

        RenderSettings.skybox = _skyboxes[estado];
        _mainSkybox.SetFloat("_Exposure", 1);
        _mainSkybox = _skyboxes[estado];
        initialRot = _mainSkybox.GetFloat("_Rotation");

        for (float i = 0; i < halfDuration; i += Time.deltaTime)
        {
            _mainSkybox.SetFloat("_Rotation", initialRot + (halfDegrees * (i / halfDuration)) % 360);
            _mainSkybox.SetFloat("_Exposure", (i / halfDuration));
            yield return null;
        }
        _mainSkybox.SetFloat("_Rotation", (initialRot + halfDegrees) % 360);
        _mainSkybox.SetFloat("_Exposure", 1);

        _rotating = false;
    }
}
