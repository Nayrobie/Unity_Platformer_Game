using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // To access Image etc.

public class UIController : MonoBehaviour
{
    // Access the script from anywhere
    public static UIController instance;

    public Image heart1, heart2, heart3;

    // We xant a reference to the sprite we want to use when switching hearts (empty / full)
    public Sprite heartFull, heartEmpty, heartHalf;

    public Text gemText;

    private void Awake() {
        instance = this;
    }
    
    void Start()
    {
        UpdateGemCount();
    }

    void Update()
    {
        
    }

    public void UpdateHealthDisplay()
    {
        // if statements are not very efficient, instead we use a Switch statement
        switch(PlayerHealthController.instance.currentHealth)
        {
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;

                break; // state the end of the case
            
            case 2.5f:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;

                break;

            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;

                break;

            case 1.5f:
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;

                break;

            case 1:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;

            case .5f:
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;

            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;

            // If there's a bug and the value of health is other than 0,1,2,3 we want to set this
            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;
        }
    }

    public void UpdateGemCount()
    {
        gemText.text = LevelManager.instance.gemsCollected.ToString();
    }
}
