using UnityEngine;

public class BaseAttack : MonoBehaviour, IAttack
{
    [SerializeField]
    private string attackAnimationName;
    [SerializeField]
    private string attackAudioName;

    // Delay modifiers
    [SerializeField]
    private float attackStartDelay;
    [SerializeField]
    private float attackDeployDelay;
    [SerializeField]
    private float attackMovementBlockDelay;
    [SerializeField]
    private float attackFinishDelay;

    // Unity assets
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject attack;
    [SerializeField]
    private Animator animator;

    public void Attack()
    {
        if (animator.GetBool("Attacking")) return;

        animator.SetBool("Attacking", true);
        animator.SetBool("MovementBlocked", true);

        Invoke("AttackStart", attackStartDelay);
        Invoke("AttackCast", attackStartDelay + attackDeployDelay);
        Invoke("MovementUnblock", attackStartDelay + attackDeployDelay + 
            attackMovementBlockDelay);
        Invoke("AttackFinish", attackStartDelay + attackDeployDelay + 
            attackMovementBlockDelay + attackFinishDelay);
    }
    private void AttackStart()
    {
        if (!gameObject.activeSelf) return;

        animator.Play(attackAnimationName);
        FindObjectOfType<AudioManager>().Play(attackAudioName);
    }
    private void AttackCast()
    {
        Instantiate(attack, firePoint.position, firePoint.rotation);
    }

    private void MovementUnblock()
    {
        animator.SetBool("MovementBlocked", false);
    }

    private void AttackFinish()
    {
        animator.SetBool("Attacking", false);
    }
}
