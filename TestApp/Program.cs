
using System;
using System.Text;

using STT.Service;
using STT.Model;
using System.Collections.Generic;
using STT.Model.Crew;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using Newtonsoft.Json;

namespace STT.TestApp
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Console.WriteLine("Communicating with service ...");

            var sk = new ShipSkill(1150, 240, 600, 40);


            var json = File.ReadAllText(@"E:\Projects\Data Analysis\short-sample.json");

            var sample = JsonConvert.DeserializeObject<List<CrewMember>>(json);

            _ = Task.Run(async () =>
            {
                var svc = new DataService();
                var crew = await svc.FetchCrewAsync();

                foreach (var crewman in crew)
                {
                    Console.WriteLine(crewman);
                }
                

            });

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var x = Console.ReadKey();
                    if (x.Key == ConsoleKey.Escape) Environment.Exit(0);
                }

                Thread.Sleep(25);                
            }
        }
    }


}
