using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COIS3020_Assignment1_TmDC_20240204
{
    internal class Test
    {
        public static void testInternet()
        {
            //The whole process is for testing

            //Method progress:
            //Addserver(): OK (1)
            //AddConnection(): OK (2)
            //AddWebPage(): OK
            //RemoveServer(): OK (3)
            //DoubleCapacity(): OK (4)
            //PrintGraph(): OK  (5)
            //FindServer(): OK  (6)
            //RemoveWebPage(): OK (7)
            //CriticalServers(): Showing STRING[] as output (Thank you, Sam) (9)
            //ShortestPath: OK (8)

            //Part 1: Testing for ServerGraph
            Console.WriteLine("Test 1 Creating ServerGraph:");
            ServerGraph server = new ServerGraph();

            if (server.AddServer("server", "no") == true)
            {
                Console.WriteLine("The AddServer method is working, now ('server','no') is connected! \n");
                server.AddServer("server", "no");
                server.AddServer("server", "no");
            }
            else Console.WriteLine("Failed");

            //will have bugs currently
            server.AddServer("server2", "server");
            server.AddServer("server3", "no");

            //try
            server.AddServer("server2", "server3");
            server.AddServer("server3", "server2");

            //implement (Test for AddConnection)
            Console.WriteLine("Test 2 Creating Connections:");
            if (server.AddConnection("server", "server3") == true)
            {
                Console.WriteLine("The AddConnection method is working, now ('server','server3') is connected! \n");
                server.AddConnection("server", "server3");
            }
            else Console.WriteLine("Failed \n");

            WebPage NoSite = new WebPage("333", "no");

            Console.WriteLine("Test 2 1/2 Creating a WebPage:");
            if (server.AddWebPage(NoSite, "server2") == true)
            {
                server.AddWebPage(NoSite, "server2");
                Console.WriteLine("The AddWebPage method is working, the NoPage WebPage is created! \n");

            }
            else Console.WriteLine("Failed \n");

            //Removing a server
            Console.WriteLine("Test 3 Removing a server:");
            if (server.RemoveServer("server3", "server") == true)
            {
                server.RemoveServer("server3", "server");
                Console.WriteLine("The RemoveServer method is working, now ('server3','server') is connected! \n");
            }
            else Console.WriteLine("Failed \n");

            //Find server
            Console.WriteLine("Test 4 Finding the Server:");
            Console.WriteLine("Server at: " + server.findServer("server"));
            Console.WriteLine("Server at: " + server.findServer("server2"));
            Console.WriteLine("If the numbers show non -1 values, then the findServer works");

            //Double capacity (5)
            server.doubleCapacity();

            //Printing graphs (6)
            Console.WriteLine("\nTest 6 Printing Graphs: ");
            Console.WriteLine("One: ");
            server.PrintGraph();

            Console.WriteLine("Test 7 Removing a server");
            if (server.RemoveWebPage("333", "server2") == true)
            {
                server.RemoveWebPage("333", "server2");
                Console.WriteLine("The WebPage is removed 333 hosted by server2 completed \n");
            }
            else
                Console.WriteLine("Failed \n");

            Console.WriteLine("Server graph after Test 7:");
            Console.WriteLine("Two: ");
            server.PrintGraph();

            //(8)
            Console.WriteLine("\nTest 8 Shortest Path: ");
            Console.WriteLine("Shortest path between server & server2: " + server.ShortestPath("server", "server2"));
            Console.WriteLine("Shortest path between server2 & server: " + server.ShortestPath("server2", "server"));
            Console.WriteLine("Showing numbers can mean ShortestPath() works");

            //(9)
            Console.WriteLine("\nTest 9 CriticalServers method: ");
            string[] critSev = server.CriticalServers();
            // Step 5: Output the result
            Console.WriteLine("Critical Servers:");
            foreach (string s in critSev)
                Console.WriteLine(s);
            //else Console.WriteLine("Failed \n");

            //Part 2: Testing for WebGraph
            //Method Progress:
            //FindPage(): (14)
            //AddPage(): OK (10)
            //RemovePage(): OK (11)
            //AddLink(): OK (12)
            //RemoveLink(): OK? tue moi (12)
            //AvgShortestPaths(): OK? Can work, late to expected (14a)
            //PrintGraph(): OK (13)

            WebGraph webGraph = new WebGraph();
            WebPage YesSite = new WebPage("555", "nnn");

            server.AddWebPage(YesSite, "meme");

            //Test for webGraph:
            Console.WriteLine("\nTest 10 -- AddPage in WebGraph.cs");

            webGraph.AddPage("Mahah", "neh", server);
            webGraph.AddPage("Masaa", "mol", server);
            webGraph.AddPage("Worst site ever", "0", server);
            webGraph.AddPage("Malabol", "mol", server);
            webGraph.AddPage("Sam", "mol", server);

            if (webGraph.AddPage("Paracal", "mol", server) == true)
            {
                webGraph.AddPage("Paracal", "mol", server);
                Console.WriteLine("The AddPage method is working\n");
            }
            else Console.WriteLine("Failed\n");
            Console.WriteLine("----The above graph are the results---- ");

            //Deleting the website
            Console.WriteLine("\nTest 11 -- RemovePage in WebGraph.cs");
            if (webGraph.RemovePage("Worst site ever", server) == true)
            {
                webGraph.RemovePage("Worst site ever", server);
                Console.WriteLine("The 'Worst site ever' website is removed from server");
            }
            else Console.WriteLine("Failed\n");
            webGraph.AddPage("Best page ever creaed!", "100", server);

            //Adding the link
            Console.WriteLine("\nTest 12 -- AddLink in WebGraph.cs");
            Console.WriteLine("The booleans of Mahah & Massa, Masaa & Mahah, and Mahah & Masaa be shown:");
            Console.WriteLine(webGraph.AddLink("Mahah", "Masaa"));
            Console.WriteLine(webGraph.AddLink("Masaa", "Mahah"));

            if (webGraph.RemoveLink("Mahah", "Masaa") == true)
                Console.WriteLine(webGraph.RemoveLink("Mahah", "Masaa") + " <-- The value is showing the link is removed");
            else
                Console.WriteLine("The RemoveLink('Mahah', 'Masaa') is failed to use");

            Console.WriteLine(webGraph.AddLink("Mahah", "Masaa"));
            webGraph.AddLink("Worst site ever", "Sam");
            webGraph.AddLink("Malabol", "Masaa");
            webGraph.AddLink("Malabol", "Best page ever creaed!");
            webGraph.AddLink("Malabol", "Sam");
            webGraph.AddLink("Malabol", "Paracal");
            webGraph.AddLink("Sam", "Paracal");
            webGraph.AddLink("Mahah", "Paracal");
            webGraph.AddLink("abcd", "Paracal");
            Console.WriteLine("\nTest 13 -- Showing the web graph");
            webGraph.PrintGraph();

            Console.WriteLine("\nTest 14a -- Showing the short paths:");
            Console.WriteLine("Average avg shortest paths for Mahah: " + webGraph.AvgShortestPaths("Mahah", server) + "");
            Console.WriteLine("For finding link Paracal in NoSite: " + NoSite.FindLink("Paracal") );
            Console.WriteLine("For finding link Paracal in YesSite: " + YesSite.FindLink("Paracal") + "\n");

            Console.WriteLine("\nTest 14b -- Finding a page:");
            Console.WriteLine("The FindPage method is for finding a name, to make it public to successfully do the test:");
            Console.WriteLine("For example, we find Paracal: ");
            Console.WriteLine("The Paracal is at: {0}", webGraph.findPage("Paracal"));

            Console.WriteLine("\nTest 15 -- Finding a link:");
            WebPage page1 = new WebPage("Home", "Server1");
            WebPage page2 = new WebPage("About", "Server1");
            WebPage page3 = new WebPage("Contact", "Server2");
            WebPage page4 = new WebPage("Products", "Server2");

            // Link pages together to form a graph
            page1.E.Add(page2); // Home -> About
            page2.E.Add(page3); // About -> Contact
            page1.E.Add(page4); // Home -> Products

            // Test FindLink for existing and non-existing pages
            Console.WriteLine($"Searching for 'About': {page1.FindLink("About")}");
            Console.WriteLine($"Searching for 'Contact': {page1.FindLink("Contact")}");
            Console.WriteLine($"Searching for 'NonExistingPage': {page1.FindLink("NonExistingPage")}");

        }

        public static void testViaSam()
        {
            // Step 1: Create an instance of ServerGraph
            ServerGraph graph = new ServerGraph();

            // Step 2: Add servers
            graph.AddServer("Server1", ""); // Adding the first server without connecting it to another
            graph.AddServer("Server2", ""); // Server2 added without making a connection
            graph.AddServer("Server3", ""); // Server3 added without making a connection
            graph.AddServer("Server4", ""); // Server4 added without making a connection

            // Step 3: Manually add connections to make Server2 critical
            graph.AddConnection("Server1", "Server4"); // Connect Server1 to Server2
            graph.AddConnection("Server2", "Server4"); // Connect Server2 to Server3, making Server2 a bridge
            graph.AddConnection("Server3", "Server4"); // Also connect Server2 to Server4, maintaining the bridge role

            // Optionally, connect Server3 and Server4 directly to each other if you want them to remain connected after removing Server2
            // This ensures Server2 is the only critical server because it's the only bridge between Server1 and the subgraph formed by Servers 3 and 4.
            // graph.AddConnection("Server3", "Server4");

            // Step 4: Identify critical servers
            string[] criticalServers = graph.CriticalServers();

            // Step 5: Output the result
            Console.WriteLine("Test 9 Critical Servers:");
            foreach (string server in criticalServers)
            {
                Console.WriteLine(server);
            }
            Console.WriteLine("\n The above results are critical servers");

            //ShortestPath

            // Step 5: Output the result
            Console.WriteLine("\nTest 15 Shortest Path between Servers:");
            
            graph.AddConnection("Server1", "Server3");
            graph.AddConnection("Server3", "Server2");
            graph.AddConnection("Server2", "Server3");
            graph.AddConnection("Server3", "Server4");
            // ShortestPath method
            int shortestPathLength = graph.ShortestPath("Server1", "Server4");
            Console.WriteLine($"Shortest path length from Server1 to Server2: {shortestPathLength}");

        }

        public static void testViaSam2()
        {
            ServerGraph serverGraph = new ServerGraph();
            WebGraph webGraph = new WebGraph();

            serverGraph.AddServer("Server1", "Server2");
            serverGraph.AddServer("Server2", "Server1");
            serverGraph.AddServer("Server3", "Server2");
            webGraph.AddPage("P1", "Server1", serverGraph);
            webGraph.AddPage("P2", "Server2", serverGraph);
            webGraph.AddPage("P3", "Server3", serverGraph);
            webGraph.AddLink("P1", "P3"); // Assuming this links P1 on Server1 to P3 on Server2


            webGraph.PrintGraph();
            float avg = webGraph.AvgShortestPaths("P1", serverGraph);
            Console.WriteLine(avg);
            //serverGraph.PrintGraph();
        }

    }
}