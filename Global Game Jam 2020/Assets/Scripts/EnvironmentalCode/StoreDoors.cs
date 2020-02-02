using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
public class StoreDoors : MonoBehaviour
{
	[SerializeField] private GameObject point;
	[SerializeField] private GameObject outTheStore;
	[SerializeField] private GameObject item;
	[SerializeField] private CinemachineVirtualCamera cam;
	public static UnityAction<Vector3,GameObject,GameObject,CinemachineVirtualCamera> goInStore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerStay(Collider other) {
		if (other.CompareTag("Player")) {
			if (Input.GetButtonDown("X")) {
				if (goInStore != null) {
					goInStore(point.transform.position,outTheStore,item,cam);
				}
			}
		}
	}
}
