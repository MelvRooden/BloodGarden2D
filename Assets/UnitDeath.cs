using UnityEngine;

public class UnitDeath : MonoBehaviour
{
    private float destroyDelay = 0.5f;

    private Transform thisUnit;
    private Animator animator;
    private GameObject remains;

    private void FixedUpdate()
    {
        int health = thisUnit.GetComponent<Unit>().GetHealth;
        if (health <= 0)
            Death();
    }

    private void Death()
    {
        animator.Play("Martial_Death");
        Invoke("DropRemains", destroyDelay);
        Destroy(gameObject, destroyDelay);
    }

    private void DropRemains()
    {
        //Instantiate(remains, thisUnit.GetComponent<>().position, new Quaternion());
    }
}
