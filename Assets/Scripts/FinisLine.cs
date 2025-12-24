using UnityEngine;
using UnityEngine.SceneManagement;

public class FinisLine : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        // Debug.Log("Trigger Entered");
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // Debug.Log("Finish Line Reached!");
            // You can add additional logic here, such as loading the next level or displaying a victory message.
        }
    }
}
