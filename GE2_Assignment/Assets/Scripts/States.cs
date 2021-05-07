using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PatrolState : State
{
    public override void Enter()
    {
        owner.GetComponent<EnemyFollowPath>().enabled = true;
    }
    public override void Think()
    {
        if(Vector3.Distance(owner.GetComponent<Fighter>().enemy.transform.position, owner.transform.position) < 10)
        {
            owner.ChangeState(new DefendState());
        }
    }
    public override void Exit()
    {
        owner.GetComponent<EnemyFollowPath>().enabled = false;
    }
}
public class DefendState : State
{
    public override void Enter()
    {
        //owner.GetComponent<OffsetPursue>().target = owner.GetComponent<Fighter>().enemy1.GetComponent<Boid>();
        //owner.GetComponent<OffsetPursue>().enabled = true;
        owner.GetComponent<Persue>().target = owner.GetComponent<Fighter>().enemy1.GetComponent<Boid>();
        owner.GetComponent<Persue>().enabled = true;
    }
    public override void Think()
    {
        Vector3 toEnemy = owner.GetComponent<Fighter>().enemy.transform.position - owner.transform.position;
        if(Vector3.Angle(owner.transform.forward, toEnemy) < 45 && toEnemy.magnitude < 30)
        {
            GameObject bullet = GameObject.Instantiate(owner.GetComponent<Fighter>().bullet, owner.transform.position + owner.transform.forward * 2, owner.transform.rotation);

        }
        if(Vector3.Distance(owner.GetComponent<Fighter>().enemy.transform.position, owner.transform.position) > 20)
        {
            owner.ChangeState(new PatrolState());
        }
    }
    public override void Exit()
    {
        //owner.GetComponent<OffsetPursue>().enabled = false;
        owner.GetComponent<Persue>().enabled = false;
    }
}
public class AttackState : State
{
    public override void Enter()
    {
        //owner.GetComponent<OffsetPursue>().target = owner.GetComponent<Fighter>().enemy.GetComponent<Boid>();
        //owner.GetComponent<OffsetPursue>().enabled = true;
        owner.GetComponent<Persue>().target = owner.GetComponent<Fighter>().enemy1.GetComponent<Boid>();
        owner.GetComponent<Persue>().enabled = true;
    }
    public override void Think()
    {
        Vector3 toEnemy = owner.GetComponent<Fighter>().enemy.transform.position - owner.transform.position;
        if(Vector3.Angle(owner.transform.forward, toEnemy) < 45 && toEnemy.magnitude < 30)
        {
            GameObject bullet = GameObject.Instantiate(owner.GetComponent<Fighter>().bullet, owner.transform.position + owner.transform.forward * 2, owner.transform.rotation);

        }
        if(Vector3.Distance(owner.GetComponent<Fighter>().enemy.transform.position, owner.transform.position) < 10)
        {
            owner.ChangeState(new EvadeState());
        }
    }
    public override void Exit()
    {
        //owner.GetComponent<OffsetPursue>().enabled = false;
        owner.GetComponent<Persue>().enabled = false;
    }
}
public class EvadeState : State
{
    public override void Enter()
    {
        owner.GetComponent<Evade>().targetGameObject = owner.GetComponent<Fighter>().enemy1;
        owner.GetComponent<Evade>().enabled = true;
    }
    public override void Think()
    {
        if(Vector3.Distance(owner.GetComponent<Fighter>().enemy1.transform.position, owner.transform.position) > 30)
        {
            owner.ChangeState(new AttackState());
        }
    }
    public override void Exit()
    {
        owner.GetComponent<Evade>().enabled = false;
    }
}
public class Alive : State
{
    
    public override void Think()
    {
        if(owner.GetComponent<Fighter>().health <= 0)
        {
            Dead dead = new Dead();
            owner.ChangeState(dead);
            owner.SetGlobalState(dead);
            return;
        }
    }
}
public class Dead : State
{
    public override void Enter()
    {
        SteeringBehaviour[] sbehaviours = owner.GetComponent<Boid>().GetComponents<SteeringBehaviour>();
        foreach(SteeringBehaviour sb in sbehaviours)
        {
            sb.enabled = false;
        }
        owner.GetComponent<StateMachine>().enabled = false;
    }
}