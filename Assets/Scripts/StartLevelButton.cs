using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelButton : MonoBehaviour
{
    
    public void StartLevel()
    {
        FindObjectOfType<FoodSpawner>().startSpawning = true;
        gameObject.SetActive(false);
        GameManager.Instance.levelCompleteText.SetActive(false);
        GameManager.Instance.levelFailedText.SetActive(false);

    }
}
