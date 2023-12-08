using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FishingState
{
    Start,
    CastingRod,
    Fishing,
    Win,
    Lose,
    Exit
}
public static class StateController
{
    public static FishingState currentState = FishingState.Start;


}
