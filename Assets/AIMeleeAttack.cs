using UnityEngine;

public class AIMeleeAttack : BaseAttack
{
    public float minAttackRange = 1.5f;
    public float maxAttackRange = 2.2f;

    public Transform target;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (target == null) return;
        if (Vector2.Distance(transform.position, target.position) >= minAttackRange &&
            Vector2.Distance(transform.position, target.position) <= maxAttackRange)
            Attack();
    }
}
