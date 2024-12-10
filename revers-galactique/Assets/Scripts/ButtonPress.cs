using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public AudioClip pressedSound;
    public AudioSource boomBox;

    private void Start()
    {
        boomBox = GetComponent<AudioSource>();
    }

    public void isPressed()
    {
        boomBox.PlayOneShot(pressedSound, 1f);
    }


}
