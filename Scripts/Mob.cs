using Godot;
using System;

public partial class Mob : CharacterBody3D
{
	public int MinSpeed { get; set;} = 10;
	public int MaxSpeed { get; set;} = 18;

	public override void _PhysicsProcess(double delta)
	{
		MoveAndSlide();
	}

	public void Initialise(Vector3 startPosition, Vector3 playerPosition)
	{
		//Sets it up looking at player
		LookAtFromPosition(startPosition, playerPosition, Vector3.Up);
		//Rotate randomly so it doesn't B-line to player (within -45 and +45 degrees)
		RotateY((float)GD.RandRange(-Mathf.Pi / 4.0, Mathf.Pi / 4.0));

		int randomSpeed = GD.RandRange(MinSpeed, MaxSpeed);
		//Forward vector to move
		Velocity = Vector3.Forward * randomSpeed;
		//Rotated to go forward the way it is looking
		Velocity = Velocity.Rotated(Vector3.Up, Rotation.Y);
	}
	private void OnVisibilityNotifierScreenExited()
	{
		QueueFree();
	}
}



