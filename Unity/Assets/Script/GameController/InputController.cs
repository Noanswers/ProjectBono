﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
	public void OnChang(string command)
	{
		
	}
	
	public void OnInput(string command)
	{
        BattleCommand inputCommand = BattleController.Instance.MakeUserCommand(command);
        BattleController.Instance.AddCommand(inputCommand);
	}
}
