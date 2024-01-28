using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiarrheaMeter : MonoBehaviour
{
    public Slider slider;

    public void setDiarrhea(int diarrhea)
    {
        slider.value = diarrhea / 100f;
    }

    /*public void setMaxDiarrhea(int diarrhea)
    {
        slider.maxValue = diarrhea;
        slider.value = diarrhea / 100f;
    }*/
}
