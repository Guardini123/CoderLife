using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    [Header("Init params")]
    private float _eat = 1f;
    public TMP_Text _eatTF;
    public float Eat 
    { 
        get 
        {
            return _eat;
        }
        set 
        {
            _eat = value;
            _eatTF.text = value.ToString();
        } 
    }

    private float _energy = 1f;
    public TMP_Text _energyTF;
    public float Energy
    {
        get
        {
            return _energy;
        }
        set
        {
            _energy = value;
            _energyTF.text = value.ToString();
        }
    }

    private float _money = 0f;
    public TMP_Text _moneyTF;
    public float Money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
            _moneyTF.text = value.ToString();
        }
    }


    [Header("Critical params")]
    private float _criticalEat = 0.4f;
    public TMP_Text _criticalEatTF;
    public float CriticalEat
    {
        get
        {
            return _criticalEat;
        }
        set
        {
            _criticalEat = value;
            _criticalEatTF.text = value.ToString();
        }
    }

    private float _criticalEnergy = 0.4f;
    public TMP_Text _criticalEnergyTF;
    public float CriticalEnergy
    {
        get
        {
            return _criticalEnergy;
        }
        set
        {
            _criticalEnergy = value;
            _criticalEnergyTF.text = value.ToString();
        }
    }


    [Header("Settings")]
    private float _eatEndTime = 15f;
    public TMP_Text _eatEndTimeTF;
    public float EatEndTime
    {
        get
        {
            return _eatEndTime;
        }
        set
        {
            _eatEndTime = value;
            _eatEndTimeTF.text = value.ToString();
        }
    }

    private float _energyEndTime = 25f;
    public TMP_Text _energyEndTimeTF;
    public float EnergyEndTime
    {
        get
        {
            return _energyEndTime;
        }
        set
        {
            _energyEndTime = value;
            _energyEndTimeTF.text = value.ToString();
        }
    }

    public float SpeedMultiplyer = 1f;


    [Header("States")]
    public State StartState;
    public State EatState;
    public State EnergyState;
    public State RandomMoveState;
    public State DeadState;

    [Header("Actual state")]
    public State CurrentState;


	private void Start()
	{
        SetState(StartState);

        Eat = _eat;
        Energy = _energy;
        Money = _money;

        CriticalEat = _criticalEat;
        CriticalEnergy = _criticalEnergy;

        EatEndTime = _eatEndTime;
        EnergyEndTime = _energyEndTime;
	}


	private void Update()
	{
        Eat -= Time.deltaTime / EatEndTime;
        Energy -= Time.deltaTime / EnergyEndTime;

        if ((Eat < -1f) || (Energy < -1f))
            SetState(DeadState);

		if (!CurrentState.IsFinished)
		{
            CurrentState.Run();
		}
        else
		{
            if (Eat <= CriticalEat)
                SetState(EatState);
            else if (Energy <= CriticalEnergy)
                SetState(EnergyState);
            else
                SetState(RandomMoveState);
		}
	}


    public void SetState(State state)
	{
        CurrentState = Instantiate(state);
        CurrentState.Character = this;
        CurrentState.Init();
	}


    public void MoveTo(Vector3 pos, float speedMult = 1.0f)
	{
        pos.y = transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * SpeedMultiplyer * speedMult);
	}


    public void SetEat(string value)
	{
        Eat = float.Parse(value);
	}

    public void SetEnergy(string value)
    {
        Energy = float.Parse(value);
    }

    public void SetMoney(string value)
    {
        Money = float.Parse(value);
    }

    public void SetCriticalEat(string value)
    {
        CriticalEat = float.Parse(value);
    }

    public void SetCriticalEnergy(string value)
    {
        CriticalEnergy = float.Parse(value);
    }

    public void SetEatEndTime(string value)
    {
        EatEndTime = float.Parse(value);
    }

    public void SetEnergyEndTime(string value)
    {
        EnergyEndTime = float.Parse(value);
    }
}
