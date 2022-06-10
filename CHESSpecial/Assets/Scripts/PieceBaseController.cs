using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PieceBaseController : MonoBehaviour
{
    // Start is called before the first frame update
    private int state; // 0 -> stop, 1 -> forward, 2 -> attack
    private float speed = 1f;
    private int steps, stopTime;
    public int dir = 1;
    protected int strength, power;
 
    void Start()
    {
        state = 1;
        steps = 0;
        stopTime = 0;
        SetStats();
    }

    void FixedUpdate()
    {
        if (state == 1) // move forward
        {
            if (CheckFront() == 0 && steps == 0) return; // blocked
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(dir, 0, 0), step);
            steps++;
            if (steps == 50)
            {
                state = 0;
                steps = 0;
            }
        }
        else if (state == 0) // stop
        {
            if (ShouldAttack()) state = 2; 
            stopTime++;
            if (stopTime == 100)
            {
                state = 1;
                stopTime = 0;
            }
        }
        else if (state == 2) // attack
        {
            Attack();
            if (!ShouldAttack()) state = 0; 
        }
    }

    private int CheckFront()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, new Vector3(dir, 0, 0) * 1f, Color.green);
        if (Physics.Raycast(transform.position, new Vector3(dir, 0, 0), out hit, 1f))
        {
            print(hit.transform.gameObject);
            return 0;
        }
        return 1; 
    }

    private bool ShouldAttack()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, new Vector3(dir, 0, 0) * 1f, Color.green);
        if (Physics.Raycast(transform.position, new Vector3(dir, 0, 0), out hit, 1f))
        {
            if (hit.transform.gameObject.tag != gameObject.tag) return true;
        }
        return false;
    }

    public abstract void Attack();
    public abstract void SetStats(); 
}
