﻿using System;
using System.Collections;
using UnityEngine;

public class APRateCalculator
{
    private readonly APCore _characterAPCore;
    private readonly SpeedCore _characterSpeedCore;

    public APRateCalculator(APCore characterAPCore, SpeedCore speedCore, bool kill = false)
    {
        _characterAPCore = characterAPCore;
        _characterSpeedCore = speedCore;
        _kill = kill;
    }

    public float GetIncrementAmount()
    {

        float amount = 3.87981F / (1F + (-(0.66F * ((float)Math.Pow(Math.E, ((-0.005) * _characterSpeedCore.Agility))))));

        return 1f / (amount / 5.6f);
    }

    public void Kill(bool kill)
    {
        _kill = kill;
    }

    public IEnumerator Increment()
    {
        DateTime start = DateTime.Now;
        do
        {
            yield return null;
            if (!_kill)
            {
                _characterAPCore.AP_Current += GetIncrementAmount() * Time.deltaTime;

                if (_characterAPCore.AP_Current == _characterAPCore.AP_Max)
                {
                    Debug.Log(
                        $"Hit {_characterAPCore.AP_Max} AP in {(DateTime.Now - start).TotalSeconds} with Agility = {_characterSpeedCore.Agility}");
                    break;
                }
            }
        } while (true);
    }

    private bool _kill = true;
}
