using UnityEngine;
 
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public float spawnInterval = 2f; 
    private float timer; 
 
    void Update() 
    {
        timer += Time.deltaTime; 
        if (timer >= spawnInterval) 
        {
            SpawnEnemy(); 
            timer = 0; 
        }
    }
 
    void SpawnEnemy() // Spawns an enemy at the right edge of the screen
    {
        float spawnX = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x; 
        float spawnY = Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize); 
        Instantiate(enemyPrefab, new Vector3(spawnX, spawnY, 0f), Quaternion.identity); 
    }
}