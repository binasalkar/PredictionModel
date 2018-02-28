using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PredictionModel
{
    public interface INode
    {
        INode RightNode { get;  }

        INode LeftNode { get;  }

        bool IsLeaf { get;  }


        int BallCount { get; }

        void PushBall();

        void DisplayBallCount();

        void BuildModel();

        IList<INode> GetLeafNodes();
    }
}
