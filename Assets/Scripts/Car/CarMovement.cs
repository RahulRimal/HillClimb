using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarMovement : MonoBehaviour
{

    public Rigidbody2D car;
    public Rigidbody2D forntWheel;
    public Rigidbody2D backWheel;

    public Image fuelImage;

    [SerializeField] float tyreTorque;
    [SerializeField] float carTroque;


    public float fuelAmount;
    float fuelConsumotionAmount;

    IEnumerator waitAndRestartGame()
    {
        yield return new WaitForSeconds(5);
        restartGame();
    }

    private void Awake()
    {
        fuelAmount = 100f;
        fuelConsumotionAmount = 5f;
    }

    private void FixedUpdate()
    {
        moveCar();
        // rotateCar();
        showFuel(fuelAmount);
    }


    void moveCar()
    {
        if(Input.GetAxisRaw("Horizontal") == 1 && fuelAmount > 0)
        {
            backWheel.AddTorque(-tyreTorque * Time.deltaTime);
            car.AddTorque(-carTroque*Time.deltaTime);
            
            fuelAmount -= fuelConsumotionAmount * Time.deltaTime;

            if(fuelAmount < 0)
                fuelAmount = 0;
            

        }

        if(Input.GetAxisRaw("Horizontal") == -1 && fuelAmount > 0)
        {
            backWheel.AddTorque(tyreTorque * Time.deltaTime);
            car.AddTorque(carTroque*Time.deltaTime);
            
            fuelAmount -= fuelConsumotionAmount * Time.deltaTime;

            if(fuelAmount < 0)
                fuelAmount = 0;
            
        }

    }

    void showFuel(float amount)
    {
        amount /= 100;

        fuelImage.fillAmount = amount;

        if(amount == 0.0f)
            StartCoroutine(waitAndRestartGame());
    }


    void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }










}
