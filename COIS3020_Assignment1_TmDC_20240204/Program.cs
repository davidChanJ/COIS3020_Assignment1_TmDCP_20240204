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

            //server.RemoveServer("meme", "no");
           
            server.doubleCapacity();

            //Part 2: Testing for WebGraph
            WebPage Bili = new WebPage("bbb", "nah");
            server.AddWebPage(Bili, "meme3");

            //Find link:
            Bili.FindLink("nah");
        }
    }
}
