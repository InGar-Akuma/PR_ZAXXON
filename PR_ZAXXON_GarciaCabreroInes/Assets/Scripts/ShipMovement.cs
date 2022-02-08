using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShipMovement : MonoBehaviour
{

    InitGameScript initGameScript;
    float speedShip = 20f;

    public bool life = true;

    //Limites de movimiento
    float limiteR = 15f;
    float limiteL = -15f;
    float limiteU = 15f;
    float limiteD = -0.6f;

    bool inLimitH = true;
    bool inLimitY = true;

    [SerializeField] GameObject shipPrefab;


    // Start is called before the first frame update
    void Start()
    {
        initGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ShipMove();
    }

    //Corrutina de movimiento
    void ShipMove()
    {
       
        //Movimiento nave por bool
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
                
        float posx = transform.position.x;
        float posy = transform.position.y;

        //Limites donde se mueve la nave
        if (inLimitH)
        {
            transform.Translate(Vector3.right * Time.deltaTime * x * speedShip, Space.World);
        }

        if (inLimitY)
        {
            transform.Translate(Vector3.up * Time.deltaTime * y * speedShip, Space.World);
        }

        //Limites donde la nave no se mueve
        if ((posx > limiteR && x > 0) || (posx < limiteL && x < 0))
        {
            inLimitH = false;
        }
        else
        {
            inLimitH = true;
        }

        if ((posy > limiteU && y > 0) || (posy < limiteD && y < 0))
        {
            inLimitY = false;
        }
        else
        {
            inLimitY = true;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        print("CHOQUE");
        if (other.gameObject.CompareTag("Cliff"))
        {           
            initGameScript.SendMessage("Chocar");
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Tentaculo"))
        {
            initGameScript.SendMessage("Chocar");
            Destroy(other.gameObject);
        }
    }


}
