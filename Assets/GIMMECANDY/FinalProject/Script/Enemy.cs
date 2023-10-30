using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] Transform Player;
    [SerializeField] AudioSource LaughSFX; 
    public Animator animator;
    public Candy CandyScore;

    public int StealCandyAmount;
    public float lineOfSite; 
    NavMeshAgent agent;



    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; 
        agent.updateUpAxis = false;

        SetRandomPatrolPoint();

    }

    private void Update()
    {
        float distanceFromPlayer = Vector2.Distance(Player.position, transform.position);
        if (distanceFromPlayer < lineOfSite)
        {
            agent.SetDestination(Player.position);
            if(transform.position.x < Player.transform.position.x) 
            {
                animator.SetBool("WalkingLeft", false);
                animator.SetBool("WalkingRight", true);
            }
            else
            {
                animator.SetBool("WalkingRight", false);
                animator.SetBool("WalkingLeft", true);
            }
        }
        else
        {
            agent.SetDestination(target.position);
            if (transform.position.x < target.transform.position.x)
            {
                animator.SetBool("WalkingLeft", false);
                animator.SetBool("WalkingRight", true);
            }
            else
            {
                animator.SetBool("WalkingRight", false);
                animator.SetBool("WalkingLeft", true);
            }
        }

        

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Interactable")
        {
            SetRandomPatrolPoint();
        }
        if(collision.tag == "Player")
        {
            StartCoroutine(CapturedPlayer());
            LaughSFX.Play();
        }
    }

    private void SetRandomPatrolPoint()
    {
        Transform random = patrolPoints[Random.Range(0, patrolPoints.Length)];
        while(random == target)
        {
            random = patrolPoints[Random.Range(0, patrolPoints.Length)];
        }
        target = random;
    }

    IEnumerator CapturedPlayer()
    {
        float temp = agent.speed; 
        agent.speed = 0;
        animator.SetBool("HitPlayer", true);
        CandyScore.DecreaseCandyAmount(StealCandyAmount);
        CandyScore.UpdateCandyAmount();
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(5);
        animator.SetBool("HitPlayer", false);
        SetRandomPatrolPoint();
        gameObject.GetComponent<Collider2D>().enabled = true;
        agent.speed = temp;
    }
}
