using UnityEngine;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class Move : MonoBehaviour
{
    [SerializeField, HideInInspector]
    NavMeshAgent agent;
    [SerializeField, HideInInspector]
    Animator animator;

    private RaycastHit hit;
    private Ray ray;

    void Reset()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        animator.SetFloat("Speed", agent.velocity.sqrMagnitude);

        if (Input.GetMouseButtonDown(1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}