using Godot;
// IMPORTANT: the name of the class MUST match the filename exactly.
// this is case sensitive!
public class MainMenu : Panel
{
    // string main_scene_pathe;
    PackedScene MainScenePath = GD.Load<PackedScene>("res://scenes/MainScene.tscn");

    public override void _Ready()
    {
        GetNode("Button").Connect("pressed", this, nameof(_OnButtonPressed));
        GetNode("Button2").Connect("pressed", this, nameof(_OnButton2Pressed));
        GetNode("Button3").Connect("pressed", this, nameof(_OnButton3Pressed));

    }

    public void _OnButtonPressed()
    {
        GetTree().ChangeScene("res://scenes/MainScene.tscn");
    }
    public void _OnButton2Pressed()
    {
        GetNode<Label>("Label2").Text = "open leaderboards";
    }
    public void _OnButton3Pressed()
    {
        GetTree().Quit();
        //GetNode<Label>("Label3").Text = "exit";
    }
}