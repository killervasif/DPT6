﻿/// The 'Subject' abstract class
public abstract class Subject
{
    public abstract void Request();
}

/// The 'RealSubject' class
public class RealSubject : Subject
{
    public override void Request()
    {
        Console.WriteLine("Called RealSubject.Request()");
    }
}

/// The 'Proxy' class
public class Proxy : Subject
{
    private RealSubject realSubject;
    public override void Request()
    {
        // Use 'lazy initialization'
        if (realSubject == null)
        {
            realSubject = new RealSubject();
        }
        realSubject.Request();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create proxy and request a service
        Proxy proxy = new Proxy();
        proxy.Request();
        // Wait for user
        Console.ReadKey();
    }
}

