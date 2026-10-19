
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;
using UnityEngine.EventSystems;

public class RunState : State
{
    protected float speed;
    protected float rotationSpeed;

    public RunState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        speed = 5;
        base.Enter();

        //player.anim.Play("RunAnim");
        Debug.Log("entering running state");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        ReadInput();

        if (player.interactAction.IsPressed())
        {
            sm.ChangeState(sm.idleState);
        }

        //debug move gameObject
        player.rb.linearVelocity = player.moveAction.ReadValue<Vector2>() * speed;

        //if the move controller is released, change to idle state


        //UIscript.ui.DrawText("*** This is the running state ***\n");
        //UIscript.ui.DrawText("Left/Right arrows = Move Sprite");
        //UIscript.ui.DrawText("E = Idle State");
        //UIscript.ui.DrawText("Space = Jump state");
    }

    public override void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collided in runstate");

        if (collision.tag == "enemy")
        {
            //collision.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        }
    }
    public override void OnTriggerExit(Collider collision)
    {
        Debug.Log("exit collision in runstate");

        if (collision.tag == "enemy")
        {
            //collision.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f);
        }
    }



    public override void FixedUpdate()
    {
    }
}
