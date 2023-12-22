using UnityEngine;

public class EnemyArcher : MonoBehaviour
{
    private Animator animator;
    public GameObject arrowPrefab;
    public float shootInterval;
    public float destroyPosition;
    public float arrowPosition;

    private float nextShootTime;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextShootTime)
        {
            ShootArrow();
            nextShootTime = Time.time + shootInterval;
        }
    }

    void ShootArrow()
    {
        animator.SetTrigger("ShootArrow");

        GameObject arrow = Instantiate(arrowPrefab, new Vector2(transform.position.x, arrowPosition), Quaternion.identity);

        arrow.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 5f, ForceMode2D.Impulse);

        ArrowDestroyer arrowDestroyer = arrow.AddComponent<ArrowDestroyer>();
        arrowDestroyer.SetDestroyerPosition(destroyPosition);
    }

    
}
