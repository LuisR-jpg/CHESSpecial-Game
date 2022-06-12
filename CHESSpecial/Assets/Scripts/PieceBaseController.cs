using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PieceBaseController : MonoBehaviour
{
    protected int state, prevState; // 0 -> stop, 1 -> forward, 2 -> attack
    protected int aState; // 0 -> good to continue, 1 -> start attack, other -> on attack
    protected float speed = 1f;
    protected int steps, stopTime;
    protected float cellSize = 1f; 
    public int dir = 1;
    public int strength, power, range;
    protected GameObject currentlyAttacking;
 
    void Start()
    {
        state = 1;
        steps = 0;
        stopTime = 0;
    }

    void FixedUpdate()
    {
        MyFixedUpdate();
    }

    public virtual void MyFixedUpdate()
    {
        if (state == 1) // move forward
        {
            if (!CheckFront() && steps == 0) return; // blocked
            CheckAttack();
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
            CheckAttack();
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
            // reassign currentyAttacking
            if (!ShouldAttack() && aState == 0) state = prevState;
        }
    }

    protected bool CheckFront()
    {
        var elev = new Vector3(0, 0.5f, 0);
        RaycastHit hit;
        Debug.DrawRay(transform.position + elev, new Vector3(dir, 0, 0) * 1f, Color.green);
        if (Physics.Raycast(transform.position + elev, new Vector3(dir, 0, 0), out hit, 1f))
        {
            if(hit.transform.gameObject.tag == gameObject.tag)
                return false;
        }
        return true; 
    }

    protected void CheckAttack()
    {
        GameObject enemy = ShouldAttack(); 
        if(enemy != null)
        {
            currentlyAttacking = enemy;
            prevState = state;
            aState = 1;
            state = 2;
        }
    }

    protected GameObject ShouldAttack()
    {
        var elev = new Vector3(0, 0.5f, 0);
        for (int offset = 0; offset < range; offset++)
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position + new Vector3(dir, 0, 0) * offset + elev, new Vector3(dir, 0, 0) * 1f, Color.red);
            if (Physics.Raycast(transform.position + new Vector3(dir, 0, 0) * offset + elev, new Vector3(dir, 0, 0), out hit, 1f))
            {
                if (hit.transform.gameObject.tag != gameObject.tag) return hit.transform.gameObject;
            }
        }
        return null;
    }

    public virtual void Damage(int damage)
    {
        strength -= damage;
        // Kill
        if (strength <= 0)
        {
            // Instantiate(explosion, transform.position, Quaternion.identity);
            // AudioSource.PlayClipAtPoint(destroyed, transform.position);
            Destroy(gameObject);
        }
    }

    public abstract void Attack();
}
