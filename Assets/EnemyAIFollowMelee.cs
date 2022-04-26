using UnityEngine;

public class EnemyAIFollowMelee : MonoBehaviour
{
    private bool facingRight = true;
    public float speed = 0.25f;
    public float agroDistance = 7f;
    public float advanceDistance = 2.2f;
    public float retreatDistance = 1.1f;

    public Transform target;
    public Transform firePoint;

    private void Update()
    {
        if (gameObject.GetComponent<Unit>().GetHealth <= 0)
            return;

        if (Vector2.Distance(transform.position, target.position) <= agroDistance)
        {
            Vector2 transformPos = transform.position;
            Vector2 targetPos = target.position;

            FollowTarget(transformPos, targetPos);
            AimAtTarget(transformPos, targetPos);
            FollowTargetX(transformPos, targetPos);
        }
    }

    private void FollowTarget(Vector2 transformPos, Vector2 targetPos)
    {
        if (Vector2.Distance(transformPos, targetPos) >= advanceDistance)
            transform.position = Vector2.MoveTowards(transformPos,
                new Vector2(targetPos.x, transformPos.y), speed * Time.fixedDeltaTime);
        else if (Vector2.Distance(transformPos, targetPos) < retreatDistance)
                transform.position = Vector2.MoveTowards(transformPos,
                    new Vector2(targetPos.x, transformPos.y), -speed * Time.fixedDeltaTime);


    }

    private void FollowTargetX(Vector2 transformPos, Vector2 targetPos)
    {
        float xDistance = transformPos.x - targetPos.x;
        if (xDistance >= 1 || xDistance <= -1)
            transform.position = Vector2.MoveTowards(transformPos,
                new Vector2(transformPos.x, targetPos.y), speed * Time.fixedDeltaTime);
    }

    private void AimAtTarget(Vector2 transformPos, Vector2 targetPos)
    {
        if (transformPos.x < targetPos.x && !facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
