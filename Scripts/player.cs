using Godot;
using System;

public partial class player : CharacterBody3D
{
	//how fast in m/s
	public int Speed { get; set; } = 14;
	//how fast downwards in m/s^2
	public int FallAcceleration { get; set; } = 75;
	public int JumpImpulse { get; set; } = 20;

	private Vector3 _targetVelocity = Vector3.Zero;

	public override void _PhysicsProcess(double delta)
	{
		//For storing direction
		var direction = Vector3.Zero;

		if(Input.IsActionPressed("move_right"))
		{
			direction.X += 1.0f;
		}
		if(Input.IsActionPressed("move_left"))
		{
			direction.X -= 1.0f;
		}
		if(Input.IsActionPressed("move_back"))
		{
			direction.Z += 1.0f;
		}
		if(Input.IsActionPressed("move_forward"))
		{
			direction.Z -= 1.0f;
		}

		if (direction != Vector3.Zero)
		{
			direction = direction.Normalized();
			//Set to alter rotation
			GetNode<Node3D>("Pivot").Basis = Basis.LookingAt(direction);
		}

		//Ground Velocity
		_targetVelocity.X = direction.X * Speed;
		_targetVelocity.Z = direction.Z * Speed;

		//Vertical Velocity/Gravity
		if(!IsOnFloor())
		{
			_targetVelocity.Y -= FallAcceleration * (float)delta;
		}
		
		if(IsOnFloor() && Input.IsActionPressed("jump"))
		{
			_targetVelocity.Y = JumpImpulse;
		}

		//Move the Character
		Velocity = _targetVelocity;
		MoveAndSlide();
	}
}


