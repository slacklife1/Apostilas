using System;

class Employee
{
    string m_name;
    public Employee(string name)
    {
        m_name = name;
    }
}

class EqualsDemo
{
    static void Main()
    {
        EqualsDemo eqDemo = new EqualsDemo();
        eqDemo.InstanceEqual();
        Console.ReadLine();
    }

    public void InstanceEqual()
    {
        string name = "Joe";
        Employee employee1 = new Employee(name);
        Employee employee2 = new Employee(name);

        // comparing references to separate instances
        bool isEqual = employee1.Equals(employee2);

        Console.WriteLine("employee1 == employee2 = {0}", isEqual);

        employee2 = employee1;

        // comparing references to the same instance
        isEqual = employee1.Equals(employee2);

        Console.WriteLine("employee1 == employee2 = {0}", isEqual);
    }
}