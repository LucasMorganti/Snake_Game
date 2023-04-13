using System.Collections.Generic;
using UnityEngine;

public class SnakeGrowth : MonoBehaviour
{
    [SerializeField] private Transform segmentPrefab;
    
    public List<Transform> segments = new List<Transform>();

    private void Start()
    {
        segments.Add(transform);
    }

    public void AddSegmentsToSnake()
    {
        //Instantiate new segment to the end of the snake object and add segment object to list
        var newSegment = Instantiate(segmentPrefab);
        newSegment.position = segments[segments.Count - 1].position;

        segments.Add(newSegment);
    }
}
