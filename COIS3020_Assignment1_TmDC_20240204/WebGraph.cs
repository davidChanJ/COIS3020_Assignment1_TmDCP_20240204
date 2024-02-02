//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

namespace COIS3020_Assignment1_TmDC_20240204
{
    public class WebPage
    {
        public string Name { get; set; }
        public string Server { get; set; }
        public List<WebPage> E { get; set; }

        public WebPage(string name, string host)
        {
            Name = name;
            Server = host;
            E = new List<WebPage>();
        }

        public int FindLink(string name)
        {
            ////Searching the link among the matrix via for-loop in indecies;
            for (int i = 0; i < E.Count; i++)
            { //finding through the list of websites
                if (E[i].Name == name)
                    return i;   //link connection exists
            }
            // no link which have the given name
            return -1;
        }
    }
    class WebGraph
    {
        private List<WebPage> P;
    
        // 2 marks
        // Create an empty WebGraph
        public WebGraph()
        {
            P = new List<WebPage>();
        }

        // 2 marks
        // Return the index of the webpage with the given name; otherwise return -1
        private int FindPage(string name)
        {
            for (int i = 0; i < P.Count;i++) {
                if (P[i].Name == name) {
                    return i;
                }
            }
            return -1;
        }

        // 4 marks
        // Add a webpage with the given name and store it on the host server
        // Return true if successful; otherwise return false
        public bool AddPage(string name, string host, ServerGraph S)
        {
            if (FindPage(name) != -1)
            {
                return false; // Means page with name assigned already exists
            }
            //Process of creating a webpage:
            WebPage np = new WebPage(name, host);

            // add webpage to server
            // if return false means host is not exist and not adding the new page to P
            if (!S.AddWebPage(np, host))
            {
                return false;
            }
            P.Add(np);
            return true;


        }
        // 8 marks
        // Remove the webpage with the given name, including the hyperlinks
        // from and to the webpage
        // Return true if successful; otherwise return false
        public bool RemovePage(string name, ServerGraph S)
        {
            int pgeIndex = FindPage(name);
            if (pgeIndex == -1)
                return false; //Page not found

            //Removing hyperlinks to the page
            foreach(WebPage pge in P)
                pge.E.RemoveAll(p => p.Name == name);

            // loop over all the servers in S
            for (int i = 0; i < S.NumServersValue; i ++)
            {
                // there may be multiple webpages with the same name in the same server
                // keep removing those webpages until the server have no webpage with the given name
                // if removed is false, means there is no any webpage with the given name in that server
                bool removed;
                do
                {
                    removed = S.RemoveWebPage(name, S.VValue[i].Name);
                } while (removed == true);

            }
            P.RemoveAt(pgeIndex);
            return true;
        }

        // 3 marks
        // Add a hyperlink from one webpage to another
        // Return true if successful; otherwise return false
        public bool AddLink(string from, string to) {
            //Setting variables
            int fIndex = FindPage(from); //origin
            int dIndex = FindPage(to);   //destination
            //Finding if from and to indecies are not empty
            if (fIndex == -1 || dIndex == -1)
                return false;
            //Link adding
            P[fIndex].E.Add(P[dIndex]);
            return true;
        }

        // 3 marks
        // Remove a hyperlink from one webpage to another
        // Return true if successful; otherwise return false
        public bool RemoveLink(string from, string to)
        {
            int fIndex = FindPage(from);
            if (fIndex == -1)
                return false; // Page not found

            //link removing
            int dIndex = FindPage(to);
            if (dIndex != -1) {
                P[fIndex].E.Remove(P[dIndex]);
                return true;
            }
            return false; // Link not found

        }
        // 6 marks
        // Return the average length of the shortest paths from the webpage with
        // given name to each of its hyperlinks
        // Hint: Use the method ShortestPath in the class ServerGraph
        public float AvgShortestPaths(string name, ServerGraph S)
        {
            //Getting index
            int targetI = FindPage(name);
            if (targetI == -1)
                return -1;      //Returns empty if the index does not exist

            int totalLength = 0;
            int reachableWebPage = 0;
            // name of server hosting the webpage with the given name
            string fromServerName = S.GetServerNameByWebPageName(name);
            foreach (WebPage webPage in P[targetI].E)
            {
                string toServerName = S.GetServerNameByWebPageName(webPage.Name);
                totalLength += S.ShortestPath(fromServerName, toServerName);
                reachableWebPage++;
            }
            if (reachableWebPage > 0)
                return (float)totalLength / reachableWebPage;

            return 0;
        }
        // 3 marks
        // Print the name and hyperlinks of each webpage
        public void PrintGraph()
        {
            foreach (var pge in P){
                Console.Write($"Page: {pge.Name}, links: ");
                foreach (var link in pge.E) 
                    Console.Write(link.Name + " ");
                Console.WriteLine("; ");
            }
            Console.WriteLine();
        }
    }
}