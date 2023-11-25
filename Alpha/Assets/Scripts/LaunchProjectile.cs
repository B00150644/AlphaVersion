using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public Transform ballSpawnPoint;
    public GameObject ballPrefab;
    public float ballSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            var ball = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
            ball.GetComponent<Rigidbody>().velocity = ballSpawnPoint.forward * ballSpeed;
        }
    }

    
}
