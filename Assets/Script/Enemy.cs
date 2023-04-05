using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, Idamageable
{
    [SerializeField] Slider healtBar;
    float maxHealth= 20f;
    float currentHealth;
    public void TakeDamage(float dmg)
    {
        print("danno");
        currentHealth -= dmg;
        healtBar.value = currentHealth / maxHealth;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
