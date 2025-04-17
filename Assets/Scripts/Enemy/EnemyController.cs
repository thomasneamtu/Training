using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{

    private EnemyState _currentState;

    public Transform[] _targetPoints;
    public Transform _enemyEye;
    public float _playerCheckDistance;
    public float _checkRadius = 0.4f;

    public NavMeshAgent _agent;

    public Transform _player;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _currentState = new EnemyIdleState(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        _currentState.OnStateEnter();
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.OnStateUpdate();
    }

    public void ChangeState(EnemyState state)
    {
        _currentState.OnStateExit();
        _currentState = state;
        _currentState.OnStateEnter();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_enemyEye.position, _checkRadius);
        Gizmos.DrawWireSphere(_enemyEye.position + _enemyEye.forward * _playerCheckDistance, _checkRadius);

        Gizmos.DrawLine(_enemyEye.position, _enemyEye.position + _enemyEye.forward * _playerCheckDistance);
    }
}
