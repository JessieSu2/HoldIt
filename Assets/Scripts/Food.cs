using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    #region Public Variables
    public float fallingSpeed;
    public enum FartFoodType { Beans, Cheese, Yogurt, Broccoli, Soda, Bread, Onions, Pepper, Garlic, Carrot, Cabbage, Milk, Beer, SweetPotato}
    public enum DiarrheaFoodType { BadGrapes, BadMilk, BadCheese, OvernightFries, BadTuna, DevilPepper, ExtraStrongCoffee}
    public bool isFartFood;
    public FartFoodType fartFoodType;
    public DiarrheaFoodType diarrheaFoodType;
    public int fartPoints;
    public int diarrheaPoints;
    [SerializeField] List<Sprite> fartFoodImages;
    [SerializeField] List<Sprite> diarrheaFoodImages;
    #endregion

    #region Private Variables
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float existingTime;
    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        existingTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Delete the food if existing too long
        if (existingTime < 4f)
        {
            existingTime += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }


    }

    void SetSpeed(float speed)
    {
        fallingSpeed = speed;
        // Set the gravity
        rb.gravityScale = fallingSpeed;
    }

    void SetFartFoodType(FartFoodType type)
    {
        isFartFood = true;
        fartFoodType = type;
    }

    void SetDiarrheaFoodType(DiarrheaFoodType type)
    {
        isFartFood = false;
        diarrheaFoodType = type;
    }

    void SetFartPoints(int points)
    {
        fartPoints = points;
    }

    void SetDiarrheaPoints(int points)
    {
        diarrheaPoints = points;
    }

    void SetFartFoodImage(FartFoodType type)
    {
        sr.sprite = fartFoodImages[(int)type];
        sr.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
    }

    void SetDiarrheaFoodImage(DiarrheaFoodType type)
    {
        sr.sprite = diarrheaFoodImages[(int)type];
        sr.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
    }

    public void InitializeFartFood(FartFoodType type, float speed, int points)
    {
        SetFartFoodType(type);
        SetSpeed(speed);
        SetFartPoints(points);
        SetFartFoodImage(type);
    }

    public void InitializeDiarrheaFood(DiarrheaFoodType type, float speed, int points)
    {
        SetDiarrheaFoodType(type);
        SetSpeed(speed);
        SetDiarrheaPoints(points);
        SetDiarrheaFoodImage(type);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        collision.gameObject.GetComponent<Animator>().SetTrigger("eat");
        if (isFartFood)
        {
        SoundManager.Instance.PlaySound(SoundManager.SoundEffects.BulpSound);
        GameManager.Instance.AddFartPoints(fartPoints);
        }
        else
        {
            SoundManager.Instance.PlaySound(SoundManager.SoundEffects.EwwSound);
            GameManager.Instance.AddDiarrheaPoints(diarrheaPoints);
        }
     }
        Destroy(gameObject);
    }
}
