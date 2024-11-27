using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounceCounter : MonoBehaviour
{
    private int BounceCounter = 0;


    public Vector3 launchDirection = Vector3.zero; // angle that'll get redefined when it hit the racket
    public float launchForce = 10f; // force

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            BounceCounter++;
            //Debug.Log(BounceCounter);
        }

        if (collision.gameObject.name == "racketObject")
        {
            //gameObject.transform.position = new Vector3(gameObject.transform.transform.position.x, gameObject.transform.transform.position.y + 1, gameObject.transform.transform.position.z);
            // Calculate the surface normal at the point of collision
            ContactPoint contact = collision.contacts[0];
            Vector3 surfaceNormal = contact.normal;

            // Calculate a direction perpendicular to the surface normal (90 degrees angle)
            // You can use the cross product to find a vector perpendicular to the surface normal
            launchDirection = Vector3.Cross(surfaceNormal, Vector3.up);

            // Ensure that the launch direction is normalized
            launchDirection.Normalize();

            gameObject.GetComponent<Rigidbody>().AddForce(launchDirection.normalized * launchForce, ForceMode.Impulse);
        }


        if (BounceCounter == 10)
        {   
            /*gameObject.transform.localScale = Vector3.one;
            Destroy(gameObject);*/
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
