using UnityEngine;

public class InfiniteBG : MonoBehaviour
{
    public float length;
    private float lastLayerZ = 0f;
    public GameObject BGprefab;
    public float spawnInterval = 5f;
    private float timer = 0f;
    private float ypos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ypos = transform.position.y;
        SpwanBG();
    }

    // Update is called once per frame
    void Update()
    {
        if (BGprefab == null) return;
        if (timer >= spawnInterval)
        {
            SpwanBG();
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    void SpwanBG()
    {
        lastLayerZ += 1f;
        GameObject bg = Instantiate(BGprefab, new Vector3(transform.position.x+length, ypos, lastLayerZ), Quaternion.identity);
    }
}
