using System;
using Microsoft.Xna.Framework;
namespace pepethegame
{
	public class Snakeplayer
	{
		//propiedades
		public Vector2 PL;
		private int[] Vec;
		private Nodes Head;
		private int total;
		//contructores
		public Snakeplayer()
		{
			Head = null;
			total = 0;
		}
		public Snakeplayer(int a, int b)
		{
			Vec = new int[2];
			Vec[0] = a;
			Vec[1] = b;
			Head = new Nodes();//falta hacer nodes
			total = 1;
		}
		//comportamientos
		public bool collision()
		{//checha si alguno de los nodos choco entre si o la pared;
			return false;
		}

		public void SetPosicion(int a, int b)
		{
			Vec[0] = a;
			Vec[1] = b;
		}
		public void DrawSnake()
		{
			// nose como pero tengo que dibujar con el spritebach y sus posiciones correspondientes
		}
		public bool moverU(/*nose que tenga que mandar*/)
		{
			//algo relacionado a las posiciones respecto a lo que mando
			// o hago que se haga el draw ahi o regreso las cordenadas o objeto para hacer draw en main
			return false;
		}

		public bool moverD(/*nose que tenga que mandar*/)
		{
			//algo relacionado a las posiciones respecto a lo que mando
			// o hago que se haga el draw ahi o regreso las cordenadas o objeto para hacer draw en main
			return false;
		}
		public bool moverL(/*nose que tenga que mandar*/)
		{
			//algo relacionado a las posiciones respecto a lo que mando
			// o hago que se haga el draw ahi o regreso las cordenadas o objeto para hacer draw en main
			return false;
		}
		public bool moverR(/*nose que tenga que mandar*/)
		{
			//algo relacionado a las posiciones respecto a lo que mando
			// o hago que se haga el draw ahi o regreso las cordenadas o objeto para hacer draw en main
			return false;
		}
	}
}
