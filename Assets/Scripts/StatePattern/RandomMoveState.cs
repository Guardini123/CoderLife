using System.Collections;
using UnityEngine;


[CreateAssetMenu]
public class RandomMoveState : State
{
	public float MaxDistance = 5f;
	Vector3 randomPosition;

	public State randomState;


	public override void Init()
	{
		if (Random.Range(0, 100) < 40)
		{
			Character.SetState(randomState);
			return;
		}

		Debug.Log("Пойду сюда похожу ...");
		var randomed = new Vector3(Random.Range(-MaxDistance, MaxDistance), 0f, Random.Range(-MaxDistance, MaxDistance));
		randomPosition = Character.transform.position + randomed;
	}


	public override void Run()
	{
		if ((Character.Eat < Character.CriticalEat) || (Character.Energy < Character.CriticalEnergy))
		{
			IsFinished = true;
			return;
		}

		var dist = (randomPosition - Character.transform.position).magnitude;

		if (dist > 0.5f)
			Character.MoveTo(randomPosition);
		else
			IsFinished = true;
	}
}