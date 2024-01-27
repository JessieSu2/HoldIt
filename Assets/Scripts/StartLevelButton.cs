using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelButton : MonoBehaviour
{
    public void StartLevel()
    {
        FindObjectOfType<FoodSpawner>().startSpawning = true;
        gameObject.SetActive(false);
    }
}
