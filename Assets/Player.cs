using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxGas = 100;
    public int currentGas;
    public GasMeter gasMeter;

    private void Start()
    {
        currentGas = maxGas;
        gasMeter.setMaxGas(maxGas);
    }

    private void Update()
    {
        
    }

    void decreaseGas(int gas)
    {
        currentGas -= gas;
    }
}
