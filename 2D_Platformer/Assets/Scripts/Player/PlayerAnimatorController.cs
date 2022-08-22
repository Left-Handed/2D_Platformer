using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    public static class Params 
    { 
        public const string Speed = nameof(Speed); 
    }

    public static class States
    {
        public const string Idle = "Idle";
        public const string Run = "Run";
        public const string Attack_Start = "Attack_Start";
        public const string Attack_Continued_1 = "Attack_Continued_1";
        public const string Attack_Continued_2 = "Attack_Continued_2";
        public const string Shield = "Shield";
        public const string Shield_Continued = "Shield_Continued";
        public const string Death = "Death";
        public const string Roll = "Roll";
    }

}
