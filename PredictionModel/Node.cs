using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PredictionModel
{
    public class Node : INode
    {
        private INode _rightNode;
        private INode _leftNode;
        private bool _isLeaf;
        private int _level;
        private bool _isRightNodeOpen;
        private int _ballCount;

        public INode RightNode
        {
            get { return _rightNode; }
        }
        public INode LeftNode
        {
            get { return _leftNode; }
        }
        public bool IsLeaf
        {
            get { return _isLeaf; }
        }
        public int Level
        {
            get { return _level; }
        }

        public int BallCount
        {
            get { return _ballCount; }
        }

        public Node(int level)
        {
            _level = level;

            //randomly set the open node to left or right
            Random random = new Random();
            _isRightNodeOpen = random.NextDouble() > 0.5;
        }

        public void BuildModel()
        {
            if(_level > 0)
            {
                //initialise the left and right node
                _rightNode = new Node(_level - 1);
                _rightNode.BuildModel();
                _leftNode = new Node(_level - 1);
                _leftNode.BuildModel();
            }
            else
            {
                //Leaf Node => set to true
                _isLeaf = true;
            }
        }

        

        public void PushBall()
        {
            if(_isLeaf)
            {
                //Leaf Node => Cannot push the ball => hold the ball and increment count
                _ballCount++;
            }
            else
            {
                if(_isRightNodeOpen)
                {
                    //Right node is open => Push ball in the right node and update the gate to left
                    _rightNode.PushBall();
                    _isRightNodeOpen = false;
                }
                else
                {
                    //Left node is open => Push ball in the left node and update the gate to right
                    _leftNode.PushBall();
                    _isRightNodeOpen = true;
                }
            }
        }

        public IList<INode> GetLeafNodes()
        {
            List<INode> leafNodes = new List<INode>();
            if (IsLeaf)
            {
                //Leaf Node => Display count of balls held by leaf node
                Console.Write(_ballCount);
                leafNodes.Add(this);
            }
            else
            {
                //traverse to the right and left to get all the leaf nodes
                leafNodes.AddRange(_rightNode.GetLeafNodes());
                leafNodes.AddRange(_leftNode.GetLeafNodes());
            }
            return leafNodes;
        }
    }
}
