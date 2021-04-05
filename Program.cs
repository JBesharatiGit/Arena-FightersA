using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_FighterA
{
    class Program
    {
        public static  Battle battle = new Battle();
        static int usualPosition = 0;
        static void Main(string[] args)
        {
            MakeCharacters();
 
            while (battle.endTotalFlag == false)
            {
                battle.GetOpponent();     

                battle.PrintField(battle.characterList[0].Lastposition, battle.characterList1[0].Lastposition);
                usualPosition = Console.CursorTop;

                battle.writePost(0);

                Character.mydelay(2000);
                battle.Message("", 1);
                battle.endFlag = false;

                while (battle.endFlag == false)
                {
                    battle.characterList[0].characterSpel();
                    
                    if (battle.characterList[0].Lastposition >= 50)
                    {
                        battle.characterList[0].Health = 1;
                        battle.characterList1[0].Health = -1;
                        battle.writePost(0);
                        battle.PrintPostBypost();
                        battle.RetirOrContinue();
                    }
                    else
                    {
                        battle.characterList1[0].characterSpel();
                        
                        if (battle.characterList1[0].Lastposition >= 50)
                        {
                            battle.characterList1[0].Health = 1;
                            battle.characterList[0].Health = -1;
                            battle.writePost(0);
                            battle.PrintPostBypost();
                            battle.RetirOrContinue();
                        }
                        else
                        {
                            battle.writePost(0);
                            battle.PrintPostBypost();
                            battle.Message("", 1);
                        }
                    }
                }

                RetirOrContinueNext();
            }
        }
        public static  void RetirOrContinueNext()
        {
            if (battle.endTotalFlag == false)
            {
                battle.WriteGame();
                ConsoleKeyInfo k = new ConsoleKeyInfo();

                battle.Message("Continue with Next Opponent?(y/n) ", 2);
                do
                {
                    k = Console.ReadKey();
                } while (char.ToLower(k.KeyChar) != 'y' && char.ToLower(k.KeyChar) != 'n');

                if (char.ToLower(k.KeyChar) == 'y' && battle.characterList.Count > 1)
                {
                    
                    battle.lstOnePass = new List<Round>();
                    ResetPlayerCharacter();
                    battle.writePost(1);
                }
                else
                {
                    battle.endFlag = true;
                    battle.endTotalFlag = true;
                    if (battle.characterList.Count == 1)
                    {
                        battle.Message("There are no more opponent", 2);
                        battle.printTotalgameHistori();
                        Console.ReadKey();
                    }
                }
            }
        }
        static void ResetPlayerCharacter()
        {

            Character Plyer = new Character();
            Plyer.CreateCharacter(battle.characterList[0].Name);
            Plyer.Rull = "Player";
            Plyer.Line = 2;
            Plyer.MoveIcon = '#';
            battle.characterList[0]= Plyer;//.Add(Plyer);
        }
        static void MakeCharacters() 
        {
            Character Plyer = new Character();
            Console.Write("Enter Player Neme : ");
            Plyer.CreateCharacter('['+Console.ReadLine()+']');
            Plyer.Rull = "Player";
            Plyer.Line = 2;
            Plyer.MoveIcon = '#';
            battle.characterList.Add(Plyer);

            string[] opponentNames = new string[] { "[Rabit]", "[Dragon]", "[Jagvar]", "[Cheeta]" };
            Plyer = new Character();
            for (int q = 0; q < opponentNames.Length; q++)
            {
                Plyer.CreateCharacter(opponentNames[q]);
                Plyer.Rull = "Opponent";
                Plyer.Line = 3;
                Plyer.MoveIcon = '?';
                battle.characterList.Add(Plyer);
                Plyer = new Character();
            }
        }
    }
}
