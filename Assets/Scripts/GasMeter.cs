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
=======

>>>>>>> 704c32be8ffbbac6d093948a6d6a093b61d9c649
    public void SetMaxGas(int gas) 
    {
        slider.maxValue= gas;
        slider.value = gas;
    }

}
