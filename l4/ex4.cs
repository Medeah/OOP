using System;
using System.Collections.Generic;

namespace l4
{

class Program
{
    static void Main(string[] args)
    {
        TestInterfaces();
    }

    static void TestInterfaces()
    {
        //Dykker-test:
        And anders = new And();
        Ubåd u51 = new Ubåd();

        List<IDykker> dykkere = new List<IDykker>() { anders, u51 };
        foreach (IDykker d in dykkere)
        Console.WriteLine(d.Dyk());

        //Flyve-test:
        Kolibri kenneth = new Kolibri(anders); //:D
        Vandflyver h20 = new Vandflyver();

        List<IFlyver> flyvere = new List<IFlyver>() { kenneth, h20 };
        foreach (IFlyver f in flyvere)
        Console.WriteLine(f.Flyv());

        //Flyde-test:
        List<IFlyder> flydere = new List<IFlyder>() { anders, h20 };
        foreach (IFlyder flyder in flydere)
        Console.WriteLine(flyder.Flyd());

        //Afgifts-test:
        List<IVægtAfgiftsObjekt> samling = new List<IVægtAfgiftsObjekt>()
        {
            u51, h20
        };
        foreach (IVægtAfgiftsObjekt iao in samling)
            Console.WriteLine("At betale: {0}", iao.Afgift);
    }
}

interface IFlyver {
    string Flyv();
}
interface IFlyder {
    string Flyd();
}
interface IDykker {
    string Dyk();
}
public interface IVægtAfgiftsObjekt
{
    double Vægt { get; set;}
    double Brændstof { get; set; }
    decimal Afgift { get; }
}

abstract class Flymaskine : IFlyver, IVægtAfgiftsObjekt {
    public int MaxHeight { get; set; }
    public int MaxSpeed { get; set; }
    public double Vægt { get; set;}
    public double Brændstof { get; set; }
    decimal IVægtAfgiftsObjekt.Afgift {
        get {
            return AfgiftsBeregner.Beregn(Vægt);
        }
    }
    public abstract string Flyv();
}

class Fastvinge : Flymaskine {
    public override string Flyv() {
        return "Fastving flyver";
    }
}

class Helikopter : Flymaskine {
    public override string Flyv() {
        return "Helikopter flyver";
    }
}

class VarmtluftsBallon : Flymaskine {
    public override string Flyv() {
        return "VarmtluftsBallon flyver";
    }
}

class Vandflyver : Flymaskine, IFlyder {
    public override string Flyv() {
        return "Vandflyver flyver";
    }
    public string Flyd() {
        return "Vandflyver flyder";
    }
}

abstract class MarineFartøj : IFlyder, IVægtAfgiftsObjekt {
    public double Width { get; set; }
    public double Length { get; set; }
    public double Vægt { get; set;}
    public double Brændstof { get; set; }
    decimal IVægtAfgiftsObjekt.Afgift {
        get {
            return AfgiftsBeregner.Beregn(Vægt);
        }
    }
    public virtual string Flyd() {
        return "generelt MarineFartøj flyder";
    }
}

static class AfgiftsBeregner {
    public static decimal Beregn (double v) {
        if (v < 2500)
            return 1250;
        else if (v < 5000)
            return 2500;
        else
            return 5000;
    }
}

class Jolle : MarineFartøj {
    public override string Flyd() {
        return  "joller flyder";
    }
}

class Ubåd : MarineFartøj, IDykker {
    public string Dyk() {
        return "ubåd dykker";
    }
}

abstract class Fugl {
    public double Næb { get; set; }
    public double Æg { get; set; }
}

abstract class FlyFugl : IFlyver {
    public string Flyv() {
        return  "fugler flyver";
    }
}

class Albatros : Fugl, IFlyder, IFlyver {
    //property injection
    public IFlyver Flyver { get; set; }
    public string Flyv() {
        return Flyver.Flyv();
    }
    public string Flyd() {
        return "Albatros flyder";
    }
}

class Kolibri : Fugl, IFlyver {
    private IFlyver _flyver;

    //constructor injection
    public Kolibri(IFlyver f){
        _flyver = f;
    }

    public string Flyv() {
        return _flyver.Flyv();
    }
}

class Pingvin : Fugl, IFlyder, IDykker {
    public string Dyk() {
        return "pingvin dykke";
    }
    public string Flyd() {
        return "pingvin flyder";
    }
}

class And : Fugl, IFlyder, IFlyver, IDykker {

    

    public string Flyv() {
        return "Kolibri flyver";
    }
    public string Flyd() {
        return "And flyder";
    }
    public string Dyk() {
        return "And dykke";
    }
}


}