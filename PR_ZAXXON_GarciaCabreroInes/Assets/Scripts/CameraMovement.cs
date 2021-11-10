using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    InitGameScript initGameScript;

    [SerializeField] Transform playerPosition;
    //Variables necesarias para la opción de suavizado
    [SerializeField] float smoothVelocity = 0.1F;
    [SerializeField] Vector3 camaraVelocity = Vector3.zero;
 

    // Start is called before the first frame update
    void Start()
    {
        initGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (initGameScript.alive)
        {
            Vector3 targetPosition = new Vector3(playerPosition.position.x, playerPosition.position.y + 1.5f, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camaraVelocity, smoothVelocity);
        }
    }
}
