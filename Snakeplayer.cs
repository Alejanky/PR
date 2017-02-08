	using System;
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Content;
	using Microsoft.Xna.Framework.Input;
	using Microsoft.Xna.Framework.Graphics;
	namespace pepethegame
	{
		public class Snakeplayer
		{
			public Boolean life;
			private int currentFrame;
			private int totalFrames;
			public Vector2 Position;
			public Vector2 Veloctiy;
			public Texture2D body;
			public int Rows;
			public int Columns;
			public KeyboardState oldState;
			public KeyboardState newState;
			public Snakeplayer(Vector2 x, ContentManager y,String a)
			{
				life = true;
				Position = x;
				body = y.Load<Texture2D>(a);// a =  ----> "Sprites/walking2"
				currentFrame = 0;
				Rows = 1;
				Columns = 6;
				totalFrames = 6;
				Veloctiy = new Vector2(0, 0.2939f) ;
			} 
			private int Move()
			{
				oldState = Keyboard.GetState();
				if (oldState.IsKeyDown(Keys.Up))
				{
					if(oldState.IsKeyDown(Keys.Left))
					{
					return 5;
					}
					else
					{
						if(oldState.IsKeyDown(Keys.Right))
						{
							return 6;
						}
						else
						{
							return 0;
						}
					}
					
				}

				if (oldState.IsKeyDown(Keys.Down))
				{
					if(oldState.IsKeyDown(Keys.Left))
					{
					return 7;
					}
					else
					{
						if(oldState.IsKeyDown(Keys.Right))
						{
							return 8;
						}
						else
						{
							return 4;
						}
					}
				}
				if (oldState.IsKeyDown(Keys.Left))
				{
					return 2;
				}
				if (oldState.IsKeyDown(Keys.Right))
				{
				return 3;
				}
				else return 4;
			}

			public void updatelogic(int x ,int y, GameTime gametime)
			{
			
				this.updatevector(this.Move(),gametime);
				
			}

			public void draw(SpriteBatch x)
			{
				this.getdraw(x);
			}

			private void Updateframe()
			{
				currentFrame++;
				if (currentFrame == totalFrames)
				{
					currentFrame = 0;
				}
			}

			public void getdraw(SpriteBatch a )
			{
				int width = body.Width / Columns;
				int height = body.Height / Rows;
				int row = (int)((float)currentFrame / (float)Columns);
				int column = currentFrame % Columns;

				Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
				Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width, height);
				a.Draw(body, destinationRectangle, sourceRectangle, Color.White);
				this.Updateframe();
			}

			public void updatevector(int a, GameTime w/*y algo mas*/)
			{
				newState = Keyboard.GetState();
				switch (a)
				{
					case 0:
						{
							Position.Y += - (0.5939f* w.ElapsedGameTime.Milliseconds);
						}
						break;
					case 2:
						{
							Position.X -= 0.2939f* w.ElapsedGameTime.Milliseconds;
							Position += Veloctiy * w.ElapsedGameTime.Milliseconds;
						}
						break;
					case 3:
						{
							Position.X += 0.2939f* w.ElapsedGameTime.Milliseconds;
							Position += Veloctiy * w.ElapsedGameTime.Milliseconds;
						}
						break;
					case 4:
						{
						if (newState.IsKeyUp(Keys.Up)){
						Position += (Veloctiy * w.ElapsedGameTime.Milliseconds) ;	
						}else
						{
							break;
						}

						}
						break;
					case 5:
					{
							Position.X -= 0.2939f * w.ElapsedGameTime.Milliseconds;
							Position += -(Veloctiy * w.ElapsedGameTime.Milliseconds);
					}
						break;
					case 6:
					{
						Position.X += 0.2939f * w.ElapsedGameTime.Milliseconds;
						Position += -(Veloctiy * w.ElapsedGameTime.Milliseconds);
					}
						break;
					case 7:
					{
							Position.X -= 0.2939f * w.ElapsedGameTime.Milliseconds;
							Position += Veloctiy * w.ElapsedGameTime.Milliseconds;
					}
						break;
					case 8:
					{
						Position.X += 0.2939f * w.ElapsedGameTime.Milliseconds;
						Position += Veloctiy * w.ElapsedGameTime.Milliseconds;
					}
						break;
				}
			}


		// falata el hit detection y que eso se compruebe dentro del updatevector para no registrar el movimiento del vector

		}
	}