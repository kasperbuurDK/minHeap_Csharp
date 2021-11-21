// See https://aka.ms/new-console-template for more information


using System;

namespace MinHeap
{
    class Program
    {
        

        static void Main(string[] args)
        {
            
            var minHeapSize = 15;
            int[] minHeapArray = new int[minHeapSize +1]; //root is at position 1, 0 is not used
            int[] inputArray = { 1,8,11,16,9,20,21,22,23,34,22,8,77,43,17,32,2,8,9,6,31,5,2,8,5,11,56,22,11,8,15,22,5,6,7,40};
            minHeapArray[0] = 0;
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
            


        }

        private void AddRestOfInput(int[] inputArray, int[] minHeapArray, int positionInInputArray)
        {
            for (int i = positionInInputArray; i < inputArray.Length; i++)
            {
                if (inputArray[i] <= minHeapArray[1]) continue;
                insert(inputArray[i], minHeapArray);
            }
        }

        private void insert(int newValue, int[] minHeapArray)
        {
            minHeapArray[1] = newValue;
            SortTop(minHeapArray, 1);
        }

        private void HeapifyAlaFloyd(int[] minHeapArray)
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
                int tempValue;
                int indexToSwap;
                if (minHeapArray[currentNode] > minHeapArray[currentNode*2] || minHeapArray[currentNode] > minHeapArray[currentNode*2+1] )
                {
                    tempValue = minHeapArray[currentNode];
                    
                    if (minHeapArray[currentNode*2] < minHeapArray[currentNode*2+1] )
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
                if (minHeapArray[currentNode] > minHeapArray[currentNode*2] || minHeapArray[currentNode] > minHeapArray[currentNode*2+1] )
                {
                    var tempValue = minHeapArray[currentNode];
                    
                    if (minHeapArray[currentNode*2] < minHeapArray[currentNode*2+1] )
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
                    if (minHeapArray[indexToSwap] > minHeapArray[indexToSwap*2] || minHeapArray[indexToSwap] > minHeapArray[indexToSwap*2+1])
                    {
                        var tempValue = minHeapArray[indexToSwap];
                        int anotherIndexToSwap;
                        if (minHeapArray[indexToSwap*2] < minHeapArray[indexToSwap*2+1] )
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

        private void SortTop(int[] minHeapArray, int currentNode)
        {
            var indexToSwap = 0;
            if (minHeapArray[currentNode] > minHeapArray[currentNode * 2] || minHeapArray[currentNode] > minHeapArray[currentNode * 2 + 1])
            {
                var tempValue = minHeapArray[currentNode];

                if (minHeapArray[currentNode * 2] < minHeapArray[currentNode * 2 + 1])
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
                if (minHeapArray[indexToSwap] > minHeapArray[indexToSwap * 2] || minHeapArray[indexToSwap] > minHeapArray[indexToSwap * 2 + 1])
                {
                    var tempValue = minHeapArray[indexToSwap];

                    if (minHeapArray[indexToSwap * 2] < minHeapArray[indexToSwap * 2 + 1])
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
                if (minHeapArray[anotherIndexToSwap] > minHeapArray[anotherIndexToSwap * 2] || minHeapArray[anotherIndexToSwap] > minHeapArray[anotherIndexToSwap * 2 + 1])
                {
                    var tempValue = minHeapArray[anotherIndexToSwap];

                    if (minHeapArray[anotherIndexToSwap * 2] < minHeapArray[anotherIndexToSwap * 2 + 1])
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


        private int ArbitraryAdd(int[] inputArray, int[] recievingArray)
        {
            for (int i = 0; i < recievingArray.Length-1; i++)
            {
                recievingArray[i+1] = inputArray[i];
            }

            return recievingArray.Length - 1;
        }

        private void PrintMinHeap(int[] arrayToPrint)
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
 
        
    }
}





    
    

       

       


        
        
      

       

    





