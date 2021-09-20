using Godot;
using System;
using System.Threading.Tasks;

public class ObstacleBox : Area2D
{
    private RandomNumberGenerator rng = new RandomNumberGenerator();
    private bool isMooving = false;
    [Export]
    private int movementDelaySecs = 5;
    [Export]
    private int boxMovementSpeed = -800;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        isMooving = true;
    }

    public void OutOfScreen()
    {
        Position = new Vector2(1124, rng.RandiRange(65, 585));
        isMooving = false;
        Task.Delay(movementDelaySecs * 1000).ContinueWith(_ =>
        {
            StartMoving();
        });
    }

    private void StartMoving()
    {
        isMooving = true;
    }


    public override void _Process(float delta)
    {
        if (isMooving) 
            Position += new Vector2(boxMovementSpeed * delta, 0);
    }
}
