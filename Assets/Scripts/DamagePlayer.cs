using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) // Function known to Unity
    {
        if (other.tag == "Player") // Damage only if it's the player touching the spikes (not the solid ground)
        {
            // Debug.Log("Hit"); // To check on the consol if it works when touching spikes

            // FindObjectOfType<PlayerHealthController>().DealDamage(); // Calls the function from the other script

            PlayerHealthController.instance.DealDamage(); // Faster than the line above

        }

    }
}
