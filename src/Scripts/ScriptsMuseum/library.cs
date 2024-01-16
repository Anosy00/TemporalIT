using Godot;
using System;

public partial class library : Node
{
	private CollisionShape2D collisionShape;
	private Vector2 collisionShapePosition;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
		if (collisionShape != null)
		{
			// Obtenez les coordonnées globales de l'élément
			collisionShapePosition = collisionShape.GlobalPosition;

			// Affichez les coordonnées
			GD.Print("Coordonnées de l'élément : (", getX(),", ", getY(),")");
		}
		else
		{
			GD.Print("L'élément n'a pas été correctement référencé.");
		}
		getPlayer();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public float getY()
	{
		return collisionShapePosition[1]-323;
	}
	public float getX()
	{
		return collisionShapePosition[0]-323;
	}
	
	public void getPlayer(){
		GD.Print(Museum.getCollisionShapePlayer(this.GetParent(),"Player/CollisionShape2D"));
	}
	//Museum.getCollisionShapePlayer(GetNode<TileMap>("Museum"),"Player/CollisionShape2D")
}
