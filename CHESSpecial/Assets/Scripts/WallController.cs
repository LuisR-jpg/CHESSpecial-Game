using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : PieceBaseController
{
    public override void MyFixedUpdate() { }

    public override void Attack() { }

    public override void Damage(int damage)
    {
        print(damage); 
    }
}
