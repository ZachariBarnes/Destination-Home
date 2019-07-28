using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Menu : MonoBehaviour
{
    public GameObject parent;
    public GameObject menu;
    public GameObject[] stars;
    public GameObject credits;
    public GameObject canvas;
    public VideoPlayer videoPlayer;


    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        stars = GameObject.FindGameObjectsWithTag("Star");

    }
    

    public void Update()
    {
        foreach(GameObject star in stars)
        {
            if(star.transform.position.x < -550)
            {
                star.transform.position= new Vector3(2000, Random.Range(0f, 1000f));
            }
        }
    }

    public void StartGame()
    {
        Application.runInBackground = true;
        videoPlayer.Play();
        GameObject.FindGameObjectWithTag("Vp").GetComponent<MovieTransition>().playingStarted = true;
        GameObject.FindGameObjectWithTag("Vp").GetComponent<MovieTransition>().nextLevel = "Level 1";
        canvas.SetActive(false);
        // StartCoroutine(playVideo());
    }

    public void StartDemo(){
        {
            Application.runInBackground = true;
            videoPlayer.Play();
            GameObject.FindGameObjectWithTag("Vp").GetComponent<MovieTransition>().playingStarted = true;
            GameObject.FindGameObjectWithTag("Vp").GetComponent<MovieTransition>().nextLevel = "Demo";
            canvas.SetActive(false);
            // StartCoroutine(playVideo());
        }
    }

    public void Credits()
    {
        if (menu.activeInHierarchy)
        {
            credits.SetActive(true);
            menu.SetActive(false);
        }
        else
        {
            credits.SetActive(false);
            menu.SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();   
    }
}
