using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            this.gameObject.tag = "Player";

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 position = transform.position;
            position = new Vector3(mousePos.x, mousePos.y, 0);
            transform.position = position;
        }
        else if (Input.touches.Length > 0)
        {
            this.gameObject.tag = "Player";

            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 position = transform.position;
                position = new Vector3(mousePos.x, mousePos.y, 0);
                transform.position = position;
            }
        }
        else
        {
            this.gameObject.tag = "Untagged";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Marki") && this.gameObject.CompareTag("Player"))
        {
            gameManager.KillCockroach(collision.gameObject, collision.tag);
        }
        if (collision.CompareTag("Joi") && this.gameObject.CompareTag("Player"))
        {
            gameManager.KillCockroach(collision.gameObject, collision.tag);
        }
        if (collision.CompareTag("DiDi") && this.gameObject.CompareTag("Player"))
        {
            gameManager.KillCockroach(collision.gameObject, collision.tag);
        }

        if (collision.CompareTag("Bob") && this.gameObject.CompareTag("Player"))
        {
            gameManager.KillBob(collision.gameObject);
        }
    }
}

