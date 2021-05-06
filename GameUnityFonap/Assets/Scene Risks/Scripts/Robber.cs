using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Robber : MonoBehaviour
{
    public Transform tarjet;
    private NavMeshAgent agent;
    private float timer = 0f;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        tarjet.position = new Vector2(Random.Range(-7, 26), Random.Range(-3, 14));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10) ChangeTargetPosition();

        agent.SetDestination(tarjet.position);
    }

    void ChangeTargetPosition()
    {
        tarjet.position = new Vector2(Random.Range(-7, 26), Random.Range(-3, 14));
        timer = 0f;
    }
}
