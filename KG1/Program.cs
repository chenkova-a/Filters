using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
public static class Mask
{
    public static bool[,] map = new bool[3, 3];
    public static int SizeX = 3;
    public static int SizeY = 3;
    public static void Reload()
    {
        map = new bool[SizeX, SizeY];
        for (int i = 0; i < SizeX; i++)
        {
            for (int j = 0; j < SizeY; j++)
            {
                map[i, j] = false;
            }
        }
    }
}
namespace KG1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
