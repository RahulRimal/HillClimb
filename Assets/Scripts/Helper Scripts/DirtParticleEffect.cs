using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtParticleEffect : MonoBehaviour
{

    public Transform backTyre;

    ParticleSystem dirtEffect;


    private void Awake()
    {
        dirtEffect = GetComponent<ParticleSystem>();
        dirtEffect.Stop();
    }

    public void emitDirt()
    {
        dirtEffect.Play();
    }

    public void stopDirt()
    {
        dirtEffect.Stop();
    }

    private void Update()
    {
        this.transform.position = backTyre.position;
    }



}
