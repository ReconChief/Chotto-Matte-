using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CindyGate : MonoBehaviour
{
	public static UnityAction winner;
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
			Debug.Log("check one");
			if (Player.GetPlayer().Items >= 2) {
				Debug.Log("check two");
				if (winner != null) {
					winner();
				}
			}
		}
	}
}
