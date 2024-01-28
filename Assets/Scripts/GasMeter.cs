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

<<<<<<< HEAD
    public void SetMaxGas(int gas) 
=======
    /*public void setMaxGas(int gas) 
>>>>>>> 27e63c3c0f87a1777547a560081600cdd27538ef
    {
        slider.maxValue= gas;
        slider.value = gas;
    }*/

}
