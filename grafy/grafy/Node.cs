using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace grafy
{
    internal class Node
    {
        public int index;
           public List<Node> neighbours;

        public Node(int index)
        {
            this.index = index;
            neighbours = new List<Node>();

        }
        public void AddNeighbour(Node neighbour)
        {
            if (neighbours.Contains(neighbour))
            {
                Console.WriteLine("this neighbour is already present");

            }
            else
            {
                neighbours.Add(neighbour);

            }
        }
        public void AddNeighbours(List<Node> newNeighbours)
        {
            foreach(Node neighbour in newNeighbours) 
            {
                AddNeighbour(neighbour);
            }
            
        }
        public void PrintNeighbours()
        {
            Console.Write("Neighbour of node" + index + " :");
            foreach (Node neighbour in neighbours)
            {
                Console.Write(neighbour.index + " ");
            }
            Console.WriteLine();
        }
        public Node FindNeighbour(int nextIndex)
        {
            foreach(Node neighbour in neighbours) 
            {
                if(neighbour.index == nextIndex)
                {
                    return neighbour;
                }
                
            }
            Console.WriteLine("Invalid neighbour, staying in the same node");
            return this;
        }


    }
}
