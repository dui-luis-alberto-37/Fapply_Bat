using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;


public class Player : MonoBehaviour
{   
    public float jumpForce = 10f;
    public float fallForce = 5f;
    public float moveSpeed = 5f;
    public AudioClip jumpSound;
    public AudioClip dieSound;

    public int autojump = 0;
    public float autojumphigh = 2f;
    public int scoreValue = 0;
    private int bestScore;

    public TextMeshProUGUI tmp;
    private ScoreManager scoreManager;


    public Animator animator;
    // public MonoBehaviour movementScript;
    bool isDead = false;
    public float soulRiseSpeed = 1f;

    private AudioManager audioManager;


    void Awake()
    {
        // animator = GetComponent<Animator>();
        // movementScript = GetComponent<MonoBehaviour>();
    }
    void Start()
    {   
        // audioManager = AudioManager.Instance;
        Time.timeScale = 1f;
        GetComponent<Transform>().GetComponent<Rigidbody2D>().linearVelocity += new Vector2(moveSpeed, 0);
        

        scoreManager = FindFirstObjectByType<ScoreManager>();
        scoreValue = 0;
        bestScore = scoreManager.LoadScore();
        scoreManager.textMeshPro = tmp;
        tmp.text = "Best Score: " + bestScore.ToString() + "\nScore: " + scoreValue.ToString();
        
        audioManager = AudioManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {   
        // Fall();

        if (isDead)
        {
            // transform.Rotate(0, 180, 0);
            transform.position += Vector3.up * soulRiseSpeed * Time.deltaTime;
        };
        Avance();
        if (autojump == 1)
        {
            if (transform.position.y < -autojumphigh)
            {
                Jump();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Debug.Log("Space key pressed!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        else{
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            // esc
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Die();
            }
        }


    }

    void Jump()
    {
        // Debug.Log("Jump");
        GetComponent<Rigidbody2D>().linearVelocity =  new Vector2(GetComponent<Rigidbody2D>().linearVelocity.x, 0);
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        audioManager.SFXPlay(audioManager.jump);
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
        transform.localScale = new Vector3(4, 4, 4);
        // AudioSource.PlayClipAtPoint(dieSound, transform.position);
        if (isDead) return;
        scoreManager.NewLastScore(scoreValue);
        isDead = true;
        animator.SetBool("isDead", true);
        // movementScript.enabled = false;

        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        GetComponent<Rigidbody2D>().simulated = false;
        // GetComponent<Rigidbody2D>().GravityScale = -10f;
        audioManager.SFXPlay(audioManager.death);
        
        // Additional death logic here
    }

    public void Respawn()
    {
        Debug.Log("Respawn");
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("trigger");

        if (other.gameObject.CompareTag("killer"))
        {
            scoreValue += 1;
            audioManager.SFXPlay(audioManager.score);
            scoreManager.Update_text(scoreValue);
            // Debug.Log("Score Up to : " + scoreValue.ToString());
        }
    }
}
