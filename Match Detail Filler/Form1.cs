using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Match_Detail_Filler
{
    public partial class Form1 : Form
    {
        static string PLAYER1 = "p1";
        static string PLAYER2 = "p2";
        static string STOCK = "stock";
        static string CHAR = "char";
        static string WIN = "win";
        static string DETAILS = "details={{BracketMatchDetails|preview=|lrthread=|interview=|recap=|comment=|live=|vod=";

        enum Field { p1char,p2char,stage,p1score,p2score }

        AutoCompleteStringCollection meleeCharacterAutoCompleteList;
        AutoCompleteStringCollection meleeStageAutoComplete;
        AutoCompleteStringCollection ssbCharacterAutoCompleteList;
        AutoCompleteStringCollection ssbStageAutoComplete;
        AutoCompleteStringCollection wiiuCharacterAutoCompleteList;
        AutoCompleteStringCollection wiiuStageAutoComplete;

        List<TextBox[]> matchList = new List<TextBox[]>();

        public Form1()
        {
            InitializeComponent();

            comboBoxGame.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGame.Items.Add("Melee");
            comboBoxGame.Items.Add("Wii U");
            comboBoxGame.Items.Add("64");

            meleeCharacterAutoCompleteList = new AutoCompleteStringCollection();
            meleeCharacterAutoCompleteList.AddRange(new string[] { "mario", "luigi", "yoshi", "dk","link","samus","kirby","fox","pikachu","jigglypuff","cf","ness","peach","bowser","doc","zelda","sheik","ganon","ylink","falco","mewtwo","pichu","ic","game and watch","marth","roy"});

            meleeStageAutoComplete = new AutoCompleteStringCollection();
            meleeStageAutoComplete.AddRange(new string[] { "Dream Land", "Final Destination", "Pokémon Stadium", "Battlefield", "Fountain of Dreams", "Yoshi's Story" });

            ssbCharacterAutoCompleteList = new AutoCompleteStringCollection();
            ssbCharacterAutoCompleteList.AddRange(new string[] { "mario", "luigi", "yoshi", "dk", "link", "samus", "kirby", "fox", "pikachu", "jigglypuff", "cf", "ness" });

            ssbStageAutoComplete = new AutoCompleteStringCollection();
            ssbStageAutoComplete.AddRange(new string[] { "Dream Land", "Hyrule Castle" });

            wiiuCharacterAutoCompleteList = new AutoCompleteStringCollection();
            wiiuCharacterAutoCompleteList.AddRange(new string[] { "mario","luigi","peach","bowser","doc","yoshi","dk","diddy","link","zelda","sheik","ganon","toon link","samus","kirby","zss","mk","fox","dedede","falco","pikachu","jigglypuff","mewtwo","charizard","lucario","cf","ness","lucas","marth","roy","ike","game and watch","pit","wario","olimar","rob","sonic","rosalina","bowser jr","greninja","robin","lucina","corrin","palutena","villager","dark pit","little mac","wii fit","duck hunt","shulk","mega man","pac-man","ryu","cloud","bayonetta","mii brawler","mii swordfighter","mii gunner" });

            wiiuStageAutoComplete = new AutoCompleteStringCollection();
            wiiuStageAutoComplete.AddRange(new string[] { "Battlefield", "Final Destination", "Smashville", "Dream Land", "Lylat Cruise", "Town and City", "Duck Hunt", "Castle Siege", "Delfino Plaza", "Halberd", "Umbra Clock Tower"});

            TextBox[] match1 = { textBoxChar1_1, textBoxChar1_2, textBoxStage1, textBoxScore1_1, textBoxScore1_2 };
            TextBox[] match2 = { textBoxChar2_1, textBoxChar2_2, textBoxStage2, textBoxScore2_1, textBoxScore2_2 };
            TextBox[] match3 = { textBoxChar3_1, textBoxChar3_2, textBoxStage3, textBoxScore3_1, textBoxScore3_2 };
            TextBox[] match4 = { textBoxChar4_1, textBoxChar4_2, textBoxStage4, textBoxScore4_1, textBoxScore4_2 };
            TextBox[] match5 = { textBoxChar5_1, textBoxChar5_2, textBoxStage5, textBoxScore5_1, textBoxScore5_2 };
            matchList.Add(match1);
            matchList.Add(match2);
            matchList.Add(match3);
            matchList.Add(match4);
            matchList.Add(match5);

            comboBoxGame.SelectedItem = "Melee";

            int tabNumber = 2;
            foreach (TextBox[] match in matchList)
            {
                for (int i = 0; i < 5; i++) 
                {
                    match[i].TabIndex = tabNumber;
                    tabNumber++;
                }

                match[(int)Field.p1char].Leave += new EventHandler(textBoxChar_Leave);
                match[(int)Field.p2char].Leave += new EventHandler(textBoxChar_Leave);
                match[(int)Field.stage].Leave += new EventHandler(textBoxStage_Leave);
            }
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            string output = string.Empty;
            int matchNumber = 1;

            foreach (TextBox[] match in matchList)
            {
                if (match[(int)Field.stage].Text != string.Empty)
                {
                    output += "|" + textBoxMatch.Text + "p1char" + matchNumber + "=" + match[0].Text + " ";
                    output += "|" + textBoxMatch.Text + "p2char" + matchNumber + "=" + match[1].Text + " ";
                    output += "|" + textBoxMatch.Text + "p1stock" + matchNumber + "=" + match[3].Text + " ";
                    output += "|" + textBoxMatch.Text + "p2stock" + matchNumber + "=" + match[4].Text + " ";

                    if (match[(int)Field.p1score].Text != string.Empty && match[(int)Field.p2score].Text != string.Empty)
                    {
                        if (int.Parse(match[(int)Field.p1score].Text) > int.Parse(match[(int)Field.p2score].Text))
                        {
                            output += "|" + textBoxMatch.Text + "win" + matchNumber + "=1 ";
                        }
                        else
                        {
                            output += "|" + textBoxMatch.Text + "win" + matchNumber + "=2 ";
                        }
                    }
                    else
                    {
                        output += "|" + textBoxMatch.Text + "win= ";
                    }
                    output += "|" + textBoxMatch.Text + "stage" + matchNumber + "=" + match[(int)Field.stage].Text + "\r\n";
                }

                matchNumber++;
            }

            if (textBoxYoutube.Text != string.Empty)
            {
                output += "|" + textBoxMatch.Text + DETAILS + textBoxYoutube.Text + "}}";
            }

            richTextBoxOutput.Text = output;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            foreach(Control x in this.Controls)
            {
                if(x is TextBox)
                {
                    ((TextBox)x).Clear();
                }
                    
            }
        }

        // Capitalize starting letter
        private void textBoxStage_Leave(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;

            if (box.Text != string.Empty)
            {
                string letter = box.Text.Substring(0, 1);
                letter = letter.ToUpper();
                box.Text = letter + box.Text.Substring(1);
            }
        }

        // Fill in char boxes below if they're empty
        private void textBoxChar_Leave(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;

            if (box == textBoxChar1_1) 
            {
                for (int i = 1; i < matchList.Count; i++) 
                {
                    matchList[i][(int)Field.p1char].Text = textBoxChar1_1.Text;
                }
            }
            else if (box == textBoxChar1_2)
            {
                for (int i = 1; i < matchList.Count; i++)
                {
                    matchList[i][(int)Field.p2char].Text = textBoxChar1_2.Text;
                }
            }
            
        }

        private void comboBoxGame_SelectedValueChanged(object sender, EventArgs e)
        {
            if(sender == comboBoxGame)
            {
                switch(comboBoxGame.SelectedItem.ToString())
                {
                    case "Melee":
                        foreach (TextBox[] match in matchList)
                        {
                            match[(int)Field.p1char].AutoCompleteCustomSource = meleeCharacterAutoCompleteList;
                            match[(int)Field.p2char].AutoCompleteCustomSource = meleeCharacterAutoCompleteList;
                            match[(int)Field.stage].AutoCompleteCustomSource = meleeStageAutoComplete;
                        }
                        break;
                    case "Wii U":
                        foreach (TextBox[] match in matchList)
                        {
                            match[(int)Field.p1char].AutoCompleteCustomSource = wiiuCharacterAutoCompleteList;
                            match[(int)Field.p2char].AutoCompleteCustomSource = wiiuCharacterAutoCompleteList;
                            match[(int)Field.stage].AutoCompleteCustomSource = wiiuStageAutoComplete;
                        }
                        break;
                    case "64":
                        foreach (TextBox[] match in matchList)
                        {
                            match[(int)Field.p1char].AutoCompleteCustomSource = ssbCharacterAutoCompleteList;
                            match[(int)Field.p2char].AutoCompleteCustomSource = ssbCharacterAutoCompleteList;
                            match[(int)Field.stage].AutoCompleteCustomSource = ssbStageAutoComplete;
                        }
                        break;
                }
            }
        }
    }
}
