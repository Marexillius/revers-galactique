using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyAINodeArea : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotationSpeed = 5f; // Adjust for smoother or faster turning
    public float nodeReachThreshold = 1f;

    private Transform currentTarget;

    //public static EnemyAINodeArea Instance { get; private set; }
    private List<Transform> nodes;

    public GameObject NodeArea;


    private void Awake()
    {
        Debug.Log(NodeArea.transform.childCount);

        /*if (Instance == null)
        {
            Instance = this;*/
            nodes = new List<Transform>();
            /*foreach (GameObject node in GameObject.FindGameObjectsWithTag("Node"))
            {
                nodes.Add(node.transform);
            }*/

            for(int i = 0; i < NodeArea.transform.childCount; i++)
            {
                nodes.Add(NodeArea.transform.GetChild(i));
            }
       /* }
        else
        {
            Destroy(gameObject);
        }*/
    }

    private void Start()
    {
        SetRandomTargetNode();
    }

    private void Update()
    {
        if (currentTarget == null) return;

        RotateTowardsTarget();
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {

        // Move towards the target node
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);

        // Check if we've reached the node
        if (Vector3.Distance(transform.position, currentTarget.position) < nodeReachThreshold)
        {
            SetRandomTargetNode();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall")
        {
            SetRandomTargetNode();
        }
    }

    private void RotateTowardsTarget()
    {

        // Calculate the direction to the target
        Vector3 direction = (currentTarget.position - transform.position).normalized;

        // Calculate the target rotation
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Smoothly rotate towards the target
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }

    private void SetRandomTargetNode()
    {
        currentTarget = GetRandomNode();
    }

    public Transform GetRandomNode()
    {
        if (nodes.Count == 0) return null;
        return nodes[Random.Range(0, nodes.Count)];
    }
}
