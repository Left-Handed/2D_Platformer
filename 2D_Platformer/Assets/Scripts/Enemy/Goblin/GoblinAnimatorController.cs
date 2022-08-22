using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAnimatorController
{
    public static class Params
    {
        public const string Speed = nameof(Speed);
    }

    public static class States
    {
        public const string Idle = "Idle";
        public const string Run = "Run";
        public const string Attack = "Attack";
        public const string Take_Hit = "Take_Hit";
        public const string Death = "Death";
    }
}
