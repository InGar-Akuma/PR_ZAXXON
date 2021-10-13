using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{

    [SerializeField] GameObject player;
    ShipMovement shipMovement;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //variable de la clase = player.GetComponent<Clase>()
    }

    IEnumerator Cuentatras()
    {
        for (int n = 5; n > 0 ; n--)
        {
            if (n == 0)
            {
                //shipMovement.life = false;
                shipMovement.SendMessage("Destruir");
            }

            print(n);
            yield return new WaitForSeconds(1f);
        }


    }






}
