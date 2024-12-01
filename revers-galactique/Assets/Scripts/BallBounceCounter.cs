using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounceCounter : MonoBehaviour
{
    private int BounceCounter = 0;
    public GameObject racket;

    public Vector3 launchDirection = Vector3.zero; // angle that'll get redefined when it hit the racket
    public float launchForce = 10f; // force

    private void Awake()
    {
        StartCoroutine(checkRotation());
    }

    private IEnumerator checkRotation()
    {
        Debug.Log("rotation X : " + racket.transform.localRotation.eulerAngles.x + " rotation Y : " + racket.transform.localRotation.eulerAngles.y + " rotation Z : " + racket.transform.localRotation.eulerAngles.z);
        yield return new WaitForSeconds(1);
        StartCoroutine(checkRotation());
        yield break;
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
}
