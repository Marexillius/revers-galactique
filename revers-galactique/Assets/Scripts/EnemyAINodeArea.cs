using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAINodeArea : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotationSpeed = 5f; // Adjust for smoother or faster turning
    public float nodeReachThreshold = 1f;
    public bool enemyisResting = false;

    private Transform currentTarget;
    public bool lineOfSight;
    public GameObject Player;
    public GameObject Enemy;

    private List<Transform> nodes;
    public GameObject NodeArea;

    private bool enemyAttackOnCooldown = false;
    public GameObject ennemyBall;
    public GameObject ennemyBallSpawnPosition;

    public AudioClip enemyAttack;
    public AudioClip enemySpot;
    public AudioClip enemyDies;
    public AudioSource boomBox;

    private void Awake()
    {
        //Debug.Log(NodeArea.transform.childCount);

            nodes = new List<Transform>();

            for(int i = 0; i < NodeArea.transform.childCount; i++)
            {
                nodes.Add(NodeArea.transform.GetChild(i));
            }
    }

    private void Start()
    {
        SetRandomTargetNode();
        boomBox = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (currentTarget == null) return;
        
        if (lineOfSight == true){
            boomBox.PlayOneShot(enemySpot, 0.3f);
            RotateTowardsPlayer();
            if (Vector3.Distance(transform.position, Player.transform.position) < 10f)
            {
                if (enemyAttackOnCooldown == false)
                {
                    StartCoroutine(attackAnimation());
                }
            } else
            {
                // StartCoroutine(walkCycle());
                Enemy.GetComponent<Animator>().Play("ennemi_move_anim");
                MoveTowardsPlayer();
            }
        } else if (lineOfSight == false)
        { 
            if(enemyisResting == false)
            {
                RotateTowardsTarget();
                MoveTowardsTarget();
            }
            else
            {
                Enemy.GetComponent<Animator>().Play("ennemi_idle_anim");
            }
            
        }
    }

    private void MoveTowardsTarget()
    {
        // Debug.Log("im walking here");
        // Move towards the target node
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
        Enemy.GetComponent<Animator>().Play("ennemi_move_anim");

        // Check if we've reached the node
        if (Vector3.Distance(transform.position, currentTarget.position) < nodeReachThreshold)
        {
            SetRandomTargetNode();
            enemyisResting = true;
            StartCoroutine(idleAnimation());
        }
    }

    private void MoveTowardsPlayer()
    {
        // Debug.Log("swiggity coming for your booty");
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

    public void SetRandomTargetNode()
    {
        currentTarget = GetRandomNode();
    }

    public Transform GetRandomNode()
    {
        if (nodes.Count == 0) return null;
        return nodes[UnityEngine.Random.Range(0, nodes.Count)];
    }
     
    private IEnumerator attackAnimation()
    {
        //Debug.Log("start attacking");
        enemyAttackOnCooldown = true;
        Enemy.GetComponent<Animator>().Play("ennemi_shoot_anim");
        //ennemyBall = Instantiate(ennemyBall, ennemyBallSpawnPosition.transform.position, Quaternion.identity);

        ennemyBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ennemyBall.transform.position = new Vector3(ennemyBallSpawnPosition.transform.position.x, ennemyBallSpawnPosition.transform.position.y, ennemyBallSpawnPosition.transform.position.z);

        yield return new WaitForSeconds(0.3f);
        boomBox.PlayOneShot(enemyAttack, 0.5f);
        ennemyBall.SetActive(true);
        ennemyBall.GetComponent<Rigidbody>().AddForce(transform.forward * 10f, ForceMode.Impulse);

        yield return new WaitForSeconds(1);
        Enemy.GetComponent<Animator>().Play("ennemi_move_anim");

        yield return new WaitForSeconds(2);
        enemyAttackOnCooldown = false;
        yield break;
    }

    private IEnumerator idleAnimation()
    {
        yield return new WaitForSeconds(3);
        enemyisResting = false;
        yield break;
    }

    private IEnumerator walkCycle()
    {
        moveSpeed = 5f;
        yield return new WaitForSeconds(0.25f);
        moveSpeed = 0f;
        yield return new WaitForSeconds(0.75f);
        yield break;
    }
}
