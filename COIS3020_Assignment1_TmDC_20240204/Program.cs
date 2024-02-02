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
            ServerGraph serverGraph = new ServerGraph();
            WebGraph webGraph = new WebGraph();

            serverGraph.AddServer("FstServer", "Mal"); //Adding number of servers
            serverGraph.AddConnection("FstServer", "Server2");   //Adding connections between servers

            //Adding number of webpages to various servers
            serverGraph.AddServer("Server2", "FstServer"); //Adding another server
            serverGraph.AddWebPage(new WebPage("WebPage1", "FstServer"), "FstServer");
            serverGraph.AddWebPage(new WebPage("WebPage2", "Server2"), "Server2");

            //Removing both webpages and servers
            webGraph.RemovePage("Webpage2", serverGraph);
            serverGraph.RemoveServer("Server2", "FstServer");

            //Determine the articulation points of the remaining internet
            string[] articulationPoints = serverGraph.CriticalServers();

            //Output parts
            Console.WriteLine("Articulation Points: ");
            foreach (string point in articulationPoints)
                Console.WriteLine(point);

            serverGraph.PrintGraph();

            webGraph.PrintGraph();

        }
    }
}
