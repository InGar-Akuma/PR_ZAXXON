using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIndividual : MonoBehaviour
{
    float speedTentaculo;
    [SerializeField] GameObject initObject;
    InitGameScript initGameScript;


    //float speedTentaclo; 

    // Start is called before the first frame update
    void Start()
    {
        initObject = GameObject.Find("InitGame");

        initGameScript = initGameScript.GetComponent<InitGameScript>();
        speedTentaculo = initGameScript.speedShipGlobal;
    }

    // Update is called once per frame
    void Update()
    {
        //speedTentaculo
        //transform.Translate(Vector3.back * Time.deltaTime * speedTentaculo);

        speedTentaculo = initGameScript.speedShipGlobal;
        transform.Translate(Vector3.back * Time.deltaTime * speedTentaculo);

        float posZ = transform.position.z;
        print(posZ);

        if (posZ < -20)
        {
            Destroy(gameObject);

        }
    }
}
