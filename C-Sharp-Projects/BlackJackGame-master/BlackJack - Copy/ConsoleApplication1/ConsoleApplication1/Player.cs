using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Player


    {
        ////Properties
        ///dfdsfd
        //Set properties of the Player class
       public string Name { get; set; }
        
       public int RandomNum { get; set; }

        public int CardValue { get; set; }
        public string CardType { get; set; }

        public string CardSuit { get; set; }

        


        ////Constructors
        public Player( string name,int randomNum,int cardValue,string cardType,string cardSuit )
        {
            
            Name = name;
            RandomNum = randomNum;
            CardValue = cardValue;
            CardType = cardType;
            CardSuit = cardSuit;
          
        }

        ////Methods


        public void PrintDetails()//prints what card is dealt using some of the class properties which have been calculated in the main class.
        {

            Console.WriteLine("The {0} of {1} was dealt \n",CardType,CardSuit);
            
           

        }







    }
}
