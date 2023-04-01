using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance; // easier to access from any other script

    public float currentHealth, maxHealth;

    public float invincibleLenght;
    private float invincibleCounter;

    private SpriteRenderer theSR;

    public GameObject deathEffect;

    private void Awake() 
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        theSR = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime; // 1/60 of a second for games running at 60 frames a sec (= 1 sec here)

            if(invincibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r,theSR.color.g,theSR.color.b, 1);
            }
        }
    }

    public void DealDamage()
    {
        if(invincibleCounter <= 0) // Take damage only when not invinsible
        {
            // currentHealth -= 1; same as currentHealth--;
            currentHealth -= .5f;

            if(currentHealth <= 0)
            {
                currentHealth = 0; // To avoid bugs leading to negative value of player health
                // gameObject.SetActive(false); // Make player disapear

                Instantiate(deathEffect, transform.position, transform.rotation);

                LevelManager.instance.RespawnPlayer();

            } else 
            {
                invincibleCounter = invincibleLenght; // To avoid taking multiple damages at once
                theSR.color = new Color(theSR.color.r,theSR.color.g,theSR.color.b, .6f); // Lower the transparency setting (alpha in RGB colours)

                PlayerController.instance.knockBack();
            }

            UIController.instance.UpdateHealthDisplay();
        }
    }

    public void HealPlayer()
    {
        currentHealth += .5f; 

        // To avoid bugs
        if(currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;
        }

        UIController.instance.UpdateHealthDisplay();
    }
}
