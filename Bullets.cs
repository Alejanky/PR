using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
namespace pepethegame
{
	public class Bullets
	{

		public Texture2D	body;
		public Rectangle rectangleposition;
		public Vector2 spriteposition;
		public bool sigue;
		public Bullets(Vector2 x)
		{
			spriteposition = x + new Vector2(50,50);
			sigue = true;
		}

		public bool updatelogical(Rectangle x,int a)
		{
			if(!(spriteposition.X>1280||spriteposition.X <0))
			{
				if (a==1){
					spriteposition += new Vector2(39f, 0);
				}
				else
				{
					spriteposition -= new Vector2(39f, 0);
				}

			}
			else
			{
				return false;
			}

			return true;
		}
		public void draw(SpriteBatch a){
			Point c = new Point(body.Width/2, body.Height/2);
			Point b = new Point(Convert.ToInt32(spriteposition.X), Convert.ToInt32(spriteposition.Y));
			rectangleposition = new Rectangle(b, c);
			 a.Draw(body,rectangleposition,Color.White);
		}

	}
}
