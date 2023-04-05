using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject ball;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.GetComponent<Idamageable>()!=null)
        {
            Idamageable damageable = collision.gameObject.GetComponent<Idamageable>();
            damageable.TakeDamage(10);
            Destroy(ball);
        }  
    }
    void Start()
    {
        Destroy(ball, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
