using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompbox : MonoBehaviour
{

    public GameObject deathEffect;

    public GameObject drop;
    [Range(0,100)] public int dropRate; // restrain the interval that can be set in Unity (creates a slider)

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
        if(other.tag == "Enemy")
        {
            Debug.Log("Hit Enemy");
            // other.gameObject.SetActive(false); // Only desacrtivate the sprite of the child
            other.transform.parent.gameObject.SetActive(false); // Desactivite the parent "Enemy Frog"
            
            Instantiate(deathEffect, other.transform.position, other.transform.rotation);

            PlayerController.instance.Bounce();

            // Note: setting dropRate to 100 doesnt drop 100% of the time (don't know how to fix)
            int dropSelect = Random.Range(0,100); // dropSelect doesnt work outside of if statements
            if (dropSelect <= dropRate)
            {
                Instantiate(drop, other.transform.position, other.transform.rotation);
            }
        }
    }
}
