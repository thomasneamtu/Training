using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // underscore to show which variable is private, is a formatting preferance
    [SerializeField] private Transform[] _targetpoints;
    [SerializeField] private Transform _enemy;
    [SerializeField] private float _playerCheckDistance;
    [SerializeField] private float _checkRadius = 0.4f;

    int _currentTarget = 0;

    private NavMeshAgent _agent;

    public bool isIdle = true;
    public bool isPlayerFound;
    public bool isCloseToPlayer;

    public Transform player;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        //Tell agent where the first point is
        _agent.destination = _targetpoints[_currentTarget].position;
    }


    void Update()
    {
        if (isIdle)
        {
            Idle();
        }
        else if (isPlayerFound)
        {
            if (isCloseToPlayer)
            {
                AttackPlayer();
            }
            else
            {
                FollowPlayer();
            }
        }
    }

    void Idle()
    {
        //choose the next destination in the array
        if (_agent.remainingDistance < 0.1f)
        {
            _currentTarget++;
            if (_currentTarget >= _targetpoints.Length)
            {
                _currentTarget = 0;
                _agent.destination = _targetpoints[_currentTarget].position;
            }
        }

        //check player
        if (Physics.SphereCast(_enemy.position, _checkRadius, transform.forward, out RaycastHit hit, _playerCheckDistance))
        {
            if(hit.transform.CompareTag("Player"))
            {
                Debug.Log("Player Found!");
                isIdle = false;
                isPlayerFound = true;
                player = hit.transform;
                _agent.destination = player.position;
            }
        }
    }

    void FollowPlayer()
    {
        if (player != null)
        {
            //logic for if we are too far away
            if(Vector3.Distance(transform.position, player.position) > 10)
            {
                isPlayerFound = false;
                isIdle = true;
            }

            if (Vector3.Distance(transform.position, player.position) > 2)
            {
                isCloseToPlayer = true;
            }
            else
            {
                isCloseToPlayer = false;
            }
            
            _agent.destination = player.position;

        }
        else
        {
            isPlayerFound = false;
            isIdle = true;
            isCloseToPlayer = false;
        }
    }

    void AttackPlayer()
    {
        if(player != null)
        {
            Debug.Log("Attacking!");
            if(Vector3.Distance(transform.position, player.position) > 2)
            {
                isCloseToPlayer = false;
            }
        }
        else
        {
            Debug.Log("No Player Found In Game!");
        }
    }    
}
