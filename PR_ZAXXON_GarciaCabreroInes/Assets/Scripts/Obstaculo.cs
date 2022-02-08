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

    float intervalo =0.25f;
    

    // Start is called before the first frame update
    void Start()
    {
        initGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();
        distanciaObstaculos = 30f;
        intervalo = distanciaObstaculos / initGameScript.speedShipGlobal;

        StartCoroutine("CreateObject");
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
                pos = new Vector3(Random.Range(-15f, 15f), Random.Range(-15f, 0f), initPos.position.z);
                Instantiate(arrayObst[randomNum], pos, Quaternion.Euler(new Vector3(0, Random.Range(0.0f, 360f), Random.Range(15f, 15f))));
            }

            if (arrayObst[randomNum].tag == "Cliff")
            {
                pos = new Vector3(0f, Random.Range(-10f, 0f), initPos.position.z);
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

