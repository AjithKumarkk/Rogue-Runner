using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Spikes" || collision.transform.tag == "Arrow")
        {
            
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                PlayerManager.isGameOver = true;
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
    }

    IEnumerator GetHurt()
    {
        // Store the initial state of layer collisions
        bool initialCollisionState = Physics2D.GetIgnoreLayerCollision(7, 8);

        // Ignore layer collision during the hurt animation
        Physics2D.IgnoreLayerCollision(7, 8, true);

        GetComponent<Animator>().SetLayerWeight(1, 1);

        yield return new WaitForSeconds(3);

        GetComponent<Animator>().SetLayerWeight(1, 0);

        // Reset layer collision to its initial state
        Physics2D.IgnoreLayerCollision(7, 8, initialCollisionState);
    }

}
