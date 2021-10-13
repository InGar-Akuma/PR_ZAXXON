using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField] GameObject tentaculo;
    [SerializeField] Transform initPos;
    //float separacionx;
    float intervalo = 1f;


    //[SerializeField] int numTentaculos = 10;
    //[SerializeField] int numFilas = 5;

    // Start is called before the first frame update
    void Start()
    {

        
        StartCoroutine("CreateObject");
        //Vector3 newPos = initPos.position;

        /*for (int n = 0; n < numTentaculos; n++)
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
            
            //Instantiate(tentaculo, initPos.position, Quaternion.identity);    //falla
            Vector3 pos = new Vector3(Random.Range(-15f, 15f), 0f, initPos.position.z);
            Instantiate(tentaculo, pos, Quaternion.identity);
            yield return new WaitForSeconds(intervalo);
    

        }

   

    }



}
