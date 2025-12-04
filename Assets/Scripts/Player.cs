using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    public float fallForce = 5f;
    public float moveSpeed = 5f;
    public AudioClip jumpSound;
    public AudioClip dieSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Transform>().GetComponent<Rigidbody2D>().linearVelocity += new Vector2(moveSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {   
        // Fall();
        Avance();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }

    void Jump()
    {
        // Debug.Log("Jump");
        GetComponent<Rigidbody2D>().linearVelocity =  new Vector2(GetComponent<Rigidbody2D>().linearVelocity.x, 0);
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        
        // StartCoroutine(Sleep());
        // AudioSource.PlayClipAtPoint(jumpSound, transform.position);
    }

    void Fall()
    {
        // Debug.Log("Fall");
        GetComponent<Rigidbody2D>().linearVelocity +=  new Vector2(0, -fallForce * Time.deltaTime);
    }

    void Die()
    {
        // AudioSource.PlayClipAtPoint(dieSound, transform.position);
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Additional death logic here
    }

    void Avance()
    {
        // Debug.Log("Avance");
        GetComponent<Transform>().localRotation = Quaternion.Euler(0, -180, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collision");

        if (other.gameObject.CompareTag("killer"))
        {
            Debug.Log("Dead");
            Die();
        }
    }
}
