using System;
using System.Collections.Generic;

namespace AlgorithmPractice
{
    public class PracticeSix
    {
        // delete duplicates in a linked list of List Nodes
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return null;

            var current = head;

            while (current.next != null)
            {

                if (current.next.val == current.val)
                    current.next = current.next.next;
                else current = current.next;
            }

            return head;
        }

        // return a list of a tree made of TreeNodes
        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            var stack = new Stack<TreeNode>();
            var currentNode = root;

            while (currentNode != null || stack.Count > 0)
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }

                currentNode = stack.Pop();
                result.Add(currentNode.val);
                currentNode = currentNode.right;

            }

            return result;
        }
        
        // check if trees are the same
        public bool IsSameTree(TreeNode p, TreeNode q) {
            if(p == null && q == null) return true;
            if(q == null || p == null) return false;
            if(p.val != q.val) return false;
            return IsSameTree(p.right, q.right) && IsSameTree(p.left, q.left);
        }
        
        // are trees symmetric?
        public bool IsSymmetric(TreeNode root) {
            return FindSymmetry(root, root);
        }
        // recursive helper fn for IsSymmetric
        public bool FindSymmetry(TreeNode first, TreeNode second){
            if(first == null && second == null) return true;
            if (first == null || second == null) return false;
            return (first.val == second.val) && FindSymmetry(first.right, second.left) && FindSymmetry(first.left, second.right);
        }
        
        
        
        
    }
    
    // singly linked node
    public class ListNode {
        public readonly int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }
    
    // tree nodes
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}