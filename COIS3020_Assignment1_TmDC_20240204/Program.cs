using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace COIS3020_Assignment1_TmDC_20240204
{
    public class Program
    {
        public static void Main(string[] args)
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
            //ShortestPath: Maybe OK?

            //Part 1: Testing for ServerGraph
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
            //FindPage(): 
            //AddPage(): OK
            //RemovePage(): OK
            //AddLink(): OK
            //RemoveLink(): OK? tue moi
            //AvgShortestPaths():
            //PrintGraph():

            WebGraph webGraph = new WebGraph();
            WebPage YesSite = new WebPage("555", "nnn");

            //Test for webGraph:
            webGraph.AddPage("Mahah", "neh");
            webGraph.AddPage("Masaa", "mol");
            webGraph.AddPage("Worst site ever", "0");
            webGraph.AddPage("Malabol", "mol");
            webGraph.AddPage("Sam", "mol");
            webGraph.AddPage("Paracal", "mol");

            //Deleting the website
            webGraph.RemovePage("Worst site ever");
            webGraph.AddPage("Best page ever creaed!", "100");

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
            webGraph.AddLink("", "Paracal");

            webGraph.PrintGraph();


            //Goes for website thing
            Console.Write(YesSite.FindLink("") + "\n");

            webGraph.PrintGraph();


            //Find link:
        }
    }
}
