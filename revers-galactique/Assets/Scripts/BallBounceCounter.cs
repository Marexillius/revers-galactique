// ##########################################
// The alex version
// ##########################################
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallBounceCounter : MonoBehaviour
{

    [SerializeField] private InputActionProperty ballSpawnButton;

    private int BounceCounter = 0;
    //public GameObject racket;

    public GameObject playerBall;
    public GameObject player;
    public GameObject topSpawn;
    public GameObject bottomSpawn;
    private Vector3 spawnLocation;

    public Vector3 launchDirection = Vector3.zero; // angle that'll get redefined when it hit the racket
    public float launchForce = 10f; // force

    /*private void Awake()
    {
        StartCoroutine(checkRotation());
    }

    private IEnumerator checkRotation()
    {
        Debug.Log("rotation X : " + racket.transform.localRotation.eulerAngles.x + " rotation Y : " + racket.transform.localRotation.eulerAngles.y + " rotation Z : " + racket.transform.localRotation.eulerAngles.z);
        yield return new WaitForSeconds(1);
        StartCoroutine(checkRotation());
        yield break;
    }*/

/*private void Update()
{
    if (ballSpawnButton.action.WasPressedThisFrame())
    {
        spawnBall();
    }
}

private void OnCollisionEnter(Collision collision)
{

    if (gameObject.tag == "ballPlayer")
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            BounceCounter++;
            //Debug.Log(BounceCounter);
        }

        if (collision.gameObject.name == "racketObject" || collision.gameObject.tag == "racket")
        {
            Vector3 test = new Vector3(gameObject.transform.transform.position.x, gameObject.transform.transform.position.y, gameObject.transform.transform.position.z);
            // Calculate the surface normal at the point of collision
            ContactPoint contact = collision.contacts[0];
            Vector3 surfaceNormal = contact.normal;

            // Calculate a direction perpendicular to the surface normal (90 degrees angle)
            // You can use the cross product to find a vector perpendicular to the surface normal
            launchDirection = Vector3.Reflect(surfaceNormal, Vector3.up);

            // Ensure that the launch direction is normalized
            //launchDirection.Normalize();

            gameObject.GetComponent<Rigidbody>().AddForce(launchDirection.normalized * launchForce, ForceMode.Impulse);
        }

        if (BounceCounter >= 10)
        {   
            /*Destroy(gameObject);*/
/*}


}
else if(gameObject.tag == "enemyAttack")
{
foreach (ContactPoint contact in collision.contacts)
{
    BounceCounter++;
    //Debug.Log(BounceCounter);
}

if (BounceCounter >= 10)
{
    Destroy(gameObject, 3f);
}

}

}

public void spawnBall()
{
Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
Vector3 topSpawnPosition = new Vector3(topSpawn.transform.position.x, topSpawn.transform.position.y, topSpawn.transform.position.z);
Vector3 bottomSpawnPosition = new Vector3(bottomSpawn.transform.position.x, bottomSpawn.transform.position.y, bottomSpawn.transform.position.z);
Vector3 playerTop = topSpawnPosition - playerPosition;
Vector3 playerBottom = bottomSpawnPosition - playerPosition;

if (playerTop.sqrMagnitude > playerBottom.sqrMagnitude)
{
spawnLocation = topSpawnPosition;
} else if (playerTop.sqrMagnitude < playerBottom.SqrMagnitude)
{
spawnLocation = bottomSpawnPosition;
}

Debug.Log("spawning balls");
playerBall = Instantiate(playerBall, spawnLocation, Quaternion.identity);
playerBall.SetActive(true);
}
}*/

// ##########################################
// The Jay version
// ##########################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallBounceCounter : MonoBehaviour
{

    [SerializeField] private InputActionProperty ballSpawnButtonRight;
    [SerializeField] private InputActionProperty ballSpawnButtonLeft;

    private int BounceCounter = 0;

    public GameObject playerBall;
    public GameObject playerBallSpawnLocation;
    private bool spawnCooldownOver = true;

    public Vector3 launchDirection = Vector3.zero; // angle that'll get redefined when it hit the racket
    public float launchForce = 10f; // force

    private void Update()
    {
        if (ballSpawnButtonRight.action.WasPressedThisFrame() || Input.GetKeyDown("l") || ballSpawnButtonLeft.action.WasPressedThisFrame())
        {
            teleportBall();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (gameObject.tag == "ballPlayer")
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                BounceCounter++;
                //Debug.Log(BounceCounter);
            }

            if (collision.gameObject.name == "racketObject" || collision.gameObject.tag == "racket")
            {
                Vector3 test = new Vector3(gameObject.transform.transform.position.x, gameObject.transform.transform.position.y, gameObject.transform.transform.position.z);
                // Calculate the surface normal at the point of collision
                ContactPoint contact = collision.contacts[0];
                Vector3 surfaceNormal = contact.normal;

                // Calculate a direction perpendicular to the surface normal (90 degrees angle)
                // You can use the cross product to find a vector perpendicular to the surface normal
                launchDirection = Vector3.Reflect(surfaceNormal, Vector3.up);

                // Ensure that the launch direction is normalized
                //launchDirection.Normalize();

                gameObject.GetComponent<Rigidbody>().AddForce(launchDirection.normalized * launchForce, ForceMode.Impulse);
            }

            if (BounceCounter >= 10)
            {
                /*Destroy(gameObject);*/
            }


        }
        else if (gameObject.tag == "enemyAttack")
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                BounceCounter++;
                //Debug.Log(BounceCounter);
            }

            if (BounceCounter >= 10)
            {
                Destroy(gameObject, 3f);
            }

        }

    }

    private IEnumerator ballSpawnCooldown()
    {
        spawnCooldownOver = false;
        yield return new WaitForSeconds(3f);
        spawnCooldownOver = true;
        yield break;
    }

    public void teleportBall()
    {
        if (spawnCooldownOver == true)
        {
            playerBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
            playerBall.transform.position = new Vector3(playerBallSpawnLocation.transform.position.x, playerBallSpawnLocation.transform.position.y + 1, playerBallSpawnLocation.transform.position.z);
            StartCoroutine(ballSpawnCooldown());
        }
    }
}
