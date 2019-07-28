using UnityEngine;

public class Explode : MonoBehaviour
{
    [Range(0, 100)]
    public float health = 100;

    [Range(1, 10)]
    public int attackValue = 1;

    [Range(0, 4)]
    public int healthBoost = 0;
    public bool safe = true;

    public bool isDead = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (!safe)
            {
                health -= attackValue;
            }
            else
            {
                if (health < 100)
                {
                    health += (float)healthBoost;
                }

                if (health < 0)
                {
                    health = 0;
                    isDead = health <= 0 ? true : false;
                }
            }
        }
        else
        {
            OnExplode();
        }
        
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            isDead = health == 0 ? true : false;
            safe = false;
            if (isDead)
            {
                OnExplode();
            }
        }

    }

    void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            isDead = health <= 0 ? true : false;
            safe = true;
            if (isDead)
            {
                OnExplode();
            }
        }

    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            isDead = health <= 0 ? true : false;
            safe = false;
            if (isDead)
            {
                OnExplode();
            }
        }
    }

    void OnCollisionExit2D(Collision2D target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            isDead = health <= 0 ? true : false;
            safe = true;
            if (isDead)
            {
                OnExplode();
            }
        }
    }

    public void OnExplode()
    {
        Destroy(gameObject);
    }

}
