using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FinalProject
{
    //yards in order passing, rushing, reciving, return
    public partial class MainWindow
    { 
       
        private List<Player> GetPlayerList(string filePath)
        {
            List<Player> playerList = new List<Player>();
            
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        double fumbles;
                        
                        Yards yards = GetPlayersYards(data);//Creates a Yards instance for each player
                        TDS tds = GetPlayersTDs(data);//Creates a Touch Down instance for each player

                        if (Double.TryParse(data[12], out fumbles))//parses fumbles to a double, if that happens then the player is added
                            playerList.Add(new NFLPlayer(data[0], data[1], data[2], data[3],
                                yards, tds, fumbles));
                    }
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine("File not found.");
            }
           
                        
            return playerList;
        }

        private TDS GetPlayersTDs(string[] data)
        {
            double[] TDs = new double[4];//creates a double array for each TDs parameter
            for (int i = 0; i < 4; i++)
            {
                double tds;
                if (Double.TryParse(data[i * 2 + 5], out tds))//if its parsed, adds to array
                    TDs[i] = tds;
                else TDs[i] = 0;
            }

            return new TDS(TDs[0], TDs[1], TDs[2], TDs[3]);//Returns the players TDs
        }

        private Yards GetPlayersYards(string[] data)
        {
            double[] yards = new double[4];//creates a double array for yards
            for (int i = 0; i < 4; i++)
            {
                double yds;
                if (Double.TryParse(data[i * 2 + 4], out yds))//if that number is parsed adds it to the array
                    yards[i] = yds;
                else yards[i] = 0;
            }
            
            return new Yards(yards[0], yards[1], yards[2], yards[3]);//returns the players Yards
        }
    }
}
