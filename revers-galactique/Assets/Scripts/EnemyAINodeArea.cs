using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyAINodeArea : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotationSpeed = 5f; // Adjust for smoother or faster turning
    public float nodeReachThreshold = 1f;

    private Transform currentTarget;
    public bool lineOfSight;
    public GameObject Player;
    public GameObject Enemy;

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
        if (lineOfSight == true){
            RotateTowardsPlayer();
            if (Vector3.Distance(transform.position, Player.transform.position) < 10f)
            {
                Enemy.GetComponent<Animator>().Play("ennemi_shoot_anim");
            } else
            {
                Enemy.GetComponent<Animator>().Play("ennemi_move_anim");
                MoveTowardsPlayer();
            }
        } else if (lineOfSight == false)
        {
            RotateTowardsTarget();
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        Debug.Log("im walking here");
        // Move towards the target node
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
        Enemy.GetComponent<Animator>().Play("ennemi_move_anim");

        // Check if we've reached the node
        if (Vector3.Distance(transform.position, currentTarget.position) < nodeReachThreshold)
        {
            SetRandomTargetNode();
        }
    }

    private void MoveTowardsPlayer()
    {
        Debug.Log("swiggity coming for your booty");
        Player.transform.position = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = (Player.transform.position - transform.position).normalized;

        // Calculate the target rotation
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Smoothly rotate towards the target
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall")
        {
            lineOfSight = false;
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
        return nodes[UnityEngine.Random.Range(0, nodes.Count)];
    }
}
