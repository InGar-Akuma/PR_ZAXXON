using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitGameScript : MonoBehaviour
{
    //Variables GLOBALES
    public float speedShipGlobal;
    float score;

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
        while (alive == true)
        {
            Score();
        }
    }

    // Update is called once per frame
    void Update()
    {
       
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
            Dead();
        }
        print("Energia = " + energy);
    }
    public void Score()
    {
        if (speedShipGlobal < maxSpeed && alive == true)
        {
            speedShipGlobal += 0.001f;
        }

        float time = Time.time;

        score = Mathf.Round(time) * speedShipGlobal;
        print(score);

    }
     
}