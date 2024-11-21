using UnityEngine;
using UnityEngine.UI;
public class Cannon : MonoBehaviour
{
    public GameObject ballPrefab;  // Reference to the Ball prefab
    public Transform firePoint;    // The point where the ball is fired from
    
    public float rotationSpeed = 50f;  // Speed at which the cannon rotates
    public float maxPower = 20f;        // Maximum launch power
    public float minPower = 5f;         // Minimum launch power
    public float powerStep = 5f;        // How fast the power increases/decreases
    private float currentPower = 10f;   // Current launch power (default)

    private bool canFire = true;
    
    public Slider powerBar;             // Reference to the power bar UI Slider
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the power bar
        if (powerBar != null)
        {
            powerBar.minValue = minPower;
            powerBar.maxValue = maxPower;
            powerBar.value = currentPower;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the cannon with Up and Down Arrow keys
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }

        // Adjust launch power with Left and Right Arrow keys
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentPower += powerStep * Time.deltaTime;  // Increase power
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentPower -= powerStep * Time.deltaTime;  // Decrease power
        }

        // Clamp the power between the min and max values
        currentPower = Mathf.Clamp(currentPower, minPower, maxPower);

        // Debug log for current power (optional, remove in production)
        Debug.Log("Current Power: " + currentPower);
        
        
        // Update the power bar
        if (powerBar != null)
        {
            powerBar.value = currentPower;
        }
        // Fire the ball when Spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space) && canFire)
        {
            FireBall();
        }
    }
    void FireBall()
    {
        // Instantiate the ball at the firePoint position and rotation
        GameObject ball = Instantiate(ballPrefab, firePoint.position, firePoint.rotation);

        // Get the Ball script and set its initial velocity
        Ball ballScript = ball.GetComponent<Ball>();
        if (ballScript != null)
        {
            ballScript.SetInitialVelocity(currentPower, transform.right); // Pass power and direction
            
            // Set the cannon to wait until the ball is destroyed
            ballScript.OnBallDestroyed += EnableFiring;
            canFire = false;
        }
    }
    void EnableFiring()
    {
        canFire = true; // Allow the cannon to fire again
    }


}
