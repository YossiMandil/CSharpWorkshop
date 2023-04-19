namespace Inheritance.Ex1;

class A
{
    public virtual char Foo() => 'A';
}

class B : A
{
    public virtual new char Foo() => 'B';
}

class C : B
{
    public override char Foo() => 'C';
}

class D : C
{
    public new char Foo() => 'D';
}

public static class Ex1Runner
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
