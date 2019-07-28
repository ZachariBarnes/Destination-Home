using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{

    public float speed = .5f;
    public float wanderDist = 2.5f;
    public Rigidbody2D rgBody;
    private Vector3 startLoc;
    bool goRight = true;
    // Use this for initialization
    void Start()
    {
        rgBody = GetComponent<Rigidbody2D>();
        startLoc = gameObject.transform.position;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Translate(new Vector3(wanderDist, 0, 0) * speed * Time.deltaTime);
        rgBody.velocity = new Vector2(transform.localScale.x, 0) * speed;

        if(goRight && ((gameObject.transform.position.x -startLoc.x) > wanderDist))
        {
            transform.localScale = new Vector3(-transform.localScale.x,  transform.localScale.y, transform.localScale.z);
            goRight = false;
            wanderDist = -wanderDist;
        }
        if (!goRight && ((gameObject.transform.position.x - startLoc.x) < wanderDist))
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            goRight = true;
            wanderDist = -wanderDist;
        }
    }
}
