using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This Ability is specific for AI characters to attack the player
/// </summary>
public class AttackAbility : MonoBehaviour
{
    [SerializeField] private float _damageToGive;
    [SerializeField] private float _attackCooldown;
    

    private bool isAttacking;
    private float _attackTimer;
    private HealthSystem _targetToAttack;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {
            _attackTimer += Time.deltaTime;
            if (_attackTimer >= _attackCooldown)
            {
                Attack();
                _attackTimer = 0;
            }
        }
    }

    public void StartAttack(Transform target)
    {
        _targetToAttack = target.GetComponent<HealthSystem>();
        Debug.Log("Started Attack From Another Script");
        isAttacking = true;
    }    

    public void Attack()
    {
        if (_targetToAttack)
        {
            _targetToAttack.DecreaseHealth(_damageToGive);
        }
    }

    public void StopAttack()
    {
        Debug.Log("Stopped Attack From Another Script");
        isAttacking = false;
    }
}