using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectRPG
{
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();
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
            Random rand = new Random();
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

            PlayerWeaponUpdate();


        }
        void MenuInit()
        {
            GW_Weapon_Panel.Hide();
            GW_Inventory_Panel.Hide();
            GW_GameStatus_Panel.Hide();
            GW_Boss_Encounter_Panel.Hide();
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

            if (Game.Player.Experience >= 100)
            {
                if (Game.Player.Experience >= 100)
                    Game.Player.Experience = Game.Player.Experience - 100;
                else
                    Game.Player.Experience = 0;

                Game.Player.LevelUp();
            }

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
            GW_EnemyName_Label.Text = Game.Enemy.Name;
            GW_EnemyHealthVal_Label.Text = ($"{Convert.ToString(Game.Enemy.Health)} / {Convert.ToString(Game.Enemy.MaxHealth)}");
            GW_EnemyTypeVal_Label.Text = Game.Enemy.Type;
            GW_EnemyStrVal_Label.Text = Convert.ToString(Game.Enemy.Strength);
            GW_EnemyIntelVal_Label.Text = Convert.ToString(Game.Enemy.Intelligence);
            GW_EnemyDexVal_Label.Text = Convert.ToString(Game.Enemy.Dexterity);
            GW_EnemyVitVal_Label.Text = Convert.ToString(Game.Enemy.Vitality);
            GW_EnemyWeap_Label.Text = $"Weapon: {Game.EnemyWeapon.Name}";

            Game.EnemyWeapon.UpdateWeapon(Game.Enemy.Strength);
        }

        void BossEncounterDialogBox()
        {
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

        void EnemyDropItems()
        {
            Random ranVal = new Random();
            int value1 = ranVal.Next(1, 3);
            int value2 = ranVal.Next(1, 3);

            //Add a random number of potion to the player's inventory
            Game.PlayerHealthPotion.Quantity += value1;
            Game.PlayerManaPotion.Quantity += value2;

            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}        {value1} Health Potion(s) has been added to your Inventory!");
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}        {value2} Mana Potion(s) has been added to your Inventory!");

            if (Game.Player.KillCount % 2 == 0) //Every 2 kills drop a Random Weapon
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
            }

            if (Game.Player.KillCount % 4 == 0) //Every 4 kills drop a weapon restore potion
            {
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}        A Weapon Restore Potion has been added to your Inventory!");
                Game.PlayerWeapRestorePotion.Quantity += 1;
            }


            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();

            InventoryUpdate();
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
            int pDamage = 0, eDamage;

            if (GW_WeapMove1_RadButton.Checked)
            {
                if (Game.PlayerWeapon.Move1Ammo > 0)
                {
                    pDamage = Game.PlayerWeapon.Move1Damage;
                    Game.PlayerWeapon.Move1Ammo -= 1;
                }
            }
            else if (GW_WeapMove2_RadButton.Checked)
            {
                if (Game.PlayerWeapon.Move2Ammo > 0)
                {
                    pDamage = Game.PlayerWeapon.Move2Damage;
                    Game.PlayerWeapon.Move2Ammo -= 1;
                }
            }
            else if (GW_WeapMove3_RadButton.Checked)
            {
                if (Game.PlayerWeapon.Move3Ammo > 0)
                {
                    pDamage = Game.PlayerWeapon.Move3Damage;
                    Game.PlayerWeapon.Move3Ammo -= 1;
                }
            }
            else if (GW_WeapMove4_RadButton.Checked)
            {
                if (Game.PlayerWeapon.Move4Ammo > 0)
                {
                    pDamage = Game.PlayerWeapon.Move4Damage;
                    Game.PlayerWeapon.Move4Ammo -= 1;
                }
            }
            else
            {
                pDamage = 0;
            }

            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} attacked {Game.Enemy.Name} for {pDamage} Damage!");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();

            //Player Turn
            Game.Enemy.Health -= pDamage;
            GW_EnemyHealthVal_Label.Text = ($"{Convert.ToString(Game.Enemy.Health)} / {Convert.ToString(Game.Enemy.MaxHealth)}");

            //Enemy Killed
            if (Game.Enemy.Health <= 0)
            {              
                Game.Enemy.Health = 0;
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Enemy.Name} has been slained. You have absorbed {Game.Enemy.Name}'s power!");
                GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
                GW_BattleAction_TextBox.ScrollToCaret();

                Game.Player.Strength += Game.Enemy.Strength;
                Game.Player.Intelligence += Game.Enemy.Intelligence;
                Game.Player.Dexterity += Game.Enemy.Dexterity;
                Game.Player.Vitality += Game.Enemy.Vitality;
                Game.Player.Experience += 75;

                Game.Player.SetHealthPool();
                Game.Player.SetManaPool();

                Game.Player.KillCount += 1;
                GW_PlayerKillCount_Label.Text = ($"Kills: {Game.Player.KillCount}");

                if (Game.Enemy.IsBoss)
                {
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

            //Enemy Turn
            eDamage = Game.Enemy.Attack();
            Game.Player.Health -= eDamage;
            if(eDamage == 0)
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Enemy.Name} missed their attack! ({eDamage} Damage Taken!)");
            else
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Enemy.Name} attacked {Game.Player.Name} for {eDamage} Damage!");

            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();

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
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} has retreated!");
            Game.Enemy.GenerateEnemy();
            EnemyUpdate();
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Enemy.Name} has appeared!");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();
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
            Game.Enemy.SetToBoss();
            GW_Attack_Button.Enabled = true;
            GW_Defend_Button.Enabled = true;
            GW_Items_Button.Enabled = true;
            GW_Retreat_Button.Enabled = true;
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
    }
}
