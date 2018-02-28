using System;
using System.Collections.Generic;

namespace PredictionModel
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get the Depth from the user
            Console.Write("Enter the Depth: ");
            var depthInput = Console.ReadLine();
            int depth = 0;
            var success = Int32.TryParse(depthInput, out depth);
            if(success == false || depth <= 0)
            {
                //invalid entry => stop processing
                Console.WriteLine("Invalid Entry");
                Console.ReadKey();
                return;
            }

            //Build the model based on the depth
            INode rootNode = new Node(depth);
            rootNode.BuildModel();

            //Calculate the number of balls and containers using the depth
            double numberOfBalls = Math.Pow(2, depth) - 1;
            Console.WriteLine($"Number of Container lanes: { numberOfBalls + 1 }");
            Console.WriteLine($"Number of Balls: { numberOfBalls }");

            //Push each of the ball - one by one
            for (double index = 0; index<numberOfBalls; index++)
            {
                rootNode.PushBall();
            }

            //Get all the leaf nodes => also displays the count of the balls held by each leaf node
            Console.Write("Container lanes with number of balls they hold: ");
            var leafNodeCollection = rootNode.GetLeafNodes();
            Console.WriteLine();
            
            //Get the leaf nodes with no balls => display to user
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
