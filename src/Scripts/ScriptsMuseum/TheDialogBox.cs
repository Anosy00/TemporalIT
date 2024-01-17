using Godot;

namespace TemporalIT.Scripts.ScriptsMuseum;

public partial class TheDialogBox : Area2D
{
	public Sprite2D _Interaction;
	
	//Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_Interaction =  GetNode<Sprite2D>("bubble");
		_Interaction.Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void _on_interactive_zone_of_the_computer_body_entered(CharacterBody2D body)
	{
		// Replace with function body.
		_Interaction.Visible = true;
	}

	public void _on_interactive_zone_of_the_computer_body_exited(CharacterBody2D body)
	{
		// Replace with function body.
		_Interaction.Visible = false;
	}
}