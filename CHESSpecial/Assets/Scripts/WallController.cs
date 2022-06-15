using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : PieceBaseController
{
    // Ignore this method, this is just shitty design
    public override void MyFixedUpdate() { }
    // Ignore this method, this is just shitty design
    public override void Attack() { }

    public override void Damage(int damage, bool willBeDestroyed)
    {
        
        print(damage); 
    }
}
