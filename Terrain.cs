using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
namespace pepethegame
{
	public class Terrain
	{
		public Texture2D terrain;
		public Vector2 [] position;
		public Rectangle[] boxes;
		private int currentFrame;
		private int totalFrames;
		public int Rows;
		public int Columns;
		public Terrain(Vector2 [] x, ContentManager y)
		{
			terrain = y.Load<Texture2D>("Sprites/sculptor-galaxy134-1600");
			currentFrame = 0;
			totalFrames =0;
			Rows =7;
			Columns =4;
		}

		public void updateframe()
		{
			
		}
		public void drawframe()
		{
			
		}
		public Vector2 hitdetected()
		{

			return new Vector2();
		}
	}
}
