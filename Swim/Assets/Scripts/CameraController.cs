using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController: MonoBehaviour
{
    public Transform farBackground, middleBackground, closeBackground; 
    public float farBackgroundSpeed = 0.5f;    // Speed for far background
    public float middleBackgroundSpeed = 1f;    // Speed for middle background
    public float closeBackgroundSpeed = 2f;  // Speed for close background
    public Vector2 scrollDirection = Vector2.right; // Direction of scroll (can be modified in inspector)
    public float resetDistance = 20f;  // Distance before resetting position
    private Vector3 farStartPos;
    private Vector3 middleStartPos;
    private Vector3 closeStartPos;

    void Start()
    {
        // Store initial positions
        farStartPos = farBackground.position;
        middleStartPos = middleBackground.position;
        closeStartPos = closeBackground.position;
    }

    void Update()
    {
        // Stop background movement if the game is over
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
        {
            return;
        }
        // Move the backgrounds
        farBackground.position += new Vector3(
            scrollDirection.x * farBackgroundSpeed * Time.deltaTime, 
            scrollDirection.y * farBackgroundSpeed * Time.deltaTime, 
            0f
        );

        middleBackground.position += new Vector3(
            scrollDirection.x * middleBackgroundSpeed * Time.deltaTime, 
            scrollDirection.y * middleBackgroundSpeed * Time.deltaTime, 
            0f
        );

        closeBackground.position += new Vector3(
            scrollDirection.x * closeBackgroundSpeed * Time.deltaTime, 
            scrollDirection.y * closeBackgroundSpeed * Time.deltaTime, 
            0f
        );

        if (Vector3.Distance(farBackground.position, farStartPos) > resetDistance)
        {
            farBackground.position = farStartPos;
        }
        
        if (Vector3.Distance(middleBackground.position, middleStartPos) > resetDistance)
        {
            middleBackground.position = middleStartPos;
        }

        if (Vector3.Distance(closeBackground.position, closeStartPos) > resetDistance)
        {
            closeBackground.position = closeStartPos;
        }
    }
}
