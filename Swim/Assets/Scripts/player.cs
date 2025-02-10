using UnityEngine;

public class player : MonoBehaviour
{
    public float diveForce = 10f; // Force applied when diving
    public float riseForce = 5f;  // Force applied when rising
    public float maxDiveDepth = -10f; // Maximum depth the player can dive
    public float buoyancy = 2f; // Buoyancy force to bring the player back up

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing!");
        }
    }

    void Update()
    {
        HandleDive();
    }

    void HandleDive()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Dive();
        }
        else
        {
            Rise();
        }
    }

    void Dive()
    {
        // Check if the player is above the maximum dive depth
        if (transform.position.y > maxDiveDepth)
        {
            // Apply a downward force to dive
            rb.AddForce(Vector2.down * diveForce, ForceMode2D.Force);
        }
    }

    void Rise()
    {
        // Apply an upward force to rise (buoyancy)
        rb.AddForce(Vector2.up * buoyancy, ForceMode2D.Force);

        // Optionally, clamp the player's position to prevent floating too high
        if (transform.position.y >= 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            transform.position = new Vector2(transform.position.x, 0);
        }
    }
}
