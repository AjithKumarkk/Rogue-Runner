using UnityEngine;

public class GearMovement : MonoBehaviour
{
    public float movementSpeed = 0.5f;
    public float movementRange = 17f;

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time * movementSpeed * 0.5f, 1);

        float horizontalMovement = Mathf.Lerp(24.5f, 41.5f, t);

        transform.position = new Vector2(horizontalMovement, transform.position.y);
    }
}
