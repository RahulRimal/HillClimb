using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFinder : MonoBehaviour
{
    public CarMovement carMovement;

    private void OnTriggerEnter2D(Collider2D other)
    {

        // To check the ground------
        if(other.gameObject.tag == "Ground")
            carMovement.isGrounded = true;
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
            carMovement.isGrounded = false;
    }





}
