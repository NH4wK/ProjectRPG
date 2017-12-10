using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

/// <summary>
/// Name: Paul Jerrold Biglete
/// RedID: 8115430506
/// ProjectRPG - Game Window
/// </summary>
/// 
namespace ProjectRPG
{
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            //Play Game Battle Music
            Game.SPlayer.PlayLooping();

            //On Game Window Load
            EnemyInit();
            CharacterInit();
            InventoryInit();
            MenuInit();
        }

        /// <summary>
        /// Character Initalization
        /// Set Initial Health / Mana, and Update Labels with Initial Values
        /// Give Player, Starting Items and a Starting Weapon
        /// </summary>
        void CharacterInit()
        {
            Game.Player.SetHealthPool();
            Game.Player.SetManaPool();
            GW_ChName_Label.Text = Game.Player.Name;
            GW_HPVal_Label.Text = ($"{Convert.ToString(Game.Player.Health)} / {Convert.ToString(Game.Player.MaxHealth)}");
            GW_MPVal_Label.Text = ($"{Convert.ToString(Game.Player.Mana)} / {Convert.ToString(Game.Player.MaxMana)}");
            GW_XPVal_Label.Text = ($"{ Convert.ToString(Game.Player.Experience)} / 100");
            GW_LevelVal_Label.Text = Convert.ToString(Game.Player.LevelNumber);
            GW_StrVal_Label.Text = Convert.ToString(Game.Player.Strength);
            GW_IntelVal_Label.Text = Convert.ToString(Game.Player.Intelligence);
            GW_DexVal_Label.Text = Convert.ToString(Game.Player.Dexterity);
            GW_VitVal_Label.Text = Convert.ToString(Game.Player.Vitality);

            Game.PlayerHealthPotion = new HealthPotion();
            Game.PlayerManaPotion = new ManaPotion();
            Game.PlayerWeapRestorePotion = new WeapRestorePotion();

            //Randomly Choose a Weapon for the Player
            Random seed = new Random();
            int seedRand = seed.Next(0, 100);
            Random rand = new Random(seedRand);

            int randVal = rand.Next(0, 7);

            if (randVal == 0)
                Game.PlayerWeapon = new WarHammer(Game.Player.Strength);
            else if (randVal == 1)
                Game.PlayerWeapon = new Mace(Game.Player.Strength);
            else if (randVal == 2)
                Game.PlayerWeapon = new Broadsword(Game.Player.Strength, Game.Player.Dexterity);
            else if (randVal == 3)
                Game.PlayerWeapon = new Greatsword(Game.Player.Strength, Game.Player.Dexterity);
            else if (randVal == 4)
                Game.PlayerWeapon = new Katana(Game.Player.Strength, Game.Player.Dexterity);
            else if (randVal == 5)
                Game.PlayerWeapon = new SpellTome(Game.Player.Strength, Game.Player.Intelligence);
            else if (randVal == 6)
                Game.PlayerWeapon = new Staff(Game.Player.Strength, Game.Player.Intelligence);
            else
                Game.PlayerWeapon = null;

            //Add Initial Weapon to Inventory
            Game.WeaponBox.Add(Game.PlayerWeapon);
            GW_WeapSel_Combo.Items.Add(Game.PlayerWeapon.Name);
            GW_WeapSel_Combo.Text = Game.PlayerWeapon.Name;

            //Starting Items
            Game.PlayerHealthPotion.Quantity = 5;
            Game.PlayerManaPotion.Quantity = 5;
            Game.PlayerWeapRestorePotion.Quantity = 1;

            GW_Player_PicBox.Image = ProjectRPG.Properties.Resources.Player_Idle;
            PlayerWeaponUpdate();
        }

        /// <summary>
        /// UI Menu Initialization
        /// Hide Weapon Panel, Inventory Panel, Game Status Panel and Boss Encounter Panel
        /// </summary>
        void MenuInit()
        {
            //Hide Panels for Initial State of Game
            GW_Weapon_Panel.Hide();
            GW_Inventory_Panel.Hide();
            GW_GameStatus_Panel.Hide();
            GW_Boss_Encounter_Panel.Hide();

            //ToolTip Init
            GW_ToolTips.SetToolTip(GW_ExecMove_Button, "Attack the Enemy!");
            GW_ToolTips.SetToolTip(GW_Attack_Button, "Choose an attack!");
            GW_ToolTips.SetToolTip(GW_Defend_Button, "Take a defensive stance! (Take 50% less damage)");
            GW_ToolTips.SetToolTip(GW_Retreat_Button, "Run away and fight a different foe!");
            GW_ToolTips.SetToolTip(GW_Items_Button, "Open Inventory");
            GW_ToolTips.SetToolTip(GW_HPPotUse_Button, $"{Game.PlayerHealthPotion.EffectDescription}");
            GW_ToolTips.SetToolTip(GW_MPPotUse_Button, $"{Game.PlayerManaPotion.EffectDescription}");
            GW_ToolTips.SetToolTip(GW_WRPotUse_Button, $"{Game.PlayerWeapRestorePotion.EffectDescription}");
            GW_ToolTips.SetToolTip(GW_WeapEquip_Button, "Equip the selected weapon!");
            GW_ToolTips.SetToolTip(GW_WeapMove1_RadButton, $"{Game.PlayerWeapon.Move1Description}");
            GW_ToolTips.SetToolTip(GW_WeapMove2_RadButton, $"{Game.PlayerWeapon.Move2Description}");
            GW_ToolTips.SetToolTip(GW_WeapMove3_RadButton, $"{Game.PlayerWeapon.Move3Description}");
            GW_ToolTips.SetToolTip(GW_WeapMove4_RadButton, $"{Game.PlayerWeapon.Move4Description}");
            GW_ToolTips.SetToolTip(GW_Boss_Yes_Button, $"Fight the Boss!");
            GW_ToolTips.SetToolTip(GW_Boss_No_Button, $"Continue fighting regular enemies.");

            //Beginning Message in Battle Log
            GW_BattleAction_TextBox.Text += ($"ProjectRPG - {Game.Player.Name} {Environment.NewLine} - Attack the Enemy!");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();
        }

        /// <summary>
        /// Inventory Initialization
        /// Update Item Quantity Labels
        /// </summary>
        void InventoryInit()
        {
            GW_QuantHPot_Label.Text = $"Quantity: {Game.PlayerHealthPotion.Quantity}";
            GW_QuantMPot_Label.Text = $"Quantity: {Game.PlayerManaPotion.Quantity}";
            GW_QuantWRPot_Label.Text = $"Quantity: {Game.PlayerWeapRestorePotion.Quantity}";
        }

        /// <summary>
        /// Initial Enemy Initialization
        /// Sets up the first enemy.
        /// </summary>
        void EnemyInit()
        {
            Game.Enemy = new Enemy();
            Game.Enemy.GenerateEnemy();

            //Hide Enemy Damaged and Boss Picture Boxes
            GW_Enemy_PicBox.Image = ProjectRPG.Properties.Resources.Enemy_Idle;

            GW_EnemyName_Label.Text = Game.Enemy.Name;
            GW_EnemyHealthVal_Label.Text = ($"{Convert.ToString(Game.Enemy.Health)} / {Convert.ToString(Game.Enemy.MaxHealth)}");
            GW_EnemyTypeVal_Label.Text = Game.Enemy.Type;
            GW_EnemyStrVal_Label.Text = Convert.ToString(Game.Enemy.Strength);
            GW_EnemyIntelVal_Label.Text = Convert.ToString(Game.Enemy.Intelligence);
            GW_EnemyDexVal_Label.Text = Convert.ToString(Game.Enemy.Dexterity);
            GW_EnemyVitVal_Label.Text = Convert.ToString(Game.Enemy.Vitality);
            GW_EnemyWeap_Label.Text = $"Weapon: {Game.EnemyWeapon.Name}";
        }


        /// <summary>
        /// Updates Inventory
        /// </summary>
        void InventoryUpdate()
        {
            if (Game.PlayerHealthPotion.Quantity == 0) //if HP Quantity is 0, disable HP Use button, otherwise enabled
                GW_HPPotUse_Button.Enabled = false;
            else
                GW_HPPotUse_Button.Enabled = true;

            if (Game.PlayerManaPotion.Quantity == 0) //if MP Quantity is 0, disable MP Use button, otherwise enabled
                GW_MPPotUse_Button.Enabled = false;
            else
                GW_MPPotUse_Button.Enabled = true;

            if (Game.PlayerWeapRestorePotion.Quantity == 0) //if WRP Quantity is 0, disable WRP button, otherwise enabled
                GW_WRPotUse_Button.Enabled = false;
            else
                GW_WRPotUse_Button.Enabled = true;

            if (Game.PlayerHealthPotion.Quantity > 999) //if HP Quantity exceeds 999 then keep it at 999
                Game.PlayerHealthPotion.Quantity = 999;

            if (Game.PlayerManaPotion.Quantity > 999) //if MP Quantity exceeds 999 then keep it at 999
                Game.PlayerManaPotion.Quantity = 999;

            if (Game.PlayerWeapRestorePotion.Quantity > 999) //if WRP Quantity exceeds 999 then keep it at 999
                Game.PlayerWeapRestorePotion.Quantity = 999;

            //Update Quantity Labels
            GW_QuantHPot_Label.Text = $"Quantity: {Game.PlayerHealthPotion.Quantity}";
            GW_QuantMPot_Label.Text = $"Quantity: {Game.PlayerManaPotion.Quantity}";
            GW_QuantWRPot_Label.Text = $"Quantity: {Game.PlayerWeapRestorePotion.Quantity}";
        }

        /// <summary>
        /// Player Weapon Update
        /// Updates Labels and updates weapon stats/damage
        /// </summary>
        void PlayerWeaponUpdate()
        {
            if ((Game.Player.Mana < (int)(Game.Player.MaxMana * 0.20)) && Game.PlayerWeapon.ElementType == "Magic")
            {
                GW_WeapMove1_RadButton.Enabled = false;
                GW_WeapMove2_RadButton.Enabled = false;
                GW_WeapMove3_RadButton.Enabled = false;
            }
            else
            {
                GW_WeapMove1_RadButton.Enabled = true;
                GW_WeapMove2_RadButton.Enabled = true;
                GW_WeapMove3_RadButton.Enabled = true;
            }

            if ((Game.Player.Mana < (int)(Game.Player.MaxMana * 0.50)) && Game.PlayerWeapon.ElementType == "Magic")
            {
                GW_WeapMove4_RadButton.Enabled = false;
            }
            else
            {
                GW_WeapMove4_RadButton.Enabled = true;
            }

            //Update Labels
            GW_WeaponName_Label.Text = $"{Game.PlayerWeapon.Name} | ({Game.PlayerWeapon.ElementType})";
            GW_WeapMove1_RadButton.Text = Game.PlayerWeapon.Move1Name;
            GW_WeapMove2_RadButton.Text = Game.PlayerWeapon.Move2Name;
            GW_WeapMove3_RadButton.Text = Game.PlayerWeapon.Move3Name;
            GW_WeapMove4_RadButton.Text = Game.PlayerWeapon.Move4Name;

            GW_M1AmmoCount_Label.Text = $"{Convert.ToString(Game.PlayerWeapon.Move1Ammo)} / {Convert.ToString(Game.PlayerWeapon.Move1MaxAmmo)}";
            GW_M2AmmoCount_Label.Text = $"{Convert.ToString(Game.PlayerWeapon.Move2Ammo)} / {Convert.ToString(Game.PlayerWeapon.Move2MaxAmmo)}";
            GW_M3AmmoCount_Label.Text = $"{Convert.ToString(Game.PlayerWeapon.Move3Ammo)} / {Convert.ToString(Game.PlayerWeapon.Move3MaxAmmo)}";
            GW_M4AmmoCount_Label.Text = $"{Convert.ToString(Game.PlayerWeapon.Move4Ammo)} / {Convert.ToString(Game.PlayerWeapon.Move4MaxAmmo)}";



            //Update Weapon Stats
            if ((Game.PlayerWeapon is WarHammer) || (Game.PlayerWeapon is Mace))
                Game.PlayerWeapon.UpdateWeapon(Game.Player.Strength);
            else if ((Game.PlayerWeapon is Broadsword) || (Game.PlayerWeapon is Greatsword) || (Game.PlayerWeapon is Katana))
                Game.PlayerWeapon.UpdateWeapon(Game.Player.Strength, 0, Game.Player.Dexterity);
            else if ((Game.PlayerWeapon is SpellTome) || (Game.PlayerWeapon is Staff))
                Game.PlayerWeapon.UpdateWeapon(Game.Player.Strength, Game.Player.Intelligence, 0);
            else
                Game.PlayerWeapon.UpdateWeapon(Game.Player.Strength, Game.Player.Intelligence, Game.Player.Dexterity);
        }

        /// <summary>
        /// Player Update
        /// -Check if Player is Dead
        /// -Check if Player is over a 100 XP to Level Up
        /// -Check if Player is at 50% Health to update Player Picture Box
        /// -Update Labels and Progress Bars
        /// </summary>
        void PlayerUpdate()
        {
            //Death Condition (Defeated by Enemy)
            if (Game.Player.Health <= 0)
            {
                Game.Player.Health = 0; //if Player is at 0 or below 0 health, set player health to 0
                GW_HPVal_Label.Text = Convert.ToString(Game.Player.Health); //Update Label
                
                //Show a message to the user in the Battle Log Panel that the player has died and has been revived.
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} has been slained by {Game.Enemy.Name}!");
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine} You have been revived by an unknown force, you feel weaker... (Stats reduced by 10%)");
                GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
                GW_BattleAction_TextBox.ScrollToCaret();

                //If Player's Stats are above 10 decrease by 10%, otherwise decrease by 1.
                if (Game.Player.Strength >= 10 || Game.Player.Intelligence >= 10 || Game.Player.Dexterity >= 10 || Game.Player.Vitality >= 10)
                {
                    Game.Player.Strength -= (int)(Game.Player.Strength * 0.10); 
                    Game.Player.Intelligence -= (int)(Game.Player.Intelligence * 0.10);
                    Game.Player.Dexterity -= (int)(Game.Player.Dexterity * 0.10);
                    Game.Player.Vitality -= (int)(Game.Player.Vitality * 0.10);
                }
                else
                {
                    Game.Player.Strength -= 1;
                    Game.Player.Intelligence -= 1;
                    Game.Player.Dexterity -= 1;
                    Game.Player.Vitality -= 1;
                }

                //If Player stats are less than or equal 0, keep it at 0
                if (Game.Player.Strength <= 0)
                    Game.Player.Strength = 0;

                if (Game.Player.Intelligence <= 0)
                    Game.Player.Intelligence = 0;

                if (Game.Player.Dexterity <= 0)
                    Game.Player.Dexterity = 0;

                if (Game.Player.Vitality <= 0)
                    Game.Player.Vitality = 0;

                //Lose Condition, when all Player's stats are zero, call Game Over function
                if ((Game.Player.Strength + Game.Player.Intelligence + Game.Player.Dexterity + Game.Player.Vitality) == 0)
                {
                    GameOver();
                }

                //Update Health and Mana
                Game.Player.SetHealthPool();
                Game.Player.SetManaPool();
            }

            //if Player exceeds a 100 XP, gain a level
            if (Game.Player.Experience >= 100 && (Game.Player.LevelNumber < 999))
            {
                if (Game.Player.Experience >= 100)
                    Game.Player.Experience = Game.Player.Experience - 100;
                else
                    Game.Player.Experience = 0;

                Game.Player.LevelUp();
            }

            //Player is under 50% health, flash red. Otherwise use normal idle.
            if (Game.Player.Health <= (Game.Player.MaxHealth / 2))
            {
                GW_Player_PicBox.Image = ProjectRPG.Properties.Resources.Player_Damaged;
            }
            else
            {
                GW_Player_PicBox.Image = ProjectRPG.Properties.Resources.Player_Idle;
            }

            //Update Progress Bar to Represent Health
            GW_Player_Health_ProgBar.Maximum = Game.Player.MaxHealth;
            GW_Player_Health_ProgBar.Minimum = 0;
            if (Game.Player.Health <= 0)
                GW_Player_Health_ProgBar.Value = 0;
            else
                GW_Player_Health_ProgBar.Value = Game.Player.Health;

            //Update Progress Bar to Represent Mana
            GW_Player_Mana_ProgBar.Maximum = Game.Player.MaxMana;
            GW_Player_Mana_ProgBar.Minimum = 0;
            if(Game.Player.Mana <= 0)
                GW_Player_Mana_ProgBar.Value = 0;
            else
                GW_Player_Mana_ProgBar.Value = Game.Player.Mana;

            //Update Player's weapon stats
            PlayerWeaponUpdate();

            //Update Labels
            GW_HPVal_Label.Text = ($"{Convert.ToString(Game.Player.Health)} / {Convert.ToString(Game.Player.MaxHealth)}");
            GW_MPVal_Label.Text = ($"{Convert.ToString(Game.Player.Mana)} / {Convert.ToString(Game.Player.MaxMana)}");
            GW_XPVal_Label.Text = ($"{ Convert.ToString(Game.Player.Experience)} / 100");
            GW_LevelVal_Label.Text = Convert.ToString(Game.Player.LevelNumber);
            GW_StrVal_Label.Text = Convert.ToString(Game.Player.Strength);
            GW_IntelVal_Label.Text = Convert.ToString(Game.Player.Intelligence);
            GW_DexVal_Label.Text = Convert.ToString(Game.Player.Dexterity);
            GW_VitVal_Label.Text = Convert.ToString(Game.Player.Vitality);
        }

        /// <summary>
        /// Enemy Update
        /// </summary>
        void EnemyUpdate()
        {
            //Check if to see if Enemy is a Boss, update Enemy Picture Box
            if (Game.Enemy.IsBoss)
            {
                GW_Enemy_PicBox.Image = ProjectRPG.Properties.Resources.Enemy_Boss_Idle;
            }

            //Update Enemy Labels
            GW_EnemyName_Label.Text = Game.Enemy.Name;
            GW_EnemyHealthVal_Label.Text = ($"{Convert.ToString(Game.Enemy.Health)} / {Convert.ToString(Game.Enemy.MaxHealth)}");
            GW_EnemyTypeVal_Label.Text = Game.Enemy.Type;
            GW_EnemyStrVal_Label.Text = Convert.ToString(Game.Enemy.Strength);
            GW_EnemyIntelVal_Label.Text = Convert.ToString(Game.Enemy.Intelligence);
            GW_EnemyDexVal_Label.Text = Convert.ToString(Game.Enemy.Dexterity);
            GW_EnemyVitVal_Label.Text = Convert.ToString(Game.Enemy.Vitality);
            GW_EnemyWeap_Label.Text = $"Weapon: {Game.EnemyWeapon.Name}";

            //Update Enemy's weapon stats
            if ((Game.EnemyWeapon is WarHammer) || (Game.EnemyWeapon is Mace))
                Game.EnemyWeapon.UpdateWeapon(Game.Enemy.Strength);
            else if ((Game.EnemyWeapon is Broadsword) || (Game.EnemyWeapon is Greatsword) || (Game.EnemyWeapon is Katana))
                Game.EnemyWeapon.UpdateWeapon(Game.Enemy.Strength, 0, Game.Enemy.Dexterity);
            else if ((Game.EnemyWeapon is SpellTome) || (Game.EnemyWeapon is Staff))
                Game.EnemyWeapon.UpdateWeapon(Game.Enemy.Strength, Game.Enemy.Intelligence, 0);
            else
                Game.EnemyWeapon.UpdateWeapon(Game.Enemy.Strength, Game.Enemy.Intelligence, Game.Enemy.Dexterity);

            //if Enemy / Boss is at half health, update there picture boxes, otherwise show regular picturebox 
            if ((Game.Enemy.Health <= (Game.Enemy.MaxHealth / 2)) && Game.Enemy.IsBoss)
            {
                GW_Enemy_PicBox.Image = ProjectRPG.Properties.Resources.Enemy_Boss_Damage;
            }
            else if (Game.Enemy.Health <= (Game.Enemy.MaxHealth / 2))
            {
                GW_Enemy_PicBox.Image = ProjectRPG.Properties.Resources.Enemy_Damage;
            }
            else
            {
                if (Game.Enemy.IsBoss)
                {
                    GW_Enemy_PicBox.Image = ProjectRPG.Properties.Resources.Enemy_Boss_Idle;
                }
                else
                {
                    GW_Enemy_PicBox.Image = ProjectRPG.Properties.Resources.Enemy_Idle;
                }
            }

            //Update Enemy Health Bar
            GW_Enemy_Health_ProgBar.Maximum = Game.Enemy.MaxHealth;
            GW_Enemy_Health_ProgBar.Minimum = 0;
            if (Game.Enemy.Health <= 0)
                GW_Enemy_Health_ProgBar.Value = 0;
            else
                GW_Enemy_Health_ProgBar.Value = Game.Enemy.Health;
        }

        /// <summary>
        /// Opens up Boss Encounter Dialog Box
        /// </summary>
        void BossEncounterDialogBox()
        {
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine} A dark energy is present!");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();

            //Show Panel and Disable Attack, Defend, Items, Retreat buttons and Hide Weapon and Inventory Panel
            GW_Boss_Encounter_Panel.Show();
            GW_Attack_Button.Enabled = false;
            GW_Defend_Button.Enabled = false;
            GW_Items_Button.Enabled = false;
            GW_Retreat_Button.Enabled = false;
            GW_Inventory_Panel.Hide();
            GW_Weapon_Panel.Hide();
        }

        /// <summary>
        /// Opens up the Game Status Panel and sets the correct text
        /// </summary>
        void GameOver()
        {
            GW_Player_PicBox.Hide();

            GW_GameStatus_Panel.Show();
            GW_Game_Status_Primary_Label.Text = "Game Over";
            GW_Game_Status_Secondary_Label.Text = "Your soul is beyond repair, your existence slowly withers away...";
            GW_Attack_Button.Enabled = false;
            GW_Defend_Button.Enabled = false;
            GW_Items_Button.Enabled = false;
            GW_Retreat_Button.Enabled = false;
            GW_Inventory_Panel.Hide();
            GW_Weapon_Panel.Hide();
        }

        /// <summary>
        /// Opens up the Game Status Panel and sets the correct text
        /// </summary>
        void GameWon()
        {
            GW_Enemy_PicBox.Hide();

            GW_GameStatus_Panel.Show();
            GW_Game_Status_Primary_Label.Text = "Victory!";
            GW_Game_Status_Secondary_Label.Text = "You have defeated the Final Boss.";
            GW_Attack_Button.Enabled = false;
            GW_Defend_Button.Enabled = false;
            GW_Items_Button.Enabled = false;
            GW_Retreat_Button.Enabled = false;
            GW_Inventory_Panel.Hide();
            GW_Weapon_Panel.Hide();
        }

        /// <summary>
        /// Function that takes care of Player Attack
        /// </summary>
        void PlayerAttack()
        {
            int pDamage = 0;

            if (GW_WeapMove1_RadButton.Checked) //if Weapon Move 1 is selected, set pDamage to Move 1 Damge and reduce Move 1 Ammo by 1
            {
                if (Game.PlayerWeapon.Move1Ammo > 0) 
                {
                    if (Game.PlayerWeapon.ElementType == "Magic") //if Magic type weapon, reduce Mana by 20%
                    {
                        pDamage = Game.PlayerWeapon.Move1Damage;
                        Game.Player.Mana -= (int)(Game.Player.MaxMana * 0.20);
                        Game.PlayerWeapon.Move1Ammo -= 1;

                    }
                    else
                    {
                        pDamage = Game.PlayerWeapon.Move1Damage;
                        Game.PlayerWeapon.Move1Ammo -= 1;
                    }
                }
            }
            else if (GW_WeapMove2_RadButton.Checked) //if Weapon Move 2 is selected, set pDamage to Move 2 Damage and reduce Move 2 Ammo by 1
            {
                if (Game.PlayerWeapon.Move2Ammo > 0)
                {
                    if (Game.PlayerWeapon.ElementType == "Magic") //if Magic Type weapon, reduce Mana by 20%
                    {
                        pDamage = Game.PlayerWeapon.Move2Damage;
                        Game.Player.Mana -= (int)(Game.Player.MaxMana * 0.20);
                        Game.PlayerWeapon.Move2Ammo -= 1;
                    }
                    else
                    {
                        pDamage = Game.PlayerWeapon.Move2Damage;
                        Game.PlayerWeapon.Move2Ammo -= 1;
                    }
                }
            }
            else if (GW_WeapMove3_RadButton.Checked) //if Weapon Move 3 is selected, set pDamage to Move 3 Damage and reduce Move 3 Ammo by 1
            {
                if (Game.PlayerWeapon.Move3Ammo > 0)
                {
                    if (Game.PlayerWeapon.ElementType == "Magic") //if Magic Type weapon, reduce Mana by 20%
                    {
                        pDamage = Game.PlayerWeapon.Move3Damage;
                        Game.Player.Mana -= (int)(Game.Player.MaxMana * 0.20);
                        Game.PlayerWeapon.Move3Ammo -= 1;

                    }
                    else
                    {
                        pDamage = Game.PlayerWeapon.Move1Damage;
                        Game.PlayerWeapon.Move3Ammo -= 1;
                    }
                }
            }
            else if (GW_WeapMove4_RadButton.Checked) //if Weapon Move 3 is selected, set pDamage to Move 4 Damage and reduce Move 4 Ammo by 1
            {
                if (Game.PlayerWeapon.Move4Ammo > 0)
                {
                    if (Game.PlayerWeapon.ElementType == "Magic") //if Magic Type weapon reduce mana by 50%
                    {
                        pDamage = Game.PlayerWeapon.Move4Damage;
                        Game.Player.Mana -= (int)(Game.Player.MaxMana * 0.50);
                        Game.PlayerWeapon.Move4Ammo -= 1;
                    }
                    else
                    {
                        pDamage = Game.PlayerWeapon.Move4Damage;
                        Game.PlayerWeapon.Move4Ammo -= 1;
                    }
                }
            }
            else //Otherwise pDamage = 0
            {
                pDamage = 0;
            }

            int ElementalDamage = 0;

            //Calculate and Add Elemental Damage
            if (Game.PlayerWeapon.ElementType == "Fire" && (Game.Enemy.Type == "Ice"))
                ElementalDamage = (int)(Game.Enemy.MaxHealth * 0.15);
            else if (Game.PlayerWeapon.ElementType == "Holy" && (Game.Enemy.Type == "Undead" || Game.Enemy.Type == "Demon" || Game.Enemy.Type == "Raging Demon"))
                ElementalDamage = (int)(Game.Enemy.MaxHealth * 0.12);
            else if (Game.PlayerWeapon.ElementType == "Normal" && (Game.Enemy.Type == "Normal"))
                ElementalDamage = (int)(Game.Enemy.MaxHealth * 0.10);
            else if (Game.PlayerWeapon.ElementType == "Wind" && (Game.Enemy.Type == "Spirit" || Game.Enemy.Type == "Fire"))
                ElementalDamage = (int)(Game.Enemy.MaxHealth * 0.12);
            else if (Game.PlayerWeapon.ElementType == "Thunder" && (Game.Enemy.Type == "Water"))
                ElementalDamage = (int)(Game.Enemy.MaxHealth * 0.12);
            else if (Game.PlayerWeapon.ElementType == "Magic")
                ElementalDamage = (int)(Game.Enemy.MaxHealth * 0.10);
            else
                ElementalDamage = 0;

            //if pDamage is negative or Player is at Max Level
            if (pDamage < 0 || Game.Player.LevelNumber == 999)
                pDamage = Game.Enemy.Health;

            Game.Enemy.Health -= pDamage + ElementalDamage; //Subtract pDamage from Enemy Health

            //Show how much damage the player did to the enemy in the battle log
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} attacked {Game.Enemy.Name} for {pDamage} Damage (+{ElementalDamage} {Game.PlayerWeapon.ElementType})!");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();

            //Update Label
            GW_EnemyHealthVal_Label.Text = ($"{Convert.ToString(Game.Enemy.Health)} / {Convert.ToString(Game.Enemy.MaxHealth)}");
        }
        /// <summary>
        /// Enemy Attack Function
        /// </summary>
        void EnemyAttack()
        {
            int eDamage = Game.Enemy.Attack();

            //if Player is at Max Level 999, Enemy Damage = 0
            if (Game.Player.LevelNumber == 999)
                eDamage = 0;

            Game.Player.Health -= eDamage;

            //Show damage done to the player
            if (eDamage == 0)
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Enemy.Name} missed their attack! ({eDamage} Damage Taken!)");
            else
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Enemy.Name} attacked {Game.Player.Name} for {eDamage} Damage!");

            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();
        }

        /// <summary>
        /// Check to see if the Enemy is dead
        /// </summary>
        void IsEnemyKilled()
        {
            //Enemy Killed
            if (Game.Enemy.Health <= 0)
            {
                Game.Enemy.Health = 0; //Set enemmy health to 0 if Enemy Health is at 0 or negative
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Enemy.Name} has been slained. You have absorbed {Game.Enemy.Name}'s power!");
                GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
                GW_BattleAction_TextBox.ScrollToCaret();

                if (Game.Player.LevelNumber < 999)
                {
                    //if Enemy Stats are below 10, increase player stats by 3, otherwise increase there stats by 25% of the Defeated Enemy Stats
                    if (Game.Enemy.Strength < 10)
                        Game.Player.Strength += 3;
                    else
                        Game.Player.Strength += (int)(Game.Enemy.Strength * 0.25);

                    if (Game.Enemy.Intelligence < 10)
                        Game.Player.Intelligence += 3;
                    else               
                        Game.Player.Intelligence += (int)(Game.Enemy.Intelligence * 0.25);

                    if (Game.Enemy.Dexterity < 10)
                        Game.Player.Dexterity += 3;
                    else
                        Game.Player.Dexterity += (int)(Game.Enemy.Dexterity * 0.25);

                    if (Game.Enemy.Vitality < 10)
                        Game.Player.Vitality += 3;
                    else
                        Game.Player.Vitality += (int)(Game.Enemy.Vitality * 0.25);

                    //If Player stats exceed the 999 max, keep it at that max.
                    if (Game.Player.Strength > 999)
                        Game.Player.Strength = 999;
                    if (Game.Player.Intelligence > 999)
                        Game.Player.Intelligence = 999;
                    if (Game.Player.Dexterity > 999)
                        Game.Player.Dexterity = 999;
                    if (Game.Player.Vitality > 999)
                        Game.Player.Vitality = 999;

                    Random ranVal = new Random();
                    int valXP = ranVal.Next(50, 76);
                    Game.Player.Experience += valXP;

                    Game.Player.SetHealthPool();
                    Game.Player.SetManaPool();
                }

                //Increment Kill Count
                Game.Player.KillCount += 1;
                GW_PlayerKillCount_Label.Text = ($"Kills: {Game.Player.KillCount}");

                //Update Boss Encounter Bar
                GW_BossEncounter_ProgBar.Value += 1;

                if (GW_BossEncounter_ProgBar.Value == 10)
                    GW_BossEncounter_ProgBar.Value = 0;

                //if a Boss was Killed
                if (Game.Enemy.IsBoss)
                {
                    PlayerUpdate();
                    EnemyUpdate();
                    GameWon();
                    return;
                }

                //Drop Items for the Player
                EnemyDropItems();

                //Generate a New Enemy
                Game.Enemy.GenerateEnemy();

                //Every 10 Kills open up Boss Encounter Dialog Box
                if (Game.Player.KillCount % 10 == 0)
                {
                    BossEncounterDialogBox();
                }

                PlayerUpdate();
                EnemyUpdate();
            }
        }

        /// <summary>
        /// Drop Items for the Player
        /// </summary>
        void EnemyDropItems()
        {
            Random seed = new Random();
            int seedRand = seed.Next(0, 100);
            Random ranVal = new Random(seedRand);

            int value1 = ranVal.Next(1, 4);
            int value2 = ranVal.Next(1, 4);

            //Add a random number of potion to the player's inventory
            Game.PlayerHealthPotion.Quantity += value1;
            Game.PlayerManaPotion.Quantity += value2;

            //Show the player how many potions dropped
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}        {value1} Health Potion(s) has been added to your Inventory!");
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}        {value2} Mana Potion(s) has been added to your Inventory!");

            //Drop a random weapon
            WeaponDrop();

            if (Game.Player.KillCount % 3 == 0) //Every 4 kills drop a weapon restore potion
            {
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}        A Weapon Restore Potion has been added to your Inventory!");
                Game.PlayerWeapRestorePotion.Quantity += 3;
            }

            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();

            InventoryUpdate();
        }
        void WeaponDrop()
        {
            //Randomly drop a weapon for the Player
            Random rand = new Random();
            int randVal = rand.Next(0, 7);

            if (randVal == 0)
                Game.PlayerWeaponTemp = new WarHammer(Game.Player.Strength);
            else if (randVal == 1)
                Game.PlayerWeaponTemp = new Mace(Game.Player.Strength);
            else if (randVal == 2)
                Game.PlayerWeaponTemp = new Broadsword(Game.Player.Strength, Game.Player.Dexterity);
            else if (randVal == 3)
                Game.PlayerWeaponTemp = new Greatsword(Game.Player.Strength, Game.Player.Dexterity);
            else if (randVal == 4)
                Game.PlayerWeaponTemp = new Katana(Game.Player.Strength, Game.Player.Dexterity);
            else if (randVal == 5)
                Game.PlayerWeaponTemp = new SpellTome(Game.Player.Strength, Game.Player.Intelligence);
            else if (randVal == 6)
                Game.PlayerWeaponTemp = new Staff(Game.Player.Strength, Game.Player.Intelligence);
            else
                Game.PlayerWeaponTemp = null;

            
            Game.WeaponBox.Add(Game.PlayerWeaponTemp); //Add PlayerWeaponTemp to the list of weapons
            GW_WeapSel_Combo.Items.Add(Game.PlayerWeaponTemp.Name); //Add the Name of the Weapon into the Combobox Item List
            GW_WeapSel_Combo.Text = Game.PlayerWeaponTemp.Name; //Set Combo text to the name of the weapon that dropped

            //show the player what weapon dropped
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}        [{Game.PlayerWeaponTemp.Name}] has been added to your Inventory!");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();
        }

        private void GW_Attack_Button_Click(object sender, EventArgs e)
        {
            GW_ExecMove_Button.Enabled = false;
            GW_WeapMove1_RadButton.Checked = false;
            GW_WeapMove2_RadButton.Checked = false;
            GW_WeapMove3_RadButton.Checked = false;
            GW_WeapMove4_RadButton.Checked = false;

            if (!GW_Weapon_Panel.Visible)
            {
                GW_Weapon_Panel.Show();
                GW_Inventory_Panel.Hide();
            }
            else
                GW_Weapon_Panel.Hide();
        }
        private void GW_Items_Button_Click(object sender, EventArgs e)
        {
            if (!GW_Inventory_Panel.Visible)
            {
                GW_Inventory_Panel.Show();
                GW_Weapon_Panel.Hide();
            }
            else
                GW_Inventory_Panel.Hide();
        }
        private void GW_ExecMove_Button_Click(object sender, EventArgs e)
        {
            //Player Attack Turn
            PlayerAttack();

            //Check to see if Enemy is dead
            IsEnemyKilled();

            //Enemy Attack Turn
            EnemyAttack();

            //Update Enemy and Player
            EnemyUpdate();
            PlayerUpdate();
            PlayerWeaponUpdate();
        }

        private void GW_WeapMove1_RadButton_CheckedChanged(object sender, EventArgs e)
        {
            GW_ExecMove_Button.Enabled = true;
        }

        private void GW_WeapMove2_RadButton_CheckedChanged(object sender, EventArgs e)
        {
            GW_ExecMove_Button.Enabled = true;
        }

        private void GW_WeapMove3_RadButton_CheckedChanged(object sender, EventArgs e)
        {
            GW_ExecMove_Button.Enabled = true;
        }

        private void GW_WeapMove4_RadButton_CheckedChanged(object sender, EventArgs e)
        {
            GW_ExecMove_Button.Enabled = true;
        }

        private void GW_Defend_Button_Click(object sender, EventArgs e)
        {
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} goes into a defensive stance! (50% Damage Taken)");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();
           
            int eDamage = Game.Enemy.Attack() / 2;

            if (Game.Player.LevelNumber == 999)
                eDamage = 0;

            Game.Player.Health -= eDamage; 

            if (eDamage == 0)
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Enemy.Name} missed their attack! ({eDamage} Damage Taken!)");
            else
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Enemy.Name} attacked {Game.Player.Name} for {eDamage} Damage!");

            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();

            PlayerUpdate();
        }

        private void GW_Retreat_Button_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int randVal = rand.Next(1, 5);
            if (randVal > 1)
            {
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} has successfully retreated!");
                Game.Enemy.GenerateEnemy();
                EnemyUpdate();

                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Enemy.Name} has appeared!");
                GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
                GW_BattleAction_TextBox.ScrollToCaret();
            }
            else
            {
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} has failed to flee away!");
                GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
                GW_BattleAction_TextBox.ScrollToCaret();

                EnemyAttack();
                PlayerUpdate();
            }

        }

        private void GW_HPPotUse_Button_Click(object sender, EventArgs e)
        {
            Game.PlayerHealthPotion.Use();
            GW_QuantHPot_Label.Text = $"Quantity: {Game.PlayerHealthPotion.Quantity}";
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} has used a Health Potion! Restored {Game.Player.MaxHealth * 0.50} Health");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();

            PlayerUpdate();
            InventoryUpdate();
        }

        private void GW_MPPotUse_Button_Click(object sender, EventArgs e)
        {
            Game.PlayerManaPotion.Use();
            GW_QuantMPot_Label.Text = $"Quantity: {Game.PlayerManaPotion.Quantity}";
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} has used a Mana Potion! Restored {Game.Player.MaxMana * 0.50} Mana");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();

            PlayerUpdate();
            InventoryUpdate();
        }

        private void GW_WeapEquip_Button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Game.WeaponBox.Count; i++)
            {
                if ((GW_WeapSel_Combo.SelectedItem.ToString()) == Game.WeaponBox[i].Name) //Selected Weapon == Weapon Name in Weapon Box
                {
                    Game.PlayerWeapon = Game.WeaponBox[i]; //equip the corresponding weapon
                    PlayerWeaponUpdate();
                }
            }

            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} has equipped {Game.PlayerWeapon.Name}!");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();
        }

        private void GW_WRPotUse_Button_Click(object sender, EventArgs e)
        {
            Game.PlayerWeapRestorePotion.Use();
            GW_QuantWRPot_Label.Text = $"Quantity: {Game.PlayerWeapRestorePotion.Quantity}";
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} has used a Weapon Restore Potion! {Game.PlayerWeapon.Name} has been restored!");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();

            PlayerWeaponUpdate();
            InventoryUpdate();
        }

        private void GW_Boss_Yes_Button_Click(object sender, EventArgs e)
        {
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine} The dark energy has consumed {Game.Enemy.Name}! A powerful enemy has spawned!");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();

            Game.Enemy.SetToBoss();
            GW_Attack_Button.Enabled = true;
            GW_Defend_Button.Enabled = true;
            GW_Items_Button.Enabled = true;
            GW_Retreat_Button.Enabled = false;
            GW_Boss_Encounter_Panel.Hide();

            PlayerUpdate();
            EnemyUpdate();
        }

        private void GW_Boss_No_Button_Click(object sender, EventArgs e)
        {
            GW_Attack_Button.Enabled = true;
            GW_Defend_Button.Enabled = true;
            GW_Items_Button.Enabled = true;
            GW_Retreat_Button.Enabled = true;
            GW_Boss_Encounter_Panel.Hide();
        }

        private void GW_GameStatus_Button_Click(object sender, EventArgs e)
        {
            Game.SPlayer.Stop();
            this.Close();
            this.Dispose();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.SPlayer.Stop();
            this.Close();
            this.Dispose();
        }

        private void MaxStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.Player.CheatGodMode();
            PlayerUpdate();
        }

        private void SuperWeaponToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.PlayerWeapon = new SuperWeapon(Game.Player.Strength);
            PlayerWeaponUpdate();
        }

        private void GenerateBossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.Enemy.SetToBoss();
            GW_Attack_Button.Enabled = true;
            GW_Defend_Button.Enabled = true;
            GW_Items_Button.Enabled = true;
            GW_Retreat_Button.Enabled = false;
            GW_Boss_Encounter_Panel.Hide();

            PlayerUpdate();
            EnemyUpdate();
        }

        private void ToAllItemQuantityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.PlayerHealthPotion.Quantity += 999;
            Game.PlayerManaPotion.Quantity += 999;
            Game.PlayerWeapRestorePotion.Quantity += 999;
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}        999 Health Potion(s) has been added to your Inventory!");
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}        999 Mana Potion(s) has been added to your Inventory!");
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}        999 Weapon Restore Potion has been added to your Inventory!");

            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();

            InventoryUpdate();
        }

        private void RandomWeaponDropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WeaponDrop();
        }

        private void LevelUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.Player.LevelUp();
            PlayerUpdate();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HowToPlayWindow HTPForm = new HowToPlayWindow();
            HTPForm.Show();
        }

        private void SetPlayerHealthTo50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.Player.Health = (Game.Player.MaxHealth / 2);
            PlayerUpdate();
        }

        private void SetEnemyHealthTo50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.Enemy.Health = (Game.Enemy.MaxHealth / 2);
            EnemyUpdate();
        }

        private void SetPlayerWeaponMoveAmmoTo999ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.PlayerWeapon.Move1MaxAmmo = 999;
            Game.PlayerWeapon.Move2MaxAmmo = 999;
            Game.PlayerWeapon.Move3MaxAmmo = 999;
            Game.PlayerWeapon.Move4MaxAmmo = 999;

            Game.PlayerWeapon.Move1Ammo = 999;
            Game.PlayerWeapon.Move2Ammo = 999;
            Game.PlayerWeapon.Move3Ammo = 999;
            Game.PlayerWeapon.Move4Ammo = 999;

            PlayerWeaponUpdate();

        }

        private void HealthTo25ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.Player.Health = (Game.Player.MaxHealth / 2) / 2;
            PlayerUpdate();
        }

        private void SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.Enemy.Health = (Game.Enemy.MaxHealth / 2) / 2;
            EnemyUpdate();
        }

        private void MusicPlayStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Game.IsMusicPlaying)
            {
                Game.IsMusicPlaying = false;
                Game.SPlayer.Stop();
            }
            else
            {
                Game.IsMusicPlaying = true;
                Game.SPlayer.PlayLooping();
            }
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Game.Player.Mana = (int)(Game.Player.MaxMana * 0.75);
            PlayerUpdate();
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Game.Player.Mana = (int)(Game.Player.MaxMana * 0.50);
            PlayerUpdate();
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Game.Player.Mana = (int)(Game.Player.MaxMana * 0.25);
            PlayerUpdate();
        }

        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Game.Player.Mana = (int)(Game.Player.MaxMana * 0.15);
            PlayerUpdate();
        }

    }
}
