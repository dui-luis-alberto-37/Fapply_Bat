using UnityEngine;
// using Player;
using Math = System.Math;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    private float y_mean;
    public float playerDistance = 1.5f;
    public float heightOffset = 2f;
    public float spawnInterval = 2f;
    private float timer = 0f;
    public float stopAfter = 5f;
    
    public int infinitePipes = 1; // if 0 then stop after certain number of pipes
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPipe();
        --stopAfter;
        stopAfter += Math.Max(0, infinitePipes);
        y_mean = transform.position.y;
        // Debug.Log($"y_mean: {y_mean}");
    }
    void Update()
    {
        if (pipePrefab == null) return;
        if (timer >= spawnInterval && stopAfter > 0)
        {
            SpawnPipe();
            timer = 0f;
            --stopAfter;
            stopAfter += Math.Max(0, infinitePipes);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
    // Update is called once per frame
    void SpawnPipe()
    {
        float yPos = Random.Range(-heightOffset, heightOffset);
        // Debug.Log($"yPos: {yPos}");
        Instantiate(pipePrefab, new Vector3(transform.position.x + playerDistance*50, yPos, -1), Quaternion.identity);
    }
}
