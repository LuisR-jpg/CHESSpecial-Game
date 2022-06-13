using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenController : PieceBaseController
{
    private int aSteps = 0; 
    public override void MyFixedUpdate()
    {
        if (state == 1) // move forward
        {
            CheckAttack();
            if (!CheckFront()) return; // blocked
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(dir, 0, 0), step);
        }
        else if (state == 2) // attack
        {
            var reScan = ShouldAttack();
            if (reScan) currentlyAttacking = reScan; 
            Attack();
            if (!reScan && aState == 0) state = 1;
        }
    }

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
            currentlyAttacking.GetComponent<PieceBaseController>().Damage(power);
        }
        else if (aState == 0)
        {
            aState = 1;
        }

    }
}
