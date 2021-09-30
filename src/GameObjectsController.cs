using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Controlls box adding, stashing and placing
/// </summary>
public class GameObjectsController : Node2D
{
    //Random number generator
    [Export]
    public int NumberOfObstecleBoxes = 15;
    private Random _rng = new Random();
    private Vector2 _standbyPlace = new Vector2(2000, 2000);
    private PackedScene _obstacleBoxScene;

    List<ObstacleBox> _standbyBoxesList = new List<ObstacleBox>();

    bool pressed;

    public override void _Ready()
    {
        _obstacleBoxScene = GD.Load<PackedScene>("res://scenes/ObstacleBox.tscn");
        CreateStandbyBoxes(NumberOfObstecleBoxes);
    }

    public override void _Process(float delta)
    {
#if DEBUG
        if (Input.IsActionJustPressed("Test")) 
        {
            TryPlaceBoxFromStandbyList();
        }
#endif
    }

    public void AddObjectToStandbyList(Node2D ReceivedObject)
    {
        if (ReceivedObject is ObstacleBox)
        {
            AddBoxToStandbyList((ObstacleBox)ReceivedObject);
        }
    }

    private void AddBoxToStandbyList(ObstacleBox ReceivedObstacleBox)
    {
        _standbyBoxesList.Add((ObstacleBox)ReceivedObstacleBox);
        ReceivedObstacleBox.GlobalPosition = _standbyPlace;
        ReceivedObstacleBox.StopMoving();
#if DEBUG
        GD.Print("DEBUG: " + ReceivedObstacleBox + " [Name: " + ReceivedObstacleBox.Name + "] moved to StandbyList");
#endif
    }
    private void TryPlaceBoxFromStandbyList()
    {
        ObstacleBox tempObstacleBoxRef;
        if (_standbyBoxesList.Count() > 0)
        {
            tempObstacleBoxRef = _standbyBoxesList[0];
            _standbyBoxesList.RemoveAt(0);
            tempObstacleBoxRef.Position = new Vector2(1124, _rng.Next(65, 585));
            tempObstacleBoxRef.StartMoving();
#if DEBUG
            GD.Print("DEBUG: " + tempObstacleBoxRef + " [Name: " + tempObstacleBoxRef.Name + "] placed in game");
#endif
        }
    }
    private void CreateStandbyBoxes(int number)
    {
        ObstacleBox tempBoxRef = new ObstacleBox();
        for (int i = 0; i < number; i++)
        {
            tempBoxRef = (ObstacleBox)_obstacleBoxScene.Instance();
            AddChild(tempBoxRef);
            AddBoxToStandbyList(tempBoxRef);
        }
#if DEBUG
        foreach (ObstacleBox item in _standbyBoxesList)
        {
            GD.Print("DEBUG: " + item + " [Name: " + item.Name + "] [" + number + "] successfully created");
        }
#endif
    }
}
