﻿using System;
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
        public ServerGraph()
        {
            NumServers = 0;
            V = new WebServer[5];
            E = new bool[5,5] ;
        }

        // 2 marks
        // Return the index of the server with the given name; otherwise return -1
        private int FindServer(string name)
        {
            int i; //variable declaring
            for (i = 0; i <NumServers; i++) {
                if (V[i].Name.Equals(name)) {
                    return i;
                }
            }
            return -1;
        }
        // 3 marks
        // Double the capacity of the server graph with the respect to web servers
        private void DoubleCapacity()
        {
            //@bug-2
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
            if(FindServer(name) != -1) return false;
            //Find if number of servers are larger than server capacity:
            if(NumServers >= V.Length) DoubleCapacity();

            //Whole process to create a new server:
            WebServer nServer = new WebServer(name);
            V[NumServers] = nServer;

            //Setting 
            int indexOther = FindServer(other);
            if (indexOther != -1) {
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
            int wIndex = FindServer(name); //Setting index from server
            //check if the index is not empty
            if (wIndex != -1){
                //Add on list
                V[wIndex].P.Add(w); //Add the webpage on server's list of webpages
                return true; //Settles as successful
            }
            return false;
        }
        // 4 marks
        // Remove the server with the given name by assigning its connections
        // and webpages to the other server
        // Return true if successful; otherwise return false
        public bool RemoveServer(string name, string other)
        {
            // index of name
            int i = FindServer(name);
            // index of other
            int j = FindServer(other);
            
            if (i> -1 && j > -1) { //Finding if the server is listed
                //Creating connections by switching from and to
                // assign connection of name to other
                for(int h = 0; h < NumServers; h++)
                {
                    if (E[i, h] == true) {
                        E[i, h] = false;
                        E[j, h] = true;
                    }
                        
                }

                // assign webpage of name to other
                for (int k = 0; k < V[i].P.Count; k ++)
                {
                    //insert page into other server
                    // V[i].P.Add(i);
                    V[j].P.Add(V[i].P[k]);
                }

                //swap i with the last vertex(include V and E)
                for (int k = 0; k<NumServers; k ++)
                {
                    E[i, k] = E[NumServers - 1, k];
                    E[k, i] = E[k, NumServers - 1];
                    E[NumServers - 1, k] = false;
                    E[k, NumServers - 1] = false;
                }
                V[i] = V[NumServers - 1];
                NumServers--;

                return true;
            }
            return false;

        }

        // Bonus
        // 3 marks (Bonus)
        // Remove the webpage from the server with the given name
        // Return true if successful; otherwise return false -- Method by Sam
        public bool RemoveWebPage(string webpageName, string serverName)
        {
            // Find the server by its name
            int serverIndex = FindServer(serverName);
            if (serverIndex == -1)
            {
                // Server not found
                return false;
            }

            // Get the server
            WebServer server = V[serverIndex];

            // Find and remove the webpage from the server's list
            int pageIndex = server.P.FindIndex(page => page.Name == webpageName);
            if (pageIndex != -1)
            {
                // Webpage found, remove it
                server.P.RemoveAt(pageIndex);
                return true;
            }

            // Webpage not found on the server
            return false;
        }

        // 3 marks
        // Add a connection from one server to another
        // Return true if successful; otherwise return false
        // Note that each server is connected to at least one other server
        public bool AddConnection(string from, string to)
        {
            //Set variables
            int i, j;
            //Creating a connection if origin and destiation exist
            if ((i = FindServer(from)) > -1 && (j = FindServer(to)) > -1) {
                if (E[i, j] == false) {    //Seek if the connection doesn't exist, then the statement makes the connection exists
                    //Connecting route from i to j
                    E[i, j] = true;
                    //returning
                    return true;
                }
            }
            return false;
        }
        // 10 marks
        // Return all servers that would disconnect the server graph into
        // two or more disjoint graphs if ever one of them would go down
        // Hint: Use a variation of the depth-first search
        
        //public string[] CriticalServers()
        //{

        //}
        
        // 6 marks
        // Return the shortest path from one server to another
        // Hint: Use a variation of the breadth-first search
        public int ShortestPath(string from, string to)
        {
            //In theory, using breadth first search can find shortest path quicker.

            int i; //As index
            bool[] visited = new bool[NumServers];

            for(i = 0; i < NumServers; i++)
                visited[i] = false;
            for(i = 0; i < NumServers; i++) {
                //Checking if not visited
                if(!visited[i]){
                    //ShortestPath(from, visited);
                    Console.WriteLine();
                }
            }
            return 0;
        }

        //A private method of shortestPath:
        private void ShortestPath(int i, bool[] visited)
        {
            //Setting if visited
            int j;
            Queue<int> Q = new Queue<int>();

            Q.Enqueue(i);

            //While loop for counting
            while (Q.Count != 0)
            {
                i = Q.Dequeue();
                Console.WriteLine(i);

                for (j = 0; j < NumServers; j++)
                    if (!visited[j] && E[i, j] == false)
                    {
                        Q.Enqueue(j);
                        visited[j] = true;
                    }
            }
        }

        // 4 marks
        // Print the name and connections of each server as well as
        // the names of the webpages it hosts
        //public void PrintGraph()
        //{
        //    for (int i = 0; i < NumServers; i++)
        //    {
        //        Console.WriteLine($"Server name: {V[i].Name}");
        //        //Checking if exists, then show connection
        //        for(int j = 0; j < NumServers; j++) {
        //            if (E[i, j] == true)
        //                Console.WriteLine("Connection: {0} and {1}: {2}", V[i], V[j], E[i, j]);
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.WriteLine();
        //}

        public void PrintGraph()
        {
            for (int i = 0; i < NumServers; i++)
            {
                WebServer server = V[i];

                // Print server name
                Console.WriteLine($"Server name: {server.Name}");

                // Print connections
                Console.Write("Connections: ");
                bool hasConnections = false;
                for (int j = 0; j < NumServers; j++)
                {
                    if (E[i, j])
                    {
                        Console.Write($"{V[j].Name} ");
                        hasConnections = true;
                    }
                }
                if (!hasConnections)
                {
                    Console.Write("None");
                }
                Console.WriteLine();

                // Print hosted webpages
                Console.Write("Hosted WebPages: ");
                if (server.P.Count > 0)
                {
                    foreach (WebPage webpage in server.P)
                    {
                        Console.Write($"{webpage.Name} ");
                    }
                }
                else
                {
                    Console.Write("None");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        //tempororary test:
        public void doubleCapacity()
        {
            DoubleCapacity();
        }
    }
}



