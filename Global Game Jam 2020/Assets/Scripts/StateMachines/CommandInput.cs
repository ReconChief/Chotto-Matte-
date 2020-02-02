using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInput : StateMachineBehaviour
{
	public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
		Player.GetPlayer().CmdInput = 0;
	}
	public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
		
	}
	public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
		GetInput();
	}
	private void GetInput() {
		if (Input.GetButtonDown("Square")) {
			Player.GetPlayer().CmdInput = 1;
		}

		
	}
}
