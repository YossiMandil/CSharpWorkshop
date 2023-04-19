namespace Inheritance.Ex2;

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
    public override char Foo() => 'D';
}


public static class Ex2Runner
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