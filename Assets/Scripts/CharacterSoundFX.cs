using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundFX : MonoBehaviour
{
    private AudioSource soundFX;
    
    [SerializeField]
    private AudioClip attackSound1, attackSound2, dieSound;
    
    void Awake()
    {
        soundFX = GetComponent<AudioSource>();
    }

    public void Attack_1() {
        soundFX.clip = attackSound1;
        soundFX.Play();
    }

    public void Attack_2()
    {
        soundFX.clip = attackSound2;
        soundFX.Play();
    }

    public void Die()
    {
        soundFX.clip = dieSound;
        soundFX.Play();
    }

}//class
