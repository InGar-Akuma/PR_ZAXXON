using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
    }

    public void IniciarJuego()
    {
        SceneManager.LoadScene(1);
    }

    public void IniciarHS()
    {
        SceneManager.LoadScene(3);
    }

    public void IniciarConfig()
    {
        SceneManager.LoadScene(4);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
