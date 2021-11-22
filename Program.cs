// See https://aka.ms/new-console-template for more information


using System;

namespace MinHeap
{

    public struct IndexData
    {
       public int index { get; set; }
       public int data { get; set; }
       public override string ToString() => $"({index}, {data})";
    }
    class Program
    {
        static void Main(string[] args)
        {
            var minHeapSize = 15;
            IndexData[] minHeapArray = new IndexData[minHeapSize +1]; //root is at position 1, 0 is not used
            int[] dataInput = {
                1, 8, 11, 16, 9, 20, 21, 22, 23, 34, 22, 8, 77, 43, 17, 32, 2, 8, 9, 6, 31, 5, 2, 8, 5, 11, 56, 22, 11, 8, 15,
                22, 5, 6, 7, 40
            };
            IndexData[] inputArray = new IndexData[36];

            for (var i = 0; i < inputArray.Length; i++)
            {
                inputArray[i].index = i;
                inputArray[i].data = dataInput[i];
            }
            /*
            
            */
            minHeapArray[0].index = minHeapArray[0].data = 0;
            int positionInInputArray = 0;
            
            //creating object of class Program
            Program p = new();
            System.Console.WriteLine("Inputarray is");
            for (int i = 0; i < inputArray.Length; i++)
            {
                System.Console.Write(inputArray[i] + ",");
            }
            System.Console.WriteLine("End of input array");
         
            positionInInputArray = p.ArbitraryAdd(inputArray, minHeapArray); // Calling method to fill minheapArray
            System.Console.WriteLine("Heap after arbitraryadd");
            p.PrintMinHeap(minHeapArray); // Calling method
            p.HeapifyAlaFloyd(minHeapArray);
            System.Console.WriteLine("Heap after heapifyAlaFloyd");
            p.PrintMinHeap(minHeapArray);
            p.AddRestOfInput(inputArray, minHeapArray, positionInInputArray);
            System.Console.WriteLine("Heap after end of input");
            p.PrintMinHeap(minHeapArray);
            p.AlternativePrintMinHeap(minHeapArray);
            
            


        }

        private void AddRestOfInput(IndexData[] inputArray, IndexData[] minHeapArray, int positionInInputArray)
        {
            for (int i = positionInInputArray; i < inputArray.Length; i++)
            {
                if (inputArray[i].data <= minHeapArray[1].data) continue;
                insert(inputArray[i], minHeapArray);
            }
        }

        private void insert(IndexData newValue, IndexData[] minHeapArray)
        {
            minHeapArray[1] = newValue;
            SortTop(minHeapArray, 1);
        }

        private void HeapifyAlaFloyd(IndexData[] minHeapArray)
        {
            var currentNode = (minHeapArray.Length-1)/2;
            
            while (currentNode > 3)
            {
                SortBottom();
                currentNode--;
            }

            while (currentNode >1)
            {
                SortMiddle();
                currentNode--;
            }

            SortTop(minHeapArray, currentNode);
            
            void SortBottom()
            {
                IndexData tempValue;
                int indexToSwap;
                if (minHeapArray[currentNode].data > minHeapArray[currentNode*2].data || minHeapArray[currentNode].data > minHeapArray[currentNode*2+1].data )
                {
                    tempValue = minHeapArray[currentNode];
                    
                    if (minHeapArray[currentNode*2].data < minHeapArray[currentNode*2+1].data )
                    {
                        indexToSwap = currentNode*2;
                        
                    }
                    else
                    {
                        indexToSwap = currentNode * 2 + 1;
                    }
                    minHeapArray[currentNode] = minHeapArray[indexToSwap];
                    minHeapArray[indexToSwap] = tempValue;
                }
            }
            
            void SortMiddle()
            {
                var indexToSwap = 0;
                if (minHeapArray[currentNode].data > minHeapArray[currentNode*2].data || minHeapArray[currentNode].data > minHeapArray[currentNode*2+1].data )
                {
                    var tempValue = minHeapArray[currentNode];
                    
                    if (minHeapArray[currentNode*2].data < minHeapArray[currentNode*2+1].data )
                    {
                        indexToSwap = currentNode*2;
                        
                    }
                    else
                    {
                        indexToSwap = currentNode * 2 + 1;
                    }
                    minHeapArray[currentNode] = minHeapArray[indexToSwap];
                    minHeapArray[indexToSwap] = tempValue;
                }

                if (indexToSwap != 0)
                {
                    if (minHeapArray[indexToSwap].data > minHeapArray[indexToSwap*2].data || minHeapArray[indexToSwap].data > minHeapArray[indexToSwap*2+1].data)
                    {
                        var tempValue = minHeapArray[indexToSwap];
                        int anotherIndexToSwap;
                        if (minHeapArray[indexToSwap*2].data < minHeapArray[indexToSwap*2+1].data )
                        {
                            anotherIndexToSwap = indexToSwap*2;
                        
                        }
                        else
                        {
                            anotherIndexToSwap = indexToSwap * 2 + 1;
                        }
                        minHeapArray[indexToSwap] = minHeapArray[anotherIndexToSwap];
                        minHeapArray[anotherIndexToSwap] = tempValue;
                    
                    }
                }
                
            }
        }

        private void SortTop(IndexData[] minHeapArray, int currentNode)
        {
            var indexToSwap = 0;
            if (minHeapArray[currentNode].data > minHeapArray[currentNode * 2].data || minHeapArray[currentNode].data > minHeapArray[currentNode * 2 + 1].data)
            {
                var tempValue = minHeapArray[currentNode];

                if (minHeapArray[currentNode * 2].data < minHeapArray[currentNode * 2 + 1].data)
                {
                    indexToSwap = currentNode * 2;
                }
                else
                {
                    indexToSwap = currentNode * 2 + 1;
                }

                minHeapArray[currentNode] = minHeapArray[indexToSwap];
                minHeapArray[indexToSwap] = tempValue;
            }
            else
            {
                return;
            }

            var anotherIndexToSwap = 0;
            if (indexToSwap != 0)
            {
                if (minHeapArray[indexToSwap].data > minHeapArray[indexToSwap * 2].data || minHeapArray[indexToSwap].data > minHeapArray[indexToSwap * 2 + 1].data)
                {
                    var tempValue = minHeapArray[indexToSwap];

                    if (minHeapArray[indexToSwap * 2].data < minHeapArray[indexToSwap * 2 + 1].data)
                    {
                        anotherIndexToSwap = indexToSwap * 2;
                    }
                    else
                    {
                        anotherIndexToSwap = indexToSwap * 2 + 1;
                    }

                    minHeapArray[indexToSwap] = minHeapArray[anotherIndexToSwap];
                    minHeapArray[anotherIndexToSwap] = tempValue;
                }
                else
                {
                    return;
                }
            }

            if (anotherIndexToSwap != 0)
            {
                if (minHeapArray[anotherIndexToSwap].data > minHeapArray[anotherIndexToSwap * 2].data || minHeapArray[anotherIndexToSwap].data > minHeapArray[anotherIndexToSwap * 2 + 1].data)
                {
                    var tempValue = minHeapArray[anotherIndexToSwap];

                    if (minHeapArray[anotherIndexToSwap * 2].data < minHeapArray[anotherIndexToSwap * 2 + 1].data)
                    {
                        indexToSwap = anotherIndexToSwap * 2;
                    }
                    else
                    {
                        indexToSwap = anotherIndexToSwap * 2 + 1;
                    }

                    minHeapArray[anotherIndexToSwap] = minHeapArray[indexToSwap];
                    minHeapArray[indexToSwap] = tempValue;
                }
                else
                {
                    return;
                }
            }
        }


        private int ArbitraryAdd(IndexData[] inputArray, IndexData[] recievingArray)
        {
            for (int i = 0; i < recievingArray.Length-1; i++)
            {
                recievingArray[i+1] = inputArray[i];
            }

            return recievingArray.Length - 1;
        }

        private void PrintMinHeap(IndexData[] arrayToPrint)
        {
            Console.WriteLine("minHeapArray start");
            for (int i = 1; i < arrayToPrint.Length; i++)
            {
                System.Console.Write(arrayToPrint[i] + ",");
            }
            Console.WriteLine();
            Console.WriteLine("minHeapArray end");
            Console.WriteLine("-------------------------- MinHeap as tree ----------------------");
            Console.WriteLine("\t\t\t\t     |" + arrayToPrint[1] + "|");            
            Console.WriteLine("\t\t    |" + arrayToPrint[2] + "|\t\t\t\t   |" + arrayToPrint[3]+"|");
            Console.WriteLine();
            Console.WriteLine("\t\t|" + arrayToPrint[4] + "| \t|" +  arrayToPrint[5] + "|\t\t\t |" + arrayToPrint[6] + "| \t|" +arrayToPrint[7] + "|");            
            Console.WriteLine();
            Console.WriteLine(" \t|" + arrayToPrint[8] + "|   |" + arrayToPrint[9] + "|\t|" + arrayToPrint[10] + "|  |" + arrayToPrint[11] + "|\t  |"
                              + arrayToPrint[12] + "|   |" + arrayToPrint[13] + "| \t |" + arrayToPrint[14] + "|   |" + arrayToPrint[15] + "|");            
            Console.WriteLine(" ------------------------------------------------------------------");            
 
            
            
        }

        private void AlternativePrintMinHeap(IndexData[] arrayToPrint)
        {
            Console.Out.WriteLine("----------------MINHEAP SidelyingTree");

            Console.Out.WriteLine("                     {0}", arrayToPrint[15]);
            Console.Out.WriteLine("             {0}", arrayToPrint[7]);
            Console.Out.WriteLine("                     {0}", arrayToPrint[14]);
            Console.Out.WriteLine("");
            Console.Out.WriteLine("     {0}", arrayToPrint[3]);
            Console.Out.WriteLine("");
            Console.Out.WriteLine("                     {0}", arrayToPrint[13]);
            Console.Out.WriteLine("             {0}", arrayToPrint[6]);
            Console.Out.WriteLine("                     {0}", arrayToPrint[12]);
            Console.Out.WriteLine("");
            Console.Out.WriteLine("{0}",arrayToPrint[1]);
            Console.Out.WriteLine("");
            Console.Out.WriteLine("                     {0}", arrayToPrint[11]);
            Console.Out.WriteLine("             {0}", arrayToPrint[5]);
            Console.Out.WriteLine("                     {0}", arrayToPrint[10]);
            Console.Out.WriteLine("");
            Console.Out.WriteLine("     {0}", arrayToPrint[2]);
            Console.Out.WriteLine("");
            Console.Out.WriteLine("                     {0}", arrayToPrint[9]);
            Console.Out.WriteLine("             {0}", arrayToPrint[4]);
            Console.Out.WriteLine("                     {0}", arrayToPrint[8]);
        }
        
    }
}





    
    

       

       


        
        
      

       

    





