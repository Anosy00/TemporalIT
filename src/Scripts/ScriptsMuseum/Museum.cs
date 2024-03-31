using Godot;

namespace TemporalIT.Scripts.ScriptsMuseum;

public partial class Museum : TileMap
{
	private String language;
	private DialogBox.DialogBox _dialogBox;
	private Godot.Timer _timer;
	private int _nbTimer;
	private AudioStreamPlayer _narrator;
	private AudioStreamPlayer _music;



	private List<Sentence> _dialog1 = LanguageManager.GetSequentialSentences("Museum/Texts/DialoguesMuseum.json");
	private Dictionary<string, string> _uniqueTexts1 = LanguageManager.getUniqueTexts("Museum/Texts/unique_textsMuseum.json");
	
	public void ForwardVoiceDialog(float temps)
	{
		if (_narrator != null)
		{
			//_narrator.Stop();
			_narrator.Seek(temps);
			//_narrator.Play();
			
			//GD.Print("time= "+temps);
		}
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_dialogBox = new DialogBox.DialogBox(GetNode<Sprite2D>("Player/DialogBox"),
			GetNode<Label>("Player/DialogBox/LabelText2"),
			GetNode<Label>("Player/DialogBox/LabelName"),
			GetNode<AnimationPlayer>("Player/DialogBox/AnimationPlayer"));
		_dialogBox.disable();
		_narrator = GetNode<AudioStreamPlayer>("Narrator");
		_music = GetNode<AudioStreamPlayer>("Music");
		_timer = GetNode<Godot.Timer>("Timer");

		GetNode<Label>("InteractiveZoneOfThePunshedCard/TheDialogBox/bubble/LabelText").Text = _uniqueTexts1["PunchedCard"];
		GetNode<Label>("RigidBody2D_TI99/TheDialogBox/bubble/LabelText").Text = _uniqueTexts1["TI994"];
		GetNode<Label>("RigidBody2D_Applemac/TheDialogBox/bubble/LabelText").Text = _uniqueTexts1["Macintosh128k"];
		GetNode<Label>("RigidBody2D_IBM5150/TheDialogBox/bubble/LabelText").Text = _uniqueTexts1["IBM5150"];
		GetNode<Label>("RigidBody2D_PC/TheDialogBox/bubble/LabelText").Text = _uniqueTexts1["PowerBook5300"];
		GetNode<Label>("RigidBody2D_PET2001/TheDialogBox/bubble/LabelText").Text = _uniqueTexts1["PET2001"];

		/*GD.Print(""+_dialog1[0]._name);
		GD.Print(""+_dialog1[0]._text);
		GD.Print(""+_dialogBox, _timer);*/
		
		SetIndex(0);
		//GD.Print("Le ZIndex de la scene est "+getZIndex());
		GD.Print(_dialog1[0]._speaker);	
		DisplayDialogBox(_dialog1[0]._speaker, _dialog1[0]._text, _dialogBox,_dialog1[0]._time);
		_narrator.Play();
		_timer.Start(6);
	}
	
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("closeDialog") && _dialogBox.isVisible())
		{
			_timer.Stop();
			Input.ActionRelease("closeDialog");
			_timer.EmitSignal("timeout");
		}
	}
	
	
	
	
	public void DisplayDialogBox(string name, string text, DialogBox.DialogBox dialogBox,float time)
	{
		dialogBox.setTextOfLabel(name, text);
		dialogBox.available("display_text");
		ForwardVoiceDialog(time);
	}
	private void _on_timer_timeout()
	{
		_nbTimer ++;
		if (_nbTimer == _dialog1.Count ) {
			_timer.Stop();
			_dialogBox.disable();
			_narrator.Stop();
			_music.Play();
		} else {
			DisplayDialogBox(_dialog1[_nbTimer]._speaker, _dialog1[_nbTimer]._text, _dialogBox,_dialog1[_nbTimer]._time);
			_timer.Start(6);
		}
		
	}
	
	public static CollisionShape2D GetCollisionShapePlayer(Node rootNode, string path)
	{
		return rootNode.GetNode<CollisionShape2D>(path);
	}
	public static CharacterBody2D GetCharacterBody2D(Node rootNode, string path)
	{
		return rootNode.GetNode<CharacterBody2D>(path);
	}
	private int GetIndex()
	{
		return ZIndex;
	}
	private void SetIndex(int number)
	{
		ZIndex = number;
	}
	
	
}
