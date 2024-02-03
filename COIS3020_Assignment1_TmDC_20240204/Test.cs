using System;
using System.Collections.Generic;
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
            //Addserver(): OK
            //AddConnection(): OK
            //AddWebPage(): OK
            //RemoveServer(): OK
            //DoubleCapacity(): OK
            //PrintGraph(): OK  (Thank you, Sam)
            //FindServer(): OK
            //RemoveWebPage(): OK
            //CriticalServers(): Showing STRING[] as output (Thank you, Sam)
            //ShortestPath: OK

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
                Console.WriteLine("The AddConnection method is working, now ('meme','no') is connected! \n");
                server.AddConnection("server", "server3");
            }
            else Console.WriteLine("Failed");

            WebPage NoSite = new WebPage("333", "no");
            server.AddWebPage(NoSite, "meme3");

            //Removing a server
            Console.WriteLine("Test 3 Removing a server:");
            if (server.RemoveServer("server3", "server") == true)
            {
                server.RemoveServer("server3", "server");
                Console.WriteLine("The RemoveServer method is working, now ('meme','no') is connected! \n");
            }

            else Console.WriteLine("god please kill me\n");

            //Find server
            Console.WriteLine("Finding the Server:");
            Console.WriteLine("Server at: " + server.findServer("server"));
            Console.WriteLine("Server at: " + server.findServer("server2"));
            Console.WriteLine("If the numbers show non -1 values, then the findServer works");

            //server.RemoveServer("meme", "no");
            server.doubleCapacity();

            Console.WriteLine("Printing graphs: \n");
            Console.WriteLine("One: ");
            server.PrintGraph();

            server.RemoveWebPage("333", "meme");

            Console.WriteLine("Two: ");
            server.PrintGraph();

            Console.WriteLine("Testing Shortest Path test:");
            Console.WriteLine("Shortest path between server2 & server3: " + server.ShortestPath("server2", "server3"));
            Console.WriteLine("Shortest path between server3 & server2: " + server.ShortestPath("server3", "server2"));
            Console.WriteLine("Showing numbers can mean ShortestPath() works");

            Console.WriteLine(server.CriticalServers() + " as critical servers being done");

            //Part 2: Testing for WebGraph
            //Method Progress:
            //FindPage(): sam and pirakash pls kill me
            //AddPage(): OK
            //RemovePage(): OK
            //AddLink(): OK
            //RemoveLink(): OK? tue moi
            //AvgShortestPaths(): OK? Can work, late to expected
            //PrintGraph(): OK

            WebGraph webGraph = new WebGraph();
            WebPage YesSite = new WebPage("555", "nnn");
            server.AddWebPage(YesSite, "meme");

            //Test for webGraph:
            webGraph.AddPage("Mahah", "neh", server);
            webGraph.AddPage("Masaa", "mol", server);
            webGraph.AddPage("Worst site ever", "0", server);
            webGraph.AddPage("Malabol", "mol", server);
            webGraph.AddPage("Sam", "mol", server);
            webGraph.AddPage("Paracal", "mol", server);

            //Deleting the website
            webGraph.RemovePage("Worst site ever", server);
            webGraph.AddPage("Best page ever creaed!", "100", server);

            //Adding the link
            Console.WriteLine(webGraph.AddLink("Mahah", "Masaa"));
            Console.WriteLine(webGraph.AddLink("Masaa", "Mahah"));
            Console.WriteLine(webGraph.RemoveLink("Mahah", "Masaa"));
            Console.WriteLine(webGraph.AddLink("Mahah", "Masaa"));
            webGraph.AddLink("Worst site ever", "Sam");
            webGraph.AddLink("Malabol", "Masaa");
            webGraph.AddLink("Malabol", "Best page ever creaed!");
            webGraph.AddLink("Malabol", "Sam");
            webGraph.AddLink("Malabol", "Paracal");
            webGraph.AddLink("Sam", "Paracal");
            webGraph.AddLink("Mahah", "Paracal");
            webGraph.AddLink("abcd", "Paracal");

            //webGraph.PrintGraph();

            ////Goes for website thing
            //Console.Write(YesSite.FindLink("Sam") + "\n");
            //webGraph.PrintGraph();
            //Console.WriteLine("Average avg shortest paths for Mahah: " + webGraph.AvgShortestPaths("Mahah", server));
            //Console.Write(NoSite.FindLink("Malabol") + "\n");
            //Console.WriteLine("\n" + YesSite.FindLink("Malabol"));

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
