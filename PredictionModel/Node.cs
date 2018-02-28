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

            //randomly set the open node
            Random random = new Random();
            _isRightNodeOpen = random.NextDouble() > 0.5;
        }

        public void BuildModel()
        {
            if(_level > 0)
            {
                _rightNode = new Node(_level - 1);
                _rightNode.BuildModel();
                _leftNode = new Node(_level - 1);
                _leftNode.BuildModel();
            }
            else
            {
                _isLeaf = true;
            }
        }

        public void DisplayBallCount()
        {
            throw new NotImplementedException();
        }

        public void PushBall()
        {
            if(_isLeaf)
            {
                _ballCount++;
            }
            else
            {
                if(_isRightNodeOpen)
                {
                    _rightNode.PushBall();
                    _isRightNodeOpen = false;
                }
                else
                {
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
                Console.Write(_ballCount);
                leafNodes.Add(this);
            }
            else
            {
                leafNodes.AddRange(_rightNode.GetLeafNodes());
                leafNodes.AddRange(_leftNode.GetLeafNodes());
            }
            return leafNodes;
        }
    }
}
