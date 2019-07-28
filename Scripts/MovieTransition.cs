using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class MovieTransition : MonoBehaviour
{
    public VideoPlayer vp;
    public bool playingStarted = false;
    public string nextLevel = "Demo";
    // Start is called before the first frame update
    void Start()
    {
        vp = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!vp.isPlaying)
        {
            if (playingStarted)
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
    }
}
