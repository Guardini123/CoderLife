using System.Collections;
using UnityEngine;


[CreateAssetMenu]
public class GoBuyFoodState : State
{
	Transform targetStoreSpace;
	Shop targetShop;

	Transform targetEatSpace;
	Fridge targetFridge;

	bool boughtFood = false;
	int boughtFoodCount = 0;

	public float speedMult = 2.5f;
	public State NoMoneyState;


	public override void Init()
	{
		Debug.Log("Еда закончилась ... Надо идти покупать");

		targetStoreSpace = GameObject.FindGameObjectWithTag("store").transform;
		targetShop = targetStoreSpace.GetComponent<Shop>();

		targetEatSpace = GameObject.FindGameObjectWithTag("eat").transform;
		targetFridge = targetEatSpace.GetComponent<Fridge>();

		if (Character.Money < targetShop.FoodCost)
		{
			Character.SetState(NoMoneyState);
			return;
		}
	}


	public override void Run()
	{
		if (IsFinished)
			return;

		if (!boughtFood)
			MoveToShop();
		else
			MoveToFridge();
	}


	void MoveToShop()
	{
		var dist = (targetStoreSpace.position - Character.transform.position).magnitude;

		if (dist > 0.2f)
		{
			Character.MoveTo(targetStoreSpace.position, speedMult);
		}
		else
		{
			boughtFoodCount = Mathf.FloorToInt(Character.Money / targetShop.FoodCost);
			Character.Money -= boughtFoodCount * targetShop.FoodCost;
			boughtFood = true;
		}
	}


	void MoveToFridge()
	{
		var dist = (targetEatSpace.position - Character.transform.position).magnitude;

		if (dist > 0.2f)
		{
			Character.MoveTo(targetEatSpace.position, speedMult);
		}
		else
		{
			targetFridge.FoodCount += boughtFoodCount;
			IsFinished = true;
		}
	}
}