using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxGas = 100;
    public int currentGas;
    public GasMeter gasMeter;
    private float buttonTimePressThreshold = 3f;
    private float timer = 0f;

    private void Start()
    {
        currentGas = maxGas;
        gasMeter.SetMaxGas(maxGas);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(timer);
            if(timer > buttonTimePressThreshold) 
            {
                DecreaseGas(5);
                
            }
            timer = 0f;
        }
   
    }


    void DecreaseGas(int gas)
    {
        currentGas -= gas;
        gasMeter.SetGas(currentGas);
    }
}
