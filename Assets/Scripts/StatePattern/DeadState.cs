using System.Collections;
using UnityEngine;

[CreateAssetMenu]
public class DeadState : State
{
	public override void Init()
	{
		Debug.Log("Dead ...");
		Character.enabled = false;
	}

	public override void Run()
	{
		
	}
}