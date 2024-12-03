using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill_animator : MonoBehaviour
{
    // Déclarer la variable dynamite en dehors des méthodes pour qu'elle soit accessible partout
    public GameObject dynamite;

    // Start is called before the first frame update
    void Start()
    {
        // Optionnellement, vous pouvez initialiser des valeurs ici si nécessaire
    }

    public void killAnimator()
    {
        // Désactiver l'Animator
        dynamite.GetComponent<Animator>().enabled = false;

        // Activer le Rigidbody
        dynamite.GetComponent<Rigidbody>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Vous pouvez ajouter du code ici si nécessaire
    }
}