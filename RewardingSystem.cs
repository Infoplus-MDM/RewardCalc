using System;
using System.Collections.Generic;
using System.Linq;

public class RewardingSystem
{
    public static int ComputeRewards(int cost)
    {
        if (cost >= 50 && cost < 100)
        {
            return cost - 50;
        }
        else if (cost > 100)
        {
            return (2 * (cost - 100) + 50);
        }
        return 0;
    }
}

public class Transaction
{
    public int Cost { get; set;}
    public int Rewards { get; set;}  

    public Transaction(int cost)
    {
        Cost = cost;
        Rewards = RewardingSystem.ComputeRewards(cost); 
    }
}

public class TransactionList
{
    private List<Transaction> list;

    public TransactionList()
    {
        list = new List<Transaction>();
    }
 

    public List<Transaction> GetAllTransactions()
    {
        return list.OrderByDescending(x => x.Cost).ToList();
    }

    public void AddTransaction(int cost)
    {
        Transaction transaction = new Transaction(cost);
        list.Add(transaction);
    }
 
 
}

public class Program
{
    public static void Main()
    {
        TransactionList myTransactionList = new TransactionList();
        myTransactionList.AddTransaction(120);
        myTransactionList.AddTransaction(51);
        List<Transaction> arr = myTransactionList.GetAllTransactions();
		Console.WriteLine(arr.Select(x=> x.Rewards).Sum());
    }
}
