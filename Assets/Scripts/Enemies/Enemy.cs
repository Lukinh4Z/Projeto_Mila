using ScriptableObjects;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float speedX;
    public float speedY;
    public float shouldDie = 50f;

    [SerializeField] private Rigidbody2D rb;
    public SoundEffectSO deathSound;
    public float scoreOnDeath = 0f;

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            Destroy(gameObject);
            deathSound.Play();
            ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
            scoreManager.GiveScore(scoreOnDeath);
        }
    }
    
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.x) > shouldDie) Destroy(gameObject);

        if (transform.position.y > 7 || transform.position.y < -7)
        {
            speedY = -1 * speedY;
        }

        rb.linearVelocity = new Vector2(-speedX, speedY);
    }
}
