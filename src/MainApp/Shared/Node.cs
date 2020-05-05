using MainApp.Shared.FP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MainApp.Shared
{
    public class Node
    {
        #region Contstruct
        public static Node Root(string title) => new Node(title);
        public static Node Sub(Node node) 
            => new Node($"Child {node.SubNodes.Count + 1}") { SuperNode = node };
        private Node(string title) => Title = title;
        #endregion

        private readonly LinkedList<Node> _subNodes = new LinkedList<Node>();

        #region Properties
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; private set; }
        public Node? SuperNode { get; private set; }
        public LinkedListNode<Node>? Link { get; private set; }
        public IReadOnlyCollection<Node> SubNodes => _subNodes;
        public bool IsFirst => SuperNode == null || SuperNode.SubNodes.FirstOrDefault()?.Id == Id;
        #endregion


        public void Rename(string title) => Title = title;

        public Node AddSubNode() => AddLast();

        public Node AddNextNeighbour() => SuperNode?.AddAffter(Link) ?? AddLast();

        #region Private methods
        private Node AddAffter(LinkedListNode<Node>? node)
            => Sub(this).Effect(sub => sub.Link = _subNodes.AddAfter(node, sub));

        private Node AddLast() 
            => Sub(this).Effect(sub => sub.Link = _subNodes.AddLast(sub));
        #endregion

        public override string ToString()
        {
            return $"{nameof(Title)}:{Title}, {nameof(SubNodes)} count = {SubNodes.Count}, {nameof(SuperNode)}.{nameof(Title)}:{SuperNode?.Title ?? "not exist"}";
        }
    }
}
