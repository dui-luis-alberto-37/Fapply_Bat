using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // public int scoreValue = 0;
    void Start()
    {
        // scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        Debug.Log(other.gameObject.tag);
        // Debug.Log("Trigger Entered");
        // if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().scoreValue += 1;
            // Debug.Log("Score!");
            Debug.Log("Score: " + other.gameObject.GetComponent<Player>().scoreValue);
            // You can add additional logic here, such as updating the score display.
        }
    }
}
