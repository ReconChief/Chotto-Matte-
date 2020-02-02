using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
	[SerializeField] private Text timer;
	[SerializeField] private Text itemCounter;
	[SerializeField] private Text healthText;

	private void Awake() {
		GameController.setTimer += SetTimer;
		Player.setItemCounter += SetItemCounter;
		Player.setHealth += SetHealth;
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void SetTimer(int time) {
		timer.text = (time/60).ToString()+" : "+(time%60).ToString();
	}
	private void SetItemCounter(int items) {
		itemCounter.text = "Items: "+items.ToString();
	}
	private void SetHealth(int health) {
		healthText.text = "Health: "+health.ToString();
	}
}
