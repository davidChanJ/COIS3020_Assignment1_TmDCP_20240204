using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace COIS3020_Assignment1_TmDC_20240204
{
    public class ServerGraph
    {
        // 3 marks
        public class WebServer
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
        public WebServer[] VValue { get { return V; } }
        private bool[,] E;
        private int NumServers;
        public int NumServersValue { get { return NumServers; } }

        // Create an empty server graph
        public ServerGraph()
        {
            NumServers = 0;
            V = new WebServer[5];
            E = new bool[5, 5];
        }

        // Return the index of the server with the given name; otherwise return -1
        private int FindServer(string name)
        {
            for (int i = 0; i < NumServers; i++)
            {
                if (V[i].Name.Equals(name))
                {
                    return i;
                }
            }
            return -1;
        }

        // Double the capacity of the server graph with the respect to web servers
        private void DoubleCapacity()
        {
            //variables as new capacity & resize of array:
            int nCapacity = V.Length * 2;
            Array.Resize(ref V, nCapacity);

            //Creating a new E matrix
            bool[,] nEMatrix = new bool[nCapacity, nCapacity];
            //for loop:
            for (int i = 0; i < E.GetLength(0); i++)
            {
                for (int j = 0; j < E.GetLength(1); j++)
                {
                    nEMatrix[i, j] = E[i, j];
                }
            }
            E = nEMatrix;
        }

        // Add a server with the given name and connect it to the other server
        // Return true if successful; otherwise return false
        public bool AddServer(string name, string other)
        {
            // return false if server is already exists
            if (FindServer(name) != -1) return false;

            // double the capacity if NumServers >= V.Length
            if (NumServers >= V.Length) DoubleCapacity();

            // create new web server with given name
            WebServer nServer = new WebServer(name);
            V[NumServers] = nServer;

            // connect the new server with other server
            int indexOther = FindServer(other);
            if (indexOther != -1)
            {
                E[NumServers, indexOther] = true;
                E[indexOther, NumServers] = true;
            }

            // increase NumServers by 1
            NumServers++;
            return true;
        }

        // Add a webpage to the server with the given name
        // Return true if successful; other return false
        public bool AddWebPage(WebPage w, string name)
        {
            // get the index of server with the given name
            int serverIndex = FindServer(name);
            //return false if server with the given name is not exist
            if (serverIndex == -1)
            {
                return false;
            }

            // add webpage to the sever
            V[serverIndex].P.Add(w);
            return true;
        }

        // Remove the server with the given name by assigning its connections
        // and webpages to the other server
        // Return true if successful; otherwise return false
        public bool RemoveServer(string name, string other)
        {
            // index of name
            int i = FindServer(name);
            // index of other
            int j = FindServer(other);

            if (i > -1 && j > -1)
            { //Finding if the server is listed
                //Creating connections by switching from and to
                // assign connection of name to other
                for (int h = 0; h < NumServers; h++)
                {
                    if (E[i, h] == true)
                    {
                        E[i, h] = false;
                        E[h, i] = false;
                        E[j, h] = true;
                        E[h, j] = true;
                    }
                }

                // assign webpage of name to other
                for (int k = 0; k < V[i].P.Count; k++)
                {
                    //insert page into other server
                    V[j].P.Add(V[i].P[k]);
                }

                //swap i with the last vertex(include V and E)
                for (int k = 0; k < NumServers; k++)
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
            if ((i = FindServer(from)) > -1 && (j = FindServer(to)) > -1)
            {
                if (E[i, j] == false)
                {    //Seek if the connection doesn't exist, then the statement makes the connection exists
                    //Connecting route from i to j
                    E[i, j] = true;
                    E[j, i] = true;
                    Console.WriteLine("Connection added");
                    return true;
                }
            }
            return false;
        }
        // 10 marks
        // Return all servers that would disconnect the server graph into
        // two or more disjoint graphs if ever one of them would go down
        // Hint: Use a variation of the depth-first search


        //public string[] CriticalServers2()
        //{
        //    bool[] visited = new bool[NumServers];
        //    int[] discoveryTime = new int[NumServers];
        //    int[] low = new int[NumServers];
        //    int[] parent = new int[NumServers];
        //    bool[] articulationPoint = new bool[NumServers];
        //    int time = 0;

        //    // Initialize arrays
        //    for (int i = 0; i < NumServers; i++)
        //    {
        //        parent[i] = -1;
        //        visited[i] = false;
        //        articulationPoint[i] = false;
        //    }

        //    // Perform DFS for each unvisited vertex
        //    for (int i = 0; i < NumServers; i++)
        //    {
        //        if (!visited[i])
        //            CriticalServersDFS(i, visited, discoveryTime, low, parent, ref articulationPoint, ref time);
        //    }

        //    // Collect and return the names of articulation points
        //    List<string> criticalServers = new List<string>();
        //    for (int i = 0; i < NumServers; i++)
        //    {
        //        if (articulationPoint[i])
        //            criticalServers.Add(V[i].Name);
        //    }

        //    return criticalServers.ToArray();
        //}

        private void DFSUtil(int u, bool[] visited, int[] disc, int[] low, int?[] parent, bool[] ap)
        {
            // A static variable to keep track of the discovery time
            int time = 0;
            int children = 0; // Count of children in the DFS tree
            visited[u] = true;
            disc[u] = low[u] = ++time; // Initialize discovery time and low value

            for (int v = 0; v < NumServers; v++)
            {
                // Go through all vertices adjacent to this
                if (E[u, v])
                {
                    if (!visited[v])
                    {
                        children++;
                        parent[v] = u;
                        DFSUtil(v, visited, disc, low, parent, ap);

                        // Check if the subtree rooted with v has a connection to one of the ancestors of u
                        low[u] = Math.Min(low[u], low[v]);

                        // u is an articulation point in the following cases

                        // (1) u is root of DFS tree and has two or more children
                        if (parent[u] == null && children > 1)
                            ap[u] = true;

                        // (2) If u is not root and low value of one of its child is more than discovery value of u
                        if (parent[u] != null && low[v] >= disc[u])
                            ap[u] = true;
                    }
                    else if (v != parent[u])
                    {
                        low[u] = Math.Min(low[u], disc[v]);
                    }
                }
            }
        }

        // The function to find and return all critical servers
        public string[] CriticalServers()
        {
            // Mark all the vertices as not visited
            bool[] visited = new bool[NumServers];
            int[] disc = new int[NumServers]; // To store discovery times of visited vertices
            int[] low = new int[NumServers]; // To store earliest visited vertex (the low value)
            int?[] parent = new int?[NumServers]; // To store parent vertices in DFS tree
            bool[] ap = new bool[NumServers]; // To store articulation points

            // Initialize parent and visited, and ap (articulation point) arrays
            for (int i = 0; i < NumServers; i++)
            {
                parent[i] = null;
                visited[i] = false;
                ap[i] = false;
            }

            // Call the recursive helper function to find articulation points in DFS tree rooted with vertex 'i'
            for (int i = 0; i < NumServers; i++)
                if (!visited[i])
                    DFSUtil(i, visited, disc, low, parent, ap);

            // Now ap[] contains articulation points, process them
            List<string> criticalServers = new List<string>();
            for (int i = 0; i < NumServers; i++)
                if (ap[i])
                    criticalServers.Add(V[i].Name);

            return criticalServers.ToArray();
        }

        private void dfs(int index, bool[] visited)
        {
            for (int i = 0; i < NumServers; i++)
            {
                if (E[index, i])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        dfs(i, visited);
                    }
                }
            }
        }


        // 6 marks
        // Return the shortest path from one server to another
        // Hint: Use a variation of the breadth-first search
        public int ShortestPath(string from, string to)
        {
            int startIndex = FindServer(from);
            int endIndex = FindServer(to);

            // Check if both servers exist
            if (startIndex == -1 || endIndex == -1)
                return -1;

            if (startIndex == endIndex)
                return 0;

            // Initialize visited array and distances
            bool[] visited = new bool[NumServers];
            int[] distances = new int[NumServers];
            for (int i = 0; i < NumServers; i++)
            {
                visited[i] = false;
                distances[i] = int.MaxValue;
            }

            // BFS Queue
            Queue<int> queue = new Queue<int>();

            // Start from the 'from' server
            visited[startIndex] = true;
            distances[startIndex] = 0;
            queue.Enqueue(startIndex);

            // BFS loop
            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                // Check all adjacent servers
                for (int i = 0; i < NumServers; i++)
                {
                    if (E[current, i] && !visited[i])
                    {
                        visited[i] = true;
                        distances[i] = distances[current] + 1;
                        queue.Enqueue(i);

                        // If the 'to' server is found, return the distance
                        if (i == endIndex)
                            return distances[i];
                    }
                }
            }

            // If the 'to' server is not reachable from the 'from' server
            return -1;
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
                    if (E[i, j])
                    {
                        Console.Write($"{V[j].Name} ");
                        hasConnections = true;
                    }
                if (!hasConnections)
                    Console.Write("None");
                Console.WriteLine();

                // Print hosted webpages
                Console.Write("Hosted WebPages: ");
                if (server.P.Count > 0)
                    foreach (WebPage webpage in server.P)
                        Console.Write($"{webpage.Name} ");
                else
                    Console.Write("None");

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public string GetServerNameByWebPageName(string webPageName)
        {
            foreach (WebServer webServer in V)
            {
                // Check if webServer is not null before accessing its properties
                if (webServer != null)
                {
                    foreach (WebPage webPage in webServer.P)
                    {
                        if (webPage.Name.Equals(webPageName))
                        {
                            return webServer.Name;
                        }
                    }
                }
            }

            return "";
        }

        public int findServer(string name)
        {
            return FindServer(name);
        }

        public void doubleCapacity()
        {
            DoubleCapacity();
        }
    }
}
