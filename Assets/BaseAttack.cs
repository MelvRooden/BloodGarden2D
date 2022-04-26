using UnityEngine;

public class BaseAttack : MonoBehaviour, IAttack
{
    public string attackAnimationName;
    public string attackAudioName;

    // Delay modifiers
    public float attackStartDelay;
    public float attackDeployDelay;
    public float attackMovementBlockDelay;
    public float attackFinishDelay;

    // Unity assets
    public Transform firePoint;
    public GameObject attack;
    public Animator animator;

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
