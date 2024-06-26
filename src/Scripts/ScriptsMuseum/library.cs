using Godot;
using System;

public partial class library : Node
{
	private CollisionShape2D collisionShape;
	private Vector2 collisionShapePosition;
	private int zIndexLibrary;
	
	private CollisionShape2D player;
	private Vector2 playerPosition;
	private int zIndexPlayer;
	Sprite2D librarySprite2D;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		librarySprite2D = GetNode<Sprite2D>("Libraries");
		zIndexPlayer = getZIndexPlayer();
		zIndexLibrary = getZIndexLibrary();
		collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
		if (collisionShape != null)
		{
			// Obtenez les coordonnées globales de l'élément
			collisionShapePosition = collisionShape.GlobalPosition;

			// Affichez les coordonnées
			//GD.Print("Coordonnées de l'élément : (", getX(),", ", getY(),")");
		}
		else
		{
			GD.Print("L'élément n'a pas été correctement référencé.");
		}
		//GD.Print(getZIndexPlayer());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		plan_selection();
	}
	
	public float getY()
	{
		return collisionShapePosition[1]-323;
	}
	public float getX()
	{
		return collisionShapePosition[0]-323;
	}
	
	public CollisionShape2D getPlayer(){
		//GD.Print(Museum.getCollisionShapePlayer(this.GetParent(),"Player/CollisionShape2D"));
		return TemporalIT.Scripts.ScriptsMuseum.Museum.GetCollisionShapePlayer(this.GetParent(),"Player/CollisionShape2D");
	}
	
	private Vector2 posPlayer()
	{
		// GetNode<CollisionShape2D>("Player/CollisionShape2D");
		player = getPlayer();
		if (player != null)
		{
			// Obtenez les coordonnées globales de l'élément
			playerPosition = player.GlobalPosition;

			// Affichez les coordonnées
			//GD.Print("Coordonnées du joueur : (", playerPosition[0]-323,", ", playerPosition[1]-323,")");
			return playerPosition;
		}
		else
		{
			GD.Print("L'élément n'a pas été correctement référencé.");
			return new Vector2(-1f ,-1f);
			
		}
	}
	public float get_PosX_player()
	{
		Vector2 coordinate = posPlayer();
		return coordinate[0]-323;
	}
		
	public float get_PosY_player()
	{
		return posPlayer()[1]-323;
	}
	
	private void plan_selection()
	{
		if (get_PosY_player() > getY()){
			setZIndexLibrary(1);
			
		} else {
			setZIndexLibrary(3);
			
		}
	}
	private int getZIndexPlayer()
	{
		
		CharacterBody2D playerCharacterBody2D = TemporalIT.Scripts.ScriptsMuseum.Museum.GetCharacterBody2D(this.GetParent(),"Player");
		return playerCharacterBody2D.ZIndex;
	}
	
	private int getZIndexLibrary()
	{
		return librarySprite2D.ZIndex;
	}
	
	private void setZIndexLibrary(int number)
	{
		librarySprite2D.ZIndex = number;
	}
}
