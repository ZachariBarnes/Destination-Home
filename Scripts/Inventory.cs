using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Inventory : MonoBehaviour
{

    public List<GameObject> _items;
    public Canvas hudCanvas;
    public AudioSource Audio;
    public AudioClip CollectItem;
    public VideoPlayer videoPlayer;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
        videoPlayer = GameObject.FindGameObjectWithTag("Vp").GetComponent<VideoPlayer>();
    }


    public Inventory() 
    {
        _items = new List<GameObject>();
    }

    public void collectItem(GameObject item)
    {
        Audio.clip = CollectItem;
        Audio.PlayOneShot(CollectItem);
        _items.Add(item);
        Debug.Log(_items.Count);
        if(item.name == "TopFin")
        {
            //(Item)BlueKeycardDisp
            GameObject topFin = GameObject.FindWithTag("TopFin");
            ChangeOpacity(topFin);

        }
        else if(item.name == "BottomFin")
        {
            GameObject bottomFin = GameObject.FindWithTag("BottomFin");
            ChangeOpacity(bottomFin);
        }
        else if (item.name == "Engine")
        {
            GameObject engine = GameObject.FindWithTag("Engine");
            ChangeOpacity(engine);
        }
        if(_items.Count == 3)
        {
            if (GameObject.FindGameObjectWithTag("MusicPlayer").activeInHierarchy)
            {
                Audio = GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<AudioSource>();
                Audio.Stop();
                videoPlayer.Play();
            }
        }
    }

    public void ChangeOpacity(GameObject card)
    {
        card.GetComponent<SpriteRenderer>().color = new Color(1F, 1F, 1F, 1F);
    }
}