namespace AlgorithmPractice
{
    public class Nary
    {
        public List<int> PreorderNaryTree(Node root) {
          var result = new List<int>();
          if (root == null) return result;

          PreOrderHelper(root, result);
          return result;
        }
    
        public void RecursivePreOrderHelper(Node node, List<int> list) {
            if (node == null) return;
            list.Add(node.val);

            for (int i = 0; i < node.children.Count; i++) {
                PreOrderHelper(node.children[i], list);
            }
        }
    }
}
