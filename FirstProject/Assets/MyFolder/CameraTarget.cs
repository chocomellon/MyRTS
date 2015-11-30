using UnityEngine;
using System.Collections;

public class CameraTarget : MonoBehaviour {

    [SerializeField, HideInInspector]
    NavMeshAgent agent;

    private RaycastHit hit;
    private Ray ray;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
