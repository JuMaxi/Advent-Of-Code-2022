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
        List<string> Crates = new List<string>();
        List<char> Stacks = new List<char>();
        List<string> WhatToDo = new List<string>();
        List<char> WhatToDoChar = new List<char>();
        List<char> copia = new List<char>();

        public void Solve01()
        {
            string Way = @"C:\Dev\AdventOfCode2022_Day01\AdventOfCode2022-Day05\Example-Day05.txt";
            string[] Read = File.ReadAllLines(Way);

            for (int Position = 0; Position < 3; Position++)
            {
                Crates.Add(Read[Position]);
            }
            for (int Position = 3; Position < 4; Position++)
            {
                string teste = Read[Position];

                for (int Positionteste = 0; Positionteste < teste.Length; Positionteste++)
                {
                    Stacks.Add(teste[Positionteste]);
                }
            }
            for (int Position = 5; Position < Read.Length; Position++)
            {
                WhatToDo.Add(Read[Position]);
            }

            //Escreve movimentos em uma List de Char;
            for (int Positionwhattodo = 0; Positionwhattodo < WhatToDo.Count; Positionwhattodo++)
            {
                string Do = WhatToDo[Positionwhattodo];

                for (int Position = 0; Position < Do.Length; Position++)
                {
                    WhatToDoChar.Add(Do[Position]);
                }

            }

            for (int PositionCrates = 0; PositionCrates < (WhatToDoChar[5]); PositionCrates++)
            {
                string LineActualCrates = Crates[PositionCrates];
                List<char> CratesChar = new List<char>();

                //Salva os Crates em uma variavel char;
                for (int Positionchar = 0; Positionchar < LineActualCrates.Length; Positionchar++)
                {
                    CratesChar.Add(LineActualCrates[Positionchar]);
                }

                //Identifica de onde a pilha e removida(posicao na char), cria uma variavel(copia) com as informacoes da remocao e apaga os mesmos dados da variavel CraterChar.
                for (int PositionStacks = 0; PositionStacks < Stacks.Count; PositionStacks++)
                {
                    if (Stacks[PositionStacks] != ' ')
                    {
                        char From = Stacks[PositionStacks];

                        if (WhatToDoChar[12] == From)
                        {
                            for (int PositionFrom = PositionStacks; PositionFrom < 8; PositionFrom++)
                            {
                                copia.Add(CratesChar[PositionFrom - 1]);
                                CratesChar[PositionFrom - 1] = ' ';
                            }
                            PositionStacks = Stacks.Count;
                        }
                    }
                }

                //Escreve novamente os dados na pilha nova.
                for (int Positioncopia = 0; Positioncopia < copia.Count; Positioncopia++)
                {
                    if (WhatToDoChar[WhatToDoChar.Count - 1] == '1')
                    {
                        CratesChar[Positioncopia] = copia[Positioncopia];
                    }
                    else
                    {
                        CratesChar[Positioncopia + 4] = copia[Positioncopia];
                    }
                }

                string algo = new string(CratesChar.ToArray());
                Crates[PositionCrates] = algo;

                PositionCrates = 0;
            }
        }
















    }
}

