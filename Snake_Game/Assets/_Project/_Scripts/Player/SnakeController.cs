using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private SnakeGrowth _snakeGrowth;
    private FoodSpawn _foodSpawn;
    
    private Vector2 _snakeDir;

    private void Start()
    {
        enabled = false;
        
        _snakeGrowth = GetComponent<SnakeGrowth>();
        _foodSpawn = GameObject.Find("Spawn Area").GetComponent<FoodSpawn>();
        
        _snakeDir = Vector2.right;
    }

    private void Update()
    {
        //Assign key to direction
        if (Input.GetKeyDown(KeyCode.W) && _snakeDir != Vector2.down)
        {
            _snakeDir = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && _snakeDir != Vector2.up)
        {
            _snakeDir = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) && _snakeDir != Vector2.right)
        {
            _snakeDir = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) && _snakeDir != Vector2.left)
        {
            _snakeDir = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        //Move segments with snake "head"
        for (var i = _snakeGrowth.segments.Count - 1; i > 0; i--)
        {
            _snakeGrowth.segments[i].position = _snakeGrowth.segments[i - 1].position;
        }
        
        //Handle snake movement
        var position = transform.position;
        position = new Vector3(Mathf.Round(position.x) + _snakeDir.x, Mathf.Round(position.y) + _snakeDir.y, 0.0f);
        transform.position = position;
    }
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            //Destroy food object collided and instantiate another one at random position
            Destroy(collision.gameObject);
            _foodSpawn.RandomSpawnPosition();

            //Call function to make snake gets bigger
            _snakeGrowth.AddSegmentsToSnake();
        }

        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Segment"))
        {
            //Gameover
            Debug.Log("Game Over");
            gameManager.GameOver();
        }
    }
}
