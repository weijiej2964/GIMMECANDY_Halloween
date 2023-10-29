using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] Transform Player;

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
        }
        else
        {

            agent.SetDestination(target.position);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PatrolPoint")
        {
            SetRandomPatrolPoint();
        }
        if(collision.tag == "Player")
        {
            StartCoroutine(CapturedPlayer());
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
        yield return new WaitForSeconds(5);
        SetRandomPatrolPoint();
        agent.speed = temp;
    }
}
