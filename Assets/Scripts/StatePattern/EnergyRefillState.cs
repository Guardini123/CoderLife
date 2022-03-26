using System.Collections;
using UnityEngine;


[CreateAssetMenu]
public class EnergyRefillState : State
{
	Transform targetSleepSpace;

	Vector3 lastCharPos;

	bool isSleepStarted;
	public float SleepTimeLeft = 7f;
	public float EnergyAfterSleep = 1f;


	public override void Init()
	{
		Debug.Log("Спать захотелось ...");
		targetSleepSpace = GameObject.FindGameObjectWithTag("sleep").transform;
	}


	public override void Run()
	{
		if (IsFinished)
			return;

		if (!isSleepStarted)
			MoveToSleep();
		else
			DoSleep();
	}


	void MoveToSleep()
	{
		var dist = (targetSleepSpace.position - Character.transform.position).magnitude;

		if (dist > 1f)
		{
			Character.MoveTo(targetSleepSpace.position, 0.8f);
		} 
		else
		{
			lastCharPos = Character.transform.position;
			Character.transform.position = targetSleepSpace.position;

			isSleepStarted = true;
		}
	}


	void DoSleep()
	{
		SleepTimeLeft -= Time.deltaTime;

		if (SleepTimeLeft > 0)
			return;

		Character.transform.position = lastCharPos;
		Character.Energy = EnergyAfterSleep;
		IsFinished = true;
	}
}