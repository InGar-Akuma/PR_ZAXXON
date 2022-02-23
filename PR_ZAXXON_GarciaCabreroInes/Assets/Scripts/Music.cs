using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource thiefMusic;
    private GameObject[] other;
    private bool NotFirst = false;

    // Start is called before the first frame update
    void Start()
    {
        other = GameObject.FindGameObjectsWithTag("Music");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Awake()
    {
        other = GameObject.FindGameObjectsWithTag("Music");

        foreach (GameObject oneOther in other)
        {
            if (oneOther.scene.buildIndex == -1)
            {
                NotFirst = true;
            }
        }

        if (NotFirst == true)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
        thiefMusic = GetComponent<AudioSource>();
    }
    public void PlayMusic()
    {
        if (thiefMusic.isPlaying) return;
        thiefMusic.Play();
    }

    public void StopMusic()
    {
        thiefMusic.Stop();
    }
}

