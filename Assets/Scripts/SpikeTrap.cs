using System.Collections;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public Sprite inactiveSprite; 
    public Sprite activeSprite;  

    public float activationDelay = 0.5f;
    public int damage = 2;

    private SpriteRenderer spriteRenderer; 
    private bool isActivated = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = inactiveSprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isActivated)
        {
            StartCoroutine(ActivateTrap(other));
        }
    }

    private IEnumerator ActivateTrap(Collider2D player)
    {
        isActivated = true;

    
        yield return new WaitForSeconds(activationDelay);
        spriteRenderer.sprite = activeSprite;

        if (player != null && player.CompareTag("Player"))
        {
            var playerHealth = player.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }

       
        yield return new WaitForSeconds(activationDelay);
        spriteRenderer.sprite = inactiveSprite;
        isActivated = false;
    }
}
