using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slide;
    public Gradient gradient;
    public Image fill;

    public static HealthBar healthBar;

    public void SetMaxHealth(float health)
    {
        slide.maxValue = health;
        slide.value = health;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(float health)
    {
        slide.value = health;
        fill.color = gradient.Evaluate(slide.normalizedValue);
    }
}
