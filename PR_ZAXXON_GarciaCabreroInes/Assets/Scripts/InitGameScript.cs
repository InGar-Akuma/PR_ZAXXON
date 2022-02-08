using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitGameScript : MonoBehaviour
{
    //Variables GLOBALES
    public float speedShipGlobal;
    public float score;
    string sceneName;
    Scene currentScene;
    float actualTime;

    [SerializeField] float maxSpeed;
    public bool alive;

    [SerializeField] float life = 2;

    //UI
    [SerializeField] Text scoreText;
    [SerializeField] Slider speedSlider;
    [SerializeField] Sprite[] spritesLife;
    private Rect lifePos;
    private SpriteRenderer spriteR;
    int spriteVersion = 0;



    Canvas GameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        //Velocidad a la que se moveran los obstaculos
        speedShipGlobal = 20f;
        //score = 0;
        maxSpeed = 1000;
        alive = true;
        spritesLife = Resources.LoadAll<Sprite>("lives");
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        lifePos = new Rect(330f, 205f, 900f, 300f);

        Scene currentScene = SceneManager.GetActiveScene();
        

    }

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
                
        if (sceneName == "Zaxxon")
        {
            score = 0;
            Score();
            UpdateUI();
        }

    }


    // Update is called once per frame
    public void Score()
    {
        float time = Time.time - actualTime;

        if (speedShipGlobal < maxSpeed && alive == true)
        {
            speedShipGlobal += 0.001f;
        }

        score = Mathf.Round(time) * Mathf.Round(speedShipGlobal);
        
        //print(score);
      }

    void UpdateUI()
    {
        float tiempo = Time.timeSinceLevelLoad;

        scoreText.text = "Points:\n" + Mathf.Round(score) + " pts.";

        //Actualizo la energía
        speedSlider.value = speedShipGlobal;

        //vidas
        //Life();
    }



    public void Dead()
    {
        print("Me he muerto");
        alive = false;
        score = 0;
        speedShipGlobal = 0f;
        GameObject.Find("ShipGroup").SetActive(false);
                  
        SceneManager.LoadScene(2);

    }

    public void Chocar()
    {
        life -= 1;
        if (life < 0)
        {
            alive = false;
            Invoke ("Dead", 0.5f);
        }
        print("Lives = " + life);
    }
   
    void Life()
    {
        if(life == 2)
        {
            spriteVersion = 0;
        }
        if (life == 1)
        {
            spriteVersion = 1;
        }
        if (life == 0)
        {
            spriteVersion = 2;
        }
    }
     
}