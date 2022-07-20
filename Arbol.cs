
public class Tree<T>
{
    public List<Tree<T>> Childs { get; set; } = new List<Tree<T>>();

    public T Value { get; set; }

    public Tree(T item) => this.Value = item;

    public bool AddChild(Tree<T> add)
    {
        if (add is null) return false;
        this.Childs.Add(add);
        return true;
    }

}



public class BinarianTree<T>
{
    public bool HaveChild => (this.HaveRigthChild || this.HaveLeftChild);
    public BinarianTree<T> LeftChild { get; set; }

    public bool HaveLeftChild => !(this.LeftChild is null);

    public BinarianTree<T> RigthChild { get; set; }

    public bool HaveRigthChild => !(this.RigthChild is null);

    public T Value { get; set; }


    public BinarianTree(T item) => this.Value = item;

    //False left   true: rigth
    public bool AddChild(BinarianTree<T> child, bool side)
    {
        if (side)
        {
            this.RigthChild = child;
            return true;
        }
        this.LeftChild = child;
        return true;
    }
}



public static class ArbolesIsomorfos
{

    public static bool Binarios<T>(BinarianTree<T> one, BinarianTree<T> two)
    {

        if (one.Value is null || two.Value is null || !one.Value.Equals(two.Value)) return false;

        var oneq = new Queue<BinarianTree<T>>();
        oneq.Enqueue(one);
        var twoq = new Queue<BinarianTree<T>>();
        twoq.Enqueue(two);
        return Rcur(oneq, twoq);
    }



    public static bool Rcur<T>(Queue<BinarianTree<T>> oneq, Queue<BinarianTree<T>> twoq)
    {

        if (oneq.Count < 1 && twoq.Count < 1) return true;

        var x = oneq.Dequeue();

        var y = twoq.Dequeue();

        var xlist = new List<BinarianTree<T>>();
        var ylist = new List<BinarianTree<T>>();
        AddChild(x, xlist, y, ylist);

        if (!CantMatch(xlist, ylist))
        { return false; }
        AddQueuwe(xlist, oneq, ylist, twoq);


        return (Rcur(oneq, twoq));
    }

    private static void AddQueuwe<T>(List<BinarianTree<T>> onel, Queue<BinarianTree<T>> oneq, List<BinarianTree<T>> twol, Queue<BinarianTree<T>> twoq)
    {
        foreach (var item in onel)
        {
            oneq.Enqueue(item);
            var i = index(item, twol);
            if (i >= 0)
            {
                var z = twol[i];
                twol.RemoveAt(i);
                twoq.Enqueue(z);
            }

        }
    }
    private static int index<T>(BinarianTree<T> one, List<BinarianTree<T>> twol)
    {
        for (int i = 0; i < twol.Count; i++)
        {
            var item = twol[i];
            if (item.Value.Equals(one.Value))
            {

                return i;
            }
        }
        return -1;

    }
    private static void AddChild<T>(BinarianTree<T> one, List<BinarianTree<T>> oneq, BinarianTree<T> two, List<BinarianTree<T>> twoq)
    {
        if (one.LeftChild != null)
        {
            oneq.Add(one.LeftChild);
        }
        if (one.RigthChild != null)
        {
            oneq.Add(one.RigthChild);
        }

        if (two.LeftChild != null)
        {
            twoq.Add(two.LeftChild);
        }

        if (two.RigthChild != null)
        {
            twoq.Add(two.RigthChild);
        }



    }

    public static bool CantMatch<T>(List<BinarianTree<T>> onel, List<BinarianTree<T>> twol)
    {
        if (onel.Count != twol.Count) return false;
        foreach (var item1 in onel)
        {
            if (!Contains(item1, twol))
            { return false; }
        }
        var temp = new List<BinarianTree<T>>();

        return true;
    }

    private static bool Contains<T>(BinarianTree<T> x, List<BinarianTree<T>> list)
    {
        foreach (var item in list)
        {

            if (item.Value.Equals(x.Value)) return true;
        }
        return false;
    }
}
