using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f; 
    public float moveDistance = 5f; 
    public float chaseDistance = 10f; 
    public float detectionRange = 5f;
    public int minDamage = 1;
    public int maxDamage = 2;


    public int eHealth = 3;

    private Vector3 startPosition;
    private bool movingRight = true;
    private bool isChasing = false;
    private Transform player;
    private Health playerHealth;

    private void Start()
    {
        startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform; 
        playerHealth = player.GetComponent<Health>(); 
    }

    private void Update()
    {
       
        if (Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

       
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
  
        float movement = movingRight ? speed * Time.deltaTime : -speed * Time.deltaTime;
        transform.Translate(movement, 0f, 0f);

        if (Mathf.Abs(transform.position.x - startPosition.x) >= moveDistance)
        {
            movingRight = !movingRight;
            startPosition = transform.position; 
        }
    }

    private void ChasePlayer()
    {
        
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.position, step);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        

        if (collision.gameObject.CompareTag("Finish"))
        {
            eHealth--;
            print("hit");
            if (eHealth == 0)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
