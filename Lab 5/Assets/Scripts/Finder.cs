using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Finder : MonoBehaviour
{
    public Transform goal;
    public GameObject body;

    private Rigidbody rigidbody;

    private Animator animator;

    private NavMeshAgent agent;

    private bool grounded = true;
    
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = body.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        agent.destination = goal.position; 
        animator.SetFloat("speed", agent.velocity.sqrMagnitude);
        if (Input.GetMouseButtonDown(0) && (!agent.isStopped))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        // when you want to jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            grounded = false;
            Vector3 currentVelocity = new Vector3(0, 0 , 0);
            if (agent.enabled)
            {
                currentVelocity = agent.desiredVelocity;
                agent.SetDestination(transform.position);
                agent.updatePosition = false;
                agent.updateRotation = false;
                agent.isStopped = true;
            }
            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;
            rigidbody.AddRelativeForce(-currentVelocity, ForceMode.Impulse);
            rigidbody.AddRelativeForce(new Vector3(0, 5f, 0), ForceMode.Impulse);
            animator.SetTrigger("jump");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != null && collision.collider.tag == "Ground")
        {
            if (!grounded)
            {
                if (agent.enabled)
                {
                    agent.nextPosition = transform.position;
                    agent.SetDestination(transform.position);
                    agent.updatePosition = true;
                    agent.updateRotation = true;
                    agent.isStopped = false;
                }
                rigidbody.isKinematic = true;
                rigidbody.useGravity = false;
                grounded = true;
            }
        }
    }
}
