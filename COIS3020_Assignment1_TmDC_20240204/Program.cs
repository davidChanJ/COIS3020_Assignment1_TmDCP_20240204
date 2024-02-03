﻿using System;
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
            // Instantiate a server graph and a web graph
            ServerGraph sg = new ServerGraph();
            WebGraph wg = new WebGraph();

            // Add servers
            sg.AddServer("server1", "server2");
            sg.AddServer("server2", "server1");
            sg.AddServer("server3", "server1");
            sg.AddServer("server4", "server1");
            sg.AddServer("server5", "server1");
            sg.AddServer("server6", "server5");

            // add additional connections between servers
            sg.AddConnection("server5", "server2");
            sg.AddConnection("server4", "server2");
            sg.AddConnection("server6", "server3");

            // check critical server

            // add webpages to servers
            wg.AddPage("webPage 1", "server3", sg);
            wg.AddPage("webPage 2", "server2", sg);
            wg.AddPage("webPage 3", "server1", sg);
            wg.AddPage("webPage 4", "server1", sg);
            wg.AddPage("webPage 5", "server1", sg);

            //add and remove hyperlinks between webpages
            wg.AddLink("webPage 1", "webPage 2");
            wg.AddLink("webPage 3", "webPage 4");
            wg.AddLink("webPage 3", "webPage 2");
            wg.AddLink("webPage 3", "webPage 1");
            wg.AddLink("webPage 4", "webPage 3");

            wg.RemoveLink("webPage 3", "webPage 1");
            wg.RemoveLink("webPage 1", "webPage 2");

            // remove webpages
            wg.RemovePage("webPage 2", sg);
            wg.RemovePage("webPage 5", sg);

            // remove servers
            sg.RemoveServer("server6", "server5");

            // determine articulation points
            string[] articulationPoints = sg.CriticalServers();
            Console.Write("Articulation points: ");
            if (articulationPoints.Length > 0)
            {
                Console.WriteLine(string.Join(", ", articulationPoints));
            } else
            {
                Console.WriteLine("none");
            }

            double averageShortestDistance = wg.AvgShortestPaths("webPage 3", sg);
            Console.WriteLine("Average shortest distance of webPage 3:", averageShortestDistance);


        }
    }
}
