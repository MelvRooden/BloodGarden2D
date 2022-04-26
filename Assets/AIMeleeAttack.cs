using UnityEngine;

public class AIMeleeAttack : BaseAttack
{
    [SerializeField]
    private float minAttackRange = 1.5f;
    [SerializeField]
    private float maxAttackRange = 2.2f;

    [SerializeField]
    private Transform target;

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
