using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField] GameObject tentaculo;
    [SerializeField] Transform initPos;

    InitGameScript initGameScript;
    [SerializeField] float distanciaObstaculos = 30f;
    float intervalo =0.25f;
  

    //[SerializeField] int numTentaculos = 10;
    //[SerializeField] int numFilas = 5;

    // Start is called before the first frame update
    void Start()
    {
        initGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();
        distanciaObstaculos = 30f;

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
        while (true)
        {
            Vector3 pos = new Vector3(Random.Range(-15f, 15f), 0f, initPos.position.z);
            intervalo = distanciaObstaculos / initGameScript.speedShipGlobal;           
            Instantiate(tentaculo, pos, Quaternion.identity);
            yield return new WaitForSeconds(intervalo);  

        }

   

    }



}
