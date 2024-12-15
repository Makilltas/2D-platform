using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameManager gameManager; 

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.CompareTag("Player"))
        {
  
            gameManager.AddCoin();

        
            Destroy(gameObject);
        }
    }
}
