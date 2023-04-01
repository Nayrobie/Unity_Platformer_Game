using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isGem, isHeal;

    private bool isCollected; // Make sure 1 object is collected only once

    public GameObject pickupEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !isCollected) // As long as the player touches the gem & it hasnt been collected yet
        {
            if(isGem)
            {
                LevelManager.instance.gemsCollected ++; // Add 1 gem when touching

                isCollected = true; // Now the gem is set to collected
                Destroy(gameObject); // And not deactivate

                Instantiate(pickupEffect, transform.position, transform.rotation); // instantiate = create a new copy of an object

                UIController.instance.UpdateGemCount();
            }

            if(isHeal)
            {
                // Can only heal the player is he's not full health
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth) 
                    {
                    PlayerHealthController.instance.HealPlayer();

                    isCollected = true; 
                    Destroy(gameObject);

                    Instantiate(pickupEffect, transform.position, transform.rotation);
                    
                    }
            }
        }
    }

}