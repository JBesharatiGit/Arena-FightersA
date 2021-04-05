using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_FighterA
{
    public class Character
    {
        #region fields
        private static int count = 0;
        public string Name { get; set; }
        public string Rull { get; set; }
        public int Strength { get { return _strength; } set { _strength = value; } }
        public int BeginHealth { get { return _beginHealth; } set { _beginHealth = value; } }
        public int Health { get; set; }
        public int Line { get; set; }
        public char MoveIcon { get; set; }
        public int CharacterDice { get; set; }
        public int Lastposition { get { return _lastPosition; } set { _lastPosition = value; } }
        public int _lastPosition = 0;
        public int _strength = 0;
        public int _beginHealth = 0;
        #endregion
        public void CreateCharacter(string name)
        {
            Name = name;
            //Strength = Round.RollDice(1,7);
            Strength = Round.RollDice(1, 7);
            _lastPosition = Strength;
                count++;
            //Health = Round.RollDice(1,4);
            Health = Round.RollDice(1, 4);
            BeginHealth = Health;
        }
        public void characterSpel()
        {
            release();
            CharacterDice = Round.RollDice(1,7);
            
            MoveAhead(Line, MoveIcon, CharacterDice, ref _lastPosition);
            Changestrength(Line, MoveIcon, ref _strength, ref _lastPosition);

        }
        public void release()
        {
            CharacterDice = 0;
            Strength = 0;
            Health = 0;
        }

        public static void MoveAhead(int line, char icon, int distance, ref int lastPosition)
        {
            int i = lastPosition;
            while (i < lastPosition + distance)
            {
                if (i > 0)
                {
                    Console.SetCursorPosition(i - 1, line);
                    Console.WriteLine(" ");
                }

                mydelay(25);
                Console.SetCursorPosition(i, line);
                Console.WriteLine(icon);
                mydelay(25);
                i++;
            }
            lastPosition = i;


        }
        public static void MoveBack(int line, char icon, int distance, ref int lastPosition)
        {
            int i = lastPosition;
            while (i > lastPosition + distance)
            {
                i--;
                if (i > 0)
                {
                    Console.SetCursorPosition(i + 1, line);
                    Console.WriteLine(" ");
                }

                mydelay(25);
                Console.SetCursorPosition(i, line);
                Console.WriteLine(icon);
                mydelay(25);
                //i++;
            }
            lastPosition = i;


        }
        public static void Changestrength(int line, char icon, ref int Strength, ref int lastPosition)
        {
            switch (lastPosition)
            {
                case 11:
                    mydelay(200);
                    Strength = -2;
                    MoveBack(line, icon, -2, ref lastPosition);
                    Console.SetCursorPosition(11, line);
                    Console.WriteLine("!");
                    break;
                case 16:
                    mydelay(200);
                    Strength = 4;
                    MoveAhead(line, icon, 4, ref lastPosition);
                    Console.SetCursorPosition(16, line);
                    Console.WriteLine("!");
                    break;
                case 26:
                    mydelay(200);
                    Strength = 2;
                    MoveAhead(line, icon, 2, ref lastPosition);
                    Console.SetCursorPosition(26, line);
                    Console.WriteLine("!");
                    break;
                case 50:
                    break;
                default:
                    break;
            }
            //PersonLog.Add((Dice + ',' + Strength).ToString());
        }
        public static void mydelay(double seconds)
        {
            DateTime d = DateTime.Now.AddMilliseconds(seconds);
            do { } while (DateTime.Now < d);
        }
    }
}

