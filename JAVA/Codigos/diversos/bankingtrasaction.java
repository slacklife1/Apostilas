 import java.util.Random;

public class BankOperation
{
  public static void main(String[] args)
  {
    int[] initialBalance = {500, 800};       // The initial account balances.
    int[] totalCredits = new int[initialBalance.length];       // Total credits.
    int[] totalDebits = new int[initialBalance.length];        // Total debits.
    int[] nCredits = new int[initialBalance.length];           // Number of credits.
    int[] nDebits = new int[initialBalance.length];            // Number of debits.
    int transactionCount = 20;               // Number of debits and of credits.

    // Create the bank and the clerks:
    Bank theBank = new Bank();                  // Create a bank.
    Clerk clerk1 = new Clerk(theBank);         // Create the first clerk.
    Clerk clerk2 = new Clerk(theBank);         // Create the second clerk.

    // Create the accounts, and initialize total credits and debits:
    Account[] accounts = new Account[initialBalance.length];
    for(int i = 0; i < initialBalance.length; i++)
    {
      accounts[i] = new Account(i+1, initialBalance[i]); // Create accounts
      totalCredits[i] = totalDebits[i] = 0;
      nCredits[i] = nDebits[i] = 0;
    }

    // Create the threads for the clerks as daemon, and start them off:
    Thread clerk1Thread = new Thread(clerk1);
    Thread clerk2Thread = new Thread(clerk2);
    clerk1Thread.setDaemon(true);                    // Set first as daemon.
    clerk2Thread.setDaemon(true);                    // Set second as daemon.
    clerk1Thread.start();                            // Start the first.
    clerk2Thread.start();                            // Start the second.

    // Generate transactions of each type and pass to the clerks:
    Random rand = new Random();                      // Random number generator
    Transaction transaction;                         // Stores a transaction
    int amount;                                      // stores an amount of money
    int select;                                      // Selects an account
    for(int i = 1; i <= transactionCount; i++)
    {
      // Generate a credit or debit at random:
      if(rand.nextInt(2)==1)
      {
        // Generate a random account index for credit operation:
        select = rand.nextInt(accounts.length);
        amount = 50 + rand.nextInt(26);                // Generate amount of $50 to $75
        transaction = new Transaction(accounts[select],       // Account
                                          Transaction.CREDIT, // Credit transaction
                                          amount);            //  of amount
        totalCredits[select] += amount;                // Keep total credit tally
        nCredits[select]++;

        clerk1.doTransaction(transaction);
      }
      else
      {
        // Generate a random account index for debit operation:
        select = rand.nextInt(accounts.length);
        amount = 30 + rand.nextInt(31);                     // Generate amount of $30 to $60.
        transaction = new Transaction(accounts[select],   // Account.
                                  Transaction.DEBIT,       // Debit transaction of amount.
                                  amount);             
        totalDebits[select] += amount;                      // Keep total debit tally.
        nDebits[select]++;

        clerk2.doTransaction(transaction);
      }
    }

    // Wait until both clerks are done:
    clerk1.isBusy();
    clerk2.isBusy();

    // Now output the results:
    for(int i = 0; i < accounts.length; i++)
      System.out.println("Account Number:"+accounts[i].getAccountNumber()+"\n"+
         "Number of credits   :  " + nCredits[i] + "\n" +
         "Number of debits    :  " + nDebits[i] + "\n" +
         "Original balance    : $" + initialBalance[i] + "\n" +
         "Total credits       : $" + totalCredits[i] + "\n" +
         "Total debits        : $" + totalDebits[i] + "\n" +
         "Final balance       : $" + accounts[i].getBalance() + "\n" +
         "Should be           : $" + (initialBalance[i] + totalCredits[i] -
                                                     totalDebits[i]) + "\n");
  }
}

//***********************
//Bank.java
//***********************
class Bank
{
  // Perform a transaction:
  public void doTransaction(Transaction transaction)
  {
    switch(transaction.getTransactionType())
    {
      case Transaction.CREDIT:
      synchronized(transaction.getAccount())
      {
        System.out.println("Start credit of " +
                 transaction.getAccount() + " amount: " +
                 transaction.getAmount());

        // Get current balance:
        int balance = transaction.getAccount().getBalance();

        // Credits require require a lot of checks:
        try
        {
          Thread.sleep(10);          // wait() time reduced to speed things up.
        }
        catch(InterruptedException e)
        {
          System.out.println(e);
        }
        balance += transaction.getAmount();             // Increment the balance.
        transaction.getAccount().setBalance(balance);   // Restore account balance.

        /*
        System.out.println("  End credit of " +
                  transaction.getAccount() + " amount: " +
                  transaction.getAmount());
                  */

        break;
      }
      case Transaction.DEBIT:
      synchronized(transaction.getAccount())
      {
        System.out.println("Start debit  of " +
                 transaction.getAccount() + " amount: " +
                 transaction.getAmount());


        // Get current balance
        int balance = transaction.getAccount().getBalance();

        // Debits require even more checks...
        try
        {
          Thread.sleep(15);          // wait()time reduced to speed things up.
        }
        catch(InterruptedException e)
        {
          System.out.println(e);
        }
        balance -= transaction.getAmount();             // Increment the balance.
        transaction.getAccount().setBalance(balance);   // Restore account balance.

        /*
        System.out.println("  End debit of " +
                  transaction.getAccount() + " amount: " +
                  transaction.getAmount());
                  */

        break;
      }
      default:                                          // We should never get here.
        System.out.println("Invalid transaction");
        System.exit(1);
    }
  }
}

//****************************
//Account.java
//****************************
// Defines a customer account.
public class Account
{
  // Constructor:
  public Account(int accountNumber, int balance)
  {
    this.accountNumber = accountNumber;            // Set the account number.
    this.balance = balance;                        // Set the initial balance.
  }

  // return the current balance:
  public int getBalance()
  {  return balance;  }

  // Set the current balance:
  public void setBalance(int balance)
  {  this.balance = balance;  }

  public int getAccountNumber()
  {  return accountNumber;  }

  public String toString()
  {
    return "A//C No. "+accountNumber+" : $"+balance;
  }

  private int balance;                             // The current account balance.
  private int accountNumber;                       // Identifies this account.
}

//***************************
//Clerk.java
//***************************
import java.util.*;

public class Clerk implements Runnable
{
  Bank theBank;
  // The in-tray holding transactions:
  private List inTray = Collections.synchronizedList(new LinkedList());

  private int maxTransactions = 8;      // Maximum transactions in the in-tray.

  // Constructor
  public Clerk(Bank theBank)
  {
    this.theBank = theBank;               // Who the clerk works for.
    //inTray     = null;                //Commented out: don't need this now.
  }

  // Receive a transaction:
  synchronized public void doTransaction(Transaction transaction)
  {
    while(inTray.size() >= maxTransactions)
    try
    {
      wait();
    }
    catch(InterruptedException e)
    {
      System.out.println(e);
    }
    inTray.add(transaction);
    notifyAll();
  }

  // The working clerk:
  synchronized public void run()
  {
    while(true)
    {
      while(inTray.size() == 0)     // No transaction waiting?
        try
        {
          wait();                   // Then take a break until there is.
        }
        catch(InterruptedException e)
        {
          System.out.println(e);
        }
      theBank.doTransaction((Transaction)inTray.remove(0));
      notifyAll();                  // Notify other threads locked on this clerk.
    }
  }

  // Busy check:
  synchronized public void isBusy()
  {
    while(inTray.size() != 0)         // Is this object busy?
      try
      {
        wait();                       // Yes, so wait for notify call.
      }

      catch(InterruptedException e)
      {
        System.out.println(e);
      }
    return;                           // It is free now.
  }
}

//****************************
//Transaction.java
//****************************

class Transaction
{
  // Transaction types:
  public static final int DEBIT = 0;
  public static final int CREDIT = 1;
  public static String[] types = {"Debit","Credit"};

  // Constructor:
  public Transaction(Account account, int transactionType, int amount)
  {
    this.account = account;
    this.transactionType = transactionType;
    this.amount = amount;
  }

  public Account getAccount()
  {  return account;  }

  public int getTransactionType()
  {  return transactionType;  }

  public int getAmount()
  {  return amount;  }

  public String toString()
  {
    return types[transactionType] + " A//C: " + ": $" + amount;
  }

  private Account account;
  private int amount;
  private int transactionType;
}
