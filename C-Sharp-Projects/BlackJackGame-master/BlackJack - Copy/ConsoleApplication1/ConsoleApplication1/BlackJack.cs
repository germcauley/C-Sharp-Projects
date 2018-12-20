//s00174412 Gerald McAuley 
//Final Assignment BlackJack game

//Rough outline of program
//Welcome screen appears

//deal card 1 to player(this will initally be a random value between 1-52 as there are 52 cards in a deck)
//different suits are represented by different ranges 1-13 is Hearts, 14-26 Diamonds,27-39 Spades, 40-52 Clubs, 
//Remainder from Randomvalue%13 will be used to indicate cards face value. eg Random%13 =0 is King value%13=1 is Ace, value%13 =2 is 2 etcetc 
//Random values are added to an array of values between 1-52.This will be used to make sure no card is dealt twice and will give an error is a card has already been used.
//deal 2nd card to player
//make sure random value between 1-52 hasnt already been used (check array)
//repeat above steps for dealer
//log value of cards to array of used values


//This is end of round one of the game.Player is now asked to stick or twist
//if player 1 decides to twist he is dealt another card which is once again tested for duplication in the 'dealt cards' array
//if the score is 21 or more player must stick
//if player 1 sticks it is dealer turn

//repeat steps for dealer
//dealer is automated to twist if his cards are worth less than 17
//dealer will stick if his cards are worth 17 or more
//once dealer sticks scores are counted and checked
//winner is declared and option to play again is displayed



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class BlackJack
    {
        
        static void Main(string[] args)
        {///DECLARE VARIABLES
            string response = ("y");//some variables declared
                   
           


            //Display Menu
            DisplayMenu();//Calls a method and displays menu outlining the rules of the game
            Console.Clear();//Clears the screen
            
           
            //MAIN SECTION
            while (response != "n")//while loop which will run the code so long as the user input is not 'n'
            {
                //Declare variables inside while loop so they reset if player chooses to play again
                string choice = ("s"), dealerChoice = ("s");
                int value, PlayerScore = 0, DealerScore = 0;
                int i = 0, j = 0, k = 0, l = 0;
                int[] cardsDealtArray = new int[52] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                //array declared, 52 values in array all set to zero initially.Card values will be added to indexes later as cards are dealt




                
            
                ///PLAYER1 HAS 2 CARDS DEALT
                while ( i != 2)//while loop runs this section twice so that player1 is dealt 2 cards
                {
                    Console.Clear();//Clear the screen
                    Console.WriteLine("Dealing Player1 cards....");
                    Console.ReadLine();
                   value = RandomNumber();//A random number is generated and assigned to a variable called 'value'
                   // value = 5;//To test the array which checks for duplicate cards Uncomment this line and comment the above line. Then start the program again. The second card dealt will return error

                    if (value != cardsDealtArray[value - 1])//if the randomvalue is NOT in the array the code will run(Its not actualy required for first card dealt but is needed for every card after that)
                    {
                        cardsDealtArray[value-1] = value;//the random number is added to the array at the index of the randomnumber -1 due to the nature of array starting at 0
                        Player Player1 = new Player("Player1", value, AssignCardValue(value), GetCardType(GetRemainderValue(value)), GetCardSuit(value)); //player1 attributes are assigned using methods
                        PlayerScore += Player1.CardValue;//the cardvalue is added to player1 score
                        Player1.PrintDetails();//Information about the card dealt is displayed
                        Console.WriteLine("Player1 score is {0}\n", PlayerScore);//player1 score is displayed
                        Console.ReadLine();
                        i ++;
                        Console.Clear();
                    }
                    else
                    {//if the random value is already in the array an error message is displayed
                        Console.WriteLine("Cant use that card it has already been dealt!!!");
                        Console.ReadLine();
                        
                    }

                }//end of while loop






                //STICK OR TWIST PROMPT
                Console.WriteLine("Player1, your score is {0} \n\nDo you want to stick or twist (s/t)?", PlayerScore); //Player now has 2 cards. Player score displayed and is prompted to stick or twist
                choice = Console.ReadLine();//Player inputs choice of s or t
                Console.Clear();//Screen is cleared




                //TWIST OR STICK
                while (choice != "s")//If the player chooses 't' then this section of code will run
                {
                    k = 0;
                    Console.WriteLine("Player1 decided to twist\n");
                    Console.WriteLine("Dealing Player1 cards....");
                    Console.ReadLine();
                    //Player card is dealt, similar to the previous section
                    while ( k !=1)//Card will be dealt so long as k is not equal to 1
                    {
                        value =  RandomNumber();   //Random value is generated and assigned to a variable
                        if (value != cardsDealtArray[value - 1])//Checks If the random value is not in the array
                        {
                            cardsDealtArray[value - 1] = value;//assigns random value to the array
                            Player Player1 = new Player("Player1", value, AssignCardValue(value), GetCardType(GetRemainderValue(value)), GetCardSuit(value));//Player 1 attributes are assigned
                            PlayerScore += Player1.CardValue;//The card value is added toPlayer score
                            Player1.PrintDetails();////Information about the card dealt is displayed
                            Console.WriteLine("Player1 score is {0}", PlayerScore);//Player1 score is displayed
                            Console.ReadLine();
                            k = 1;//k is made equal to 1 so the while loop will stop
                        }
                        else
                        {//if the random value is already in the array and error message is displayed
                            Console.WriteLine("Cant use that card it has already been dealt!!!");
                            Console.ReadLine();
                           
                        }

                       

                    }//end of inner while loop
                    
                    Console.Clear();//Clear the screen

                   
                        
                        
                    if (PlayerScore >= 21)//if playerscore is 21 or more Player must automatically stick
                    {
                        Console.WriteLine("Player1, your score is {0} ", PlayerScore);//Player score displayed 
                        choice = "s";
                    }
                    else//otherwise player has option to stick or twist
                    {
                        Console.WriteLine("Player1, your score is {0} \nDo you want to stick or twist?", PlayerScore);//Player score displayed and is prompted to stick or twist
                        choice = Console.ReadLine();
                    }
                    
                }//end of outer while loop






                //DEALER 2 CARDS DEALT
                Console.WriteLine("Player1 decided to stick");
                Console.ReadLine();
                Console.Clear();

                while (j !=2)//while loop runs this section twice so that player1 is dealt 2 cards
                {
                    ///Dealer cards are dealt
                    
                    Console.WriteLine("Dealing Dealer's cards....");
                    Console.ReadLine();
                    value = RandomNumber();//A random number is generated and assigned to a variable called 'value'
                    //value = 5;To test the array which checks for duplicate cards Uncomment this line and comment the above line. Then start the program again. The second card dealt will reurn error
                    
                    if (value != cardsDealtArray[value - 1])//if the randomvalue is NOT in the array the code will run
                    {
                        cardsDealtArray[value - 1] = value;//the random number is added to the array at the index of the randomnumber -1 due to the nature of array starting at 0
                        Player Dealer = new Player("Dealer", value, AssignCardValue(value), GetCardType(GetRemainderValue(value)), GetCardSuit(value));//Dealer attributes assigned
                        Dealer.PrintDetails();//Information about the card dealt is displayed
                        DealerScore += Dealer.CardValue;//Cardvalue added to score
                        Console.WriteLine("Dealer's score is {0}", DealerScore);//score is displayed
                        Console.ReadLine();
                        j ++;
                    }
                    else//if the random number is already in the array this section of code will run
                    {
                        Console.WriteLine("Cant use that card it has already been dealt!!!");
                        Console.ReadLine();
                        
                    }
                }
                Console.Clear();//Clears screen, Dealer now has 2 cards




              
                //DEALER STICK OR TWIST
                
                if (DealerScore<17) { dealerChoice = "t"; }// if the dealer's score is less than 17 it will automatically choose 'twist' and request another card otherwise it will choose 'stick'
                else { dealerChoice = "s"; }
                Console.Clear();

                while (dealerChoice != "s")//As long as the dealer's choice is to 'twist' this code will run
                {
                    l = 0;
                    Console.WriteLine("Dealer decided to twist");
                    Console.WriteLine("Dealing dealer's cards....");
                    Console.ReadLine();

                    while(l !=1) //As long as variable l is not equal to 1 this code will run
                    {
                        value = RandomNumber();//Generate random number
                        if (value != cardsDealtArray[value - 1]) //If the random number is not already in the array this code will run
                        {
                            cardsDealtArray[value - 1] = value;//Places the random number in the array
                            Player Dealer = new Player("Dealer", value, AssignCardValue(value), GetCardType(GetRemainderValue(value)), GetCardSuit(value));//Dealer attributes assigned
                            Dealer.PrintDetails();//Information about the card dealt is displayed
                            DealerScore += Dealer.CardValue;//the cardvalue is added to score
                            Console.WriteLine("Dealerscore is {0}", DealerScore);//Display score
                            Console.ReadLine();
                            l = 1;// l is made equal to 1 and while oop ends
                        }
                        else
                        {//if the random number is already in the array this will run
                            Console.WriteLine("Cant use that card it has already been dealt!!!");
                            Console.ReadLine();
                           
                        }


                    }
                    
                    Console.Clear();//Clear the screen



                    if (DealerScore >= 17) { dealerChoice = "s"; }//if the dealer score is more than 17 the dealer will automatically choose 'stick'
                    else { dealerChoice = "t"; }

                }//end of while loop (stick or twist for dealer)
                Console.WriteLine("Dealer score is {0}",DealerScore);
                Console.WriteLine("Dealer decided to stick");
                Console.ReadLine(); //END OF CARD DEALING AS BOTH PLAYER HAVE CHOSEN STICK
                Console.Clear();//clear screen

                //CALCULATE WINNER

                if (PlayerScore > DealerScore&& PlayerScore <= 21)//If player1 has a greater score than the Dealer and Player1 score is less than or equal to 21 Player 1 wins
                {
                    Console.WriteLine("♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣  Player1 wins!!! ♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣\n\n ");
                }
                    
                else if (DealerScore > PlayerScore && DealerScore <= 21)//If Dealer has a greater score than the Player and Dealerscore is less than or equal to 21 Dealer wins
                {
                    Console.WriteLine("♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣  Dealer wins!!! ♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣ \n\n");
                }
                    
                else if (PlayerScore >21 && DealerScore <= 21)//if Player 1 score is more than 21 and Dealer is less than 21 Dealer wins
                {
                    Console.WriteLine("♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣  Dealer wins!!! ♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣ \n\n");
                }
                else if (DealerScore >21 && PlayerScore <= 21) //if Dealer score is more than 21 and PlayerScore is less than 21 Player1 wins
                {
                    Console.WriteLine("♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣  Player1 wins!!! ♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣\n\n ");
                }
                else
                    Console.WriteLine("♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣  It's a draw!!! ♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣ \n\n");//Otherwise its a draw






               // TEST CODE TO SEE IF ARRAY TAKES VALUES OF CARDS CORRECTLY.PRINTS ALL INDEXES IN ARRAY AND SHOWS WHAT RANDOM NUMBERS HAVE BEEN GENERATED AND STORED IN THE ARRAY
                //Console.WriteLine("The index is");
                //for (var x = 0; x < 52; x++)
                //{
                //    Console.WriteLine("Index{0} is :" + cardsDealtArray[x], x);
                //}





                Console.WriteLine("Do you want to play again? (y/n)");//PROMPT USER TO PLAY AGAIN y/n?
                response = Console.ReadLine();//User input response
            }//end of first while loop





            //If player decides to exit the game by typing 'n'. leave the while loop
            Console.Clear();//clear screen
            Console.WriteLine("\t\t  Thank you for playing.\n\n♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣ Goodbye! ♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣ ");//display goodbye message
            Console.ReadLine();

        }

      
       /////METHODS
      
        //Display menu
        public static void DisplayMenu()//displays a menu
        {
            Console.WriteLine("\t♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣    Welcome to Blackjack    ♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣\n\n");
            Console.WriteLine("Rules of the game:\n");
            Console.WriteLine("♠The goal of the game is to get the score closest to 21 with\nyour combination of cards\n");
            Console.WriteLine("♣Each player starts with 2 cards and can choose to stick with\nthese or deal another card which might get you closer to 21\n");
            Console.WriteLine("♥If your score goes above 21 you lose\n\n");
            Console.WriteLine("♦Press enter to continue...");
            Console.ReadLine();
        }
        
       
      

        public static int RandomNumber()//generate random number between 1 -52 and returns it as an int
        {
            Random rnd = new Random();
            int Randomvalue = rnd.Next(1, 53);
            //Console.WriteLine("The Random number is:"+Randomvalue);
            //Console.ReadLine();
            return Randomvalue;
        }

        public static string GetCardSuit(int RandomValue)//Takes randomValue as input. 
            //Returns a string which will be the suit assigned to a card depending on what range the number falls into. 52/4 is 13 so every 13 numbers are reserved for a different card suit
        {
            
            
            if (RandomValue >= 1 && RandomValue <= 13)//if random number is between 1-13 card will be hearts
            {
                
                return ("Hearts");
            }
            else if (RandomValue >=14 && RandomValue <= 26)//if number is between 14 and 26 cardwill be diamonds
            {


                return ("Diamonds");
            }
            else if (RandomValue >=27 && RandomValue <= 39)//if number is between 27 and 29 card will be spades
            {

                return ("Spades");
            }
            else
            {
                return ("Clubs");//otherwise card is clubs
            }

               
        }

        public static int AssignCardValue(int RandomValue)//Takes random value as input and returns an int.
            //Remainder of RandomValue%13 is used to assign a value eg 41 %13 is 2, this will give us a 2 card. Remainder 0,1 11 and 12  are reserved for picture cards
        {
            int cardValue;
            if (RandomValue % 13 == 1)
            {
                cardValue = 11;//For Ace
                return cardValue;
            }
           else if (RandomValue % 13 == 2)
            {
                cardValue = 2;
                return cardValue;
            }
            else if (RandomValue % 13 == 3)
            {
                cardValue = 3;
                return cardValue;
            }
            else if (RandomValue % 13 == 4)
            {
                cardValue = 4;
                return cardValue;
            }
            else if (RandomValue % 13 == 5)
            {
                cardValue = 5;
                return cardValue;
            }
            else if (RandomValue % 13 == 6)
            {
                cardValue = 6;
                return cardValue;
            }
            else if (RandomValue % 13 == 7)
            {
                cardValue = 7;
                return cardValue;
            }
            else if (RandomValue % 13 == 8)
            {
                cardValue = 8;
                return cardValue;
            }
            else if (RandomValue % 13 == 9)
            {
                cardValue = 9;
                return cardValue;
            }
            else if (RandomValue % 13 == 10)
            {
                cardValue = 10;
                return cardValue;
            }
            else if (RandomValue % 13 == 11)
            {
                cardValue = 10;//For Jack
                return cardValue;
            }
            else if (RandomValue % 13 == 12)
            {
                cardValue = 10;//for Queen
                return cardValue;
            }
            else 
            {
                cardValue = 10;//For king
                return cardValue;
            }
           
        }

        public static int GetRemainderValue(int RandomValue)//The same method as above but returns the remainder instead of the cardvalue. Remainder is used to generate string for our output message
        {
            int remainder;
            if (RandomValue % 13 == 1)
            {
                remainder = 1;//For Ace
                return remainder;
            }
            else if (RandomValue % 13 == 2)
            {
                remainder = 2;
                return remainder;
            }
            else if (RandomValue % 13 == 3)
            {
                remainder = 3;
                return remainder;
            }
            else if (RandomValue % 13 == 4)
            {
                remainder = 4;
                return remainder;
            }
            else if (RandomValue % 13 == 5)
            {
                remainder = 5;
                return remainder;
            }
            else if (RandomValue % 13 == 6)
            {
                remainder = 6;
                return remainder;
            }
            else if (RandomValue % 13 == 7)
            {
                remainder = 7;
                return remainder;
            }
            else if (RandomValue % 13 == 8)
            {
                remainder = 8;
                return remainder;
            }
            else if (RandomValue % 13 == 9)
            {
                remainder = 9;
                return remainder;
            }
            else if (RandomValue % 13 == 10)
            {
                remainder = 10;
                return remainder;
            }
            else if (RandomValue % 13 == 11)
            {
                remainder = 11;//For Jack
                return remainder;
            }
            else if (RandomValue % 13 == 12)
            {
                remainder = 12;//for Queen
                return remainder;
            }
            else
            {
                remainder = 0;//For king
                return remainder;
            }
        }

        public static string GetCardType(int remainderValue)//takes remainder of the above  method as input and uses it to return the correct string for our card.
            //This is used in our output message from the PrintDetails method in the PlayerClass.
        {
            int val = remainderValue;
            if (remainderValue == 0)
            {
                return "King";
            }
            else if (remainderValue == 12)
            {
                return "Queen";
            }
            else if(remainderValue == 11)
            {
                return "Jack";
            }
            else if(remainderValue == 1)
            {
                return "Ace";

            }
            else
            {
                return remainderValue.ToString();
            }
        }

        



    }///END OF CLASS
}//END OF NAMESPACE
