using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            restartGame();
        }
    }

    void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }






}
