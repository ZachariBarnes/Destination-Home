using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour {

    [Range(0f, 100f)]
    public float speed = 20f;

    [Range(0,100)]
    public int damage = 40;

    public Rigidbody2D rb;

    public GameObject impactEffect;

    public GameObject CreatedImpactEffect;

    public bool isDestroyed = false;

	// Use this for initialization
	void Start () {
        rb.velocity = transform.right * speed;
	}

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            CreatedImpactEffect = Instantiate(impactEffect, transform.position, transform.rotation, enemy.transform);
            Destroy(CreatedImpactEffect, 0.3f); //Despawn Bullet After 1 seconds
        }
        else
        {
            CreatedImpactEffect = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(CreatedImpactEffect, 0.3f); //Despawn Bullet After 1 seconds
        }
        Destroy(gameObject);
        //isDestroyed = true;
        //LazerHit();
    }
    /*
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    */
    //void LazerHit()
    //{
    //    if (isDestroyed == true)
    //    {
    //        Destroy(this.CreatedImpactEffect);
    //    }
    //}

}
