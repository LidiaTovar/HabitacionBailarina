using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] Slider _slider;
    [SerializeField] string _animationName;
    [SerializeField] Text _botonReproduccionTx;
    bool _setting;
    bool _paused;

    // Update is called once per frame
    void Update()
    {
        if (!_paused && !_setting)
        {
            _animator.speed = 1;
            _slider.value = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1;
        }
        else
        {
            if (_setting)
            {
                _animator.speed = 0;
                _animator.Play(_animationName, 0, _slider.value);
            }
        }
    }
   
    public void SettingSlider(bool isSetting)
    {
        _setting = isSetting;
    }

    public void BotonReproduccion()
    {
        _paused = !_paused;
        if (_paused)
        {
            _animator.speed = 0;
            _botonReproduccionTx.text = "Play";
        }
        else
        {
            _animator.speed = 1;
            _botonReproduccionTx.text = "Pause";
        }
    }
}
