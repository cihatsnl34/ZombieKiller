using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

enum ZombieState
{
    Idle=0,
    Walk=1,
    Attack=2,
    Dead=3,
}
public class ZombieAI : MonoBehaviour
{
    Animator animator;
    NavMeshAgent navMesh;
    ZombieState zombieState;
    GameObject PlayerObject;
    HpPlayer hpPlayer;
    ZombieHP zombieHP;
    GameObject DoorObject;
    private int DeatZombies = 0;
    private int sceneID;
    
    void Start()
    {
       
        zombieHP = GetComponent<ZombieHP>();
        zombieState = ZombieState.Idle;
        animator = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
        PlayerObject = GameObject.FindWithTag("Player");
        hpPlayer = PlayerObject.GetComponent<HpPlayer>();
        DoorObject= GameObject.FindWithTag("door");
        
        sceneID = SceneManager.GetActiveScene().buildIndex;

        
    }

    
    void Update()
    {
       
        if (zombieHP.GetHealth() <= 0)
        {
            setState(ZombieState.Dead);
                          
        }
        switch (zombieState)
        {
            case ZombieState.Dead:
                KillZombie();
               
                break;
            case ZombieState.Attack:
                Attack();
                break;
            case ZombieState.Walk:
                SearchForTarget();
                break;
            case ZombieState.Idle:
                SearchForTarget();
                break;
            
            
            default:
                break;
        }

    }

    private void Attack()
    {
        setState(ZombieState.Attack);
        navMesh.isStopped = true;

    }
    void MakeAttack()
    {
        hpPlayer.deductHealth(10);
        SearchForTarget();
    }

    private void SearchForTarget()
    {
        float
            distance = Vector3.Distance(transform.position, PlayerObject.transform.position);
        if (distance <2f)
        {
            Debug.Log("dista");
            Attack();
        }
        else if (distance < 10)
        {
            MovetoPlayer();
        }
        else
        {
            setState(ZombieState.Idle);
            navMesh.isStopped = true;
        }
    }

    private void MovetoPlayer()
    {

        navMesh.isStopped = false;
        navMesh.SetDestination(PlayerObject.transform.position);
        setState(ZombieState.Walk); 
    }
    private void setState(ZombieState state)
    {
        zombieState = state;
        animator.SetInteger("state", (int)state);
    }
    private void KillZombie()
    {
        setState(ZombieState.Dead);
        navMesh.isStopped = true;
        Destroy(gameObject,5);
      
      

    }
}
