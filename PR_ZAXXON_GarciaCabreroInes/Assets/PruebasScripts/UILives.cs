using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILives : MonoBehaviour
{
    InitGameScript initGameScript;
    [SerializeField] Image lives;
    [SerializeField] Sprite[] livesArray;

    [SerializeField] int vidas;
    int spritesPos = 0;


    // Start is called before the first frame update
    void Start()
    {
        
        vidas = livesArray.Length;
        lives.sprite = livesArray[spritesPos];
        
    }

    // Update is called once per frame
    void Update()
    {


    }
    void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.layer == 6)
        {
            initGameScript.SendMessage("Chocar");
            Destroy(gameObject);
        }*/
    }
    public void Collide()
    {
        if (vidas > 0)
        {
            vidas--;
            spritesPos++;
            lives.sprite = livesArray[spritesPos];
        }
       else
        {
            //initGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>("Dead");
        }
    }
    
}

