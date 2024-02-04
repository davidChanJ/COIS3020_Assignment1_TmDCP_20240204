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

            if (server.AddServer("server", "no") == true) {
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
            if(server.AddConnection("server", "server3") == true)
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
            Console.WriteLine("Test 6 Printing Graphs: \n");
            Console.WriteLine("One: ");
            server.PrintGraph();

            Console.WriteLine("Test 7 Removing a server");
            if (server.RemoveWebPage("333", "server2") == true) {
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
            if (critSev.Length > 0)
            {
                Console.WriteLine("Critial Server: " + string.Join(", ", critSev) + "\n");
            }
            else Console.WriteLine("Failed \n");

            //Part 2: Testing for WebGraph
            //Method Progress:
            //FindPage(): (14)
            //AddPage(): OK (10)
            //RemovePage(): OK (11)
            //AddLink(): OK (12)
            //RemoveLink(): OK? tue moi (12)
            //AvgShortestPaths(): OK? Can work, late to expected (15)
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
            if(webGraph.RemovePage("Worst site ever", server) == true)
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

            Console.WriteLine("\nTest 13 -- Showing the graph");
            webGraph.PrintGraph();

            //Goes for website thing
            Console.WriteLine("\nTest 14 -- Finding the link");
            Console.Write(YesSite.FindLink("Sam") + "\n");
            webGraph.PrintGraph();

            Console.WriteLine("\nTest 15 -- Showing the short paths:");
            Console.WriteLine("Average avg shortest paths for Mahah: " + webGraph.AvgShortestPaths("Mahah", server) + "");
            Console.Write(NoSite.FindLink("Malabol") + "\n");
            Console.WriteLine("\n" + YesSite.FindLink("Malabol") + "\n");

            //Find link:
        }

        //public static void testFromSam()
        //{
        //    // Create a ServerGraph
        //    ServerGraph serverGraph = new ServerGraph();

        //    // Add servers
        //    serverGraph.AddServer("Server1", null);
        //    serverGraph.AddServer("Server2", null);

        //    // Create a WebGraph
        //    WebGraph webGraph = new WebGraph();

        //    // Add webpages and specify which server they're hosted on
        //    webGraph.AddPage("Page1", "Server1", serverGraph);
        //    webGraph.AddPage("Page2", "Server2", serverGraph);
        //    webGraph.AddPage("Page3", "Server2", serverGraph);
        //    webGraph.AddPage("Page4", "Server2", serverGraph);

        //    // Add links from Page1 to Page3 and Page4
        //    webGraph.AddLink("Page1", "Page3");
        //    webGraph.AddLink("Page1", "Page4");

        //    // Now, add a link from Page1 to Page2
        //    bool linkAdded = webGraph.AddLink("Page1", "Page2");

        //    // Verify if the link was added successfully
        //    if (linkAdded)
        //    {
        //        Console.WriteLine("Link from Page1 to Page2 was added successfully.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Failed to add link from Page1 to Page2.");
        //    }

            //// Use FindLink method to check for the link's existence
            //int linkIndex = webGraph.P.First(wp => wp.Name == "Page1").FindLink("Page2");

            //// Print result
            //if (linkIndex != -1)
            //{
            //    Console.WriteLine($"Link from Page1 to Page2 found at index: {linkIndex}");
            //}
            //else
            //{
            //    Console.WriteLine("Link from Page1 to Page2 not found.");
            //}
        //}

    }
}
