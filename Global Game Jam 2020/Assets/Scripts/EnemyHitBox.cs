﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyHitBox : MonoBehaviour
{
	public static UnityAction hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			if (hit != null) {
				hit();
			}
		}
	}
}
