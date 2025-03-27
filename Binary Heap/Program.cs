//	• Zaimplementuj minimalną stertę/kopiec reprezentowaną jako tablica
//	• Wykonaj wstawianie (w pierwszym pustym miejscu i w razie potrzeby przesuń w górę)
//	• Zaimplementuj usuwanie

//Przypadek użycia
//	• Wstaw 15, 40, 30, 50, 10, 100, 40
//	• Sprawdź, czy w tej strukturze danych znajduje się liczba 40.
//	• Wydrukuj wszystkie odwiedzone elementy przed znalezieniem 40
//  • Usuń 10

//Wzory
//(index − 1)/2 (parent index)
//– 2 index + 1(left child) ∗ index + 1(left child)
//– 2 index + 2(right child)

string scissors = "\n8<----------------------------------------------------------";

//MAIN
//Tworzenie kopca
MinHeap Heap1 = new MinHeap();

//Wstawienie elementów:
Heap1.Wstaw(15);
Heap1.Wydrukuj();
Heap1.Wstaw(40);
Heap1.Wydrukuj();
Heap1.Wstaw(30);
Heap1.Wydrukuj();
Heap1.Wstaw(50);
Heap1.Wydrukuj();
Heap1.Wstaw(10);
Heap1.Wydrukuj();
Heap1.Wstaw(100);
Heap1.Wydrukuj();
Heap1.Wstaw(40);
Heap1.Wydrukuj();

//dodatkowo
Heap1.Wstaw(20);
Heap1.Wydrukuj();

Console.WriteLine(scissors);

//Znalezienie elementu
Heap1.ZnajdzElem(40);

Console.WriteLine(scissors);

//Usunięcie elementu
Heap1.UsunElem(10);
Heap1.Wydrukuj();


Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("CopyRights Anastasiia Bzova 66617");
Console.ReadLine();
Console.ResetColor();
//


public class MinHeap
{
    private List<int> kopiec;
    public MinHeap()       //konstrutor tworzenia kopca
    {
        kopiec = new List<int>();
    }
    List<int> indeksyElementu = new List<int>();

    public void Wstaw(int elem)      //metoda wstawiania elementu do kopca
    {
        Console.WriteLine($"nowy element w kopcu - {elem}");
        //Tak samo jak  - kopiec[kopiec.Count] = elem;
        kopiec.Add(elem);
        MinHeapifyUp();

    }
    public void MinHeapifyUp()
    {
        int index = kopiec.Count - 1;       //ostatni index kopca

        while (index >= 0 && kopiec[index] < kopiec[(index - 1) / 2])       //powtarzanie się dopóki index >  0  && kopiec[index] < kopiec[Indexrodzica]
        {
            //zamiana:
            int temp = kopiec[index];
            kopiec[index] = kopiec[(index - 1) / 2];
            kopiec[(index - 1) / 2] = temp;
            index = (index - 1) / 2;
        }
    }


    public bool ZnajdzElem(int elem)
    {
        Console.WriteLine($"Szukany element - {elem}");
        indeksyElementu.Clear();
        //przebieramy indeksy zaczynając od zera:
        for (int i = 0; i < kopiec.Count; i++)
        {
            if (elem == kopiec[i])
            {
                indeksyElementu.Add(i);
                continue;
            }
        }
        if (indeksyElementu.Count == 0)
        {
            Console.WriteLine("Element nie znaleziono :(");
            return false;
        }
        else
        {
            Console.WriteLine("Znaleziono element po indeksami:");
            foreach (int item in indeksyElementu)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
            return true;
        }
    }

    public bool UsunElem(int elem)
    {

        Console.WriteLine($"Usuwany element - {elem}");
        if (ZnajdzElem(elem))
        {
            int index = indeksyElementu[0];       //pierwszy znaleziony index elementu do usuwania
            int lastindex = kopiec.Count - 1;       //ostatni index kopca

            //zamiana elementu z ostatnim:
            int temp = kopiec[index];
            kopiec[index] = kopiec[lastindex];
            kopiec[lastindex] = temp;

            kopiec.RemoveAt(lastindex);       //usunięcie ostatniego elementu

            MinHeapifyDown(index);
            return true;
        }
        else
        {
            Console.WriteLine("Element nie znaleziono :(");
            return false;

        }
    }
    public void MinHeapifyDown(int index)
    {
        //poprawa kolejności kopca:
        while (index < kopiec.Count)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int smallindex = index;

            if (leftChildIndex < kopiec.Count && kopiec[leftChildIndex] < kopiec[smallindex])
                smallindex = leftChildIndex;

            if (rightChildIndex < kopiec.Count && kopiec[rightChildIndex] < kopiec[smallindex])
                smallindex = rightChildIndex;

            if (smallindex == index)
                break;

            //zamiana:
            int temp = kopiec[index];
            kopiec[index] = kopiec[smallindex];
            kopiec[smallindex] = temp;
            index = smallindex;
        }
    }

    public void Wydrukuj()      //metoda wydrukowania
    {
        foreach (int item in kopiec)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }


}
