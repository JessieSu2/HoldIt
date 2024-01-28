using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeStoryPage : MonoBehaviour
{
    public Sprite[] images;
    public int maxNumImages;
    public Image image;
    private int pageNum = 0;

    private void Start()
    {
        image.sprite = images[pageNum];
    }
    public void FlipPage()
    {
        if (pageNum == maxNumImages -1)
        { 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        pageNum++;
        image.sprite = images[pageNum];
    }
    public void GoBack()
    {
        if (pageNum != 0)
        {
            pageNum--;
            image.sprite = images[pageNum];
        }
        
    }
}
