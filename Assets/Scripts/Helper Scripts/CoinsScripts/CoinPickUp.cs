using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{

    public GameManager gameManager;

    SpriteRenderer rend;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(FadeOutCoin());

            if(this.tag == "5")
                increaseCoinCount(5);
            else if(this.tag == "25")
                increaseCoinCount(25);
            else if(this.tag == "100")
                increaseCoinCount(100);
            else
                increaseCoinCount(500);

        }


    }



    IEnumerator FadeOutCoin()
    {

        for(float f = 1.1f; f >= -0.05f; f -=0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;

            this.transform.position += new Vector3(0, 0.02f, 0);

            yield return new WaitForSeconds(0.05f);
        }

        Destroy(gameObject);


    }

    void increaseCoinCount(int value)
    {
        gameManager.coinCount += value;
    }


}
