using Godot;
using System;

public class Player : RigidBody2D
{
    [Signal]
    public delegate void GameOver();
    private bool duck = false;
    public Boolean canJump = false;

    public AnimationPlayer walkingAnimation;

    public AnimationPlayer duckAnimation;

    public AnimationPlayer jumpAnimation;
    public AnimationPlayer duckWalkingAnimation;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        walkingAnimation = GetNode<AnimationPlayer>("walking");
        duckAnimation = GetNode<AnimationPlayer>("duck");
        jumpAnimation = GetNode<AnimationPlayer>("jump");
        duckWalkingAnimation = GetNode<AnimationPlayer>("duckWalking");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    /* public override void _Process(float delta)
    {
    } */
    public void _on_Player_body_entered(RigidBody2D body)
    {
        if (body.Name == "map")
        {
            walkingAnimation.Play("Walking");
            canJump = true;

        }
        else
        {
            EmitSignal("GameOver");
        }
    }
    public void _on_Player_body_exited(PhysicsBody2D body)
    {
        canJump = false;
    }

    public override void _IntegrateForces(Physics2DDirectBodyState state)
    {
        base._IntegrateForces(state);
        if (Input.IsActionPressed("jump") && !duck && canJump)
        {
            walkingAnimation.Stop(true);
            jumpAnimation.Play("jump");
            state.ApplyImpulse(Vector2.Down, new Vector2(0, -150));
        }
        if (Input.IsActionJustPressed("duck") && canJump)
        {

            duckAnimation.Play("duck");
            duckWalkingAnimation.Play("walking");
            walkingAnimation.Stop(true);
            //GetNode<CollisionShape2D>("HeadColader").Position = new Vector2(0, 20);
            duck = true;

        }
        else if (Input.IsActionJustReleased("duck") && canJump)
        {
            duck = false;
            duckAnimation.PlayBackwards("duck");
            duckWalkingAnimation.Stop(true);
            walkingAnimation.Play("Walking");
            //GetNode<CollisionShape2D>("HeadColader").Position = new Vector2(0, -60);
        }
    }
}
