using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    #region Public Variables
    public float timeToGenerateFood;
    public float currentTime;
    public bool startSpawning = false;
    [SerializeField] GameObject foodPrefab;
    public float diarrheaFoodRatio;
    public float foodSpeed;
    public int fartFoodPoints;
    public int diarrheaFoodPoints;
    #endregion

    #region Private Variables
    private Vector3 spawnerPosition;
    private float halfScreenWidth;
    private Vector3 foodSpawnPos;
    #endregion

    void Awake()
    {
        // Set the spawner to the upper middle position of the screen
        halfScreenWidth = Screen.width / 2;
        spawnerPosition = new Vector3(halfScreenWidth, Screen.height + 10f, 0f);
        transform.position = Camera.main.ScreenToWorldPoint(spawnerPosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

        currentTime = 0f;
        timeToGenerateFood = 2f;
        diarrheaFoodRatio = 0.5f;
        foodSpeed = 0.2f;
        fartFoodPoints = 10;
        diarrheaFoodPoints = 10;
}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!startSpawning) return;

        // Spawn Food every timeToGenerateFood
        if (currentTime < timeToGenerateFood)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            currentTime = 0f;
            SpawnFood();
        }
    }

    public void SpawnFood()
    {
        foodSpawnPos = new Vector3(Random.Range(0, Screen.width), Screen.height, 0f);
        foodSpawnPos = Camera.main.ScreenToWorldPoint(foodSpawnPos);
        foodSpawnPos = new Vector3(foodSpawnPos.x, foodSpawnPos.y, 0f);

        GameObject food = Instantiate(foodPrefab, foodSpawnPos, Quaternion.identity);
        if (Random.Range(0f, 1f) > diarrheaFoodRatio)
        {
            int foodIndex = Random.Range(0, 14);
            food.GetComponent<Food>().InitializeFartFood((Food.FartFoodType)foodIndex, foodSpeed, fartFoodPoints);
        }
        else
        {
            int foodIndex = Random.Range(0, 7);
            food.GetComponent<Food>().InitializeDiarrheaFood((Food.DiarrheaFoodType)foodIndex, foodSpeed, diarrheaFoodPoints);
        }
    }
}
