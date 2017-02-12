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
		private Snakeplayer2 player2;
		private Texture2D background;
		private Terrain blocks;
		private Terrain blocks2;
		private Terrain blocks3;
		private Terrain blocks4;
		private Song Background;
		private SpriteFont font;
		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsFixedTimeStep = true;
			TargetElapsedTime = TimeSpan.FromMilliseconds(30);
			parameters = new PresentationParameters();
			graphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.Reach, parameters);
			graphics.PreferredBackBufferWidth = 1024;
			graphics.PreferredBackBufferHeight = 768;
			graphics.ApplyChanges();
		}

		protected override void Initialize()
		{
			player1 = new Snakeplayer(new Vector2(100,300),Content);
			player2 = new Snakeplayer2(new Vector2 (800,300),Content);
			player1.enemy = player2.destinationRectangle;
			Vector2 [] izquierda;
			izquierda = new Vector2[10];
			int a = 0;
			for (int i = 0; i < 10; i++)
			{
				izquierda[i] = new Vector2(-64,a);
				a += 128;
			}
			blocks = new Terrain(izquierda,Content,"Sprites/Tile (6)");
			////////////
			Vector2[] derecha;
			derecha = new Vector2[10];
			int b = 0;
			for (int i = 0; i < 10; i++)
			{
				derecha[i] = new Vector2(960, b);
				b += 128;
			}
			blocks2 = new Terrain(derecha, Content, "Sprites/Tile (4)");
			/////////////
			Vector2[] abajo;
			abajo = new Vector2[10];
			int c = 0;
			for (int i = 0; i < 10; i++)
			{
				abajo[i] = new Vector2(c,656);
				c += 128;
			}
			blocks3 = new Terrain(abajo, Content, "Sprites/Tile (2)");
			/////////////
			Vector2[] arriba;
			arriba = new Vector2[10];
			int d = 0;
			for (int i = 0; i < 10; i++)
			{
				arriba[i] = new Vector2(d, -64);
				d += 128;
			}
			blocks4 = new Terrain(arriba, Content, "Sprites/Tile (9)");
			base.Initialize();

		}

		protected override void LoadContent()
		{
			
			spriteBatch = new SpriteBatch(GraphicsDevice);
			Background = Content.Load<Song>("soundeffects/C418 - Minecraft (Volumes Alpha & Beta) (2011 - 2013) {320}/Alpha/12. Dry Hands");
			MediaPlayer.Play(Background); 
			MediaPlayer.IsRepeating = true;
			background = Content.Load<Texture2D>("Sprites/BG");
			font = Content.Load<SpriteFont>("font1/hola");
		}

		protected override void Update(GameTime gameTime)
		{
			#if !__IOS__ && !__TVOS__
				if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			#endif
			if(player1.life >0  && player2.life>0)
			{
					player1.updatelogic(gameTime, new Rectangle(0,656,1280,64));
					player2.updatelogic(gameTime, new Rectangle(0, 656, 1280, 64));
					player2.shoot(Keys.Space);
					player1.shoot(Keys.RightControl);
				try
				{
					player2.alive(player1.bullets());		
				}
				catch (Exception ex)
				{

				}
				try
				{
					player1.alive(player2.bullets());

				}
				catch (Exception ex)
				{

				}
			}
			else
			{
				//WEY QUE VERGA HACES AQUI NO MAMES				
			}

				
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			
			graphics.GraphicsDevice.Clear(Color.Black);
			spriteBatch.Begin();
			spriteBatch.Draw(background, new Rectangle(0, 0, graphicsDevice.DisplayMode.Width, graphicsDevice.DisplayMode.Height), Color.White);
			blocks.drawframe(spriteBatch);
			blocks2.drawframe(spriteBatch);
			blocks3.drawframe(spriteBatch);
			blocks4.drawframe(spriteBatch);
			player1.draw(spriteBatch);
			player2.draw(spriteBatch);
			spriteBatch.DrawString(font,"Personaje 1: "+ player1.life, new Vector2(100,100),Color.White);
			spriteBatch.DrawString(font,"Personaje 2: "+ player2.life, new Vector2(700,100),Color.Black);
		
			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
