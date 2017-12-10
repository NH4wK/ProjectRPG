using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
/// <summary>
/// Name: Paul Jerrold Biglete
/// RedID: 8115430506
/// ProjectRPG - Game Class
/// </summary>
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
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainWindow = new ProjectRPG_MainForm());
        }

        public static void CreateGameWindow()
        {
            GameWindow = new GameWindow();
            GameWindow.ShowDialog();
        }

        /// <summary>
        /// My Global Variables/Objects
        /// </summary>
        public static Player Player = null;
        public static Weapon PlayerWeapon = null;
        public static Weapon PlayerWeaponTemp = null;
        public static Item PlayerHealthPotion = null;
        public static Item PlayerManaPotion = null;
        public static Item PlayerWeapRestorePotion = null;
        public static Weapon EnemyWeapon = null;
        public static GameWindow GameWindow = null;
        public static ProjectRPG_MainForm MainWindow = null;
        public static Enemy Enemy = null;
        public static List<Weapon> WeaponBox = new List<Weapon>();
        public static bool IsMusicPlaying = true;
        public static SoundPlayer SPlayer = new SoundPlayer(ProjectRPG.Properties.Resources.sawsquarenoise___03___Field_Force_neg25dB);
        public static SoundPlayer SPlayerMainMenu = new SoundPlayer(ProjectRPG.Properties.Resources.MenuClickneg20dB);
    }
}
