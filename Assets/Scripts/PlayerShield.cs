﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    private HealthScript healthScript;
    // Start is called before the first frame update
    void Awake()
    {
        healthScript = GetComponent<HealthScript>();
    }
    
    public void ActivatedShield(bool shieldActive) {
        healthScript.shieldActivated = shieldActive;
    }

}//class
