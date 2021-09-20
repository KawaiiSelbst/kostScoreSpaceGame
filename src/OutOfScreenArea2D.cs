using Godot;
using System;

public class OutOfScreenArea2D : Area2D
{
    public override void _Ready()
    {
    }
    public void _on_Area2D_Entered(Area2D EnteredArea)
    {
        EnteredArea.Call("OutOfScreen");
    }
    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
