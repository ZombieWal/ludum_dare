using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Color disabledColor;

    public void SetMax(int max_value)
    {
        slider.maxValue = max_value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        // fill.color = gradient.Evaluate(1f);
    }

    public void SetProgress(int progress)
    {
        slider.value = progress;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void Disable()
    {
        fill.color = disabledColor;
    }

}
