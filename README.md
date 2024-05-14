Міністерство освіти і науки України
Національний технічний університет України «Київський політехнічний
інститут імені Ігоря Сікорського»
Факультет інформатики та обчислювальної техніки

Кафедра інформатики та програмної інженерії


Звіт

з лабораторної роботи № 6
з дисципліни
«Алгоритми та структури даних. Частина 2. Структури даних»

«Метод швидкого сортування»





 
Виконав(ла) 


Перевірив


ІП-33 Цапурда Є. Д.
(шифр, прізвище, ім'я, по батькові)
	
Соколовський В. В
(прізвище, ім'я, по батькові)

 



Київ 2024
Постановка задачі:
В даній роботі необхідно розв'язати наступну задачу визначення послідовності медіан для заданого вхідного масиву. Нагадаємо, що медіаною для масиву називається елемент, який займає середнє положення у відсортованому масиві. Так, якщо кількість елементів у масиві непарна, то медіана одна та індекс її у відсортованому масиві визначається як [n/2] (де n — розмір вхідного масиву). Якщо кількість елементів у масиві парна, то медіан буде дві та їх індекси визначаються за формулами [n/2] та [n/2] + 1.
Задача формулюється наступним чином. Нехай заданий вхідний масив A = [x1, ..., xN]. Припустимо, що елементи масиву поступають на вхід програми послідовно: в кожний момент часу розглядається новий елемент xi. Необхідно для кожного i (від 1 до N) визначити медіану підмасиву A' = [x1, ..., xi], тобто медіану для масиву елементів, які були отримані програмою на даний момент часу. Необхідно розв’язати цю задачу, використовуючі структури даних пірамід і так, щоб кожна медіана визначалась за час O(log(i)).
Псевдокод алгоритму:
1. class Heap:
2.     List<int> maxHeap = new List<int>() 
3.     List<int> minHeap = new List<int>() 
4.     int maxHeapCount = 0
5.     int minHeapCount = 0
6. 
7.     Method FindMedian(data):
8.         SmartInsert(data)
9.         if maxHeapCount ≥ minHeapCount then
10.             return maxHeap[0]
11.         else
12.             return minHeap[0]
13. 
14.     Method FindSecondMedian():
15.         return minHeap[0]
16. 
17.     Method SmartInsert(data):
18.         if not maxHeap or data < maxHeap[0] then
19.             InsertInMax(data)
20.         else
21.             InsertInMin(data)
22. 
23.         if maxHeapCount - minHeapCount = 2 then
24.             InsertInMin(maxHeap[0])
25.             DeleteInMax()
26.         else if minHeapCount - maxHeapCount = 2 then
27.             InsertInMax(minHeap[0])
28.             DeleteInMin()
29. 
30.     Method InsertInMax(data):
31.         maxHeap.Add(data)
32.         int i ← maxHeapCount
33.         int parent ← (i - 1) / 2
34. 
35.         while maxHeap[i] > maxHeap[parent] do
36.             Swap maxHeap[i] and maxHeap[parent]
37.             i ← parent
38.             parent ← (i - 1) / 2
39.             if i = 0 then
40.                 break
41. 
42.         maxHeapCount ← maxHeapCount + 1
43. 
44.     Method InsertInMin(data):
45.         minHeap.Add(data)
46.         int i ← minHeapCount
47.         int parent ← (i - 1) / 2
48. 
49.         while minHeap[i] < minHeap[parent] do
50.             Swap minHeap[i] and minHeap[parent]
51.             i ← parent
52.             parent ← (i - 1) / 2
53.             if i = 0 then
54.                 break
55. 
56.         minHeapCount ← minHeapCount + 1
57. 
58.     Method DeleteInMax():
59.         maxHeapCount ← maxHeapCount - 1
60. 
61.         Swap maxHeap[0] and maxHeap[maxHeapCount]
62.         maxHeap.Remove(maxHeap[maxHeapCount])
63. 
64.         int i ← 0
65.         int left ← 2 * i + 1 if 2 * i + 1 < maxHeapCount else i
66.         int right ← 2 * i + 2 if 2 * i + 2 < maxHeapCount else i
67. 
68.         while maxHeap[i] < maxHeap[left] or maxHeap[i] < maxHeap[right] or left ≠ i and right ≠ i do
69.             if maxHeap[left] > maxHeap[right] then
70.                 Swap maxHeap[i] and maxHeap[left]
71.                 i ← left
72.             else
73.                 Swap maxHeap[i] and maxHeap[right]
74.                 i ← right
75. 
76.             left ← 2 * i + 1 if 2 * i + 1 < maxHeapCount else i
77.             right ← 2 * i + 2 if 2 * i + 2 < maxHeapCount else i
78. 
79.     Method DeleteInMin():
80.         minHeapCount ← minHeapCount - 1
81. 
82.         Swap minHeap[0] and minHeap[minHeapCount]
83.         minHeap.Remove(minHeap[minHeapCount])
84. 
85.         int i ← 0
86.         int left ← 2 * i + 1 if 2 * i + 1 < minHeapCount else i
87.         int right ← 2 * i + 2 if 2 * i + 2 < minHeapCount else i
88. 
89.         while minHeap[i] > minHeap[left] or minHeap[i] > minHeap[right] or left ≠ i and right ≠ i do
90.             if minHeap[left] < minHeap[right] then
91.                 Swap minHeap[i] and minHeap[left]
92.                 i ← left
93.             else
94.                 Swap minHeap[i] and minHeap[right]
95.                 i ← right
96. 
97.             left ← 2 * i + 1 if 2 * i + 1 < maxHeapCount else i
98.             right ← 2 * i + 2 if 2 * i + 2 < maxHeapCount else i
99. 
100. end class

Код програми (C#): 

using System.Reflection;
using System.Text;

Console.WriteLine("Введіть назву файлу у форматі 'file_name.txt'");

string fileName = Console.ReadLine();

string assemblyLocation = Assembly.GetExecutingAssembly().Location;

string programDirectory = Path.GetDirectoryName(assemblyLocation);

string filePath = Path.Combine(programDirectory, fileName);

string fileNameOutput = fileName.Replace(".txt", "_output.txt");
string filePathOutput = Path.Combine(programDirectory, fileNameOutput);

string? line;
    
using StreamReader sr = new StreamReader(filePath, Encoding.UTF8);
using StreamWriter sw = new StreamWriter(filePathOutput);
sr.ReadLine();
int number = 0;
Heap heap = new Heap();

while ((line = sr.ReadLine()) != null)
{
    number++;
    if (number % 2 == 0)
    {
        sw.Write(heap.FindMedian(Int32.Parse(line)));
        sw.Write(" ");
        sw.Write(heap.FindSecondMedian());
        sw.Write("\n");
    }
    else
    {
        sw.WriteLine(heap.FindMedian(Int32.Parse(line)));
    }
}

class Heap
{
    private List<int> maxHeap = new List<int>();
    private List<int> minHeap = new List<int>();
    private int maxHeapCount = 0;
    private int minHeapCount = 0;

    public int FindMedian(int data)
    {
        SmartInsert(data);
        if (maxHeapCount >= minHeapCount)
            return maxHeap[0];
        
        return minHeap[0];
    }

    public int FindSecondMedian()
    {
        return minHeap[0];
    }
    

    void SmartInsert(int data)
    {
        if (!maxHeap.Any() || data < maxHeap[0])
        {
            InsertInMax(data);
        }
        else
        {
            InsertInMin(data);
        }

        if (maxHeapCount - minHeapCount == 2)
        {
            InsertInMin(maxHeap[0]);
            DeleteInMax();
        }
        else if (minHeapCount - maxHeapCount == 2)
        {
            InsertInMax(minHeap[0]);
            DeleteInMin();
        }
    }

    void InsertInMax(int data)
    {
        maxHeap.Add(data);
        int i = maxHeapCount;
        int parent = (i - 1) / 2;

        while (maxHeap[i] > maxHeap[parent])
        {
            (maxHeap[i], maxHeap[parent]) = (maxHeap[parent], maxHeap[i]);
            i = parent;
            parent = (i - 1) / 2;
            if (i == 0)
                break;
        }
        
        maxHeapCount++;
    }
    
    void InsertInMin(int data)
    {
        minHeap.Add(data);
        int i = minHeapCount;
        int parent = (i - 1) / 2;

        while (minHeap[i] < minHeap[parent])
        {
            (minHeap[i], minHeap[parent]) = (minHeap[parent], minHeap[i]);
            i = parent;
            parent = (i - 1) / 2;
            
            if (i == 0)
                break;
        }
        
        minHeapCount++;
    }

    void DeleteInMax()
    {
        maxHeapCount--;
        
        (maxHeap[0], maxHeap[maxHeapCount]) = (maxHeap[maxHeapCount], maxHeap[0]);
        maxHeap.Remove(maxHeap[maxHeapCount]);
        
        int i = 0;
        int left = 2 * i + 1 < maxHeapCount ? 2 * i + 1 : i;
        int right = 2 * i + 2 < maxHeapCount ? 2 * i + 2 : i;

        while (maxHeap[i] < maxHeap[left] || maxHeap[i] < maxHeap[right] || left != i && right != i)
        {
            if (maxHeap[left] > maxHeap[right])
            {
                (maxHeap[i], maxHeap[left]) = (maxHeap[left], maxHeap[i]);
                i = left;
            }
            else
            {
                (maxHeap[i], maxHeap[right]) = (maxHeap[right], maxHeap[i]);
                i = right;
            }
            
            left = 2 * i + 1 < maxHeapCount ? 2 * i + 1 : i;
            right = 2 * i + 2 < maxHeapCount ? 2 * i + 2 : i;
        }
    }
    
    void DeleteInMin()
    {
        minHeapCount--;
        
        (minHeap[0], minHeap[minHeapCount]) = (minHeap[minHeapCount], minHeap[0]);
        minHeap.Remove(minHeap[minHeapCount]);

        int i = 0;
        int left = 2 * i + 1 < minHeapCount ? 2 * i + 1 : i;
        int right = 2 * i + 2 < minHeapCount ? 2 * i + 2 : i;

        while (minHeap[i] > minHeap[left] || minHeap[i] > minHeap[right] || left != i && right != i)
        {
            if (minHeap[left] < minHeap[right])
            {
                (minHeap[i], minHeap[left]) = (minHeap[left], minHeap[i]);
                i = left;
            }
            else
            {
                (minHeap[i], minHeap[right]) = (minHeap[right], minHeap[i]);
                i = right;
            }
            
            left = 2 * i + 1 < maxHeapCount ? 2 * i + 1 : i;
            right = 2 * i + 2 < maxHeapCount ? 2 * i + 2 : i;
        }
    }
}

Робота програми:
Консоль програми:
 
Рис. 1. Консоль після запуску програми
 
Рис. 2. Вводимо назву файлу та натискаємо Enter/Return
 
Рис. 3. Результат роботи моєї програми
 
Рис. 4. Вихідний файл з прикладу



Висновок:
Під час виконання цієї лабораторної роботи ми розв'язали задачу визначення послідовності медіан для заданого вхідного масиву, використовуючи структури даних пірамід. Ми використали дві піраміди (max-heap та min-heap), які допомогли нам ефективно знаходити медіани для кожного підмасиву A', що формується при додаванні нових елементів до вхідного масиву. Алгоритм був реалізований таким чином, щоб кожна медіана визначалася за час O(log(i)), де i - це кількість елементів у поточному підмасиві.

Ми також вивчили та використали принципи роботи з max-heap та min-heap, включаючи їхню властивість, яка дозволяє нам швидко знаходити максимальний та мінімальний елементи, відповідно. Крім того, ми вміємо ефективно вставляти та видаляти елементи з цих пірамід, забезпечуючи збереження їхньої властивості.

Отже, завдяки цій лабораторній роботі ми отримали практичні навички використання структур даних пірамід для вирішення складних задач, таких як знаходження медіан, що мають важливе застосування у різних областях, включаючи аналіз даних та алгоритміку.
![image](https://github.com/R0BIK/FindMedianByHeap/assets/99051328/4530bfab-5875-4e8e-9afd-7bf92a33e202)
