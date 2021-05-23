using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarMovement : MonoBehaviour
{

    public SpeedoMeter speedoMeter;
    public DirtParticleEffect dirtParticleEffect;


    public Rigidbody2D car;
    public Rigidbody2D forntWheel;
    public Rigidbody2D backWheel;

    public Image fuelImage;

    [SerializeField] float tyreTorque;
    [SerializeField] float carTroque;


    public float fuelAmount;
    float fuelConsumotionAmount;
    public bool isGrounded;

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
        showFuel(fuelAmount);
    }


    void moveCar()
    {
        float frontWheelTorque = tyreTorque / 2 ;

        if(Input.GetAxisRaw("Horizontal") == 1 && fuelAmount > 0)
        {

            backWheel.AddTorque(-tyreTorque * Time.deltaTime);
            speedoMeter.indicateSpeed();

            if(isGrounded)
            {
                forntWheel.AddTorque(-frontWheelTorque * Time.deltaTime);
                car.AddForce(car.transform.right * 7f);
                dirtParticleEffect.emitDirt();
            }
                

            if(!isGrounded)
            {
                car.AddTorque(carTroque*Time.deltaTime);
                dirtParticleEffect.stopDirt();
            }
            
            fuelAmount -= fuelConsumotionAmount * Time.deltaTime;

            if(fuelAmount < 0)
                fuelAmount = 0;
            
        }

        else if(Input.GetAxisRaw("Horizontal") == -1 && fuelAmount > 0)
        {
            backWheel.AddTorque(tyreTorque * Time.deltaTime);
            
            if(isGrounded)
            {
                dirtParticleEffect.emitDirt();
                forntWheel.AddTorque(-frontWheelTorque * Time.deltaTime);
            }

            if(!isGrounded)
            {
                dirtParticleEffect.stopDirt();
                car.AddTorque(-carTroque*Time.deltaTime);
            }
                
            
            fuelAmount -= fuelConsumotionAmount * Time.deltaTime;

            if(fuelAmount < 0)
                fuelAmount = 0;
            
        }

        else
        {
            speedoMeter.decreaseSpeedoMeter();
            dirtParticleEffect.stopDirt();
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
