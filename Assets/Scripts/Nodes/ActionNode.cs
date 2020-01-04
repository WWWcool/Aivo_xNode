using UnityEngine.Events;
using AivoTree;

namespace BTree
{
    public class ActionNode : BTreeNode
    {
        public UnityEvent callback;

        public override TreeNode<BTreeContext> Build()
        {
            this.node = new AivoTree.ActionNode<BTreeContext>(Exec);
            return this.node as AivoTree.ActionNode<BTreeContext>;
        }

        private AivoTreeStatus Exec(long time, BTreeContext context)
        {
            callback.Invoke();
            return AivoTreeStatus.Success;
        }
    }
}