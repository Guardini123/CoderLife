using System.Collections;
using UnityEngine;


[CreateAssetMenu]
public class WorkState : State
{
	Transform targetWorkSpace;

	bool onWork = false;

	public float MoneyRefill = 0.1f;
	public float MaxNeedMoney = 200f;
	public float MinNeedMoney = 100f;
	
	float targetMoney = 0;

	public override void Init()
	{
		Debug.Log("Надо идти работать ...");
		targetWorkSpace = GameObject.FindGameObjectWithTag("work").transform;
		targetMoney = Random.Range(MinNeedMoney, MaxNeedMoney);
	}


	public override void Run()
	{
		if (IsFinished)
			return;

		if (!onWork)
			MoveToWork();
		else
			DoWork();
	}


	void MoveToWork()
	{
		var dist = (targetWorkSpace.position - Character.transform.position).magnitude;

		if (dist > 0.5f)
			Character.MoveTo(targetWorkSpace.position);
		else
			onWork = true;
	}


	void DoWork()
	{
		if (Character.Money < targetMoney)
			Character.Money += MoneyRefill * Time.deltaTime;
		else
			IsFinished = true;
	}
}