using Godot;
namespace TemporalIT.Scripts.Credits;

public partial class CreditsScene : Control
{
	private VBoxContainer _vBoxContainer;
	private const float Speed = 6f;
	private Vector2I _screenSize;
	private AnimatedSprite2D _animateSprite;
	private RichTextLabel _label;
	private TextureRect _textureRect;
	private CenterContainer _centerContainer;
	private PanelContainer _panelContainer;
	private int _index;
	private CharacterBody2D _characterBody2D;
	private AnimationPlayer _animationLabel;

	private static Dictionary<string, string>_uniqueTexts1 = LanguageManager.getUniqueTexts("Scripts/Credits/Texts/unique_texts.json");

	private readonly string[][] _text = 
	{
		new[]
		{
			"[font_size=70][center]" + _uniqueTexts1["ProgrammingTeam"] +"\n",
			"[font_size=40]Alexandre Billonnet\n",
			"Lucas Theodore\n",
			"Matias Deveze\n",
			"William Lefebvre\n",
			"Rémi Lhuissier"
		},
		new[]
		{
			"[center][font_size=70]" + _uniqueTexts1["VoiceActors"] +"\n",
			"[font_size=40]Logan Ferreira\n",
			"Sofia Aylal\n",
			"Matys Deschamps"
		},
		new []
		{
			"[center][font_size=70]TemporalIT\n",
			"[font_size=40]" + _uniqueTexts1["ThanksForPlaying"]
		}
	};
	
	public override void _Ready()
	{
		base._Ready();
		_centerContainer = GetNode<CenterContainer>("CenterContainer");
		_panelContainer = _centerContainer.GetNode<PanelContainer>("PanelContainer");
		_vBoxContainer = _panelContainer.GetNode<VBoxContainer>("VBoxContainer");
		_characterBody2D = GetNode<CharacterBody2D>("Player");
		_screenSize = DisplayServer.WindowGetSize();
		_animateSprite = _characterBody2D.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_label = _vBoxContainer.GetNode<RichTextLabel>("RichTextLabel");
		_textureRect = _vBoxContainer.GetNode<TextureRect>("TextureRect");
		_animationLabel = _label.GetNode<AnimationPlayer>("AnimationPlayer");
		ResetPlayerResetPosition();
	}

	public override void _PhysicsProcess(double d)
	{
		var velocity = new Vector2
		{
			X = Speed
		};
		_animateSprite.Play("moveRight");
		_characterBody2D.MoveAndCollide(velocity);
		if (_characterBody2D.Position.X > _screenSize.X * 1.05)
		{
			ResetPlayerResetPosition();
		}
	}

	private void ResetPlayerResetPosition()
	{
		if (_index == 3)
		{
			GetTree().ChangeSceneToFile("res://TitleScreen/TitleScreen.tscn");
			return;
		}
		ReloadLabel(_index);
		_index += 1;
		_characterBody2D.Position = new Vector2((float)Math.Round(_screenSize.X * -0.05), (int)Math.Round(_screenSize.Y * 0.95));
	}
	
	private void ReloadLabel(int index)
	{
		_label.Clear();
		foreach (var j in _text[index])
		{
			_label.AppendText(j);
			if (index is not 0 and not 1)
			{
				_textureRect.Show();
			}
		}
		_animationLabel.Play("reset");
	}
}
