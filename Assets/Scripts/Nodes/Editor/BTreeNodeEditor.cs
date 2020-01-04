using BTree;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace BTreeEditor
{
    [CustomNodeEditor(typeof(BTreeNode))]
    public class BTreeNodeEditor : NodeEditor
    {

        public override void OnHeaderGUI()
        {
            GUI.color = Color.white;
            BTreeNode node = target as BTreeNode;
            BTreeGraph graph = node.graph as BTreeGraph;
            string title = target.name;
            GUILayout.Label(title, NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
            GUI.color = Color.white;
        }

        public override void OnBodyGUI()
        {
            base.OnBodyGUI();
            BTreeNode node = target as BTreeNode;
            BTreeGraph graph = node.graph as BTreeGraph;
        }
    }
}