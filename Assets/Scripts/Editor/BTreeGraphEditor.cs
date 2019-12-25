using UnityEditor;
using UnityEngine;
using BTree;
using XNodeEditor;

namespace BTreeEditor
{
    [CustomNodeGraphEditor(typeof(BTreeGraph))]
    public class BTreeGraphEditor : NodeGraphEditor
    {
        /// <summary> 
        /// Overriding GetNodeMenuName lets you control if and how nodes are categorized.
        /// In this example we are sorting out all node types that are not in the XNode.Examples namespace.
        /// </summary>
        public override string GetNodeMenuName(System.Type type)
        {
            if (type.Namespace == "BTree")
            {
                return base.GetNodeMenuName(type).Replace("BTree/BTree Graph/", "");
            }
            else return null;
        }

        public override void OnGUI()
        {
            // Repaint each frame
            window.Repaint();
        }
    }
}