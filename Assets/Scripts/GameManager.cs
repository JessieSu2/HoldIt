using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Public Variables
    public int currentFartScore;
    public int currentDiarrheaScore;
    public int currentLevel;
    [SerializeField] GameObject startLevelButton;
    [SerializeField] TextMeshProUGUI levelText;
    public GameObject levelCompleteText;
    public GameObject levelFailedText;
    public GameObject ppSplash;
    public GameObject ffSplash;
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

        spawner = FindObjectOfType<FoodSpawner>();

        currentFartScore = 0;
        currentDiarrheaScore = 0;
        currentLevel = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        FindObjectOfType<GasMeter>().setGas(currentFartScore);
        FindObjectOfType<DiarrheaMeter>().setDiarrhea(currentDiarrheaScore);
        levelText.text = "Level: " + currentLevel.ToString();

        if (currentFartScore >= 100 && currentDiarrheaScore < 100 && FindObjectOfType<Timer>().targetTime > 0f)
        {
            FinishLevel();
        }

        if (currentDiarrheaScore >= 100 || FindObjectOfType<Timer>().targetTime <= 0f)
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
        startLevelButton.SetActive(true);
    }

    void DestroyAllFood()
    {
        Food[] foods = FindObjectsOfType<Food>();
        foreach (Food f in foods)
        {
            Destroy(f.gameObject);
        }
    }

    public void FinishLevel()
    {
        currentFartScore = 0;
        currentDiarrheaScore = 0;
        currentLevel++;
        FindObjectOfType<Timer>().targetTime = 60f;
        spawner.startSpawning = false;
        spawner.foodSpeed += 0.5f;
        FindObjectOfType<PlayerMovement>().speed *= 1.2f;
        float tempTime = spawner.timeToGenerateFood - 0.2f;
        spawner.timeToGenerateFood = Mathf.Max(tempTime, 0.2f);
        FindObjectOfType<GasMeter>().SetGas(0);
        FindObjectOfType<DiarrheaMeter>().setDiarrhea(0);
        DestroyAllFood();
        startLevelButton.SetActive(true);
        levelCompleteText.SetActive(true);
        FindObjectOfType<PlayerMovement>().gameObject.GetComponent<Animator>().SetBool("fart", true);
        ffSplash.SetActive(true);

    }

    public void FailLevel()
    {
        currentFartScore = 0;
        currentDiarrheaScore = 0;
        currentLevel = 1;
        FindObjectOfType<Timer>().targetTime = 60f;
        spawner.startSpawning = false;
        spawner.foodSpeed = 0.2f;
        spawner.timeToGenerateFood = 2f;
        FindObjectOfType<GasMeter>().SetGas(0);
        FindObjectOfType<DiarrheaMeter>().setDiarrhea(0);
        DestroyAllFood();
        startLevelButton.SetActive(true);
        levelFailedText.SetActive(true);
        FindObjectOfType<PlayerMovement>().gameObject.GetComponent<Animator>().SetBool("fart", true);
        ppSplash.SetActive(true);
    }
}
