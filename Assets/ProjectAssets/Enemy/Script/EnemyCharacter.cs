using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    private StarterAssets.ThirdPersonController _player;
    private Animator _animator;
    private int maxHealth = 100;
    public int currentHealth;
    
    private bool once = true;
    public bool collidedWithSword = false;

    void Start()
    {
        _player = FindFirstObjectByType<StarterAssets.ThirdPersonController>();
        _animator = GetComponent<Animator>();

        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (currentHealth <= 0 && once)
        {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            once = false;
        }
    }

    public void PlayBackStabVictimAnim()
    {
        _animator.Play("Backstab_Victim");
    }
    public void TakeDamageAnimation()
    {
        _animator.Play("Parry_Parried");
    }
    public void TakeDamage(int ammount)
    {
        currentHealth -= ammount;
        _animator.SetInteger("health", currentHealth);
    }
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Sword"))
        {
            collidedWithSword = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Sword"))
        {
            collidedWithSword = false;
        }
    }
}
