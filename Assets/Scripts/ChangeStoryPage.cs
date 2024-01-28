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
        SoundManager.Instance.PlaySound(SoundManager.SoundEffects.ClickSound);
        pageNum++;
        if (pageNum == maxNumImages)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        { 
            if (pageNum == 1)
            {
                SoundManager.Instance.PlaySound(SoundManager.SoundEffects.TummyGrumbleSound);
            }
            else if (pageNum == 2)
            {
                SoundManager.Instance.PlaySound(SoundManager.SoundEffects.FartSound);
            }
            image.sprite = images[pageNum];
        }
        
        

    }
    public void GoBack()
    {
        
        if (pageNum != 0)
        {
            SoundManager.Instance.PlaySound(SoundManager.SoundEffects.ClickSound);
            pageNum--;
            image.sprite = images[pageNum];
        }
        
    }
}
