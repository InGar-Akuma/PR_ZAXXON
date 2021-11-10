using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public static float volumeMusic = 5;
    public static float highScore = 0;

    InitGameScript initGameScript;

    private void Start()
    {
        volumeSlider.value = GameManager.volumeMusic;
        GameObject.Find("InitGame");
    }
    /*private void Update()
    {
        highScore = initGameScript.score;
    }*/

    public void ChangeMusicVol()
    {
        GameManager.volumeMusic = volumeSlider.value;
    }

   
}
