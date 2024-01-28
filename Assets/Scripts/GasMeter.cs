 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GasMeter : MonoBehaviour
{
    public Slider slider;

    public void SetGas(int gas)
    {
        slider.value = gas/100f;
    }

    public void SetMaxGas(int gas) 
    {
        slider.maxValue= gas;
        slider.value = gas;
    }

}
