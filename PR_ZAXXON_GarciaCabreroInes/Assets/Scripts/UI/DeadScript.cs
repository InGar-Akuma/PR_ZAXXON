using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeadScript : MonoBehaviour
{
   public void Reintentar()
    {
        SceneManager.LoadScene(1);
        InitGameScript.time = 0f;
        InitGameScript.score = 0f;
        ShipMovement.speedShip = 20f;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        InitGameScript.time = 0f;
        InitGameScript.score = 0f;
        ShipMovement.speedShip = 20f;
    }
}
