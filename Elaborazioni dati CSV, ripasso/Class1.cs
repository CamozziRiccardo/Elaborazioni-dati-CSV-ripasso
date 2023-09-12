using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elaborazioni_dati_CSV__ripasso
{
    internal class funzioni
    {
        public void Azione1()
        {
            Random r = new Random();
            string s;
            int i = 0;
            StreamWriter sw = new StreamWriter("camozzi1.csv", append: false);
            if (File.Exists("camozzi.csv"))
            {
                StreamReader sr = new StreamReader("camozzi.csv");
                s = sr.ReadLine();
                while (s != null)
                {
                    if (i == 0)
                    {
                        sw.WriteLine(s + ";MioValore;Cancellazione Logica;Campo Univoco");
                    }
                    else
                    {
                        sw.WriteLine(s + ";" + r.Next(10, 21) + ";true");
                    }
                    i++;
                    s = sr.ReadLine();
                }
                sr.Close();
            }
            sw.Close();
        }
        public int Azione2()
        {
            string s;
            int count;
            StreamReader sr = new StreamReader("camozzi1.csv");
            s = sr.ReadLine();
            sr.Close();
            return count = s.Split(';').Length;
        }

        public int Azione3()
        {
            StreamReader sr = new StreamReader("camozzi1.csv");
            int lung = 0, lungMax = 0, i = 0;
            string s;

            s = sr.ReadLine();
            while (s != null)
            {
                lung = s.Length;
                if (i != 0)
                {
                    if (lungMax < lung)
                    {
                        lungMax = s.Length;
                    }
                }
                s = sr.ReadLine();
                i++;
            }
            sr.Close();
            return lungMax;
        }

        public void Azione4()
        {
            string s;
            int i = 0;
            StreamReader sr = new StreamReader("camozzi1.csv");
            StreamWriter wr = new StreamWriter("temporaneo.csv");

            s = sr.ReadLine();
            while (s != null)
            {
                if (i != 0)
                {
                    wr.WriteLine(s.PadRight(200));
                }
                else
                {
                    wr.WriteLine(s.PadRight(200));
                }

                s = sr.ReadLine();
                i++;
            }

            sr.Close();
            wr.Close();

            File.Replace("temporaneo.csv", "camozzi1.csv", "backup.csv");
        }

        public void Azione5(string comune, string provincia, string regione, string nome, string anno, string dataEdOra, string identificatore, string longitudine, string latitudine)
        {
            int i = 0;
            StreamReader sr = new StreamReader("camozzi1.csv");
            string s = sr.ReadLine();
            while (s != null)
            {
                i++;
                s = sr.ReadLine();
            }
            sr.Close();
            var o = new FileStream("camozzi1.csv", FileMode.Append, FileAccess.Write, FileShare.Read);
            BinaryWriter wr = new BinaryWriter(o);
            string line = $"{comune};{provincia};{regione};{nome};{anno};{dataEdOra};{identificatore};{longitudine};{latitudine}".PadRight(200);
            byte[] data = Encoding.ASCII.GetBytes(line);
            wr.Write(data);

            wr.Close();
            o.Close();

            Azione1();
        }

        public int Azione7(string parola)
        {
            StreamReader sr = new StreamReader("camozzi1.csv");
            string s;
            int i = 0;
            s = sr.ReadLine();
            while (s != null)
            {
                String[] split = s.Split(';');
                String[] split1 = split[Azione2() - 1].Split(' ');

                if (split1[0] == parola)
                {
                    sr.Close();
                    return i;
                }
                i++;
                s = sr.ReadLine();
            }
            sr.Close();
            return -1;
        }

        public void Azione8(string comune, string provincia, string regione, string nome, string anno, string dataEdOra, string identificatore, string longitudine, string latitudine, string mioVal, string cancLog, int search)
        {
            var o = new FileStream("camozzi1.csv", FileMode.Open, FileAccess.Write, FileShare.Read);
            BinaryWriter sw = new BinaryWriter(o);

            o.Seek(0, SeekOrigin.Begin);
            o.Seek((200 * search), SeekOrigin.Current);
            string s = $"{comune};{provincia};{regione};{nome};{anno};{dataEdOra};{identificatore};{longitudine};{latitudine};{mioVal};{cancLog}".PadRight(200);
            byte[] data = Encoding.ASCII.GetBytes(s);
            sw.Write(data);

            sw.Close();
            o.Close();
        }

        public void Azione9(string regione)
        {
            int line = Azione7(regione);
            var rs = new FileStream("camozzi1.csv", FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryReader r = new BinaryReader(rs);

            //Legge i dati e li converte in stringa
            rs.Seek(0, SeekOrigin.Begin);
            rs.Seek(200 * line, SeekOrigin.Current);

            byte[] data = new byte[200];
            rs.Read(data, 0, 200);
            string s = Encoding.ASCII.GetString(data);

            rs.Close();
            r.Close();

            String[] split = s.Split(';');
            String[] split1 = split[10].Split(' ');

            var ws = new FileStream("camozzi1.csv", FileMode.Open, FileAccess.Write, FileShare.Write);
            BinaryWriter w = new BinaryWriter(ws);

            ws.Seek(0, SeekOrigin.Begin);
            ws.Seek((200 * line), SeekOrigin.Current);

            //Scrive i dati
            string newLine = $"{split[0]};{split[1]};{split[2]};{split[3]};{split[4]};{split[5]};{split[6]};{split[7]};{split[8]};{split[9]};true".PadRight(200);
            byte[] data2 = Encoding.ASCII.GetBytes(newLine);
            w.Write(data2);

            w.Close();
            ws.Close();
        }
    }
}
