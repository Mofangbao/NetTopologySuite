using System;
using System.Collections;
using System.Diagnostics;
using System.Text;

using GisSharpBlog.NetTopologySuite.Geometries;

namespace GisSharpBlog.NetTopologySuite.Planargraph
{
    /// <summary>
    /// A map of <c>Node</c>s, indexed by the coordinate of the node.
    /// </summary>   
    public class NodeMap
    {
        private IDictionary nodeMap = new SortedList();

        /// <summary>
        /// Constructs a NodeMap without any Nodes.
        /// </summary>
        public NodeMap() { }

        /// <summary>
        /// Adds a node to the map, replacing any that is already at that location.
        /// </summary>
        /// <param name="n"></param>
        /// <returns>The added node.</returns>
        public virtual Node Add(Node n)
        {
            Coordinate key = n.Coordinate;
            bool contains = nodeMap.Contains(key);            
            if (!contains) nodeMap.Add(key, n);            
            return n;
        }

        /// <summary>
        /// Removes the Node at the given location, and returns it (or null if no Node was there).
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public virtual Node Remove(Coordinate pt)
        {
            Node node = (Node)nodeMap[pt];
            nodeMap.Remove(pt);
            return node;
        }

        /// <summary>
        /// Returns the Node at the given location, or null if no Node was there.
        /// </summary>
        /// <param name="coord"></param>
        /// <returns></returns>
        public virtual Node Find(Coordinate coord) 
        {
            return (Node)nodeMap[coord]; 
        }

        /// <summary>
        /// Returns an Iterator over the Nodes in this NodeMap, sorted in ascending order
        /// by angle with the positive x-axis.
        /// </summary>
        public virtual IEnumerator GetEnumerator()
        {
            return nodeMap.Values.GetEnumerator();
        }

        /// <summary>
        /// Returns the Nodes in this NodeMap, sorted in ascending order
        /// by angle with the positive x-axis.
        /// </summary>
        public virtual ICollection Values
        {
            get
            {
                return nodeMap.Values;
            }
        }
    }
}
