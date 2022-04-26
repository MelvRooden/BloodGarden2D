using UnityEngine;

public class AIFollowTarget : MonoBehaviour
{
    [SerializeField]
    private bool facingRight = true;
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float agroDistance = 7f;
    [SerializeField]
    private float advanceDistance = 2.2f;
    [SerializeField]
    private float retreatDistance = 1.5f;

    [SerializeField]
    private Transform target;
    [SerializeField]
    private Animator animator;


    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        // Movement
        if (target == null) return;
        if (animator.GetBool("MovementBlocked")) return;

        Vector2 transformPos = transform.position;
        Vector2 targetPos = target.position;
        float distance = Vector2.Distance(transformPos, targetPos);

        if (distance <= agroDistance)
            if (distance < retreatDistance || distance > advanceDistance)
            {
                transformPos = FollowTarget(transformPos, targetPos);
                transformPos = FollowTargetY(transformPos, targetPos);
                animator.SetBool("Moving", true);
            }
            else animator.SetBool("Moving", false);
        else animator.SetBool("Moving", false);

        AimAtTarget(transformPos, targetPos);
    }

    private Vector2 FollowTarget(Vector2 transformPos, Vector2 targetPos)
    {
        float distance = Vector2.Distance(transformPos, targetPos);

        if (distance >= advanceDistance)
            transform.position = Vector2.MoveTowards(transformPos,
                new Vector2(targetPos.x, transformPos.y), speed * Time.fixedDeltaTime);
        else if (distance <= retreatDistance)
            transform.position = Vector2.MoveTowards(transformPos,
                new Vector2(targetPos.x, transformPos.y), -speed * Time.fixedDeltaTime);

        return transform.position;
    }

    private Vector2 FollowTargetY(Vector2 transformPos, Vector2 targetPos)
    {
        float yDistance = transformPos.y - targetPos.y;
        if (yDistance >= 0.2 || yDistance <= -0.2)
        {
            transform.position = Vector2.MoveTowards(transformPos, 
                new Vector2(transformPos.x, targetPos.y), speed * Time.fixedDeltaTime);
        } 

        return transform.position;
    }

    private void AimAtTarget(Vector2 transformPos, Vector2 targetPos)
    {
        if (transformPos.x < targetPos.x && !facingRight)
            Flip();
        else if (transformPos.x > targetPos.x && facingRight)
            Flip();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
