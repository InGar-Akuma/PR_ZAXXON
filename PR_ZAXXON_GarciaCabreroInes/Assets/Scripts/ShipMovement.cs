using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    

    //Velocidades de la nave en x e y
    /*[SerializeField] float speedx = 10f;
    [SerializeField] float speedy = 10f;*/


    [SerializeField] float speedShip = 10f;

    /*public bool life = true;*/

    //Limites de movimiento
    float limiteR = 15f;
    float limiteL = -15f;
    float limiteU = 15f;
    float limiteD = 0f;

    bool inLimitH = true;
    bool inLimitY = true;


    // Start is called before the first frame update
    void Start()
    {
        
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



        //Mmovimiento de nave usando 2 velocidades (en x y en y )
        

        /*transform.Translate(Vector3.left * Time.deltaTime * x * speedShip);
        transform.Translate(Vector3.up * Time.deltaTime * y * speedShip);

         if (posx > limiteR && x > 0 || posx < limiteL && x <0)
         {
             speedx = 0;
         }
         else
         {
             speedx = 10f;
         }


         if (posy > limiteU && y > 0 || posy < limiteD && y < 0)
         {
             speedy = 0;
         }
         else
         {
             speedy = 10f;
         }
        */



        //Movimiento con las teclas wasd individualmente

        /*if (Input.GetKey(KeyCode.W))
        {            
            transform.position += new Vector3(0, 1, 0) * Time.deltaTime * speed;

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -1, 0) * Time.deltaTime * speed;

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;

        }
        if (Input.GetKey(KeyCode.A))
        {           
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;

        }*/

    }



}
