using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{

    public Slider slider;
    public Image fill;

    public Color inProgressColor;
    public Color fullColor;
    public Color disabledColor;

    void SetColor()
    {
        if (slider.value < slider.maxValue)
            fill.color = inProgressColor;
        else
            fill.color = fullColor;
    }

    public void SetMax(int max_value)
    {
        slider.maxValue = max_value;
        SetColor();
    }

    public void SetProgress(int progress)
    {
        slider.value = progress;
        SetColor();
        
    }

    public void Disable()
    {
        fill.color = disabledColor;
    }

}
