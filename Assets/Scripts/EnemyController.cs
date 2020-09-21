using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState { 
    CHASE,ATTACK
}

public class EnemyController : MonoBehaviour
{
    private CharacterAnimations enemyAnim;
    private NavMeshAgent navAgent;
    private AttackMovement attackBehaivor;

    private Transform playerTarget;

    public float moveSpeed = 3.5f;
    public float attackDistance = 1f;
    public float chasePlayerAfterAttackDistance = 1f;

    private float waitBeforeAttackTime = 1f;
    private float attackTimer;

    private EnemyState enemyState;

    public GameObject attackPoint;

    void Awake()
    {
        enemyAnim = GetComponent<CharacterAnimations>();
        navAgent = GetComponent<NavMeshAgent>();
        attackBehaivor = new AttackMovement();
        attackBehaivor.soundFX = GetComponentInChildren<CharacterSoundFX>();

        playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
    }

    void Start() {
        enemyState = EnemyState.CHASE;

        attackTimer = waitBeforeAttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyState == EnemyState.CHASE) {
            ChasePlayer();
        }

        if(enemyState == EnemyState.ATTACK) {
            AttackPlayer();
        }
    }

    void ChasePlayer() {
        navAgent.SetDestination(playerTarget.position);
        navAgent.speed = moveSpeed;

        if (navAgent.velocity.sqrMagnitude == 0) {
            enemyAnim.Walk(false);
        }else {
            enemyAnim.Walk(true);
        }

        if (Vector3.Distance(transform.position, playerTarget.position) <= attackDistance) {
            enemyState = EnemyState.ATTACK;
        }
    }

    void AttackPlayer() {
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;

        enemyAnim.Walk(false);
        attackTimer += Time.deltaTime;
        
        if (attackTimer > waitBeforeAttackTime){
            attackBehaivor.Attack(enemyAnim);
            attackTimer = 0f;
        }//if we can attack

        if (Vector3.Distance(transform.position, playerTarget.position) > attackDistance + chasePlayerAfterAttackDistance) {
            navAgent.isStopped = false;
            enemyState = EnemyState.CHASE;
        }
    }

    void ActivateAttackPoint()
    {
        attackPoint.SetActive(true);
    }

    void DeactivateAttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }

    }

}//class


public interface AttackBehaivor {
    void Attack(CharacterAnimations animations);
}

public class AttackMovement :MonoBehaviour, AttackBehaivor
{
    public CharacterSoundFX soundFX;
    public void Attack(CharacterAnimations animations)
    {
        if (Random.Range(0, 2) > 0)
        {
            animations.Attack_1();
            soundFX.Attack_1();
        }
        else
        {
            animations.Attack_2();
            soundFX.Attack_2();
        }
    }
}