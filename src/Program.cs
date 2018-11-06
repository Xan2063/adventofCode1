using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;

namespace _1
{

    public class Player{
        public Vector2D direction = new Vector2D(0,1), position;
        public HashSet<Vector2D> alreadyUsedPositions = new HashSet<Vector2D>();

        public Player()
        {
            alreadyUsedPositions.Add(position);
        }

        public void ExecuteMove((int length, Angle angle) movement)
        {
            direction = direction.Rotate(movement.angle );
            for (int i = 0; i < movement.length; i++)
            {
                position += direction;
                if (alreadyUsedPositions.Contains(position))
                {
                    Console.WriteLine(position);

                }
                alreadyUsedPositions.Add(position);
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var angle =  Angle.FromRadians(Math.PI/2);
            var player = new Player();
           
            var movements = File.ReadAllText(@"input.txt").Split(',').Select(text => Decompose(text.Trim()));

            foreach (var movement in movements)
            {
                player.ExecuteMove(movement);

            }



            Console.WriteLine("Hello World!");
        }

        

        public static (int length, Angle angle) Decompose(string movement){
            string direction = movement.Substring(0, 1);
            int length = int.Parse(movement.Substring(1));
            var directionChange = direction == "L" ? Angle.FromDegrees(90) : Angle.FromDegrees(-90);
            return (length, directionChange);

            

        }

        public static DenseMatrix createTurnLeft(){
            return new DenseMatrix(2,2,new double[]{0,1,-1,0});
        }
        public static DenseMatrix createTurnRight(){
            return new DenseMatrix(2,2,new double[]{0,-1,1,0});
        }
    }
}
