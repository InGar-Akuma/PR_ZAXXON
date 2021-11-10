using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitGameScript : MonoBehaviour
{
    //Variables GLOBALES
    public float speedShipGlobal;
    public float score;

    [SerializeField] float maxSpeed;
    public bool alive;

    [SerializeField] float energy = 100;

    // Start is called before the first frame update
    void Start()
    {
        //Velocidad a la que se moveran los obstaculos
        speedShipGlobal = 20f;
        //score = 0;
        maxSpeed = 1000;
        alive = true;        
    }

    private void Update()
    {
        Score();
    }


    // Update is called once per frame
    public void Score()
    {
        if (speedShipGlobal < maxSpeed && alive == true)
        {
            speedShipGlobal += 0.001f;
        }

        float time = Time.time;

        score = Mathf.Round(time) * Mathf.Round(speedShipGlobal);
        
        //print(score);

      
}
    public void Dead()
    {
        print("Me he muerto");
        alive = false;
        speedShipGlobal = 0f;
        GameObject.Find("ShipGroup").SetActive(false);
                  
        SceneManager.LoadScene(2);

    }

    public void Chocar()
    {
        energy -= 20;
        if (energy <= 0)
        {
            alive = false;
            Invoke ("Dead", 0.5f);
        }
        print("Energia = " + energy);
    }
   
     
}