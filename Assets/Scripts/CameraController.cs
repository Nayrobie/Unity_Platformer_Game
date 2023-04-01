using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Transform farBackground, middleBackground;

    public float minHeight, maxHeight;

    //private float lastXPos;
    private Vector2 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        //lastXPos = transform.position.x;
        lastPos = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        /* transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z); */

        // Horizontal Parallax
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);


        //float amountToMoveX = transform.position.x - lastXPos;

        // Vertical Parallax
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f); // Always follow the camera
        middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f; // += shorter than previous line

        //lastXPos = transform.position.x;
        lastPos = transform.position; 
    }
}
