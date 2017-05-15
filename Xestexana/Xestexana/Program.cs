using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xestexana
{
    public static class sobe_gs
        {
        public static hekim hekim;
        public static sobe sobe;
       
        public  static void Showsobe()
        {
            if (Console.ReadKey(true).Key == ConsoleKey.S)
            {
                int i = 0;
                foreach (var a in Xestexana.sobe_listi)
                {
                    i++;
                    Console.WriteLine(i + "." + a.wobe_adi);
                }
            }
        }
        public static void showhekim()
        {

            Console.WriteLine( "secmek istediyiniz wobe" );

            int y = Convert.ToInt16(Console.ReadLine()) - 1;
            if (y < 0 || y > Xestexana.sobe_listi.Count)
            {
                Console.WriteLine("xestexanada  secdiyiniz wobe yoxdur");
                Showsobe();
                showhekim();


            }
            else
            {

                Console.WriteLine("secdiyiniz Wobe");
                Console.WriteLine(Xestexana.sobe_listi[y].wobe_adi);
                int i = 0;
                foreach (var a in Xestexana.sobe_listi[y].hekimler)
                {
                    i++;
                    Console.WriteLine(i + "." + a.hekim_name + " " + a.hekim_surname);
                }
                Console.WriteLine("hekiminizi secin");
                var x = Convert.ToInt32(Console.ReadLine()) - 1;


               Console.WriteLine("secdiyiniz hekim " + Xestexana.sobe_listi[y].hekimler[x].hekim_name + " " + Xestexana.sobe_listi[y].hekimler[x].hekim_surname);
                Console.WriteLine("Hekiminizin ish vaxtlari");
                foreach (var xi in Xestexana.sobe_listi[y].hekimler[x].ish.Keys)
                {
                    Console.WriteLine(xi + " " + Xestexana.sobe_listi[y].hekimler[x].ish[xi]);

                }
                Console.WriteLine("hansi vaxtlarda hekimle goruwmek istesiz?");
                int z = Convert.ToInt16(Console.ReadLine())-1;
               

                  
                        if (Xestexana.sobe_listi[y].hekimler[x].ish.Values.ElementAt(z) == "bosh")

                        {

                    var gh = Xestexana.sobe_listi[y].hekimler[x].ish.Keys.ElementAt(z);
                    Xestexana.sobe_listi[y].hekimler[x].ish[gh] = "dolu";
                    foreach (var xi in Xestexana.sobe_listi[y].hekimler[x].ish.Keys)
                    {
                        Console.WriteLine(xi + " " + Xestexana.sobe_listi[y].hekimler[x].ish[xi]);

                    }



                }
                        else
                        {
                            Console.WriteLine("hmein seans zanitdir");
                        }
               





            }


           

        }
     
    }
  
     public static class iw_vaxti

    {
        public static  Dictionary<hekim,Dictionary<string,string>> siyahi = new Dictionary<hekim, Dictionary<string,string>>();
    }
    public class hekim
    {
    public  Dictionary<string, string> ish = new Dictionary<string, string>()
      {
          {"08:00-10:00","bosh" },
          {"10:00-12:00","bosh" },
          {"12:00-14:00","dolu" },
          {"14:00-16:00","bosh" },
          {"16:00-18:00","bosh" },
      };
        public string hekim_name;
        public string hekim_surname;
      
        public hekim(string hn,string hs,sobe sobe)

        {
            hekim_name = hn;
            hekim_surname = hs;
            sobe.hekimler.Add(this);
            iw_vaxti.siyahi.Add(this, this.ish);

        }

    }
    public class sobe
    {
        public List<hekim> hekimler = new List<hekim>();
        public string wobe_adi;
      
        public sobe(string adi)
        {
            wobe_adi = adi;
            Xestexana.sobe_listi.Add(this);
        }

    }
    public  static class Xestexana
    {
        public static List<sobe> sobe_listi = new List<sobe>();
        
    }
    public class xeste
    {
        public string name;
        public string surname;
        public xeste()
        {
            Console.WriteLine("ADinizi daxil edin");
            name = Console.ReadLine();
            Console.WriteLine("Soyadivizi daxil edin");
            surname = Console.ReadLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var xestexuste = new xeste();
            var sobe = new sobe("stamatologiya");
            var sobe1 = new sobe("Terapevt");
            var sobe2 = new sobe("Reanimasiya");
            var sobe3 = new sobe("Uroloq");
            var sobe4 = new sobe("dermatologiya");
            var hekim = new hekim("cefer", "cabbarli", sobe1);
            var hekim1 = new hekim("huseyn", "cabbarli", sobe2);
            var hekim2 = new hekim("hesen", "cabbarli", sobe3);
            var hekim3 = new hekim("xeyal", "cabbarli", sobe4);
            var hekim4 = new hekim("ismayil", "cabbarli", sobe4);
            var hekim5 = new hekim("kamran", "cabbarli", sobe3);
            var hekim6 = new hekim("bakshi", "cabbarli", sobe1);
            var hekim7 = new hekim("nail", "cabbarli", sobe2);



            sobe_gs.showhekim();
             
            Console.ReadKey();
        
        }
    }
}
