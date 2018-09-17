using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace codjam
{
    class Program
    {
        static void Main(string[] args)
        {
            new CodeJam.CJ2008.QualificationRound().B();
        }
    }

    class CodeJam
    {
        public class CJ2008
        {
            public class QualificationRound
            {
                public void A()
                {
                    string[] lines = File.ReadAllLines(@"c:\users\thiago\source\repos\codjam\codjam\cj-2008\QualificationRound\A-large-practice.in");
                    var index = 0;
                    var n = int.Parse(lines[index++]);

                    var sb = new StringBuilder();
                    for (var t = 1; t <= n; t++)
                    {
                        var m = new List<string>();
                        var s = index + int.Parse(lines[index++]);

                        for (var i = index; index <= s; index++)
                            m.Add(lines[index]);

                        var w = new List<string>();
                        var q = index + int.Parse(lines[index++]);
                        for (var i = index; index <= q; index++)
                            w.Add(lines[index]);

                        if (w.Count == 0)
                        {
                            sb.AppendLine($"Case #{t}: 0");
                            continue;
                        }

                        if (m.Any(x => !w.Contains(x)))
                        {
                            sb.AppendLine($"Case #{t}: 0");
                            continue;
                        }

                        var countSwitch = 0;
                        while (w.Count > 0)
                        {
                            var b = w.Distinct().Last();

                            if (m.Any(x => !w.Contains(x)))
                            {
                                w.Clear();
                                break;
                            }

                            while (w.Count > 0)
                            {
                                if (w[0] != b)
                                    w.RemoveAt(0);
                                else
                                    break;
                            }
                            countSwitch++;
                        }
                        sb.AppendLine($"Case #{t}: {countSwitch}");
                    }

                    using (var sw = File.CreateText(@"c:\users\thiago\source\repos\codjam\codjam\cj-2008\QualificationRound\A-large-practice.out"))
                    {
                        sw.WriteLine(sb.ToString());
                    }
                }
                public void B(string size = "small")
                {
                    string[] lines = File.ReadAllLines($@"c:\users\thiago\source\repos\codjam\codjam\cj-2008\QualificationRound\B-{size}-practice.in");
                    var index = 0;
                    var ns = int.Parse(lines[index++]);
                    var sb = new StringBuilder();
                    for (var n = 1; n <= ns; n++)
                    {
                        var t = int.Parse(lines[index++]);
                        var ab = lines[index++].Split(' ');
                        var NA = int.Parse(ab[0]);
                        var NB = int.Parse(ab[1]);
                        var NAs = new List<B_Hours>();
                        var NBs = new List<B_Hours>();
                        for (var i = 0; i < NA + NB; i++)
                        {
                            ab = lines[index++].Split(' ');
                            if (NA > i)
                                NAs.Add(new B_Hours { start = TimeSpan.Parse(ab[0]), end = TimeSpan.Parse(ab[1]).Add(new TimeSpan(0, t, 0)), used = false });      
                            else
                                if (ab[1] == "23:59")
                                    NBs.Add(new B_Hours { start = TimeSpan.Parse(ab[0]), end = TimeSpan.Parse(ab[1]), used = false });
                                else
                                    NBs.Add(new B_Hours { start = TimeSpan.Parse(ab[0]), end = TimeSpan.Parse(ab[1]).Add(new TimeSpan(0, t, 0)), used = false });
                        }

                        NAs = NAs.OrderBy(o => o.end).ToList();
                        NBs = NBs.OrderBy(o => o.end).ToList();
                        foreach (var na in NAs)
                            foreach (var nb in NBs)
                                if (na.start >= nb.end && !nb.used)
                                {
                                    NA--;
                                    nb.used = true;
                                    break;
                                }

                        foreach (var nb in NBs)
                            foreach (var na in NAs)
                                if (nb.start >= na.end && !na.used)
                                {
                                    NB--;
                                    na.used = true;
                                    break;
                                }

                        sb.AppendLine($"Case #{n}: {NA} {NB}");
                    }

                    using (var sw = File.CreateText($@"c:\users\thiago\source\repos\codjam\codjam\cj-2008\QualificationRound\B-{size}-practice.out"))
                    {
                        sw.WriteLine(sb.ToString());
                    }
                }

                class B_Hours
                {
                    public TimeSpan start { get; set; }
                    public TimeSpan end { get; set; }
                    public bool used { get; set; }
                }
            }


        }

        public class CJ2009
        {
            public class QualificationRound
            {
                public void C()
                {
                    string[] lines = File.ReadAllLines(@"c:\users\thiago\source\repos\codjam\codjam\cj-2009\QualificationRound\C-small-practice.in");

                    var n = int.Parse(lines[0]);
                    var sb = new StringBuilder();
                    for (int i = 1; i < lines.Length; i++)
                    {
                        Console.WriteLine("\t" + lines[i]);

                        sb.Append($"Case #{i}: {1}");
                    }

                    using (var sw = File.CreateText(@"c:\users\thiago\source\repos\codjam\codjam\cj-2009\QualificationRound\C-small-practice.out"))
                    {
                        sw.WriteLine(sb.ToString());
                    }
                }
            }
        }
    }
}
