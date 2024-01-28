using System;
using System.Collections.Generic;
using System.Linq;
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
            //PrintGraph(): OK
            //FindServer(): OK
            //RemoveWebPage(): OK
            //CriticalServers():
            //ShortestPath: 

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

            //Part 2: Testing for WebGraph
            //Method Progress:
            //FindPage():
            //AddPage():
            //RemovePage():
            //AddLink():
            //RemoveLink():
            //AvgShortestPaths():
            //PrintGraph():
            
            //Creating 2 new sample servers
            ServerGraph SndSeVE = new ServerGraph();
            ServerGraph Thr = new ServerGraph();
            //Creating webpages
            WebPage bal = new WebPage("Bal", "Bal");
            SndSeVE.AddWebPage(bal, "Bal");
            //Creating graph
            WebGraph Bili = new WebGraph();
            //Adding pages:
            Bili.AddPage("Mal", "Bal");
            

            //Find link:
        }
    }
}
