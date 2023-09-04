using System;

public interface Imylterator
{
    int Next();
    void Begin();
    bool HasNext();
}

public class MyCollection
{
    private int[] arr = new int[10000];
    private int tos = -1;
    private int nav = -1;

    public void Add(int i)
    {
        if (tos < 9999)
        {
            tos++;
            arr[tos] = i;
        }
    }

    public Imylterator GetIterator()
    {
        return new MyIterator(this);
    }


    public class MyIterator : Imylterator
    {
        private MyCollection collection;

        public MyIterator(MyCollection c)
        {
            collection = c;
        }

        public int Next()
        {
            if (collection.tos != -1 && collection.nav <= collection.tos)
            {
                int result = collection.arr[collection.nav];
                collection.nav++;
                return result;
            }
            return -1;
        }

        public void Begin()
        {
            if (collection.tos > 0)
            {
                collection.nav = 0;
            }
        }

        public bool HasNext()
        {
            return collection.nav <= collection.tos;
        }
    }

}

public class Program
{
    public static void Main()
    {
        MyCollection col1 = new MyCollection();


        for (int i = 1; i <= 100; i++)
        {
            col1.Add(i);
        }


        Imylterator it = col1.GetIterator();
        it.Begin();


        while (it.HasNext())
        {
            int value = it.Next();
            Console.WriteLine(value);
        }
    }
}
