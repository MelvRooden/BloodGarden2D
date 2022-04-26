using UnityEngine;

public class Sweep : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    [Range(0.7f, 1f)]
    private float range = 6f;
    [SerializeField]
    private int damage = 20;

    [SerializeField]
    private Rigidbody2D rb;


    // Start is called before the first frame update
    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void FixedUpdate()
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
