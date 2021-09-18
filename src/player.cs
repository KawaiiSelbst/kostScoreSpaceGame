using Godot;
using System;

public class player : RigidBody2D
{
    int Up_Pressed, Down_Pressed, Right_Pressed, Left_Pressed;
    int Move_Speed = 20;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        Up_Pressed = -Convert.ToInt32(Input.IsActionPressed("ui_up"));
        Down_Pressed = Convert.ToInt32(Input.IsActionPressed("ui_down"));
        Right_Pressed = Convert.ToInt32(Input.IsActionPressed("ui_right"));
        Left_Pressed = -Convert.ToInt32(Input.IsActionPressed("ui_left"));
        ApplyImpulse(Vector2.Zero, new Vector2((Right_Pressed + Left_Pressed) * Move_Speed, (Up_Pressed + Down_Pressed) * Move_Speed));
        //Position += new Vector2((Right_Pressed + Left_Pressed) * Move_Speed, (Up_Pressed + Down_Pressed) * Move_Speed);
        //ApplyImpulse(Vector2.Zero, Vector2.Zero);
    }

    public override void _UnhandledInput(InputEvent @event) { 
         if (@event is InputEventKey eventKey)
            if (eventKey.Pressed && eventKey.Scancode == (int) KeyList.Escape) 
                GetTree().Quit();
     }
}
