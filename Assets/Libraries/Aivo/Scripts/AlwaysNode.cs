namespace AivoTree
{
    public class AlwaysNode<T> : TreeNode<T>
    {
        private readonly TreeNode<T> node;
        private readonly AivoTreeStatus targetStatus;

        public AlwaysNode(TreeNode<T> node, AivoTreeStatus targetStatus)
        {
            this.node = node;
            this.targetStatus = targetStatus;
        }

        public AivoTreeStatus Tick(long timeTick, T context)
        {
            node.Tick(timeTick, context);
            return targetStatus;
        }
    }
}