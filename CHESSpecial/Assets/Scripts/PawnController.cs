using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnController : PieceBaseController
{
    public override void SetStats()
    {
        strength = 50;
        power = 10; 
    }
    public override void Attack()
    {
        print("Attack");
    }
}
