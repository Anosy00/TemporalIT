using Godot;
namespace TemporalIT.Scripts.OptionMenu;

public partial class VolumeSlideBar : HSlider
{
	private int _masterBus = AudioServer.GetBusIndex("Master");
	
	public override void _Ready()
	{
		base._Ready();
		Disconnect("value_changed", new Callable(this, "_on_value_changed"));
		Connect("value_changed", new Callable(this, "_on_value_changed"));
		Value = 0.5f;
	}
	
	private static float _linear_to_db(float value)
	{
		return 20 * Mathf.Log(value);
	}
	
	private void _on_value_changed(float value)
	{
		AudioServer.SetBusVolumeDb(_masterBus, _linear_to_db(value));
	}
}
