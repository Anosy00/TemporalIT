using Godot;
using System;
using TemporalIT;
using TemporalIT.JMJ_s_Room.Room.SaverManagement;
using TemporalIT.Morse_s_room.Rooms.Maze.Scripts.Player;

public partial class Saddler : Node2D
{
	private PlayerSaveManagerJMJ _playerSaveManager;
	private CharacterBody2D _characterBody2D;
	private static Sprite2D _objectifSaddler;
	private static Label _labelText;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_characterBody2D = GetNode<CharacterBody2D>("TileMap/Player");
		_playerSaveManager = new PlayerSaveManagerJMJ();
		_playerSaveManager.load();
		if (GlobalJMJ.firstEntryInSaddler)
		{
			_characterBody2D.Position = _playerSaveManager.launchingPosition();
			GlobalJMJ.firstEntryInSaddler = false;
		}
		else
		{
			_characterBody2D.Position = new Vector2(-34, -5);
		}

		_objectifSaddler = GetNode<Sprite2D>("../ObjectifSaddler");
		_labelText = GetNode<Label>("../ObjectifSaddler/LabelText");
		_labelText.AddThemeFontSizeOverride("font_size", 35);
		_objectifSaddler.Visible = false;
	}

	public override void _Process(double delta)
	{
		if (GlobalJMJ.objectifStringActive)
		{
			_labelText.Text = "Trouver du fil \n Indice : Date de décès dans le journal";
			_objectifSaddler.Visible = true;
		}
		
		else if (GlobalJMJ.objectifPlankActive)
		{
			_labelText.Text = "Récupérer les planches";
			_objectifSaddler.Visible = true;
		}
		else
		{
			_objectifSaddler.Visible = false;
		}
	}

	public void _on_tree_exited()
	{
		var playerPosition = _characterBody2D.GetPositionDelta();
		GD.Print(playerPosition.X + " " + playerPosition.Y);
		_playerSaveManager.save(playerPosition.X,playerPosition.Y);
	}
}
