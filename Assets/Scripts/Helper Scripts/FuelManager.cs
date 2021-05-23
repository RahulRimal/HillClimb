using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelManager : MonoBehaviour
{

    public CarMovement carMovement;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            carMovement.fuelAmount = 100f;
            Destroy(gameObject);
        }
            
        
    }
}
