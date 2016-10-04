using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;



namespace ConsoleApplication1



        
{
    class Program
    {




        [STAThread]
            
        static void Main(string[] args)
        {


            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth - 15, Console.LargestWindowHeight - 12);


            FolderBrowserDialog dirOdabran = new FolderBrowserDialog();

            dirOdabran.Tag = "Odaberi folder";
            dirOdabran.ShowDialog();
            
            

            string path = dirOdabran.SelectedPath;


            Console.WriteLine(path);
            Console.WriteLine("Unesi ekstenziju file-ova (Na primer txt ili bmp");
            string ekstenzija = Console.ReadLine();

            ekstenzija = "." + ekstenzija;


            int i = 0;
            // int iterator;

            Console.WriteLine(" Svi " + ekstenzija + "  file-ovi su: ");
            Console.WriteLine("-------------------------------------");

            string[] lista = Directory.GetFiles(path, "*"+ ekstenzija);

            DirectoryInfo direktorijuminfo = new DirectoryInfo(path);
            FileInfo[] infoofileu = direktorijuminfo.GetFiles();

            
            double ukupnoVelicina1 = 0;

            foreach (FileInfo clanovi in direktorijuminfo.GetFiles("*"+ ekstenzija))
            {
                

                //string trenutni = clanovi.get;
              //  if (trenutni  == lista[i])
                    
                //{
                
                Console.WriteLine(clanovi.Name);



                double velicinaFilea = clanovi.Length / 1024.00;

                velicinaFilea = Math.Round((velicinaFilea / 1024.00), 5);
                ukupnoVelicina1 = ukupnoVelicina1 + velicinaFilea;

                Console.WriteLine(" velicine = " + velicinaFilea + " Megabytes");
                i = i + 1;
          //  }
                
            }

            int iterator = Directory.GetFiles(path, "*" + ekstenzija).Count();

            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Odabrani folder  " + path);
            Console.WriteLine("------------------------------------");
            Console.WriteLine("sadrzi - " + i + " file-ova tipa  " + ekstenzija);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("UKUPNO ZAUZIMAJU : " + ukupnoVelicina1 + " Megabytes");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("UKUPNO ZAUZIMAJU : " + Math.Round(ukupnoVelicina1 / 1024, 5) + " Gigabytes");
            Console.WriteLine("------------------------------------------------");

            //var allFilenames = Directory.EnumerateFiles(path).Select(p => Path.GetFileName(p));

            // Get all filenames that have a inputed  extension, excluding the extension
            //var candidates = allFilenames.Where(fn => Path.GetExtension(fn) == ekstenzija)
                             //.Select(fn => Path.GetFileNameWithoutExtension(fn));


            
            //Console.WriteLine(candidates);


           // foreach (clan in allFilenames)
            //{
              //  Console.WriteLine(clan);
            
           // }

            Console.WriteLine("Da ti snimim u TXT file - da / ne ");

            string odgovor = Console.ReadLine();

            if (odgovor == "da")
            {
  
                dirOdabran.Tag = "Odaberi folder";
                dirOdabran.ShowDialog();
                string putanjanova = dirOdabran.SelectedPath;

                Console.WriteLine("Unesi ime TXT File - a, SAMO SLOVA I BROJEVI MOLIM");

                string imenovogfilea = Console.ReadLine();

                ArrayList nlista = new ArrayList();

                nlista.Add("Spisak file-ova sa ekstenzijom " + ekstenzija + " je sledeci:  ");
                nlista.Add("-------------------------------------------------------------");
                // foreach (FileInfo e in direktorijuminfo.GetFiles("*"+ ekstenzija))
                
                double ukupnoVelicina = 0;


                foreach (FileInfo e in direktorijuminfo.GetFiles("*" + ekstenzija))
                {
                    double m = (e.Length / 1024); 
                        m = Math.Round((m / 1024),5);
                        ukupnoVelicina = ukupnoVelicina + m;

                    nlista.Add(e.Name + " - " + m.ToString() + " Megabytes");
                nlista.Add("-------------------------------------------------------------------------------");
                }

                
                nlista.Add("-------------------------------------------------------------------------------");

                //string boldovano = "Odabrani folder - " + path;
                ///FontStyle stil = new FontStyle();
               //// FontStyle.Bold(boldovano);
                
                //FontStyle.Bold(boldovano);


                nlista.Add("Odabrani folder - "+ path);



                nlista.Add("sadrzi - " + i + " file-ova tipa  " + ekstenzija);
                nlista.Add("-------------------------------------------------------------------------------");
                nlista.Add("UKUPNO ZAUZIMAJU : " + ukupnoVelicina + " Megabytes");
                nlista.Add("-------------------------------------------------------------------------------");
                nlista.Add("UKUPNO ZAUZIMAJU : " + Math.Round(ukupnoVelicina1 / 1024, 5) + " Gigabytes");
                nlista.Add("-------------------------------------------------------------------------------");

                string[] array = nlista.ToArray(typeof(string)) as string[];

                    System.IO.File.WriteAllLines(putanjanova + "\\" + imenovogfilea + ".txt", array);
                Console.WriteLine(putanjanova + "\\" + imenovogfilea + ".txt");


                Console.WriteLine("-----------------------");
                Console.WriteLine(putanjanova + "\\" + imenovogfilea + ".txt ---- S N I M L J E N O");
            }

            




            Console.WriteLine("-----------------------");

            Console.WriteLine("E N D E");
            Console.ReadLine();

        }


        
        
    }
}
