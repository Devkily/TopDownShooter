using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] Gradient _gradient;
    [SerializeField] Image _fill;
    public void SetMaxHealth(int helath)
    {
        _slider.maxValue = helath;
        _slider.value = helath;
        _fill.color = _gradient.Evaluate(1f);
        
    }

    public void SetHealth(int health)
    {
        _slider.value = health;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
    
}
