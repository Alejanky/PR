using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.ComponentModel;
namespace pepethegame
{
	public class Snakeplayer2
	{
		public Rectangle enemy { get; set; }
		public int life;
		private int currentFrame;
		private int totalFrames;
		public Vector2 Position;
		public Vector2 Veloctiy;
		public Texture2D idle;
		public Texture2D run;
		public Texture2D shot;
		public Texture2D jump;
		public Texture2D body;
		public int Rows;


		public bool permiso;
		public Bullets balas;

		public Texture2D temp;
		public int Columns;
		public KeyboardState oldState;
		public KeyboardState newState;
		public Rectangle destinationRectangle;
		public int state;
		public Snakeplayer2(Vector2 x, ContentManager y)
		{
			life = 70;
			Position = x;
			idle = y.Load<Texture2D>("Sprites/idle2");
			run = y.Load<Texture2D>("Sprites/Run");
			shot = y.Load<Texture2D>("Sprites/shot");
			jump = y.Load<Texture2D>("Sprites/Jump2");
			temp = y.Load<Texture2D>("Sprites/bullet2");
			currentFrame = 0;
			Rows = 3;
			Columns = 3;
			totalFrames = 9;
			Veloctiy = new Vector2(0, 0.5939f);

		}
		private int Move()
		{
			oldState = Keyboard.GetState();
			if (oldState.IsKeyDown(Keys.W))   // hacer algo con el up stroke 
			{
				if (oldState.IsKeyDown(Keys.A))
				{
					body = jump;
					totalFrames = 9;
					return 5;
				}
				else
				{
					if (oldState.IsKeyDown(Keys.D))
					{
						body = jump;
						totalFrames = 9;
						return 6;
					}
					else
					{
						totalFrames = 9;
						body = jump;
						return 0;
					}
				}

			}

			if (oldState.IsKeyDown(Keys.S))   // probablemente no hacer cambiio 
			{
				if (oldState.IsKeyDown(Keys.A))
				{
					totalFrames = 9;
					body = idle;
					return 7;
				}
				else
				{
					if (oldState.IsKeyDown(Keys.D))
					{
						totalFrames = 9;
						body = idle;
						return 8;
					}
					else
					{
						totalFrames = 9;
						body = idle;
						return 4;
					}
				}
			}
			if (oldState.IsKeyDown(Keys.A))
			{
				totalFrames = 8;
				body = run;
				return 2;
			}
			if (oldState.IsKeyDown(Keys.D))
			{
				body = run;
				totalFrames = 8;
				return 3;
			}
			else
			{
				totalFrames = 9;
				body = idle;
				return 4;
			}
		}



		public void shoot(Keys a)
		{
			if (Keyboard.GetState().IsKeyDown(a) && permiso == false)
			{
				balas = new Bullets(Position);
				balas.body = temp;
				permiso = true;
			}
		}

		public void updatelogic(GameTime gametime, Rectangle X)
		{

			int a = this.Move();
			this.updatevector(a, gametime, X);
			if (permiso == true)
			{
				// talves la a me ayude, talves no
				permiso = this.balas.updatelogical(enemy, 2);
			}

		}
		public void draw(SpriteBatch x)
		{
			this.getdraw(x);
			if (permiso == true)
			{
				this.balas.draw(x);
			}
		}

		private void Updateframe()
		{
			currentFrame++;

			if (currentFrame == totalFrames || currentFrame > totalFrames)
			{
				currentFrame = 0;
			}
		}

		public void getdraw(SpriteBatch a)
		{
			int width = body.Width / Columns;
			int height = body.Height / Rows;
			int row = (int)((float)currentFrame / (float)Columns);
			int column = currentFrame % Columns;
			Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
			destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width / 4, height / 4);

			a.Draw(body, destinationRectangle, sourceRectangle, Color.Black);
			this.Updateframe();
		}

		public void updatevector(int a, GameTime w, Rectangle x)
		{
			newState = Keyboard.GetState();

			switch (a)
			{
				case 0:
					{
						if (Position.Y > 64)
						{ Position.Y += -(0.6939f * w.ElapsedGameTime.Milliseconds); }
						else { break; }


					}
					break;
				case 2:
					{
						if (Position.X > 64)
						{
							Position.X -= 0.5939f * w.ElapsedGameTime.Milliseconds;
							if (this.hitcollision(x, w, a))
							{
								Position += Veloctiy * w.ElapsedGameTime.Milliseconds;
							}
						}
						else
						{
							if (this.hitcollision(x, w, a))
							{
								Position += Veloctiy * w.ElapsedGameTime.Milliseconds;
							}
						}
					}
					break;
				case 3:
					{
						if (Position.X < 900)
						{
							Position.X += 0.5939f * w.ElapsedGameTime.Milliseconds;
							if (this.hitcollision(x, w, a))
							{
								Position += Veloctiy * w.ElapsedGameTime.Milliseconds;
							}
						}
						else
						{
							if (this.hitcollision(x, w, a))
							{
								Position += Veloctiy * w.ElapsedGameTime.Milliseconds;
							}
						}
					}
					break;
				case 4:
					{
						if (newState.IsKeyUp(Keys.Up) && this.hitcollision(x, w, a))
						{
							Position += 2*(Veloctiy * w.ElapsedGameTime.Milliseconds);
						}
						else
						{
							break;
						}

					}
					break;
				case 5:
					{
						if (Position.Y > 64)
						{
							Position += -(Veloctiy * w.ElapsedGameTime.Milliseconds);
							if (Position.X > 64)
							{
								Position.X -= 0.5939f * w.ElapsedGameTime.Milliseconds;
							}

						}

						else
						{
							if (Position.X > 64)
							{
								Position.X -= 0.5939f * w.ElapsedGameTime.Milliseconds;
							}
						}
						{

						}
					}
					break;
				case 6:
					{
						if (Position.Y > 64)
						{
							Position += -(Veloctiy * w.ElapsedGameTime.Milliseconds);
							if (Position.X < 900)
							{
								Position.X += 0.5939f * w.ElapsedGameTime.Milliseconds;
							}

						}

						else
						{
							if (Position.X < 900)
							{
								Position.X += 0.5939f * w.ElapsedGameTime.Milliseconds;
							}
						}
						{

						}
					}
					break;
				case 7:
					{
						if (this.hitcollision(x, w, a))
						{
							Position += Veloctiy * w.ElapsedGameTime.Milliseconds;
							if (Position.X > 64)
							{
								Position.X -= 0.5939f * w.ElapsedGameTime.Milliseconds;
							}
						}
						else
						{
							if (Position.X > 64)
							{
								Position.X -= 0.5939f * w.ElapsedGameTime.Milliseconds;
							}

						}
					}
					break;
				case 8:
					{
						if (this.hitcollision(x, w, a))
						{
							Position += Veloctiy * w.ElapsedGameTime.Milliseconds;
							if (Position.X < 900)
							{
								Position.X += 0.5939f * w.ElapsedGameTime.Milliseconds;
							}
						}
						else
						{
							if (Position.X < 900)
							{
								Position.X += 0.5939f * w.ElapsedGameTime.Milliseconds;
							}

						}
					}
					break;
			}


		}// fin de update vector



		public Rectangle bullets()
		{
			return balas.rectangleposition;
		}
		public void alive(Rectangle x)
		{
			if ((destinationRectangle.Intersects(x)))
			{
				life--;
			}
		}













		public bool hitcollision(Rectangle X, GameTime w, int a)
		{
			Rectangle copia = destinationRectangle;
			switch (a)
			{
				case 0:
					{
						copia.Y += Convert.ToInt32(0.5939f * w.ElapsedGameTime.Milliseconds);
					}
					break;
				case 2:
					{
						copia.X -= Convert.ToInt32(0.5939f * w.ElapsedGameTime.Milliseconds);
						copia.Y += Convert.ToInt32(0.5939f * w.ElapsedGameTime.Milliseconds);
					}
					break;
				case 3:
					{
						copia.X += Convert.ToInt32(0.5939f * w.ElapsedGameTime.Milliseconds);
						copia.Y += Convert.ToInt32(0.5939f * w.ElapsedGameTime.Milliseconds);
					}
					break;
				case 4:
					{
						if (newState.IsKeyUp(Keys.Up))
						{
							copia.Y += Convert.ToInt32(0.5939f * w.ElapsedGameTime.Milliseconds);
						}
						else
						{
							break;
						}

					}
					break;
				case 5:
					{
						copia.X -= Convert.ToInt32(0.5939f * w.ElapsedGameTime.Milliseconds);
						copia.Y += Convert.ToInt32(0.5939f * w.ElapsedGameTime.Milliseconds);
					}
					break;
				case 6:
					{
						copia.X += Convert.ToInt32(0.5939f * w.ElapsedGameTime.Milliseconds);
						copia.Y -= Convert.ToInt32(0.5939f * w.ElapsedGameTime.Milliseconds);
					}
					break;
				case 7:
					{
						copia.X -= Convert.ToInt32(0.5939f * w.ElapsedGameTime.Milliseconds);
						copia.Y += Convert.ToInt32(0.5939f * w.ElapsedGameTime.Milliseconds);
					}
					break;
				case 8:
					{
						copia.X += Convert.ToInt32(0.5939f * w.ElapsedGameTime.Milliseconds);
						copia.Y += Convert.ToInt32(0.5939f * w.ElapsedGameTime.Milliseconds);
					}
					break;
			}
			bool z = copia.Intersects(X);
			return !z;
		}

		// fala
	}
}//if (Position.X< 1152 && Position.X> 64 && Position.Y > 64)
