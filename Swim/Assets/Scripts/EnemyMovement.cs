
using UnityEngine;
 
public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; 
    private Vector3 startPosition; 
 
    void Start()
    {
        startPosition = transform.position; 
    }
 
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime); // Move the enemy to the left
        if (transform.position.x < -15) 
        {
            Respawn(); 
        }
    }
 
    void Respawn() // Respawn the enemy at the right side of the screen
    {
        float randomY = Random.Range(-Camera.main.orthographicSize + 0.3f, Camera.main.orthographicSize - 0.3f); 
        transform.position = new Vector3(Camera.main.pixelWidth, randomY, transform.position.z); 
    }
}