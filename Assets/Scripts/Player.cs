using Godot;
using System;

public partial class Player : CharacterBody2D
{
	// Gravedad del juego para que el jugador no flote al saltar
	[Export]
	public int GRAVITY { get; private set; } = 4200;

	// Velocidad de salto
	[Export]
	public int JUMP_SPEED { get; private set; } = 1800;

	public Vector2 ScreenSize;

	// Movimiento del personaje
	public override void _PhysicsProcess(double delta)
	{
		// Aplicar gravedad
		Velocity = new Vector2(Velocity.X, Velocity.Y + (float)(GRAVITY * delta));

		// Detectar si el jugador quiere saltar
		if (Input.IsActionJustPressed("jump_key") && IsOnFloor())
		{
			Velocity = new Vector2(Velocity.X, -JUMP_SPEED);
		}

		// Aplicar el movimiento
		MoveAndSlide();
	}
}
