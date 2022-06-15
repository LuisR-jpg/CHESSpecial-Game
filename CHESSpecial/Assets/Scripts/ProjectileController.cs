using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : PieceBaseController
{
    // aState 1 -> shoot, 2 -> wait
    int aWait = 0;
    public GameObject projectile;

    public override void Attack()
    {
        if(aState == 1)
        {
            aState = 2;
            if (currentlyAttacking == null) return;
            var p = Instantiate(projectile, transform.position + new Vector3(0, 1, 0), transform.rotation);
            p.layer = LayerMask.NameToLayer("Ignore Raycast");
            float v = Mathf.Sqrt(9.81f * (Mathf.Abs(currentlyAttacking.transform.position.x - transform.position.x) - 0.70f) / 2);
            p.GetComponent<Rigidbody>().velocity = new Vector3(dir * v, v, 0);
            currentlyAttacking.GetComponent<PieceBaseController>().Damage(power, false);
        }
        else if (aState == 2)
        {
            aWait++;
            if(aWait == 50)
            {
                aWait = 0;
                aState = 0;
            }
        }
        else if(aState == 0)
        {
            aState = 1;
        }
    }
}
