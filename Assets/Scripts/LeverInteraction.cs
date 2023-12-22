using UnityEngine;

public class LeverInteraction : MonoBehaviour
{
    public float activationRange = 2f;
    public LayerMask playerLayer;
    public GameObject HangingGround;

    private bool playerRange = false;
    private bool isTriggered = false;
    private Animator leverAnimator;

    // Start is called before the first frame update
    void Start()
    {
        leverAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerRange && !isTriggered)
        {
            leverAnimator.SetTrigger("MoveTrigger");
            isTriggered = true;

            Rigidbody2D obj = HangingGround.GetComponent<Rigidbody2D>();
            if (obj != null)
            {
                obj.bodyType = RigidbodyType2D.Dynamic;
                obj.mass = 100f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerRange = false;
        }
    }
}
