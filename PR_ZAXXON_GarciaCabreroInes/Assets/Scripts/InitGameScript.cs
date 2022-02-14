using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitGameScript : MonoBehaviour
{
        //Variables GLOBALES
    public float speedShipGlobal = 0f;
    public static float score = 0f;
    string sceneName;
    Scene currentScene;
    float tiempo;
    public static float time = 0f;

    [SerializeField] float maxSpeed;
    public bool alive;

    [SerializeField] GameObject bubble;


    //UI
    [SerializeField] Text scoreText;
    [SerializeField] Slider speedSlider;
   

        //Vidas
    public GameObject heart1, heart2, heart3;
    public int life;

 
    //Explosion
    public GameObject barquito;
    public GameObject explosion;


    Canvas GameOverCanvas;

        // Start is called before the first frame update
    void Start()
    {

            //Musica
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().StopMusic();
            //Velocidad a la que se moveran los obstaculos
        speedShipGlobal = 10f;
        score = 0;
        maxSpeed = 1000;
        Time.timeScale = 1;
        time = Time.timeScale;
        alive = true;
        life = 3;
        //spritesLife = Resources.LoadAll<Sprite>("lives");
        //spriteR = gameObject.GetComponent<SpriteRenderer>();
        //lifePos = new Rect(330f, 205f, 900f, 300f);

        Scene currentScene = SceneManager.GetActiveScene();       

    }

    private void Update()
    {
        if (life > 3)
        {
            life = 3;
        }

        speedShipGlobal += 0.001f;
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
             
        if (sceneName == "Zaxxon")
        {
            Score();
            UpdateUI();
            Life();
        }
             
        if (!alive)
            ResetScore();

    }


    // Update is called once per frame
    public void Score()
    {
        time += 0.001f;       
        score = Mathf.Round(time) * Mathf.Round(speedShipGlobal);        
    }

    public void ResetScore()
    {
        score = 0;
    }

    void UpdateUI()
    {
        tiempo = Time.timeSinceLevelLoad;

        scoreText.text = "Points:\n" + Mathf.Round(score) + " pts.";

        //Actualizo la velocidad
        speedSlider.value = speedShipGlobal;
    }



    public void Dead()
    {
        ShipMovement.speedShip = 0f;
        print("Me he muerto");
        alive = false;
        score = 0;
        speedShipGlobal = 0f;
        //barquito.SetActive(false);
        Time.timeScale = 0;
        time = Time.timeScale;

        SceneManager.LoadScene(2);
    }
    public void Moriste()
    {
        
        life = 0;
        barquito.SetActive(false);
        explosion.SetActive(true);
        bubble.SetActive(true);
        Invoke("Dead", 4f);      
    }

    public void Chocar()
    {
        speedShipGlobal -= 2f;

        life -= 1;
        if (life == 0)
        {
            Moriste();
        }
        print("Lives = " + life);
        print(speedShipGlobal);
    }

    void Life()
    {
        if (life > 3)
        {
            life = 3;
        }

        switch (life)
        {
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);

                ShipMovement.speedShip = 0f;

                break;

            case 1:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(true);

                break;

            case 2:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);

                break;

            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);

                explosion.SetActive(false);
                bubble.SetActive(false);

                break;
        }
    }
}