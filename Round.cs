﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_FighterA
{
    public class Round
    {
        #region Fields

        public static int count = 0;

        public string pName = "";
        public int pDice = 0;
        public int pStrength = 0;
        public int pHealth = 0;
        public static  int PTS = 0;
        public static  int PTH = 0;        
        public  int pTotalStrenth = 0;
        public int pBeginHealth = 0;
        public  int pTotalHealth = 0;

        public string oName = "";
        public int oDice = 0;
        public int oStrength = 0;
        public int oHealth = 0;
        public static int OTS = 0;
        public static int OTH = 0;
        public int oTotalStrenth = 0;
        public int oBeginHealth = 0;
        public int oTotalHealth = 0;

        private static int _dice;
        private static Random rnd = new Random();
        public static int Dice { get { return _dice; } }
        #endregion
        public Round()
        {
            PTS = 0;
            PTH = 0;
            OTS = 0;
            OTH = 0;
        }
        public Round(int ots,int oth,int pts,int pth)
        {
            //if (count>0)
            //{
                PTS += pts;
                PTH += pth;
                OTS+= ots;
                OTH += oth;
            //}
            
            count += 1;

        }
        public static int RollDice(int from, int to)
        {
            _dice = rnd.Next(from, to);
            return Dice;
        }
    }
}
