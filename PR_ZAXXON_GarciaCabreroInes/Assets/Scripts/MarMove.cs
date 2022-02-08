using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarMove : MonoBehaviour
{
    float speedSea;
    InitGameScript initGameScript;
    [SerializeField] GameObject seaPrefab;
    Vector3 instantiatePos = new Vector3(0f, 0f, 180.4f);
    //Vector3 instantiatePosSec = new Vector3(0f, 0f, 380.4f);
    // Start is called before the first frame update
    void Start()
    {

        initGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();
        //speedSea = initGameScript.speedShipGlobal;


    }

    // Update is called once per frame
    void Update()
    {
        speedSea = initGameScript.speedShipGlobal;
        transform.Translate(Vector3.back * Time.deltaTime * speedSea);


        if (transform.position.z <= -99)
        {
            Instantiate(seaPrefab, instantiatePos ,Quaternion.identity);
            //Instantiate(seaPrefab, instantiatePosSec, Quaternion.identity);
            //Instantiate(seaPrefab, instantiatePos + new Vector3 (0f, 0f, 180.4f), Quaternion.identity);
            Destroy(gameObject);            
        }
    }
}
