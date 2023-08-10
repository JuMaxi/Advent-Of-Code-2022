using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022_Day05
{
    internal class Part01
    {


        public void Solve01()
        {
            string Way = @"C:\Dev\Advent-Of-Code-2022\AdventOfCode2022-Day05\Example-Day05.txt";
            string[] Read = File.ReadAllLines(Way);
            List<string> crafts = new List<string>();
            List<string> moves = new List<string>();

            bool newList = false;
            for (int i = 0; i < Read.Length; i++)
            {
                if (Read[i] == "")
                {
                    newList = true;
                }

                if (newList == false)
                {
                    crafts.Add(Read[i]);
                }
                else
                {
                    moves.Add(Read[i]);
                }
            }



            for (int i = 1; i < moves.Count; i++)
            {
                string line = moves[i];

                int move = Convert.ToInt32(Convert.ToString(line[5]));
                int from = Convert.ToInt32(Convert.ToString(line[12]));


                //Para copiar apenas as linhas que serao alteradas.
                List<string> temp = new List<string>();
                while (move > 0)
                {
                    temp.Add(crafts[move - 1]);
                    move--;
                }

                //Para saber a posicao char para reescrever o caixote.
                int to = Convert.ToInt32(Convert.ToString(line[17]));
                if (to == 1)
                {
                    to = 0;
                }
                else
                {
                    if (to == 2)
                    {
                        to = 4;
                    }
                    else
                    {
                        to = 8;
                    }
                }


                for (int itemp = temp.Count - 1; itemp >= 0; itemp--)
                {
                    List<char> characters = new List<char>();

                    foreach (char c in temp[itemp])
                    {
                        if (c != ' ')
                        {
                            characters.Add(c);
                        }
                    }
                    temp[itemp] = "";

                    string n = "";
                    for(int ii= 0; ii < 11; ii++)
                    {
                        if(ii != to)
                        {
                            n = n + " ";
                            
                        }
                        else
                        {
                            foreach(char c in characters)
                            {
                                n = n + c;
                            }
                            break;
                        }
                    }
                    temp[itemp] = n;
                }
                for (int iCrafts = 0; iCrafts < temp.Count; iCrafts++)
                {
                    crafts[iCrafts] = temp[iCrafts];
                }





            }

        }
















    }
}

