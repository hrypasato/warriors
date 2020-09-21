using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    private CharacterAnimations playerAnimation;
    
    private AttackMovement attackMovement;
    
    public GameObject attackPoint;

    private PlayerShield playerShield;

    void Awake()
    {
        playerAnimation = GetComponent<CharacterAnimations>();

        playerShield = GetComponent<PlayerShield>();

        attackMovement = new AttackMovement();
        attackMovement.soundFX= GetComponentInChildren<CharacterSoundFX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))//defend when J pressed is down
        {
            playerAnimation.Defend(true);
            playerShield.ActivatedShield(true);
        }

        if (Input.GetKeyUp(KeyCode.J))//release defence when J is released
        {
            playerAnimation.UnFreezeAnimation();
            playerAnimation.Defend(false);
            playerShield.ActivatedShield(false);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            attackMovement.Attack(playerAnimation);
        }
    }

    void ActivateAttackPoint() {
        attackPoint.SetActive(true);
    }

    void DeactivateAttackPoint()
    {
        if (attackPoint.activeInHierarchy) {
            attackPoint.SetActive(false);
        }
        
    }
}//class
