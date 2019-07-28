using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class OutroScript : MonoBehaviour
{
    public bool hasplayed = false;
    public VideoPlayer vp;
    // Start is called before the first frame update
    void Start()
    {
        vp = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vp.isPlaying)
        {
            hasplayed = true;
        }
        if(hasplayed && !vp.isPlaying)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
