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
		public int Rows;
		public int Columns;

		public Terrain(Vector2 [] x, ContentManager y, string a)
		{
			terrain = y.Load<Texture2D>(a);
			currentFrame = 0;
			Rows =1;
			Columns =1;
			position = x;
			boxes= new Rectangle [position.GetLength(0)] ;
		}

		public void drawframe(SpriteBatch a)
		{
			int width = terrain.Width / Columns;
			int height = terrain.Height / Rows;
			int row = (int)((float)currentFrame / (float)Columns);
			int column = currentFrame % Columns;
			int i;
			for (i =0; i < position.GetLength(0); i++)
			{
				Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
				boxes[i] = new Rectangle((int)position[i].X, (int)position[i].Y, width, height);
				a.Draw(terrain, boxes[i], sourceRectangle, Color.White);
			}
		}
		public Vector2 hitdetected()
		{

			return new Vector2();
		}

		public void updatelogic(int x, int y, GameTime gametime)
		{

			this.hitdetected();
		}

	}
}
