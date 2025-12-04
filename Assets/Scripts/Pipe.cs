using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float distroyTime = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, distroyTime);
    }
}
