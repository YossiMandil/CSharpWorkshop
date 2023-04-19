namespace Inheritance.Ex3;

class A
{
    public char Foo() => 'A';
}

class B : A
{
    public new virtual char Foo() => 'B';
}

class C : B
{
    public override char Foo() => 'C';
}

class D : C
{
    public new char Foo() => 'D';
}


public static class Ex3Runner
{
    public static List<char> Run()
    {
        D d = new D();
        A a = d;
        B b = d;
        C c = d;

        return new List<char> { a.Foo(), b.Foo(), c.Foo(), d.Foo() };
    }
}