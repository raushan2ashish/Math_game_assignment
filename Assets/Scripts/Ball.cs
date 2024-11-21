using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Ball : MonoBehaviour
{

    private Vector2 velocity;      // Ball's current velocity
    private Vector2 position;      // Ball's current position
    public float gravity = -9.8f;  // Gravity affecting the ball
    
    public float collisionRadius = 0.3f; // Radius for collision detection
    public System.Action OnBallDestroyed; // Event to notify when the ball is destroyed

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position; // Initialize the starting position
    }

    // Update is called once per frame
    void Update()
    {

        MoveBall();  // Apply movement each frame
        CheckCollisionWithTargets();

    }
    public void SetInitialVelocity(float power, Vector2 direction)
    {
        // Set the initial velocity based on power and direction
        velocity = power * direction;
    }
    void MoveBall()
    {
        // Update the position using the velocity
        position.x += velocity.x * Time.deltaTime; // Horizontal motion is constant
        position.y += velocity.y * Time.deltaTime; // Vertical motion includes gravity

        // Apply gravity to the vertical velocity
        velocity.y += gravity * Time.deltaTime;

        // Update the ball's position in the scene
        transform.position = position;

        // Destroy the ball if it goes below the ground (y <= -5)
        if (position.y <= -5)
        {
            DestroyBall();
        }
        else if (position.y >= 10)
        {
            DestroyBall();
        }
        else if (position.x <= -9)
        {
            DestroyBall();
        
        }
        else if(position.x >= 9)
        {  DestroyBall();
        }
    }
    void CheckCollisionWithTargets()
    {
        // Use Physics2D.OverlapCircle to check if the ball overlaps with any targets
        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(position, collisionRadius);
        foreach (var hitTarget in hitTargets)
        {
            if (hitTarget.CompareTag("Target")) // Check if it's a target
            {
                Destroy(hitTarget.gameObject); // Destroy the target
            }
        }
    }
    void DestroyBall()
    {
        OnBallDestroyed?.Invoke(); // Notify the cannon
        Destroy(gameObject);       // Destroy the ball object
    }
    //void OnDrawGizmos()
    //{
    //    // Optional: Draw the collision radius in the editor for debugging
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, collisionRadius);
    //}




}
