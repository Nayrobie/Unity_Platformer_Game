using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToRespawn; 

    public int gemsCollected;

    private void Awake() 
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo()); // instead of normal functions called like RespawnCo();

    }

    private IEnumerator RespawnCo() // Coroutines appen outside of the Unity loop (start, update, other functions in circle)
    {
        PlayerController.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToRespawn); // the routine waits (yield return) for a certain value to be true (waitToSpawn)

        PlayerController.instance.gameObject.SetActive(true);

        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint; // spawnPoint is by default at (O,O,O)

        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth; // Gain back full health when respawn
        UIController.instance.UpdateHealthDisplay(); // And updates the UI to show the 3 full hearts
    }
}
