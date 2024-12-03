using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill_animator : MonoBehaviour
{
    // Déclarer la variable dynamite en dehors des méthodes pour qu'elle soit accessible partout
    public GameObject dynamite;



    public void killAnimator()
    {
        // Désactiver l'Animator
        dynamite.GetComponent<Animator>().enabled = false;

        // Activer le Rigidbody
        dynamite.AddComponent<Rigidbody>();
        dynamite.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

}