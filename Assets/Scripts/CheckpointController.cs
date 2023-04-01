using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;
    
    // We want to reference all the checkpoints used for the level (we use an array list)
    private Checkpoint[] checkpoints;

    public Vector3 spawnPoint;

    private void Awake() 
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>(); // Find objectS search for every object with the script "Checkpoint" attached

        spawnPoint = PlayerController.instance.transform.position; // Makes player spawn back at 1st position (otherwise spawnPoint is (0,0,0) by default)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // To deactivate older checkpoints
    public void DeactivateCheckpoints()
    {
        for(int i = 0; i < checkpoints.Length; i++) // (start at; if condition; increment)
        {
            checkpoints[i].ResetCheckpoint();
        }
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint) // newSpawnPoint variable only exist in this funciton
    {
        spawnPoint = newSpawnPoint;
    }
}
