using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletAnimation;
    public GameObject bulletPrefab;
    public AudioSource Audio;
    public AudioClip Blaster;
    //public AudioSource BlasterSound;
    public int damage = 40;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            
        }

    }

    void Shoot()
    {
        Audio.clip = Blaster;
        Instantiate(bulletAnimation, firePoint.position, firePoint.rotation);
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Audio.PlayOneShot(Blaster);
        //Audio.Play();
        Destroy(Temporary_Bullet_Handler, .5f); //Despawn Bullet After 1 seconds
        
    }
}
