using System.Text.Json.Serialization;

public struct Sentence
{
	[JsonPropertyName("Speaker")]
	public readonly string _speaker;
	
	[JsonPropertyName("Text")]
	public readonly string _text;
	
	[JsonPropertyName("Time")]
	public readonly float _time;
	
	public Sentence(string speaker, string text,float time){
		_speaker = speaker;
		_text = text;
		_time = time;
		
	}
}
