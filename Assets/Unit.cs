using UnityEngine;

public class Unit : MonoBehaviour, IUnit
{
    public int health = 100;
    public float deathDelay = 0.5f;
    public float respawnDelay = 5f;
    public string takeHitAnimationName;
    public string deathAnimationName;

    public Animator animator;
    public GameObject remains;
    public GameObject respawnUnit;
    public GameController gameController;
    public HealthBar healthBar;

    private Vector3 startingPosition;

    public int GetHealth => health;

    public void Start()
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
