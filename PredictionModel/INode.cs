using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PredictionModel
{
    public interface INode
    {
        /// <summary>
        /// Holds teh Right Node
        /// </summary>
        INode RightNode { get;  }

        /// <summary>
        /// Holds the Left node
        /// </summary>
        INode LeftNode { get;  }

        /// <summary>
        /// True if leaf node else false
        /// </summary>
        bool IsLeaf { get;  }

        /// <summary>
        /// Holds the ball count for the leaf nodes
        /// For non-leaf nodes, it is 0
        /// </summary>
        int BallCount { get; }

        /// <summary>
        /// Pushes a single ball along the model from the root node till it reaches the leaf node
        /// </summary>
        void PushBall();

        /// <summary>
        /// Builds the model from root node till leaf nodes based on the depth
        /// </summary>
        void BuildModel();

        /// <summary>
        /// Gets the collection of the leaf nodes
        /// </summary>
        /// <returns></returns>
        IList<INode> GetLeafNodes();
    }
}
