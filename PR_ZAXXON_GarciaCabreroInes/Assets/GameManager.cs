using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public static float volumeMusic = 5;
    public static int highScore = 0;

    private void Start()
    {
        volumeSlider.value = GameManager.volumeMusic;
    }

    public void ChangeMusicVol()
    {
        GameManager.volumeMusic = volumeSlider.value;
    }
}
