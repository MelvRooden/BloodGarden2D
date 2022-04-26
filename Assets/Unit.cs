using UnityEngine;

public class Unit : MonoBehaviour, IUnit
{
    [SerializeField]
    private int health = 100;
    [SerializeField]
    private float deathDelay = 0.5f;
    [SerializeField]
    private float respawnDelay = 5f;
    [SerializeField]
    private string takeHitAnimationName;
    [SerializeField]
    private string deathAnimationName;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject remains;
    [SerializeField]
    private GameObject respawnUnit;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private HealthBar healthBar;

    private Vector3 startingPosition;

    public int GetHealth => health;
    public Vector3 GetStartingPos => startingPosition;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

        startingPosition = transform.position;

        if (healthBar) healthBar.SetMaxHealth(health);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (healthBar) healthBar.SetHealth(health);

        if (health <= 0) Death();
        else animator.Play(takeHitAnimationName);
    }

    public void HealDamage(int damage)
    {
        health += damage;

        if (healthBar) healthBar.SetHealth(health);
    }

    private void Death()
    {
        if (gameObject.tag == "Player") gameController.GameOver();
        else if (gameObject.tag == "Enemy") gameController.AddToScore(1);
        else gameController.GameOver();

        animator.SetBool("MovementBlocked", true);
        animator.Play(deathAnimationName);
        Invoke("DropRemains", deathDelay);
    }

    private void DropRemains()
    {
        Instantiate(remains, transform.position, new Quaternion());

        if (respawnUnit != null)
        {
            gameObject.SetActive(false);
            Invoke("Respawn", respawnDelay);
        }
        else Destroy(gameObject, deathDelay);
    }

    private void Respawn()
    {
        GameObject newUnit = Instantiate(respawnUnit, startingPosition, Quaternion.identity) as GameObject;
        newUnit.SetActive(true);

        Destroy(gameObject, deathDelay);
    }
}
