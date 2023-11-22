using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            this.gameObject.tag = "Player";

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 position = transform.position;
            position = mousePos;
            transform.position = position;
        }
        else if (Input.touches.Length > 0)
        {
            this.gameObject.tag = "Player";

            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 position = transform.position;
                position = mousePos;
                transform.position = position;
            }
        }
        else
        {
            this.gameObject.tag = "Untagged";
        }
    }
}
