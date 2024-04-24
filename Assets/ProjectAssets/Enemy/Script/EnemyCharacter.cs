using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    private StarterAssets.ThirdPersonController _player;
    private Animator _animator;
    private int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        _player = FindFirstObjectByType<StarterAssets.ThirdPersonController>();
        _animator = GetComponent<Animator>();

        currentHealth = maxHealth;
    }

    public void PlayBackStabVictimAnim()
    {
        _animator.Play("Backstab_Victim");
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
}
