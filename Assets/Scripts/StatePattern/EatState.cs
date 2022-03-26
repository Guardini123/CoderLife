using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class EatState : State
{
	public float RestoresEat = 0.6f;
	public State NoFoodState;

	Transform targetEatSpace;
	Fridge targetFridge;


	public override void Init()
	{
		Debug.Log(" ушать кушать  ”Ўј“№!!!!");
		targetEatSpace = GameObject.FindGameObjectWithTag("eat").transform;
		targetFridge = targetEatSpace.GetComponent<Fridge>();
	}


	public override void Run()
	{
		if (IsFinished)
			return;

		MoveToEat();
	}


	void MoveToEat()
	{
		var dist = (targetEatSpace.position - Character.transform.position).magnitude;

		if (dist > 0.2f)
			Character.MoveTo(targetEatSpace.position, 1.4f);
		else
			DoEat();
	}


	void DoEat()
	{
		if (Random.Range(0, 100) < 33)
		{
			targetFridge.FoodCount = targetFridge.FoodCount / 2;
		}

		if (targetFridge.FoodCount == 0)
		{
			Character.SetState(NoFoodState);
			return;
		}

		Character.Eat += targetFridge.FoodRestore;
		targetFridge.FoodCount--;
		IsFinished = true;
	}
}
