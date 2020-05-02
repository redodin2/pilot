using MainApp.Shared.FP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MainApp.Shared
{
    public class Node
    {
        public static Node Root(string title) => new Node(title);
        public static Node Sub(Node node) 
            => new Node($"Child {node.SubNodes.Count + 1}") { SuperNode = node };

        private readonly LinkedList<Node> _subNodes = new LinkedList<Node>();

        private Node(string title) => Title = title;

        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; private set; }
        public Node? SuperNode { get; private set; }
        public LinkedListNode<Node>? Link { get; private set; }
        public IReadOnlyCollection<Node> SubNodes => _subNodes;

        public bool IsFirst => SuperNode == null || SuperNode.SubNodes.FirstOrDefault()?.Id == Id;

        public Node AddSubNode() => AddAffterOrLast();
        public Node AddNextNeighbour() => SuperNode?.AddAffterOrLast(Link) ?? AddSubNode();

        private Node AddAffterOrLast(LinkedListNode<Node>? node = null)
            => Sub(this).Effect(sub => sub.Link = node != null 
                ? _subNodes.AddAfter(node, sub) 
                : _subNodes.AddLast(sub));

        public void Rename(string title) => Title = title;

        public override string ToString()
        {
            return $"{nameof(Title)}:{Title}, {nameof(SubNodes)} count = {SubNodes.Count}, {nameof(SuperNode)}.{nameof(Title)}:{SuperNode?.Title ?? "not exist"}";
        }
    }
}
