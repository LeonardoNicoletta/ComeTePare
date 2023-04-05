using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    Vector3 moveDir = new(0, 0, 0);
    public Transform attackPoint;
    [SerializeField]  float ms = 10f;
    [SerializeField] float range=.7f;
    Rigidbody2D rb;
    float damage= 5f;
    bool facingR =true;
    [SerializeField] float jumpf;
    [SerializeField] float ballSpeed;
    private bool isGrounded;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }
    // Update is called once per frames
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            moveDir.x = -1f;
            if (facingR)
            {
                facingR = false;
                FlipGameObj();
            }
      
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDir.x = 1f;
            if (!facingR)
            {
                facingR = true;
                FlipGameObj();
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
                rb.AddForce(Vector2.up * jumpf, ForceMode2D.Impulse);
        }
        moveDir.Normalize();
        transform.position += ms * Time.deltaTime * moveDir;
        moveDir.x = 0;
        moveDir.y = 0;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Ability();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
            

    }
    public void FlipGameObj()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    public void Ability()
    {
        GameObject ball= Instantiate(ballPrefab, attackPoint.position, Quaternion.identity);
        
        Rigidbody2D rbBall= ball.GetComponent<Rigidbody2D>();
        if(facingR)
            rbBall.AddForce(transform.right * ballSpeed, ForceMode2D.Impulse);
        else
            rbBall.AddForce(-transform.right * ballSpeed, ForceMode2D.Impulse);

    }
    public void Attack()
    {
        Collider2D[] hit=Physics2D.OverlapCircleAll(attackPoint.position, range);
        foreach(Collider2D enemy in hit)
        {
            Idamageable damageable=enemy.GetComponent<Idamageable>();
            Debug.Log(damageable);
            if (damageable != null)
                damageable.TakeDamage(damage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, range);
    }
}
