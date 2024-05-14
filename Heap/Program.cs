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