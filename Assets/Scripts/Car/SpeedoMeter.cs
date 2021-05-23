using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedoMeter : MonoBehaviour
{
    public RectTransform speedNeedle;
    public RectTransform boostNeedle;

    float time;
    float totalTime = 3f;


    float minAngle = 129f;
    float maxAngle = -5f;

    Vector3 speedVector;
    Vector3 boostVector;


    public void indicateSpeed()
    {
        time = 0;
        while(time < totalTime)
        {
            speedNeedle.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minAngle, maxAngle, time / totalTime));
            boostNeedle.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minAngle, maxAngle + 50f, time / totalTime));
            time += Time.deltaTime;
        }
    }

    public void decreaseSpeedoMeter()
    {
        time = 0;
        while(time < totalTime)
            {
                speedNeedle.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(maxAngle, minAngle, time / totalTime));
                boostNeedle.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(maxAngle, minAngle, time / totalTime));
                time += Time.deltaTime;
            }

    }



}
