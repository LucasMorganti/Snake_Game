using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;

    private BoxCollider2D _myBoxCollider;
    private Bounds _spawnBounds;

    private void Start()
    {
        _myBoxCollider = GetComponent<BoxCollider2D>();
        _spawnBounds = _myBoxCollider.bounds;
    }

    public void RandomSpawnPosition()
    {
        //Setup limits for food spawn (bounds)
        var x = Random.Range(_spawnBounds.min.x, _spawnBounds.max.x);
        var y = Random.Range(_spawnBounds.min.y, _spawnBounds.max.y);
        var spawnPosition = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

        //Instantiate food object inside spawn area
        Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
    }
}
