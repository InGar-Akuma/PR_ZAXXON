using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIndividual : MonoBehaviour
{
    float speedTentaculo;
    [SerializeField] GameObject initObject;
    InitGameScript initGameScript;


    // Start is called before the first frame update
    void Start()
    {
        
        initGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();
        speedTentaculo = initGameScript.speedShipGlobal;


    }

    // Update is called once per frame
    void Update()
    {
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
