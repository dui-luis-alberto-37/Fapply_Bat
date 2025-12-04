using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;

    private float offsetX;
    private float offsetY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveCamera();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }
    void MoveCamera()
    {
        offsetX = player.position.x;
        offsetY = transform.position.y;

        transform.position = new Vector3(offsetX,offsetY, -200);
    }
}
