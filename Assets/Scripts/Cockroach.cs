using UnityEngine;

public class Cockroach : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private Vector2 moveDirection;

    private void Awake()
    {
        moveDirection = new Vector2(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
            ).normalized;
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)(moveSpeed * Time.fixedDeltaTime * moveDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Side")
        {
            moveDirection.x *= -1f;
        }
        if (collision.tag == "Top")
        {
            moveDirection.y *= -1f;
        }

        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
