using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpin : MonoBehaviour
{
/*this code is to animate the wheels to spin as the car drives.*/
    void Start()
    {
        
    }
    void Update()
    {

        transform.Rotate (0 ,0 ,250 * Time.deltaTime);
    }
}