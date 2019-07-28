using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int health = 100;
    public float deathTime = 0;
    public AudioSource Audio;
    public AudioClip HitNoise;
    public AudioClip DeathNoise;
    //public GameObject deathEffect;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if ((Time.fixedTime - deathTime) > 5){
            gameObject.SetActive(true);
        }

    }
    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Audio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
            Audio.clip = DeathNoise;
            Audio.PlayOneShot(DeathNoise);
            Debug.Log("work");
            Die();

        }
        else
        {
            Audio.clip = HitNoise;
            Audio.PlayOneShot(HitNoise);
        }
    }
    public void Respawn()
    {
        gameObject.SetActive(true);
        health = 100;
        deathTime = 0;
    }
    void Die ()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        deathTime = Time.fixedTime;
        gameObject.SetActive(false);
    }

}
