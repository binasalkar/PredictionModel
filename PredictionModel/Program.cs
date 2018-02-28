using System;
using System.Collections.Generic;

namespace PredictionModel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the Depth: ");
            var depthInput = Console.ReadLine();
            int depth = 0;
            var success = Int32.TryParse(depthInput, out depth);
            if(success == false || depth <= 0)
            {
                Console.WriteLine("Invalid Entry");
                Console.ReadKey();
                return;
            }
            INode rootNode = new Node(depth);
            rootNode.BuildModel();

            double numberOfBalls = Math.Pow(2, depth) - 1;
            Console.WriteLine($"Number of Container lanes: { numberOfBalls + 1 }");
            Console.WriteLine($"Number of Balls: { numberOfBalls }");

            for (double index = 0; index<numberOfBalls; index++)
            {
                rootNode.PushBall();
            }
            Console.Write("Container lanes with number of balls they hold: ");
            var leafNodeCollection = rootNode.GetLeafNodes();
            Console.WriteLine();
            Console.Write("Container lane number with empty balls: ");
            for (int index = 0; index < leafNodeCollection.Count; index ++ )
            {
                var leafNode = leafNodeCollection[index];
                if(leafNode.BallCount == 0)
                {
                    Console.Write($"{index+1} ");
                }
            }
            Console.ReadKey();
        }
    }
}
