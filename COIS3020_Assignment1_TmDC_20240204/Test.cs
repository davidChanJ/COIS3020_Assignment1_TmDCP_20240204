﻿using System;
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
            Console.Write("Test 1 Creating ServerGraph:");
            ServerGraph server = new ServerGraph();
            server.AddServer("meme", "no");
            server.AddServer("meme", "no");

            //will have bugs currently
            server.AddServer("meme2", "meme");
            server.AddServer("meme3", "no");

            //try
            server.AddServer("meme2", "meme3");
            server.AddServer("meme3", "meme2");

            //implement
            server.AddConnection("meme", "meme3");
            WebPage NoSite = new WebPage("333", "no");
            server.AddWebPage(NoSite, "meme3");

            server.RemoveServer("meme3", "meme");

            //Find server
            Console.WriteLine("Server at: " + server.findServer("meme"));
            Console.WriteLine("Server at: " + server.findServer("meme2"));

            //server.RemoveServer("meme", "no");

            server.doubleCapacity();

            Console.WriteLine("One: ");
            server.PrintGraph();

            server.RemoveWebPage("333", "meme");

            Console.WriteLine("Two: ");
            server.PrintGraph();

            Console.WriteLine("Shortest path between meme2 & meme3: " + server.ShortestPath("meme", "meme2"));
            Console.WriteLine("Shortest path between meme3 & meme2: " + server.ShortestPath("meme2", "meme"));

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

            webGraph.PrintGraph();


            //Goes for website thing
            Console.Write(YesSite.FindLink("Sam") + "\n");
            webGraph.PrintGraph();
            Console.WriteLine("Average avg shortest paths for Mahah: " + webGraph.AvgShortestPaths("Mahah", server));
            Console.Write(NoSite.FindLink("Malabol") + "\n");
            Console.WriteLine("\n" + YesSite.FindLink("Malabol"));


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

        //    // Use FindLink method to check for the link's existence
        //    int linkIndex = webGraph.P.First(wp => wp.Name == "Page1").FindLink("Page2");

        //    // Print result
        //    if (linkIndex != -1)
        //    {
        //        Console.WriteLine($"Link from Page1 to Page2 found at index: {linkIndex}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Link from Page1 to Page2 not found.");
        //    }
        //}

    }
}
