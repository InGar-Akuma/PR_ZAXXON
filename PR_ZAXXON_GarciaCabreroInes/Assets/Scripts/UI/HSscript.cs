using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HSscript : MonoBehaviour
{

    [SerializeField] Text HStext;
    void start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
    }
    private void Update()
    {
        
        HStext.text = (InitGameScript.highScore.ToString());
    }
    public void Volver()
    {
        SceneManager.LoadScene(0);
    }


}
