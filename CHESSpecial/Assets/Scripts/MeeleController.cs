using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleController : PieceBaseController
{
    // aState 1 -> backwards, 2 -> forward, 3 -> attacking
    private int aSteps = 0;

    public override void Attack()
    {
        if (aState == 1)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, transform.position - new Vector3(dir, 0, 0), step);
            aSteps++;
            if (aSteps == 20)
            {
                aSteps = 0;
                aState = 2;
            }
        }
        else if (aState == 2)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(dir, 0, 0), step);
            aSteps++;
            if (aSteps == 20)
            {
                aSteps = 0;
                aState = 3;
            }
        }
        else if (aState == 3)
        {
            aState = 0;
            if (currentlyAttacking == null) return;
            PieceBaseController enemy = currentlyAttacking.GetComponent<PieceBaseController>();
            enemy.Damage(power, strength < enemy.strength);
        }
        else if (aState == 0)
        {
            aState = 1;
        }

    }
}
