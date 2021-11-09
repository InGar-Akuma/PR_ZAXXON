using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField] Transform initPos;
    [SerializeField] GameObject[] arrayObst;

    int level = 2;

    InitGameScript initGameScript;

    [SerializeField] float distanciaObstaculos = 30f;
    //[SerializeField] float distPrimerObst = 60f;

    float intervalo =0.25f;
    
    

    //[SerializeField] int numTentaculos = 10;
    //[SerializeField] int numFilas = 5;

    // Start is called before the first frame update
    void Start()
    {
        initGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();
        distanciaObstaculos = 30f;
        intervalo = distanciaObstaculos / initGameScript.speedShipGlobal;

        StartCoroutine("CreateObject");

        //Creacion random de obstaculos
        /*Vector3 newPos = initPos.position;

        for (int n = 0; n < numTentaculos; n++)
        {
            
            separacionx = Random.Range(-8f, 8f);
           
            Vector3 despl = new Vector3(separacionx, 0f, 0f);
            
            Instantiate(tentaculo, newPos, Quaternion.identity);
            newPos = newPos + despl;         

        }
        */


    }

    void Update()
    {
       
        
    }

   IEnumerator CreateObject()
    {
       
        int n = 0;
        bool cliffInstantiated = false;

        while (true)
        {
            int randomNum;
            
            Vector3 pos = new Vector3(0f, 0f, initPos.position.z);
           


            if (level == 0)
            {
                randomNum = 0;
            }
            else if (level > 0 && level < 4 || cliffInstantiated == true)
            {
                randomNum = Random.Range(0, 2);
            }
            else
            {
                //En este caso, el nº aleatorio es entre 0 y la longitud del Array
                randomNum = Random.Range(0, arrayObst.Length);
            }


            if (arrayObst[randomNum].tag == "Tentaculo")
            {
                pos = new Vector3(Random.Range(-15f, 15f), 0f, initPos.position.z);
                Instantiate(arrayObst[randomNum], pos, Quaternion.Euler(new Vector3(0, Random.Range(0.0f, 360f), Random.Range(15f, 15f))));
            }

            if (arrayObst[randomNum].tag == "Cliff")
            {
                pos = new Vector3(0f, 0f, initPos.position.z);
                Instantiate(arrayObst[randomNum], pos, Quaternion.identity);
            }


            intervalo = distanciaObstaculos / initGameScript.speedShipGlobal;
           

            //print(arrayObst[randomNum].tag);

            if (arrayObst[randomNum].tag == "Cliff")
            {
                cliffInstantiated = true; 
            }

            if (cliffInstantiated)
            {
                n++;
            }

            if (n == 3)
            {
                cliffInstantiated = false;
                n = 0;
            }

            yield return new WaitForSeconds(intervalo);  

        }

   

    }



}

