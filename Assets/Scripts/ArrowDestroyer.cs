using UnityEngine;

public class ArrowDestroyer : MonoBehaviour
{
    public float destroyPosition;
    // Start is called before the first frame update
    public void SetDestroyerPosition(float xPosition)
    {
        destroyPosition = xPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < destroyPosition)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" || collision.transform.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
