using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    private float y_mean;
    public float playerDistance = 1.5f;
    public float heightOffset = 2f;
    public float spawnInterval = 2f;
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPipe();
        y_mean = transform.position.y;
        Debug.Log($"y_mean: {y_mean}");
    }
    void Update()
    {
        if (pipePrefab == null) return;
        if (timer >= spawnInterval)
        {
            SpawnPipe();
            timer = 0f;
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
        Debug.Log($"yPos: {yPos}");
        Instantiate(pipePrefab, new Vector3(transform.position.x + playerDistance*50, yPos, -1), Quaternion.identity);
    }
}
