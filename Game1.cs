using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace pepethegame
{
	
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		GraphicsDevice graphicsDevice;
		SpriteBatch spriteBatch;
		PresentationParameters parameters;

		private Snakeplayer player1;
		private Snakeplayer player2;
		private Texture2D background;
		private Song Background;
		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsFixedTimeStep = true;
			TargetElapsedTime = TimeSpan.FromMilliseconds(30);
			parameters = new PresentationParameters();
			graphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.Reach, parameters);
			graphics.PreferredBackBufferWidth = graphicsDevice.DisplayMode.Width;
			graphics.PreferredBackBufferHeight = graphicsDevice.DisplayMode.Height;
			graphics.ApplyChanges();
		}

		protected override void Initialize()
		{
			player1 = new Snakeplayer(new Vector2(0,0),Content,"Sprites/walking2");
			player2 = new Snakeplayer(new Vector2 (110,110),Content,"Sprites/walking2");
			base.Initialize();
		}

		protected override void LoadContent()
		{
			
			spriteBatch = new SpriteBatch(GraphicsDevice);
			Background = Content.Load<Song>("soundeffects/C418 - Minecraft (Volumes Alpha & Beta) (2011 - 2013) {320}/Alpha/12. Dry Hands");
			MediaPlayer.Play(Background); 
			MediaPlayer.IsRepeating = true;
			background = Content.Load<Texture2D>("Sprites/sculptor-galaxy134-1600");

		}

		protected override void Update(GameTime gameTime)
		{
			#if !__IOS__ && !__TVOS__
				if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
#endif
			if(player1.life)
			{
				player1.updatelogic(graphicsDevice.DisplayMode.Width, graphicsDevice.DisplayMode.Height,gameTime);
				player2.updatelogic(graphicsDevice.DisplayMode.Width, graphicsDevice.DisplayMode.Height, gameTime);
			}
			else
			{
				Exit();
			}


			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			
			graphics.GraphicsDevice.Clear(Color.Black);
			float frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
			Console.WriteLine(frameRate);
			spriteBatch.Begin();
			spriteBatch.Draw(background, new Rectangle(0, 0, graphicsDevice.DisplayMode.Width, graphicsDevice.DisplayMode.Height), Color.White);
			player1.draw(spriteBatch);
			player2.draw(spriteBatch);
			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
