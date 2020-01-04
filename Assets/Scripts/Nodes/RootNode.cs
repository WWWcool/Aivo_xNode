using System;
using UnityEngine;
using XNode;
using AivoTree;

namespace BTree
{
    public class RootNode : Node
    {
        [Output(connectionType = ConnectionType.Override)] public AivoTreeStatus output;

        public AivoTree.TreeNode<BTreeContext> Build()
        {
            NodePort outputPort = GetOutputPort("output");

            if (!outputPort.IsConnected)
            {
                Debug.LogWarning("Node isn't connected");
                return null;
            }

            var node = outputPort.Connection.node as BTreeNode;
            if (node)
            {
                return node.Build();
            }
            return null;
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}