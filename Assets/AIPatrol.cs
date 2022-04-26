using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol;
    public float speed;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
            Patrol();
    }

    void Patrol()
    {
        rb.velocity = new Vector2 (speed * Time.fixedDeltaTime, rb.velocity.y);
    }

}
