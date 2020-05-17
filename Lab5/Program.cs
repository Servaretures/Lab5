using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    //C:/Users/Макс/Desktop/Data.txt
    abstract public class MusicGroup
    {
        public string Name { get; set; }
        public string HeadName { get; set; }

        public static List<TouringTrip> ReadDate(string path)
        {
            List<TouringTrip> g = new List<TouringTrip>();
            string text = "";
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            string[] Dates = text.Split('/');
            foreach (string s in Dates)
            {
                string[] MetaDete = s.Split('|');
                if (MetaDete.Length == 5)
                {
                    TouringTrip d = new TouringTrip
                    {
                        City = MetaDete[0],
                        Date = MetaDete[1],
                        Count = Convert.ToInt32(MetaDete[2]),
                        Name = MetaDete[3],
                        HeadName = MetaDete[4]
                    };
                    g.Add(d);
                }
            }
            return g;
        }
        public static void SaveDate(List<TouringTrip> Date, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                foreach (TouringTrip g in Date)
                {

                    sw.WriteLine(g.City.Trim() + "|" + g.Date + "|" + g.Count + "|" + g.Name + "|" + g.HeadName + "/");

                }
            }
        }
        public static void ChangeDate(List<TouringTrip> Date)
        {
            Console.WriteLine("Enter Date of trip that`s need to change");
            string Nam = Console.ReadLine();
            TouringTrip Choosen = new TouringTrip();
            Choosen.Name = "";
            foreach (TouringTrip g in Date)
            {
                if (g.Date == Nam)
                {
                    Choosen = g;
                    break;
                }
            }
            if (Choosen.Name != "")
            {
                Console.WriteLine();
                Console.WriteLine("1)Change City\n2)Change Date\n3)Change Count\n4)Change Name\n5)Change Head Name\n6)Delete");
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine("Enter new value");
                try
                {
                    if (key == '1')
                    {
                        Choosen.City = Console.ReadLine();
                    }
                    if (key == '2')
                    {

                        Choosen.Date = Console.ReadLine();
                    }
                    if (key == '3')
                    {
                        Choosen.Count = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(Choosen.Count);

                    }
                    if (key == '4')
                    {
                        Choosen.Name = Console.ReadLine();
                    }
                    if (key == '5')
                    {
                        Choosen.HeadName = Console.ReadLine();
                    }
                    if (key == '6')
                    {
                        Date.Remove(Choosen);
                    }
                }
                catch
                {
                    Console.WriteLine("New value is incorrect");
                }
                //Lviv|29.03.2019|7|Great Pistols|Ridme/
            }
            else
            {
                Console.WriteLine("TouringTrip Not found");
            }

        }
        public static void AddNew(List<TouringTrip> Date)
        {
            Console.WriteLine("Enter City");
            TouringTrip neww = new TouringTrip();
            neww.City = Console.ReadLine();
            Console.WriteLine("Enter Date");
            neww.Date = Console.ReadLine();
            Console.WriteLine("Enter Count");
            neww.Count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Group Name");
            neww.Name = Console.ReadLine();
            Console.WriteLine("Enter Head Name");
            neww.HeadName = Console.ReadLine();
            Date.Add(neww);
        }
        public static void ShowTable(List<TouringTrip> TouringTrip)
        {
            int MaxI = 8;
            int MaxN = 12;
            int MaxW = 7;
            int MaxC = 15;
            int MaxL = 11;
            Console.WriteLine("|  City  |    Date    | Count |   GroupName   | Head Name |");
            foreach (TouringTrip g in TouringTrip)
            {
                int ni = MaxI - Convert.ToString(g.City.Trim()).Length;
                int nn = MaxN - g.Date.Count();
                int nw = MaxW - Convert.ToString(g.Count).Length;
                int nc = MaxC - Convert.ToString(g.Name).Length;
                int nl = MaxL - Convert.ToString(g.HeadName).Length;
                Console.WriteLine("|" + Convert.ToString(g.City.Trim()) + PS(ni) + "|" + g.Date + PS(nn) + "|" +
                 Convert.ToString(g.Count) + PS(nw) + "|" + Convert.ToString(g.Name) + PS(nc) + "|"
                 + Convert.ToString(g.HeadName) + PS(nl) + "|");
            }
            Console.WriteLine(" p - Edit/Delete,\n d - Create\n n - search,\n m - Most Count\n t - To search city\nEnter - exit");
        }
        public static string PS(int count)
        {
            string s = "";
            for (int i = 0; i < count; i++)
            {
                s += " ";
            }
            return s;
        }
        //--------------------------------------------------------------------
        public abstract int MaxCount(List<TouringTrip> lst);
        public abstract void ToCity(List<TouringTrip> lst);
        public abstract char LastLetter(List<TouringTrip> lst);
    }
    public class TouringTrip : MusicGroup
    {
        public string City { get; set; }
        public string Date { get; set; }
        public int Count { get; set; }
        //-------------------------------------------------------------------
        public override int MaxCount(List<TouringTrip> lst)
        {
            Console.Clear();
            int IndexMax = 0;
            foreach(TouringTrip gs in lst)
            {
                if(gs.Count > lst[IndexMax].Count)
                {
                    IndexMax = lst.IndexOf(gs);
                }
            }
            int MaxI = 8;
            int MaxN = 12;
            int MaxW = 7;
            int MaxC = 15;
            int MaxL = 11;
            TouringTrip g = lst[IndexMax];
            Console.WriteLine("|  City  |    Date    | Count |   GroupName   | Head Name |");
            int ni = MaxI - Convert.ToString(g.City.Trim()).Length;
            int nn = MaxN - g.Date.Count();
            int nw = MaxW - Convert.ToString(g.Count).Length;
            int nc = MaxC - Convert.ToString(g.Name).Length;
            int nl = MaxL - Convert.ToString(g.HeadName).Length;
            Console.WriteLine("|" + Convert.ToString(g.City.Trim()) + PS(ni) + "|" + g.Date + PS(nn) + "|" +
             Convert.ToString(g.Count) + PS(nw) + "|" + Convert.ToString(g.Name) + PS(nc) + "|"
             + Convert.ToString(g.HeadName) + PS(nl) + "|");
            return g.Count;
        }
        public override void ToCity(List<TouringTrip> lst)
        {
            
            Console.WriteLine("Enter City name");
            string cim = Console.ReadLine();
            Console.Clear();
            int MaxI = 8;
            int MaxN = 12;
            int MaxW = 7;
            int MaxC = 15;
            int MaxL = 11;
            Console.WriteLine("|  City  |    Date    | Count |   GroupName   | Head Name |");
            foreach (TouringTrip g in lst)
            {
                if (g.City.Trim() == cim.Trim())
                {
                    int ni = MaxI - Convert.ToString(g.City.Trim()).Length;
                    int nn = MaxN - g.Date.Count();
                    int nw = MaxW - Convert.ToString(g.Count).Length;
                    int nc = MaxC - Convert.ToString(g.Name).Length;
                    int nl = MaxL - Convert.ToString(g.HeadName).Length;
                    Console.WriteLine("|" + Convert.ToString(g.City.Trim()) + PS(ni) + "|" + g.Date + PS(nn) + "|" +
                     Convert.ToString(g.Count) + PS(nw) + "|" + Convert.ToString(g.Name) + PS(nc) + "|"
                     + Convert.ToString(g.HeadName) + PS(nl) + "|");
                }
                
            }
            Console.WriteLine("Press any key for beak into full table");
            Console.ReadKey();
        }
        public override char LastLetter(List<TouringTrip> lst)
        {
            Console.WriteLine("Enter date of trip");
            string dt = Console.ReadLine();
            Console.Clear();
            foreach (TouringTrip g in lst)
            {
                if(g.Date == dt)
                {
                    Console.WriteLine(g.HeadName[g.HeadName.Length - 1]);
                    Console.WriteLine("Press any key to return into table");
                    Console.ReadKey();
                    return g.HeadName[g.HeadName.Length - 1];
                }
            }
            return '0';


        }
    }
    class Program
    {
        static void Main()
        {
            task1();
            Console.WriteLine((Char)Console.ReadKey().KeyChar);
        }
        static void task1()
        {
            string path = "";
            List<TouringTrip> goods = new List<TouringTrip>();
            Console.WriteLine("Enter path to file like '' or enter any to create new file");
            path = Console.ReadLine();
            try
            {
                goods = MusicGroup.ReadDate(path);
            }
            catch
            {
                path = "Data.txt";
            }

            while (true)
            {
                Console.Clear();
                MusicGroup.ShowTable(goods);
                var press = Console.ReadKey().Key;
                if (press.ToString() == "Enter")
                {
                    Main();
                }
                if (press.ToString() == "P")
                {
                    Console.WriteLine();
                    MusicGroup.ChangeDate(goods);
                    MusicGroup.SaveDate(goods, path);
                }
                if (press.ToString() == "D")
                {
                    Console.WriteLine();
                    MusicGroup.AddNew(goods);
                    MusicGroup.SaveDate(goods, path);
                }
                if (press.ToString() == "M")
                {
                    Console.WriteLine();
                    if(goods.Count > 0)
                    {
                        goods[0].MaxCount(goods);
                        Console.WriteLine("Press any key to return into table");
                        Console.ReadKey();
                    }
                    MusicGroup.SaveDate(goods, path);
                }
                if (press.ToString() == "T")
                {
                    Console.WriteLine();
                    if (goods.Count > 0)
                    {
                        goods[0].ToCity(goods);
                    }
                    MusicGroup.SaveDate(goods, path);
                }
                if (press.ToString() == "N")
                {
                    Console.WriteLine();
                    if (goods.Count > 0)
                    {
                        goods[0].LastLetter(goods);
                    }
                    MusicGroup.SaveDate(goods, path);
                }

            }

        }
        
        
        
        
        
    }
}
