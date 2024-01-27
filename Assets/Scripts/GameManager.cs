using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Public Variables
    public int currentFartScore;
    public int currentDiarrheaScore;
    public int currentLevel;
    public static GameManager Instance { get; private set; }
    #endregion

    #region Private Variables
    private FoodSpawner spawner;
    #endregion


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        spawner = GameObject.FindObjectOfType<FoodSpawner>();

        currentFartScore = 0;
        currentDiarrheaScore = 0;
        currentLevel = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFartScore >= 100 && currentDiarrheaScore < 100)
        {
            FinishLevel();
        }

        if (currentDiarrheaScore >= 100)
        {
            FailLevel();
        }

    }

    public void AddFartPoints(int points)
    {
        currentFartScore += points;
    }

    public void AddDiarrheaPoints(int points)
    {
        currentDiarrheaScore += points;
    }

    public void StartLevel()
    {
        spawner.startSpawning = true;
    }

    public void FinishLevel()
    {
        currentFartScore = 0;
        currentDiarrheaScore = 0;
        currentLevel++;
        spawner.startSpawning = false;
        spawner.foodSpeed += 0.1f;
    }

    public void FailLevel()
    {
        currentFartScore = 0;
        currentDiarrheaScore = 0;
        currentLevel = 1;
        spawner.startSpawning = false;
        spawner.foodSpeed = 0.2f;
    }
}
