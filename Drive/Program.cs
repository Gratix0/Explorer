using System;

namespace Drive
{
    public class Program
    {
        static void Main(string[] argrs)
        {
            int a = Drives.Drivers();
            
            while (true)
            {
                int disk = Arrow.Move(a);
                if (disk == -1)
                {
                    Console.Clear();

                    if (Drives.lastPath.Count() == 1)
                    {
                        a = Drives.Drivers();
                        Drives.paths.Clear();

                        Arrow.pose = 0;
                    }
                    else if (Drives.lastPath.Count() > 1)
                    {
                        int len = Drives.lastPath.Count() - 1;

                        string last = Drives.lastPath[len - 1];

                        Drives.lastPath.RemoveAt(len);
                        Drives.lastPath.RemoveAt(len - 1);
                        Drives.getDrivers(last);

                        a = Drives.paths.Count();

                        Arrow.pose = 0;
                    }
                }
                else if (Drives.paths.Count() == 0)
                {
                    Console.Clear();
                    Drives.getDrivers(Drives.disks[0].Name);
                    a = Drives.paths.Count();
                }
                else
                {
                    Console.Clear();
                    Drives.getDrivers(Drives.paths[disk]);
                    a = Drives.paths.Count();
                    Arrow.pose = 0;

                }
                }
        }
    }
}