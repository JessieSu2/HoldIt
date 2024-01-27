 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GasMeter : MonoBehaviour
{
    public Slider slider;

    public void setGas(int gas)
    {
        slider.value = gas;
    }

    public void setMaxGas(int gas) 
    {
        slider.maxValue= gas;
        slider.value = gas;
    }

}
