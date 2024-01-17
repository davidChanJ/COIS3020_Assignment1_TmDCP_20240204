using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace COIS3020_Assignment1_TmDC_20240204
{
    public class ServerGraph
    {
        // 3 marks
        private class WebServer
        {
            public string Name;
            public List<WebPage> P;

            //Constructor:
            public WebServer(string name)
            {
                Name = name;
                P = new List<WebPage>();
            }
        }
        private WebServer[] V;
        private bool[,] E;
        private int NumServers;
    
        // 2 marks
        // Create an empty server graph
        public ServerGraph(int MaxNumServers)
        {
            NumServers = 0;
            V = new WebServer[MaxNumServers];
            E = new bool[MaxNumServers, MaxNumServers];
        }
        // 2 marks
        // Return the index of the server with the given name; otherwise return -1
        private int FindServer(string name)
        {
            int i; //variable declaring
            for (i = 0; i <NumServers; i++) {
                if (V[i].Equals(name))
                    return i;
                return -1;
            }
            return -1;
        }
        // 3 marks
        // Double the capacity of the server graph with the respect to web servers
        private void DoubleCapacity()
        {
            //variables as new capacity & resize of array:
            int nCapacity = V.Length * 2;
            Array.Resize(ref V, nCapacity);

            //Creating a new E matrix
            bool[,] nEMatrix = new bool[nCapacity,nCapacity];
            //for loop:
            for (int i = 0;i < E.GetLength(0); i++) {
                for (int j = 0;j < E.GetLength(1); j++) {
                    nEMatrix[i,j] = E[i,j];    
                }
            }
            E = nEMatrix;
        }
        // 3 marks
        // Add a server with the given name and connect it to the other server
        // Return true if successful; otherwise return false
        public bool AddServer(string name, string other)
        {
            //Finding if server is not empty, then no add due already exists
            if(FindServer(name) == -1) return false;
            //Find if number of servers are larger than server capacity:
            if(NumServers >= V.Length) DoubleCapacity();

            //Whole process to create a new server:
            WebServer nServer = new WebServer(name);
            V[NumServers] = nServer;

            //Setting 
            int indexOther = FindServer(other);
            if (indexOther == -1) {
                E[NumServers, indexOther] = true;
                E[indexOther, NumServers] = true;
            }

            NumServers++; //An increase
            return true;
        }
        // 3 marks
        // Add a webpage to the server with the given name
        // Return true if successful; other return false
        public bool AddWebPage(WebPage w, string name)
        {
            //See if the page is not empty:
            if ()
        }
        // 4 marks
        // Remove the server with the given name by assigning its connections
        // and webpages to the other server
        // Return true if successful; otherwise return false
        public bool RemoveServer(string name, string other)
        {
            int i, j; //declaring variables
            
            if ((i = FindServer(name))> -1) { //Finding if the server is listed
                NumServers--;
                V[i] = V[NumServers];         //Switching the end into the selected server
                for (j = NumServers; j >= 0; j--) {
                    E[i, j] = E[j, NumServers];
                    E[j, i] = E[NumServers, j];
                    return true;
                }
            }
            return false;
        }
        // 3 marks
        // Add a connection from one server to another
        // Return true if successful; otherwise return false
        // Note that each server is connected to at least one other server
        public bool AddConnection(string from, string to)
        {
            
        }
        // 10 marks
        // Return all servers that would disconnect the server graph into
        // two or more disjoint graphs if ever one of them would go down
        // Hint: Use a variation of the depth-first search
        public string[] CriticalServers()
        {
           
        }
        // 6 marks
        // Return the shortest path from one server to another
        // Hint: Use a variation of the breadth-first search
        public int ShortestPath(string from, string to)
        {
            return 0;
        }
        // 4 marks
        // Print the name and connections of each server as well as
        // the names of the webpages it hosts
        public void PrintGraph()
        {

        }
    
    }
}



