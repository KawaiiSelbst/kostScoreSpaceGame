using Godot;
using System;
using System.Threading.Tasks;

public class ObstacleBox : Area2D
{
    [Export]
    private bool _isMooving = false;
    [Export]
    private int _boxMovementSpeed = -800;

    private GameObjectsController _gameObjectsControllerInstance;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _gameObjectsControllerInstance = GetParent<GameObjectsController>();
    }

    public void _on_ObstacleBox_area_entered(Area2D enteredArea)
    {
        if (enteredArea.Name == "OutOfScreenArea2D")
        {
            _gameObjectsControllerInstance.AddObjectToStandbyList(this);
#if DEBUG
            GD.Print("DEBUG: " + _gameObjectsControllerInstance + " [Name: " + _gameObjectsControllerInstance.Name + "] out of screen");
#endif
        }
    }

    public void StopMoving()
    {
        _isMooving = false;
    }
    public void StartMoving()
    {
        _isMooving = true;
    }


    public override void _Process(float delta)
    {
        if (_isMooving) 
            Position += new Vector2(_boxMovementSpeed * delta, 0);
    }
}
