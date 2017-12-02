using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectRPG
{
    static public class Game
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainWindow = new ProjectRPG_MainForm());
        }

        public static void CreateGameWindow()
        {
            GameWindow = new GameWindow();
            GameWindow.ShowDialog();
        }

        public static Player Player = null;
        public static Weapon PlayerWeapon = null;
        public static Item PlayerHealthPotion = null;
        public static Item PlayerManaPotion = null;
        public static Weapon EnemyWeapon = null;
        public static GameWindow GameWindow = null;
        public static ProjectRPG_MainForm MainWindow = null;
        public static Enemy Enemy = null;
    }
}
