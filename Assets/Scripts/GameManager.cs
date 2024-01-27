using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Public Variables
    public int currentFartScore;
    public int currentDiarrheaScore;
    #endregion

    #region Private Variables
    public static GameManager Instance { get; private set; }
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

        currentFartScore = 0;
        currentDiarrheaScore = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddFartPoints(int points)
    {
        currentFartScore += points;
    }

    public void AddDiarrheaPoints(int points)
    {
        currentDiarrheaScore += points;
    }
}
