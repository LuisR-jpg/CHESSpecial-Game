using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleController : PieceBaseController
{
    // aState 1 -> backwards, 2 -> forward, 3 -> attacking
    private int aSteps = 0;
    public AudioClip hitAudio1, hitAudio2;

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
            enemy.Damage(power, power < enemy.power);
            AudioClip toPlay = (Random.Range(0, 10) % 2 == 0 ? hitAudio1 : hitAudio2); 
            AudioSource.PlayClipAtPoint(toPlay, transform.position, 1.0f);
        }
        else if (aState == 0)
        {
            aState = 1;
        }

    }
}
