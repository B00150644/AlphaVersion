using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*this code is to control the player, ie. the racecar*/
    //Private variables
    private Rigidbody playerRb;

    public float speed = 25.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    //PowerUp
    public bool hasPowerup = false;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;
    //Projectiles
    Vector3 ImpulseVector = new Vector3(300.0f, 0.0f, 0.0f);

    //private bool isBouncing = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        //Player Input to move car 
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Turn Car
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);        
    }

private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.name == "Wall")
    {
        float bounce = 5000f;
        Debug.Log("Entered Collision with " + collision.gameObject.name);
        playerRb.AddForce(collision.contacts[0].normal * bounce);
       // isBouncing = true;
      //  Invoke("StopBounce", 0.3f);
    }

    if (hasPowerup == true)
    {
        Debug.Log("powerup working");
    }
}
private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Powerup"))
    {
        Destroy(other.gameObject);
        hasPowerup = true;
        powerupIndicator.SetActive(true);
        StartCoroutine(PowerupCooldown());
    }
}
    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    void StopBounce()
    {
      //  isBouncing = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Wall")
        {
            Debug.Log("Colliding with " + collision.gameObject.name);

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Wall")
        {
            Debug.Log("Exited Collision with " + collision.gameObject.name);

        }
    }

}
