using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
// [SerializeField] private GameObject winScreen;
    [SerializeField] private TextMeshProUGUI text;
    public float targetTime = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<FoodSpawner>().startSpawning) return;

        targetTime -= Time.deltaTime;
        text.text = targetTime.ToString("F2");
        if (targetTime <= 0.0f)
        {
            //timerEnded();
            targetTime = 0f;
        }
        //print(targetTime);
    }

    void timerEnded()
    {
        //winScreen.SetActive(true);
        
    }

}
