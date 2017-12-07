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
            EnemyInit();
            CharacterInit();
            InventoryInit();
            MenuInit();
        }

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

            int randVal = rand.Next(0, 6);

            if (randVal == 0)
                Game.PlayerWeapon = new WarHammer(Game.Player.Strength);
            else if (randVal == 1)
                Game.PlayerWeapon = new Mace(Game.Player.Strength);
            else if (randVal == 2)
                Game.PlayerWeapon = new Broadsword(Game.Player.Strength);
            else if (randVal == 3)
                Game.PlayerWeapon = new Greatsword(Game.Player.Strength);
            else if (randVal == 4)
                Game.PlayerWeapon = new Katana(Game.Player.Strength);
            else if (randVal == 5)
                Game.PlayerWeapon = new SpellTome(Game.Player.Strength);
            else if (randVal == 6)
                Game.PlayerWeapon = new Staff(Game.Player.Strength);
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

            GW_Player_Damaged_PicBox.Hide();
            PlayerWeaponUpdate();
        }
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
            GW_ToolTips.SetToolTip(GW_Defend_Button, "Take a defensive stance! (Take 50% Enemy Damage)");
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


        }
        void InventoryInit()
        {
            GW_QuantHPot_Label.Text = $"Quantity: {Game.PlayerHealthPotion.Quantity}";
            GW_QuantMPot_Label.Text = $"Quantity: {Game.PlayerManaPotion.Quantity}";
            GW_QuantWRPot_Label.Text = $"Quantity: {Game.PlayerWeapRestorePotion.Quantity}";
        }
        void EnemyInit()
        {
            Game.Enemy = new Enemy();
            Game.Enemy.GenerateEnemy();
            GW_Enemy_Damaged_PicBox.Hide();
            GW_Enemy_Boss_PicBox.Hide();
            GW_Enemy_Boss_Damage_PicBox.Hide();

            GW_EnemyName_Label.Text = Game.Enemy.Name;
            GW_EnemyHealthVal_Label.Text = ($"{Convert.ToString(Game.Enemy.Health)} / {Convert.ToString(Game.Enemy.MaxHealth)}");
            GW_EnemyTypeVal_Label.Text = Game.Enemy.Type;
            GW_EnemyStrVal_Label.Text = Convert.ToString(Game.Enemy.Strength);
            GW_EnemyIntelVal_Label.Text = Convert.ToString(Game.Enemy.Intelligence);
            GW_EnemyDexVal_Label.Text = Convert.ToString(Game.Enemy.Dexterity);
            GW_EnemyVitVal_Label.Text = Convert.ToString(Game.Enemy.Vitality);
            GW_EnemyWeap_Label.Text = $"Weapon: {Game.EnemyWeapon.Name}";
        }

        void InventoryUpdate()
        {
            if (Game.PlayerHealthPotion.Quantity == 0)
                GW_HPPotUse_Button.Enabled = false;
            else
                GW_HPPotUse_Button.Enabled = true;

            if (Game.PlayerManaPotion.Quantity == 0)
                GW_MPPotUse_Button.Enabled = false;
            else
                GW_MPPotUse_Button.Enabled = true;

            if (Game.PlayerWeapRestorePotion.Quantity == 0)
                GW_WRPotUse_Button.Enabled = false;
            else
                GW_WRPotUse_Button.Enabled = true;

            if (Game.PlayerHealthPotion.Quantity > 999)
                Game.PlayerHealthPotion.Quantity = 999;

            if (Game.PlayerManaPotion.Quantity > 999)
                Game.PlayerManaPotion.Quantity = 999;

            if (Game.PlayerWeapRestorePotion.Quantity > 999)
                Game.PlayerWeapRestorePotion.Quantity = 999;

            GW_QuantHPot_Label.Text = $"Quantity: {Game.PlayerHealthPotion.Quantity}";
            GW_QuantMPot_Label.Text = $"Quantity: {Game.PlayerManaPotion.Quantity}";
            GW_QuantWRPot_Label.Text = $"Quantity: {Game.PlayerWeapRestorePotion.Quantity}";
        }
        void PlayerWeaponUpdate()
        {
            GW_WeaponName_Label.Text = Game.PlayerWeapon.Name;
            GW_WeapMove1_RadButton.Text = Game.PlayerWeapon.Move1Name;
            GW_WeapMove2_RadButton.Text = Game.PlayerWeapon.Move2Name;
            GW_WeapMove3_RadButton.Text = Game.PlayerWeapon.Move3Name;
            GW_WeapMove4_RadButton.Text = Game.PlayerWeapon.Move4Name;

            GW_M1AmmoCount_Label.Text = $"{Convert.ToString(Game.PlayerWeapon.Move1Ammo)} / {Convert.ToString(Game.PlayerWeapon.Move1MaxAmmo)}";
            GW_M2AmmoCount_Label.Text = $"{Convert.ToString(Game.PlayerWeapon.Move2Ammo)} / {Convert.ToString(Game.PlayerWeapon.Move2MaxAmmo)}";
            GW_M3AmmoCount_Label.Text = $"{Convert.ToString(Game.PlayerWeapon.Move3Ammo)} / {Convert.ToString(Game.PlayerWeapon.Move3MaxAmmo)}";
            GW_M4AmmoCount_Label.Text = $"{Convert.ToString(Game.PlayerWeapon.Move4Ammo)} / {Convert.ToString(Game.PlayerWeapon.Move4MaxAmmo)}";

            Game.PlayerWeapon.UpdateWeapon(Game.Player.Strength);
        }
        void PlayerUpdate()
        {
            //Death Condition (Defeated by Enemy)
            if (Game.Player.Health <= 0)
            {
                Game.Player.Health = 0;
                GW_HPVal_Label.Text = Convert.ToString(Game.Player.Health);
                
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} has been slained by {Game.Enemy.Name}!");
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine} You have been revived by an unknown force, you feel weaker... (Stats reduced by 10%)");
                GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
                GW_BattleAction_TextBox.ScrollToCaret();

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

                if (Game.Player.Strength <= 0)
                    Game.Player.Strength = 0;

                if (Game.Player.Intelligence <= 0)
                    Game.Player.Intelligence = 0;

                if (Game.Player.Dexterity <= 0)
                    Game.Player.Dexterity = 0;

                if (Game.Player.Vitality <= 0)
                    Game.Player.Vitality = 0;

                if ((Game.Player.Strength + Game.Player.Intelligence + Game.Player.Dexterity + Game.Player.Vitality) == 0)
                {
                    GameOver();
                }


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
                GW_Player_Damaged_PicBox.Show();
                GW_Player_PicBox.Hide();
            }
            else
            {
                GW_Player_PicBox.Show();
                GW_Player_Damaged_PicBox.Hide();
            }

            //Update Progress Bar to Represent Health
            GW_Player_Health_ProgBar.Maximum = Game.Player.MaxHealth;
            GW_Player_Health_ProgBar.Minimum = 0;
            GW_Player_Health_ProgBar.Value = Game.Player.Health;

            //Update Progress Bar to Represent Mana
            GW_Player_Mana_ProgBar.Maximum = Game.Player.MaxMana;
            GW_Player_Mana_ProgBar.Minimum = 0;
            GW_Player_Mana_ProgBar.Value = Game.Player.Mana;

            Game.PlayerWeapon.UpdateWeapon(Game.Player.Strength);

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
        void EnemyUpdate()
        {
            if (Game.Enemy.IsBoss)
            {
                GW_Enemy_Boss_PicBox.Show();
                GW_Enemy_PicBox.Hide();
                GW_Enemy_Damaged_PicBox.Hide();
            }

            GW_EnemyName_Label.Text = Game.Enemy.Name;
            GW_EnemyHealthVal_Label.Text = ($"{Convert.ToString(Game.Enemy.Health)} / {Convert.ToString(Game.Enemy.MaxHealth)}");
            GW_EnemyTypeVal_Label.Text = Game.Enemy.Type;
            GW_EnemyStrVal_Label.Text = Convert.ToString(Game.Enemy.Strength);
            GW_EnemyIntelVal_Label.Text = Convert.ToString(Game.Enemy.Intelligence);
            GW_EnemyDexVal_Label.Text = Convert.ToString(Game.Enemy.Dexterity);
            GW_EnemyVitVal_Label.Text = Convert.ToString(Game.Enemy.Vitality);
            GW_EnemyWeap_Label.Text = $"Weapon: {Game.EnemyWeapon.Name}";

            Game.EnemyWeapon.UpdateWeapon(Game.Enemy.Strength);

            if ((Game.Enemy.Health <= (Game.Enemy.MaxHealth / 2)) && Game.Enemy.IsBoss)
            {
                GW_Enemy_Boss_Damage_PicBox.Show();
                GW_Enemy_Boss_PicBox.Hide();
            }
            else if (Game.Enemy.Health <= (Game.Enemy.MaxHealth / 2))
            {
                GW_Enemy_Damaged_PicBox.Show();
                GW_Enemy_PicBox.Hide();
            }
            else
            {
                if (Game.Enemy.IsBoss)
                {
                    GW_Enemy_Boss_PicBox.Show();
                    GW_Enemy_Boss_Damage_PicBox.Hide();
                }
                else
                {   
                    GW_Enemy_PicBox.Show();
                    GW_Enemy_Damaged_PicBox.Hide();
                }
            }

            GW_Enemy_Health_ProgBar.Maximum = Game.Enemy.MaxHealth;
            GW_Enemy_Health_ProgBar.Minimum = 0;
            GW_Enemy_Health_ProgBar.Value = Game.Enemy.Health;
        }

        void BossEncounterDialogBox()
        {
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine} A dark energy is present!");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();

            GW_Boss_Encounter_Panel.Show();
            GW_Attack_Button.Enabled = false;
            GW_Defend_Button.Enabled = false;
            GW_Items_Button.Enabled = false;
            GW_Retreat_Button.Enabled = false;
            GW_Inventory_Panel.Hide();
            GW_Weapon_Panel.Hide();
        }
        void GameOver()
        {
            GW_Player_PicBox.Hide();
            GW_Player_Damaged_PicBox.Hide();

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
        void GameWon()
        {
            GW_Enemy_Boss_Damage_PicBox.Hide();
            GW_Enemy_Boss_PicBox.Hide();

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

        void PlayerAttack()
        {
            int pDamage = 0;

            if (GW_WeapMove1_RadButton.Checked)
            {
                if (Game.PlayerWeapon.Move1Ammo > 0)
                {
                    if (Game.PlayerWeapon.ElementType == "Magic")
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
            else if (GW_WeapMove2_RadButton.Checked)
            {
                if (Game.PlayerWeapon.Move2Ammo > 0)
                {
                    if (Game.PlayerWeapon.ElementType == "Magic")
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
            else if (GW_WeapMove3_RadButton.Checked)
            {
                if (Game.PlayerWeapon.Move3Ammo > 0)
                {
                    if (Game.PlayerWeapon.ElementType == "Magic")
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
            else if (GW_WeapMove4_RadButton.Checked)
            {
                if (Game.PlayerWeapon.Move4Ammo > 0)
                {
                    if (Game.PlayerWeapon.ElementType == "Magic")
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
            else
            {
                pDamage = 0;
            }

            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} attacked {Game.Enemy.Name} for {pDamage} Damage!");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();

            if (pDamage < 0 || Game.Player.LevelNumber == 999)
                pDamage = Game.Enemy.Health;

            if (Game.Enemy.IsBoss)
                pDamage = pDamage / 2;

            Game.Enemy.Health -= pDamage;
            GW_EnemyHealthVal_Label.Text = ($"{Convert.ToString(Game.Enemy.Health)} / {Convert.ToString(Game.Enemy.MaxHealth)}");
        }
        void EnemyAttack()
        {
            int eDamage = Game.Enemy.Attack();
            if (Game.Player.LevelNumber == 999)
                eDamage = 0;

            Game.Player.Health -= eDamage;
            if (eDamage == 0)
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Enemy.Name} missed their attack! ({eDamage} Damage Taken!)");
            else
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Enemy.Name} attacked {Game.Player.Name} for {eDamage} Damage!");

            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();
        }
        void IsEnemyKilled()
        {
            //Enemy Killed
            if (Game.Enemy.Health <= 0)
            {
                Game.Enemy.Health = 0;
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
                    int valXP = ranVal.Next(50, 75);
                    Game.Player.Experience += valXP;

                    Game.Player.SetHealthPool();
                    Game.Player.SetManaPool();
                }

                Game.Player.KillCount += 1;
                GW_PlayerKillCount_Label.Text = ($"Kills: {Game.Player.KillCount}");

                GW_BossEncounter_ProgBar.Value += 1;

                if (GW_BossEncounter_ProgBar.Value == 10)
                    GW_BossEncounter_ProgBar.Value = 0;

                if (Game.Enemy.IsBoss)
                {

                    PlayerUpdate();
                    EnemyUpdate();
                    GameWon();
                    return;
                }

                EnemyDropItems();

                Game.Enemy.GenerateEnemy();

                if (Game.Player.KillCount % 10 == 0)
                {
                    BossEncounterDialogBox();
                }

                PlayerUpdate();
                EnemyUpdate();
            }
        }
        void EnemyDropItems()
        {
            Random seed = new Random();
            int seedRand = seed.Next(0, 100);
            Random ranVal = new Random(seedRand);

            int value1 = ranVal.Next(1, 3);
            int value2 = ranVal.Next(1, 3);

            //Add a random number of potion to the player's inventory
            Game.PlayerHealthPotion.Quantity += value1;
            Game.PlayerManaPotion.Quantity += value2;

            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}        {value1} Health Potion(s) has been added to your Inventory!");
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}        {value2} Mana Potion(s) has been added to your Inventory!");

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
            int randVal = rand.Next(0, 6);

            if (randVal == 0)
                Game.PlayerWeaponTemp = new WarHammer(Game.Player.Strength);
            else if (randVal == 1)
                Game.PlayerWeaponTemp = new Mace(Game.Player.Strength);
            else if (randVal == 2)
                Game.PlayerWeaponTemp = new Broadsword(Game.Player.Strength);
            else if (randVal == 3)
                Game.PlayerWeaponTemp = new Greatsword(Game.Player.Strength);
            else if (randVal == 4)
                Game.PlayerWeaponTemp = new Katana(Game.Player.Strength);
            else if (randVal == 5)
                Game.PlayerWeaponTemp = new SpellTome(Game.Player.Strength);
            else if (randVal == 6)
                Game.PlayerWeaponTemp = new Staff(Game.Player.Strength);
            else
                Game.PlayerWeaponTemp = null;

            Game.WeaponBox.Add(Game.PlayerWeaponTemp);
            GW_WeapSel_Combo.Items.Add(Game.PlayerWeaponTemp.Name);
            GW_WeapSel_Combo.Text = Game.PlayerWeaponTemp.Name;

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
            int randVal = rand.Next(1, 4);
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
                if ((GW_WeapSel_Combo.SelectedItem.ToString()) == Game.WeaponBox[i].Name)
                {
                    Game.PlayerWeapon = Game.WeaponBox[i];
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
            this.Close();
            this.Dispose();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
    }
}
