using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace QuickMatch___AI__
{
    class Program
    {

        private static Random getRand = new Random();
        static string[] CardClubs = new string[16] { "The One Of Clubs", "The Two Of Clubs", "The Three Of Clubs", "The Four Of Clubs", "The Five Of Clubs", "The Six Of Clubs", "The Seven Of Clubs", "The Eight Of Clubs", "The Nine Of Clubs", "The Ten Of Clubs", "The King Of Clubs", "The Queen Of Clubs", "The Jack Of Clubs", "The Princess Of Clubs", "The Ace Of Clubs", "The Joker Of Clubs" };
        static string[] CardHearts = new string[16] { "The One Of Hearts", "The Two Of Hearts", "The Three Of Hearts", "The Four Of Hearts", "The Five Of Hearts", "The Six Of Hearts", "The Seven Of Hearts", "The Eight Of Hearts", "The Nine Of Hearts", "The Ten Of Hearts", "The King Of Hearts", "The Queen Of Hearts", "The Jack Of Hearts", "The Princess Of Hearts", "The Ace Of Hearts", "The Joker Of Hearts" };
        static string[] CardSpades = new string[16] { "The One Of Spades", "The Two Of Spades", "The Three Of Spades", "The Four Of Spades", "The Five Of Spades", "The Six Of Spades", "The Seven Of Spades", "The Eight Of Spades", "The Nine Of Spades", "The Ten Of Spades", "The King Of Spades", "The Queen Of Spades", "The Jack Of Spades", "The Princess Of Spades", "The Ace Of Spades", "The Joker Of Spades" };
        static string[] CardDiamonds = new string[16] { "The One Of Diamonds", "The Two Of Diamonds", "The Three Of Diamonds", "The Four Of Diamonds", "The Five Of Diamonds", "The Six Of Diamonds", "The Seven Of Diamonds", "The Eight Of Diamonds", "The Nine Of Diamonds", "The Ten Of Diamonds", "The King Of Diamonds", "The Queen Of Diamonds", "The Jack Of Diamonds", "The Princess Of Diamonds", "The Ace Of Diamonds", "The Joker Of Diamonds" };
        static string[] CardName = new string[4] { "Diamonds", "Clubs", "Hearts", "Spades" };/*xandy*/
        static string[] CardRank = new string[16] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "King", "Queen", "Jack", "Princess", "Ace", "Joker" };
        static string[] p1Cards = new string[6] { " ", " ", " ", " ", " ", " " };
        static string[] p2Cards = new string[6] { " ", " ", " ", " ", " ", " " };
        static string[] AICards = new string[6] { " ", " ", " ", " ", " ", " " };
        static string[] Names = new string[] { "Zira", "Mark", "Lucy", "Carlos", "Andy", "Amaka" };
        static string Player1, Player2, Player3, Player4, AI;
        static string drawn, discarded;
        static string gameMode = "play";
        static int noOfPlayers, cP;
        static int game = 1;
        static int ret = 0;
        static int toBeDiscarded;
        static int cR = 0, cN = 0;
        static int[] toCount = new int[4];
        static int[] temp = new int[4];
        static string[] mA = new string[1];
        static int tC,tC2 =0;
        static int returnd;

        public void onStart()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t\tWelcome to [Quick Match] ");
            Console.WriteLine("\t\tThe first player to collect five cards of the same suit wins the game");
            try
            {
                Console.Write("\nEnter the number of players <1-2> : ");
                noOfPlayers = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e) { Console.WriteLine("Invalid PlayerMode"); Console.Clear(); onStart(); }
            if (noOfPlayers == 1)
            {
                Console.Write("Player 1 Name : ");
                Player1 = Console.ReadLine();
                Console.Write("Player 2 Name : ");
                int x = getRand.Next(0,5);
                AI = Names[x];
                Thread.Sleep(1000);
                //for (Char ch in Names[x])
                //{}
                Console.Write(AI);
                Thread.Sleep(1000);
                populateCards();
                Console.WriteLine("\n--------------------2PlayerMode--------------------");
                singlePlayer();
            }
            else if (noOfPlayers == 2)
            {
                Console.Write("Player 1 Name : ");
                Player1 = Console.ReadLine();
                Console.Write("Player 2 Name : ");
                Player2 = Console.ReadLine();
                populateCards();
                Console.WriteLine("--------------------2PlayerMode--------------------");
                forTwoPlayers();
            }
            else { Console.WriteLine("Player mode not available"); onStart(); }

        }
        public void singlePlayer()
        {
            while (gameMode == "play")
            {
                Console.WriteLine("\n\tPlayer1: {0}'s Turn", Player1);
                Console.WriteLine("\n{0}'s Card", Player1);
                Console.WriteLine("\t{0}", p1Cards[0]);
                Console.WriteLine("\t{0}", p1Cards[1]);
                Console.WriteLine("\t{0}", p1Cards[2]);
                Console.WriteLine("\t{0}", p1Cards[3]);
                Console.WriteLine("\t{0}", p1Cards[4]);
                Console.WriteLine("\t{0}\n", p1Cards[5]);
                if (game == 1) { drawCard(); }
                else { drawCard2(); }
                for (int i = 0; i < 6; i++)
                {
                    if (p1Cards[i] == " ") { p1Cards[i] = drawn; }
                }
                Console.WriteLine("\n1. {0}", p1Cards[0]);
                Console.WriteLine("2. {0}", p1Cards[1]);
                Console.WriteLine("3. {0}", p1Cards[2]);
                Console.WriteLine("4. {0}", p1Cards[3]);
                Console.WriteLine("5. {0}", p1Cards[4]);
                Console.WriteLine("6. {0}", p1Cards[5]);
                int cc = discardCard();
                cc = cc - 1;
                discarded = p1Cards[cc];
                p1Cards[cc] = " ";
                Console.WriteLine("\nCard discarded is {0}.\n", discarded);
                cP = 21; checkCard();
                game = 2;
                //---------------------player 2-----------------------------
                Console.WriteLine("---------------------AI-----------------------------");
                /*xandy*/
                Console.WriteLine("\n\tPlayer 2: {0}'s Turn", AI);
                Console.WriteLine("\n{0}'s Card", AI);
                Console.WriteLine("\t{0}", p2Cards[0]);
                Console.WriteLine("\t{0}", p2Cards[1]);
                Console.WriteLine("\t{0}", p2Cards[2]);
                Console.WriteLine("\t{0}", p2Cards[3]);
                Console.WriteLine("\t{0}", p2Cards[4]);
                Console.WriteLine("\t{0}\n", p2Cards[5]);
                aiDrawCard();
                for (int i = 0; i < 6; i++)
                {
                    if (p2Cards[i] == " ") { p2Cards[i] = drawn; }
                }
                Console.WriteLine("\n\n1. {0}", p2Cards[0]);
                Console.WriteLine("2. {0}", p2Cards[1]);
                Console.WriteLine("3. {0}", p2Cards[2]);
                Console.WriteLine("4. {0}", p2Cards[3]);
                Console.WriteLine("5. {0}", p2Cards[4]);
                Console.WriteLine("6. {0}", p2Cards[5]);
                int ccc = aiDiscardCard3();
                //ccc = ccc - 1;
                discarded = p2Cards[returnd];
                p2Cards[returnd] = " ";
                Console.WriteLine("\n\nCard discarded is {0}.\n", discarded);
                cP = 22; checkCard();
            }
        }
        public void forTwoPlayers()
        {
            while (gameMode == "play")
            {
                Console.WriteLine("\n\tPlayer1: {0}'s Turn", Player1);
                Console.WriteLine("\n{0}'s Card", Player1);
                Console.WriteLine("\t{0}", p1Cards[0]);
                Console.WriteLine("\t{0}", p1Cards[1]);
                Console.WriteLine("\t{0}", p1Cards[2]);
                Console.WriteLine("\t{0}", p1Cards[3]);
                Console.WriteLine("\t{0}", p1Cards[4]);
                Console.WriteLine("\t{0}\n", p1Cards[5]);
                if (game == 1) { drawCard(); }
                else { drawCard2(); }
                for (int i = 0; i < 6; i++)
                {
                    if (p1Cards[i] == " ") { p1Cards[i] = drawn; }
                }
                Console.WriteLine("\n1. {0}", p1Cards[0]);
                Console.WriteLine("2. {0}", p1Cards[1]);
                Console.WriteLine("3. {0}", p1Cards[2]);
                Console.WriteLine("4. {0}", p1Cards[3]);
                Console.WriteLine("5. {0}", p1Cards[4]);
                Console.WriteLine("6. {0}", p1Cards[5]);
                int cc = discardCard();
                cc = cc - 1;
                discarded = p1Cards[cc];
                p1Cards[cc] = " ";
                Console.WriteLine("\nCard discarded is {0}.\n", discarded);
                cP = 21; checkCard();
                game = 2;
                //---------------------player 2-----------------------------
                Console.WriteLine("---------------------player 2-----------------------------");
                /*xandy*/
                Console.WriteLine("\n\tPlayer2: {0}'s Turn", Player2);
                Console.WriteLine("\n{0}'s Card", Player2);
                Console.WriteLine("\t{0}", p2Cards[0]);
                Console.WriteLine("\t{0}", p2Cards[1]);
                Console.WriteLine("\t{0}", p2Cards[2]);
                Console.WriteLine("\t{0}", p2Cards[3]);
                Console.WriteLine("\t{0}", p2Cards[4]);
                Console.WriteLine("\t{0}\n", p2Cards[5]);
                drawCard2();
                for (int i = 0; i < 6; i++)
                {
                    if (p2Cards[i] == " ") { p2Cards[i] = drawn; }
                }
                Console.WriteLine("\n1. {0}", p2Cards[0]);
                Console.WriteLine("2. {0}", p2Cards[1]);
                Console.WriteLine("3. {0}", p2Cards[2]);
                Console.WriteLine("4. {0}", p2Cards[3]);
                Console.WriteLine("5. {0}", p2Cards[4]);
                Console.WriteLine("6. {0}", p2Cards[5]);
                int ccc = discardCard();
                ccc = ccc - 1;
                discarded = p2Cards[ccc];
                p2Cards[ccc] = " ";
                Console.WriteLine("\nCard discarded is {0}.\n", discarded);
                cP = 22; checkCard();
            }

        }
        public void populateCards()
        {
            int num;
            string val;
            if (noOfPlayers == 1)
            {
                num = getRand.Next(0, 15);
                p1Cards[0] = CardClubs[num];
                num = getRand.Next(0, 15);
                p2Cards[0] = CardClubs[num];

                num = getRand.Next(0, 15);
                p1Cards[1] = CardHearts[num];
                num = getRand.Next(0, 15);
                p2Cards[1] = CardHearts[num];

                num = getRand.Next(0, 15);
                p1Cards[2] = CardSpades[num];
                num = getRand.Next(0, 15);
                p2Cards[2] = CardSpades[num];

                num = getRand.Next(0, 15);
                p1Cards[3] = CardDiamonds[num];
                num = getRand.Next(0, 15);
                p2Cards[3] = CardDiamonds[num];

                val = getCard();
                p1Cards[4] = val;
                val = getCard();
                p2Cards[4] = val;
            }
            else if (noOfPlayers == 2)
            {
                num = getRand.Next(0, 15);
                p1Cards[0] = CardClubs[num];
                num = getRand.Next(0, 15);
                p2Cards[0] = CardClubs[num];

                num = getRand.Next(0, 15);
                p1Cards[1] = CardHearts[num];
                num = getRand.Next(0, 15);
                p2Cards[1] = CardHearts[num];

                num = getRand.Next(0, 15);
                p1Cards[2] = CardSpades[num];
                num = getRand.Next(0, 15);
                p2Cards[2] = CardSpades[num];

                num = getRand.Next(0, 15);
                p1Cards[3] = CardDiamonds[num];
                num = getRand.Next(0, 15);
                p2Cards[3] = CardDiamonds[num];

                val = getCard();
                p1Cards[4] = val;
                val = getCard();
                p2Cards[4] = val;
            }
        }
        public void aiDrawCard() 
        {
            int cH = 0, cC = 0, cD = 0, cS = 0;
            string[] disc = new string[1];disc[0] = discarded;
            Console.Write("Press [T] to take the card discarded or [D] to draw a card from the pile :  ");
            for (int i = 0; i <= 5; i++)
            {
                if (p2Cards[i].Contains("Hearts")) { cH++; }
                else if (p2Cards[i].Contains("Clubs")) { cC++; }
                else if (p2Cards[i].Contains("Diamonds")) { cD++; }
                else if (p2Cards[i].Contains("Spades")) { cS++; }
                else { }
            }
            if      (cH >= 2 && (cC >= 2 || cD >= 2 || cS >= 2))
            {
                if (cH >= 2 && cC >= 2) 
                {
                    if (cH > cC)
                    {
                        if (disc[0].Contains("Hearts")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else if (cC > cH)
                    {
                        if (disc[0].Contains("Clubs")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else
                    {
                        if (disc[0].Contains("Hearts") || disc[0].Contains("Clubs")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                }
                else if (cH >= 2 && cD >= 2) 
                {
                    if (cH > cD)
                    {
                        if (disc[0].Contains("Hearts")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else if (cD > cH)
                    {
                        if (disc[0].Contains("Diamonds")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else
                    {
                        if (disc[0].Contains("Hearts") || disc[0].Contains("Diamonds")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                }
                else if (cH >= 2 && cS >= 2) 
                {
                    if (cH > cS)
                    {
                        if (disc[0].Contains("Hearts")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else if (cS > cH)
                    {
                        if (disc[0].Contains("Spades")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else
                    {
                        if (disc[0].Contains("Hearts") || disc[0].Contains("Spades")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                }
            }
            else if (cC >= 2 && (cH >= 2 || cD >= 2 || cS >= 2))
            {
                if (cC >= 2 && cH >= 2)
                {
                    if (cH > cC)
                    {
                        if (disc[0].Contains("Hearts")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else if (cC > cH)
                    {
                        if (disc[0].Contains("Clubs")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else
                    {
                        if (disc[0].Contains("Hearts") || disc[0].Contains("Clubs")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                }
                else if (cC >= 2 && cD >= 2)
                {
                    if (cC > cD)
                    {
                        if (disc[0].Contains("Clubs")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else if (cD > cC)
                    {
                        if (disc[0].Contains("Diamonds")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else
                    {
                        if (disc[0].Contains("Diamonds") || disc[0].Contains("Clubs")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                }
                else if (cC >= 2 && cS >= 2)
                {
                    if (cC > cS)
                    {
                        if (disc[0].Contains("Clubs")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else if (cS > cC)
                    {
                        if (disc[0].Contains("Spades")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else
                    {
                        if (disc[0].Contains("Spades") || disc[0].Contains("Clubs")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                }
            }
            else if (cD >= 2 && (cC >= 2 || cH >= 2 || cS >= 2))
            {
                if (cD >= 2 && cH >= 2)
                {
                    if (cH > cD)
                    {
                        if (disc[0].Contains("Hearts")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else if (cD > cH)
                    {
                        if (disc[0].Contains("Diamonds")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else
                    {
                        if (disc[0].Contains("Hearts") || disc[0].Contains("Diamonds")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                }
                else if (cD >= 2 && cC >= 2)
                {
                    if (cC > cD)
                    {
                        if (disc[0].Contains("Clubs")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else if (cD > cC)
                    {
                        if (disc[0].Contains("Diamonds")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else
                    {
                        if (disc[0].Contains("Diamonds") || disc[0].Contains("Clubs")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                }
                else if (cD >= 2 && cS >= 2)
                {
                    if (cD > cS)
                    {
                        if (disc[0].Contains("Diamonds")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else if (cS > cD)
                    {
                        if (disc[0].Contains("Spades")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else
                    {
                        if (disc[0].Contains("Spades") || disc[0].Contains("Diamonds")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                }
            }
            else if (cS >= 2 && (cC >= 2 || cD >= 2 || cH >= 2))
            {
                if (cS >= 2 && cH >= 2)
                {
                    if (cH > cS)
                    {
                        if (disc[0].Contains("Hearts")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else if (cS > cH)
                    {
                        if (disc[0].Contains("Spades")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else
                    {
                        if (disc[0].Contains("Hearts") || disc[0].Contains("Spades")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                }
                else if (cS >= 2 && cC >= 2)
                {
                    if (cC > cS)
                    {
                        if (disc[0].Contains("Clubs")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else if (cS > cC)
                    {
                        if (disc[0].Contains("Spades")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else
                    {
                        if (disc[0].Contains("Spades") || disc[0].Contains("Clubs")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                }
                else if (cD >= 2 && cS >= 2)
                {
                    if (cD > cS)
                    {
                        if (disc[0].Contains("Diamonds")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else if (cS > cD)
                    {
                        if (disc[0].Contains("Spades")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                    else
                    {
                        if (disc[0].Contains("Spades") || disc[0].Contains("Diamonds")) { Thread.Sleep(2000); Console.Write("T"); drawn = discarded; Thread.Sleep(1000); }
                        else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
                    }
                }
            }
            else if (cH >= 2)
            {
                if (disc[0].Contains("Hearts")){ Thread.Sleep(2000);Console.Write("T"); drawn = discarded;Thread.Sleep(1000);}
                else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
            }
            else if (cC >= 2)
            {
                if (disc[0].Contains("Clubs")){ Thread.Sleep(2000);Console.Write("T"); drawn = discarded;Thread.Sleep(1000);}
                else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
            }
            else if (cD >= 2)
            {
                if (disc[0].Contains("Diamonds")){ Thread.Sleep(2000);Console.Write("T"); drawn = discarded;Thread.Sleep(1000);}
                else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
            }
            else if (cS >= 2)
            {
                if (disc[0].Contains("Spades")){ Thread.Sleep(2000);Console.Write("T"); drawn = discarded;Thread.Sleep(1000);}
                else { Thread.Sleep(2000); Console.Write("D"); drawn = getCard(); Thread.Sleep(1000); }
            }
            else{}
        }
        public void drawCard()
        {
            Console.Write("Press D to draw a card from the pile :  ");
            string vals = Console.ReadLine().ToUpper();
            if (vals == "D") { drawn = getCard(); }
            else { drawCard(); }
        }
        public void drawCard2()
        {
            Console.Write("Press [T] to take the card discarded or [D] to draw a card from the pile :  ");
            string vals = Console.ReadLine().ToUpper();
            if (vals == "D") { drawn = getCard(); }
            else if (vals == "T") { drawn = discarded; }
            else { drawCard2(); }
        }
        public string getCard()
        {
            int name = getRand.Next(0, 3);
            int rank = getRand.Next(0, 15);
            string card = "The " + CardRank[rank] + " of " + CardName[name] + "";
            return card;
        }
        public void checkCard()
        {
            int cardCountH = 0, cardCountS = 0, cardCountC = 0, cardCountD = 0;
            if (cP == 21)
            {
                if (p1Cards[0].Contains("Hearts")) { cardCountH++; }
                if (p1Cards[1].Contains("Hearts")) { cardCountH++; }
                if (p1Cards[2].Contains("Hearts")) { cardCountH++; }
                if (p1Cards[3].Contains("Hearts")) { cardCountH++; }
                if (p1Cards[4].Contains("Hearts")) { cardCountH++; }
                if (p1Cards[5].Contains("Hearts")) { cardCountH++; }

                if (p1Cards[0].Contains("Spades")) { cardCountS++; }
                if (p1Cards[1].Contains("Spades")) { cardCountS++; }
                if (p1Cards[2].Contains("Spades")) { cardCountS++; }
                if (p1Cards[3].Contains("Spades")) { cardCountS++; }
                if (p1Cards[4].Contains("Spades")) { cardCountS++; }
                if (p1Cards[5].Contains("Spades")) { cardCountS++; }

                if (p1Cards[0].Contains("Clubs")) { cardCountC++; }
                if (p1Cards[1].Contains("Clubs")) { cardCountC++; }
                if (p1Cards[2].Contains("Clubs")) { cardCountC++; }
                if (p1Cards[3].Contains("Clubs")) { cardCountC++; }
                if (p1Cards[4].Contains("Clubs")) { cardCountC++; }
                if (p1Cards[5].Contains("Clubs")) { cardCountC++; }

                if (p1Cards[0].Contains("Diamonds")) { cardCountD++; }
                if (p1Cards[1].Contains("Diamonds")) { cardCountD++; }
                if (p1Cards[2].Contains("Diamonds")) { cardCountD++; }
                if (p1Cards[3].Contains("Diamonds")) { cardCountD++; }
                if (p1Cards[4].Contains("Diamonds")) { cardCountD++; }
                if (p1Cards[5].Contains("Diamonds")) { cardCountD++; }

                if (cardCountH == 5) { Console.WriteLine("Player 1: [{0}] won!!", Player1); Exit(); }
                else if (cardCountS == 5) { Console.WriteLine("Player 1: [{0}] won!!", Player1); Exit(); }
                else if (cardCountC == 5) { Console.WriteLine("Player 1: [{0}] won!!", Player1); Exit(); }
                else if (cardCountD == 5) { Console.WriteLine("Player 1: [{0}] won!!", Player1); Exit(); }
            }
            else if (cP == 22)
            {
                if (p2Cards[0].Contains("Hearts")) { cardCountH++; }
                if (p2Cards[1].Contains("Hearts")) { cardCountH++; }
                if (p2Cards[2].Contains("Hearts")) { cardCountH++; }
                if (p2Cards[3].Contains("Hearts")) { cardCountH++; }
                if (p2Cards[4].Contains("Hearts")) { cardCountH++; }
                if (p2Cards[5].Contains("Hearts")) { cardCountH++; }

                if (p2Cards[0].Contains("Spades")) { cardCountS++; }
                if (p2Cards[1].Contains("Spades")) { cardCountS++; }
                if (p2Cards[2].Contains("Spades")) { cardCountS++; }
                if (p2Cards[3].Contains("Spades")) { cardCountS++; }
                if (p2Cards[4].Contains("Spades")) { cardCountS++; }
                if (p2Cards[5].Contains("Spades")) { cardCountS++; }

                if (p2Cards[0].Contains("Clubs")) { cardCountC++; }
                if (p2Cards[1].Contains("Clubs")) { cardCountC++; }
                if (p2Cards[2].Contains("Clubs")) { cardCountC++; }
                if (p2Cards[3].Contains("Clubs")) { cardCountC++; }
                if (p2Cards[4].Contains("Clubs")) { cardCountC++; }
                if (p2Cards[5].Contains("Clubs")) { cardCountC++; }

                if (p2Cards[0].Contains("Diamonds")) { cardCountD++; }
                if (p2Cards[1].Contains("Diamonds")) { cardCountD++; }
                if (p2Cards[2].Contains("Diamonds")) { cardCountD++; }
                if (p2Cards[3].Contains("Diamonds")) { cardCountD++; }
                if (p2Cards[4].Contains("Diamonds")) { cardCountD++; }
                if (p2Cards[5].Contains("Diamonds")) { cardCountD++; }

                if (cardCountH == 5) { Console.WriteLine("Player 2: [{0}] won!!", AI); Exit(); }
                else if (cardCountS == 5) { Console.WriteLine("Player 2: [{0}] won!!", AI); Exit(); }
                else if (cardCountC == 5) { Console.WriteLine("Player 2: [{0}] won!!", AI); Exit(); }
                else if (cardCountD == 5) { Console.WriteLine("Player 2: [{0}] won!!", AI); Exit(); }
            }
            
        }
        public int discardCard()
        {
            //int val;
            Console.Write("\nEnter the card number to be discarded <1-6> : ");
            try
            {
                toBeDiscarded = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e) { Console.WriteLine("Invalid Integer"); discardCard(); }
            if (toBeDiscarded == 1 || toBeDiscarded == 2 || toBeDiscarded == 3 || toBeDiscarded == 4 || toBeDiscarded == 5 || toBeDiscarded == 6) { }
            else { Console.WriteLine("Invalid card number"); discardCard(); }
            return toBeDiscarded;
        }
        public int aiDiscardCard()
        {
            int cH = 0, cC = 0, cD = 0, cS = 0;
            int[] temp = new int[4];
            int[] low = new int[3]{5, 5, 5};
            int cR = 0, cN =0;
            string lowText ="bababab";
            //temp[0] = p2Cards[0];
            Console.Write("\nEnter the card number to be discarded <1-6> : ");
            for (int i = 0; i <= 5; i++)
            {
                if (p2Cards[i].Contains("Hearts")) { cH++; }
                else if (p2Cards[i].Contains("Clubs")) { cC++; }
                else if (p2Cards[i].Contains("Diamonds")) { cD++; }
                else if (p2Cards[i].Contains("Spades")) { cS++; }
                else { }
            }
            temp[0] = cH; temp[1] = cC; temp[2] = cD; temp[3] = cS;
            int f = temp.Min();
            for (int i = 0; i <= 3; i++)
            {
                if (temp[i] == f) { low[cR] = i; cR++; }
                else { }
            }
            for (int i = 0; i <= 2; i++)
            {
                if (low[i] != 5) { cN++; }
                else { }
            }
            if (cN == 1) 
            {
                if (low[0] == 0) { lowText = "Hearts"; }
                else if (low[0] == 1) { lowText = "Clubs"; }
                else if (low[0] == 2) { lowText = "Diamonds"; }
                else if (low[0] == 3) { lowText = "Spades"; }
                for (int i = 0; i <= 5; i++)
                {
                    if (p2Cards[i].Contains(lowText)) { ret = i; }
                }
            }//     Hearts  Clubs   Diamonds    Spades
                //      0       1       2           3
            else if (cN == 2) 
            {
                string[] arr = new string[1] {""+low[0].ToString() + low[2].ToString()+""};
                if (arr[0].Contains("0") && arr[0].Contains("1") )
                {
                    int q = getRand.Next(1, 2);
                    if (q == 1) { lowText = "Hearts"; }
                    else { lowText = "Clubs"; }
                }
                else if (arr[0].Contains("0") && arr[0].Contains("2")) 
                {
                    int q = getRand.Next(1, 2);
                    if (q == 1) { lowText = "Hearts"; }
                    else { lowText = "Diamonds"; }
                }
                else if (arr[0].Contains("0") && arr[0].Contains("3")) 
                {
                    int q = getRand.Next(1, 2);
                    if (q == 1) { lowText = "Hearts"; }
                    else { lowText = "Spades"; }
                }
                else if (arr[0].Contains("1") && arr[0].Contains("2")) 
                {
                    int q = getRand.Next(1, 2);
                    if (q == 1) { lowText = "Diamonds"; }
                    else { lowText = "Clubs"; }
                }
                else if (arr[0].Contains("1") && arr[0].Contains("3")) 
                {
                    int q = getRand.Next(1, 2);
                    if (q == 1) { lowText = "Spades"; }
                    else { lowText = "Clubs"; }
                }
                else if (arr[0].Contains("2") && arr[0].Contains("3")) 
                {
                    int q = getRand.Next(1, 2);
                    if (q == 1) { lowText = "Diamonds"; }
                    else { lowText = "Spades"; }
                }
                for (int i = 0; i <= 5; i++)
                {
                    if (p2Cards[i].Contains(lowText)) { ret = i; }
                }
            }//     Hearts  Clubs   Diamonds    Spades
            //      0       1       2           3
            else if (cN == 3)
            {
                string[] arr = new string[1] { "" + low[0].ToString() + low[1].ToString() + low[2].ToString() + "" };
                if (arr[0].Contains("0") && arr[0].Contains("1") && arr[0].Contains("2"))
                {
                    int q = getRand.Next(1, 3);
                    if (q == 1) { lowText = "Hearts"; }
                    else if (q == 2) { lowText = "Diamonds"; }
                    else { lowText = "Clubs"; }
                }
                else if (arr[0].Contains("0") && arr[0].Contains("1") && arr[0].Contains("3"))
                {
                    int q = getRand.Next(1, 3);
                    if (q == 1) { lowText = "Hearts"; }
                    else if (q == 2) { lowText = "Spades"; }
                    else { lowText = "Clubs"; }
                }
                else if (arr[0].Contains("2") && arr[0].Contains("1") && arr[0].Contains("3"))
                {
                    int q = getRand.Next(1, 3);
                    if (q == 1) { lowText = "Spades"; }
                    else if (q == 2) { lowText = "Diamonds"; }
                    else { lowText = "Clubs"; }
                }
                for (int i = 0; i <= 5; i++)
                {
                    if (p2Cards[i].Contains(lowText)) { ret = i; }
                }
            }
            else { }
            //if (low[0] == 0) { }
            Thread.Sleep(3000);
            Console.Write(ret+1);
            Thread.Sleep(1000);
            return ret;
        }
        public int aiDiscardCard2()
        {
            int cH = 0, cC = 0, cD = 0, cS = 0;
            int[] temp = new int[4];
            int[] low = new int[3] { 5, 5, 5 };
            //int cR = 0, cN = 0;
            string lowText = "bababab";
            //temp[0] = p2Cards[0];
            Console.Write("\nEnter the card number to be discarded <1-6> : ");
            for (int i = 0; i <= 5; i++)
            {
                if (p2Cards[i].Contains("Hearts")) { cH++; }
                else if (p2Cards[i].Contains("Clubs")) { cC++; }
                else if (p2Cards[i].Contains("Diamonds")) { cD++; }
                else if (p2Cards[i].Contains("Spades")) { cS++; }
                else { }
            }
            temp[0] = cH; temp[1] = cC; temp[2] = cD; temp[3] = cS;
            int f = temp.Min();
            for (int i = 0; i <= 3; i++)
            {
                Console.Write("Its A card");
                if (temp[i] == f) { low[cR] = i; cR++; }
                else { }
            }
            for (int i = 0; i <= 2; i++)
            {
                if (low[i] != 5) { cN++; }
                else { }
            }
            if (cN == 1)
            {
                if (low[0] == 0) { lowText = "Hearts"; }
                else if (low[0] == 1) { lowText = "Clubs"; }
                else if (low[0] == 2) { lowText = "Diamonds"; }
                else if (low[0] == 3) { lowText = "Spades"; }
                for (int i = 0; i <= 5; i++)
                {
                    if (p2Cards[i].Contains(lowText)) { ret = i; }
                }
            }//     Hearts  Clubs   Diamonds    Spades
            //      0       1       2           3
            else if (cN == 2)
            {
                int[] arr = new int[2] {low[0],low[1]};
                if ((arr[0] == 0 && arr[1] == 1) || (arr[0] == 1 && arr[1] == 0))
                {
                    int q = getRand.Next(1, 2);
                    if (q == 1) { lowText = "Hearts"; }
                    else { lowText = "Clubs"; }
                }
                else if ((arr[0] == 0 && arr[1] == 2) || (arr[0] == 2 && arr[1] == 0))
                {
                    int q = getRand.Next(1, 2);
                    if (q == 1) { lowText = "Hearts"; }
                    else { lowText = "Diamonds"; }
                }
                else if ((arr[0] == 0 && arr[1] == 3) || (arr[0] == 3 && arr[1] == 0))
                {
                    int q = getRand.Next(1, 2);
                    if (q == 1) { lowText = "Hearts"; }
                    else { lowText = "Spades"; }
                }
                else if ((arr[0] == 1 && arr[1] == 2) || (arr[0] == 2 && arr[1] == 1))
                {
                    int q = getRand.Next(1, 2);
                    if (q == 1) { lowText = "Diamonds"; }
                    else { lowText = "Clubs"; }
                }
                else if ((arr[0] == 1 && arr[1] == 3) || (arr[0] == 3 && arr[1] == 1))
                {
                    int q = getRand.Next(1, 2);
                    if (q == 1) { lowText = "Spades"; }
                    else { lowText = "Clubs"; }
                }
                else if ((arr[0] == 2 && arr[1] == 3) || (arr[0] == 3 && arr[1] == 2))
                {
                    int q = getRand.Next(1, 2);
                    if (q == 1) { lowText = "Diamonds"; }
                    else { lowText = "Spades"; }
                }
                for (int i = 0; i <= 5; i++)
                {
                    if (p2Cards[i].Contains(lowText)) { ret = i; }
                }
            }//     Hearts  Clubs   Diamonds    Spades
            //      0       1       2           3
            else if (cN == 3)
            {
                int[] arr = new int[3] {low[0], low[1], low[2]};
                if ((arr[0] == 0 && arr[1] == 1 && arr[2] == 2) ||
                    (arr[0] == 0 && arr[1] == 2 && arr[2] == 1) ||
                    (arr[0] == 1 && arr[1] == 0 && arr[2] == 2) ||
                    (arr[0] == 1 && arr[1] == 2 && arr[2] == 0) ||
                    (arr[0] == 2 && arr[1] == 1 && arr[2] == 0) ||
                    (arr[0] == 2 && arr[1] == 0 && arr[2] == 1))
                {
                    int q = getRand.Next(1, 3);
                    if (q == 1) { lowText = "Hearts"; }
                    else if (q == 2) { lowText = "Diamonds"; }
                    else { lowText = "Clubs"; }
                }
                else if ((arr[0] == 0 && arr[1] == 1 && arr[2] == 3) ||
                        (arr[0] == 0 && arr[1] == 3 && arr[2] == 1) ||
                        (arr[0] == 1 && arr[1] == 0 && arr[2] == 3) ||
                        (arr[0] == 1 && arr[1] == 3 && arr[2] == 0) ||
                        (arr[0] == 3 && arr[1] == 0 && arr[2] == 1) ||
                        (arr[0] == 3 && arr[1] == 1 && arr[2] == 0))
                {
                    int q = getRand.Next(1, 3);
                    if (q == 1) { lowText = "Hearts"; }
                    else if (q == 2) { lowText = "Spades"; }
                    else { lowText = "Clubs"; }
                }
                else if ((arr[0] == 2 && arr[1] == 1 && arr[2] == 3) ||
                        (arr[0] == 2 && arr[1] == 3 && arr[2] == 1) ||
                        (arr[0] == 1 && arr[1] == 2 && arr[2] == 3) ||
                        (arr[0] == 1 && arr[1] == 3 && arr[2] == 2) ||
                        (arr[0] == 3 && arr[1] == 1 && arr[2] == 2) ||
                        (arr[0] == 3 && arr[1] == 2 && arr[2] == 1))
                {
                    int q = getRand.Next(1, 3);
                    if (q == 1) { lowText = "Spades"; }
                    else if (q == 2) { lowText = "Diamonds"; }
                    else { lowText = "Clubs"; }
                }
                for (int i = 0; i <= 5; i++)
                {
                    if (p2Cards[i].Contains(lowText)) { ret = i; }
                }
            }
            else { }
            //if (low[0] == 0) { }
            Thread.Sleep(3000);
            Console.Write(ret + 1);
            Thread.Sleep(1000);
            return ret;
        }
        public int aiDiscardCard3()
        {
            returnd = 0;
            int cH = 0, cC = 0, cD = 0, cS = 0;
            mA[0] = "";
            string strl = "";
            //int returnd = 0;
            Console.Write("\nEnter the card number to be discarded <1-6> : ");
            for (int i = 0; i <= 5; i++)
            {
                if (p2Cards[i].Contains("Hearts")) { cH++; }
                else if (p2Cards[i].Contains("Clubs")) { cC++; }
                else if (p2Cards[i].Contains("Diamonds")) { cD++; }
                else if (p2Cards[i].Contains("Spades")) { cS++; }
                else { }
            }
            //the error here is sometimes a card isnt included in the deck and it registers as zero which is the min -- find a way to exclude zero values
            toCount[0] = cH; toCount[1] = cC; toCount[2] = cD; toCount[3] = cS;

            //experimental block of code to exclude zero values
            //Console.WriteLine("To Count Length: "+toCount.Length);
            for (int i = 0; i < toCount.Length; i++) {
                if (toCount[i] == 0) { toCount[i] = 10; }
            }
            //experimental block of code ends here

            tC = toCount.Min();
            for (int i = 0; i <= 3; i++)
            {
                if (toCount[i] == tC) 
                { 
                    if      (i == 0){strl = "Hearts";}
                    else if (i == 1){strl = "Clubs";}
                    else if (i == 2){strl = "Diamonds";}
                    else if (i == 3){strl = "Spades";}
                    //mA[tC2] = i.ToString(); tC2 = tC2 + 1; 
                    mA[0] = mA[0] + strl;
                }
            }
            //Console.WriteLine(mA[0]);
            int count = 0;
            if (mA[0].Contains("Hearts")) { count = count + 1; }
            if (mA[0].Contains("Clubs")) { count = count + 1; }
            if (mA[0].Contains("Diamonds")) { count = count + 1; }
            if (mA[0].Contains("Spades")) { count = count + 1; }
            //Console.WriteLine("--------" + mA[0] + "-------");
            if (count == 1) 
            {
                if (mA[0].Contains("Hearts")) 
                {
                    for (int i = 0; i <= 5; i++)
                    {
                        if (p2Cards[i].Contains("Hearts")) { returnd = i; break; }
                    }
                }
                else if (mA[0].Contains("Clubs")) 
                {
                    for (int i = 0; i <= 5; i++)
                    {
                        if (p2Cards[i].Contains("Clubs")) { returnd = i; break; }
                    }
                }
                else if (mA[0].Contains("Diamonds")) 
                {
                    for (int i = 0; i <= 5; i++)
                    {
                        if (p2Cards[i].Contains("Diamonds")) { returnd = i; break; }
                    }
                }
                else if (mA[0].Contains("Spades")) 
                {
                    for (int i = 0; i <= 5; i++)
                    {
                        if (p2Cards[i].Contains("Spades")) { returnd = i; break; }
                    }
                }
            }
            else if (count == 2) 
            {
                if      (mA[0].Contains("Hearts") && mA[0].Contains("Clubs")) 
                {
                    int q = getRand.Next(1, 2);
                    if (q == 1) 
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Hearts")) { returnd = i; break; }
                        }
                    }
                    else if(q == 2)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Clubs")) { returnd = i; break; }
                        }
                    }
                }
                else if (mA[0].Contains("Hearts") && mA[0].Contains("Diamonds")) 
                {
                    int q = getRand.Next(1, 2);
                    if (q == 1)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Hearts")) { returnd = i; break; }
                        }
                    }
                    else if (q == 2)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Diamonds")) { returnd = i; break; }
                        }
                    }
                }
                else if (mA[0].Contains("Hearts") && mA[0].Contains("Spades")) 
                {
                    int q = getRand.Next(1, 2);
                    if (q == 1)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Hearts")) { returnd = i; break; }
                        }
                    }
                    else if (q == 2)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Spade")) { returnd = i; break; }
                        }
                    }
                }
                else if (mA[0].Contains("Clubs") && mA[0].Contains("Diamonds")) 
                {
                    int q = getRand.Next(1, 2);
                    if (q == 1)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Diamonds")) { returnd = i; break; }
                        }
                    }
                    else if (q == 2)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Clubs")) { returnd = i; break; }
                        }
                    }
                }
                else if (mA[0].Contains("Clubs") && mA[0].Contains("Spades")) 
                {
                    int q = getRand.Next(1, 2);
                    if (q == 1)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Spades")) { returnd = i; break; }
                        }
                    }
                    else if (q == 2)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Clubs")) { returnd = i; break; }
                        }
                    }
                }
                else if (mA[0].Contains("Diamonds") && mA[0].Contains("Spades")) 
                {
                    int q = getRand.Next(1, 2);
                    if (q == 1)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Diamonds")) { returnd = i; break; }
                        }
                    }
                    else if (q == 2)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Spades")) { returnd = i; break; }
                        }
                    }
                }
            }//     Hearts  Clubs   Diamonds    Spades
            //      0       1       2           3`
            else if (count == 3) 
            {
                if      (mA[0].Contains("Hearts") && mA[0].Contains("Clubs") && mA[0].Contains("Diamonds")) 
                {
                    int q = getRand.Next(1, 3);
                    if (q == 1)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Hearts")) { returnd = i; break; }
                        }
                    }
                    else if (q == 2)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Clubs")) { returnd = i; break; }
                        }
                    }
                    else if (q == 3)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Diamonds")) { returnd = i; break; }
                        }
                    }
                }
                else if (mA[0].Contains("Hearts") && mA[0].Contains("Clubs") && mA[0].Contains("Spades")) 
                {
                    int q = getRand.Next(1, 3);
                    if (q == 1)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Hearts")) { returnd = i; break; }
                        }
                    }
                    else if (q == 2)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Clubs")) { returnd = i; break; }
                        }
                    }
                    else if (q == 3)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Spades")) { returnd = i; break; }
                        }
                    }
                }
                else if (mA[0].Contains("Hearts") && mA[0].Contains("Diamonds") && mA[0].Contains("Spades")) 
                {
                    int q = getRand.Next(1, 3);
                    if (q == 1)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Hearts")) { returnd = i; break; }
                        }
                    }
                    else if (q == 2)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Diamonds")) { returnd = i; break; }
                        }
                    }
                    else if (q == 3)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Spades")) { returnd = i; break; }
                        }
                    }
                }
                else if (mA[0].Contains("Clubs") && mA[0].Contains("Diamonds") && mA[0].Contains("Spades")) 
                {
                    int q = getRand.Next(1, 3);
                    if (q == 1)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Clubs")) { returnd = i; break; }
                        }
                    }
                    else if (q == 2)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Diamonds")) { returnd = i; break; }
                        }
                    }
                    else if (q == 3)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (p2Cards[i].Contains("Spades")) { returnd = i; break; }
                        }
                    }
                }
            }
            else if (count == 4) { Console.WriteLine("Null"); }
            Thread.Sleep(2000);
            Console.WriteLine(returnd);
            return returnd;
        }
        public void Exit()
        {
            Console.ReadLine();
            Console.Write("\n\t\t\tDo you wish to replay the game[Y/n] :   ");
            /*xandy*/
            string x = Console.ReadLine();
            if (x == "y")
            {
                onStart();
            }
            else
            {
                Environment.Exit(0);
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Program qm = new Program();
            Thread t = new Thread(new ThreadStart(qm.onStart));
            t.Start();//Starting the new thread

            //qm.onStart();
            Console.Read();
        }
    }
}
