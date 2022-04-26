using UnityEngine;

public class Sweep : MonoBehaviour
{
    public float speed = 20f;
    [Range(0.7f, 1f)]
    public float range = 6f;
    public int damage = 20;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    public void Start()
    {
        rb.velocity = transform.right * speed;
    }

    public void FixedUpdate()
    {
        float x = transform.localScale.x;
        float y = transform.localScale.y;

        transform.localScale = new Vector3(x * range / 1.01f, y * range / 1.01f, 1f);

        if (transform.localScale.x <= 0.5) this.Destroy();
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Unit unit = hitInfo.GetComponent<Unit>();

        if (unit != null) unit.TakeDamage(damage);

        this.Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
