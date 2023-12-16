using System;
using System.Collections.Generic;
using NUnit.Framework;

// Clase para los vasos
public class Vasos
{
    private Dictionary<int, int> cantidadVasosDisponibles = new Dictionary<int, int>
    {
        { 1, 10 }, // Vaso pequeño
        { 2, 15 }, // Vaso mediano
        { 3, 20 }  // Vaso grande
    };

    public bool EsVasoDisponible(int tamanoVaso)
    {
        return cantidadVasosDisponibles.ContainsKey(tamanoVaso) && cantidadVasosDisponibles[tamanoVaso] > 0;
    }

    public void DescontarVaso(int tamanoVaso)
    {
        if (EsVasoDisponible(tamanoVaso))
        {
            cantidadVasosDisponibles[tamanoVaso]--;
        }
    }
}

// Clase para la cafetera
public class Cafetera
{
    private int cantidadCafeDisponible = 30; // Cantidad de café inicial

    public bool EsCantidadCafeSuficiente(int cantidadCafe)
    {
        return cantidadCafeDisponible >= cantidadCafe;
    }

    public void DescontarCafe(int cantidadCafe)
    {
        if (EsCantidadCafeSuficiente(cantidadCafe))
        {
            cantidadCafeDisponible -= cantidadCafe;
        }
    }
}

// Clase para el azucarero
public class Azucarero
{
    private Dictionary<int, int> cantidadAzucarDisponible = new Dictionary<int, int>
    {
        { 1, 50 }, // Cucharadas de azúcar para vaso pequeño
        { 2, 75 }, // Cucharadas de azúcar para vaso mediano
        { 3, 100 } // Cucharadas de azúcar para vaso grande
    };

    public bool EsCantidadAzucarSuficiente(int cantidadAzucar, int tamanoVaso)
    {
        return cantidadAzucarDisponible.ContainsKey(tamanoVaso) && cantidadAzucarDisponible[tamanoVaso] >= cantidadAzucar;
    }

    public int ObtenerCantidadAzucarDisponible(int tamanoVaso)
    {
        return cantidadAzucarDisponible.ContainsKey(tamanoVaso) ? cantidadAzucarDisponible[tamanoVaso] : 0;
    }

    public void DescontarAzucar(int cantidadAzucar, int tamanoVaso)
    {
        if (EsCantidadAzucarSuficiente(cantidadAzucar, tamanoVaso))
        {
            cantidadAzucarDisponible[tamanoVaso] -= cantidadAzucar;
        }
    }
}

public class MaquinaDeCafe
{
    private Vasos vasos;
    private Cafetera cafetera;
    public Azucarero azucarero;

    public MaquinaDeCafe(Vasos vasos, Cafetera cafetera, Azucarero azucarero)
    {
        this.vasos = vasos;
        this.cafetera = cafetera;
        this.azucarero = azucarero;
    }

    public string PrepararCafe(int tamanoVaso, int cantidadCafe, int cantidadAzucar)
    {
        if (!vasos.EsVasoDisponible(tamanoVaso))
        {
            return "Vaso no disponible";
        }

        if (!cafetera.EsCantidadCafeSuficiente(cantidadCafe))
        {
            return "No hay suficiente café";
        }

        if (!azucarero.EsCantidadAzucarSuficiente(cantidadAzucar, tamanoVaso))
        {
            return "No hay suficiente azúcar";
        }

        vasos.DescontarVaso(tamanoVaso);
        cafetera.DescontarCafe(cantidadCafe);
        azucarero.DescontarAzucar(cantidadAzucar, tamanoVaso);

        return $"Vaso de café (tamaño {tamanoVaso}) con {cantidadAzucar} cucharadas de azúcar";
    }
}

class Program
{
    static void Main()
    {
        // Crear instancias de las clases
        Vasos vasos = new Vasos();
        Cafetera cafetera = new Cafetera();
        Azucarero azucarero = new Azucarero();

        // Crear la máquina de café
        MaquinaDeCafe maquinaDeCafe = new MaquinaDeCafe(vasos, cafetera, azucarero);

        // Menú principal
        while (true)
        {
            Console.WriteLine("¡Bienvenido a la Máquina de Café!");
            Console.WriteLine("1. Preparar café");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        PrepararCafe(maquinaDeCafe);
                        break;
                    case 2:
                        Console.WriteLine("Gracias por usar la Máquina de Café. ¡Hasta luego!");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
            }

            Console.WriteLine();
        }
    }

    static void PrepararCafe(MaquinaDeCafe maquinaDeCafe)
    {
        Console.WriteLine("\nSeleccione el tamaño del vaso:");
        Console.WriteLine("1. Pequeño");
        Console.WriteLine("2. Mediano");
        Console.WriteLine("3. Grande");

        Console.Write("Seleccione una opción: ");

        if (int.TryParse(Console.ReadLine(), out int tamanoVaso) && tamanoVaso >= 1 && tamanoVaso <= 3)
        {
            // Validar la cantidad máxima de café para el tamaño del vaso seleccionado
            int maxCantidadCafe = 0;
            switch (tamanoVaso)
            {
                case 1: maxCantidadCafe = 10; break; // Vaso pequeño
                case 2: maxCantidadCafe = 15; break; // Vaso mediano
                case 3: maxCantidadCafe = 20; break; // Vaso grande
            }

            Console.Write($"Ingrese la cantidad de café (en Oz, máximo {maxCantidadCafe}): ");
            if (int.TryParse(Console.ReadLine(), out int cantidadCafe) && cantidadCafe > 0 && cantidadCafe <= maxCantidadCafe)
            {
                // Validar la cantidad máxima de azúcar para el tamaño del vaso seleccionado
                int maxCantidadAzucar = 0;
                if (maquinaDeCafe.azucarero.EsCantidadAzucarSuficiente(0, tamanoVaso)) // Verificar la existencia del tamaño en el azucarero
                {
                    maxCantidadAzucar = maquinaDeCafe.azucarero.ObtenerCantidadAzucarDisponible(tamanoVaso);
                }

                Console.Write($"Ingrese la cantidad de azúcar (en cucharadas, máximo {maxCantidadAzucar}): ");
                if (int.TryParse(Console.ReadLine(), out int cantidadAzucar) && cantidadAzucar >= 0 && cantidadAzucar <= maxCantidadAzucar)
                {
                    string resultado = maquinaDeCafe.PrepararCafe(tamanoVaso, cantidadCafe, cantidadAzucar);
                    Console.WriteLine(resultado);

                    // Limpiar la pantalla antes de volver al menú principal
                    Console.WriteLine("Presione Enter para volver al menú principal...");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"La cantidad de azúcar debe ser un número entero no negativo y no puede superar el límite para el tamaño de vaso seleccionado ({maxCantidadAzucar}).");
                }
            }
            else
            {
                Console.WriteLine($"La cantidad de café debe ser un número entero positivo y no puede superar el límite para el tamaño de vaso seleccionado ({maxCantidadCafe}).");
            }
        }
        else
        {
            Console.WriteLine("Opción no válida. Seleccione un tamaño de vaso válido.");
        }
    }
}



[TestFixture]
public class MaquinaDeCafeTests
{
    private Vasos vasos;
    private Cafetera cafetera;
    private Azucarero azucarero;
    private MaquinaDeCafe maquinaDeCafe;

    [SetUp]
    public void SetUp()
    {
        vasos = new Vasos();
        cafetera = new Cafetera();
        azucarero = new Azucarero();
        maquinaDeCafe = new MaquinaDeCafe(vasos, cafetera, azucarero);
    }

    [Test]
    public void PrepararCafe_VasoPequeno_SuficienteCafeAzucar_RetornaMensaje()
    {
        // Arrange
        int tamanoVaso = 1; // Vaso pequeño
        int cantidadCafe = 5;
        int cantidadAzucar = 2;

        // Act
        string resultado = maquinaDeCafe.PrepararCafe(tamanoVaso, cantidadCafe, cantidadAzucar);

        // Assert
        Assert.AreEqual($"Vaso de café (tamaño {tamanoVaso}) con {cantidadAzucar} cucharadas de azúcar", resultado);
    }

    [Test]
    public void PrepararCafe_VasoMediano_NoSuficienteCafe_RetornaMensajeNoCafe()
    {
        // Arrange
        int tamanoVaso = 2; // Vaso mediano
        int cantidadCafe = 20; // Más café del disponible

        // Act
        string resultado = maquinaDeCafe.PrepararCafe(tamanoVaso, cantidadCafe, 0);

        // Assert
        Assert.AreEqual("No hay suficiente café", resultado);
    }

    [Test]
    public void PrepararCafe_VasoGrande_NoSuficienteAzucar_RetornaMensajeNoAzucar()
    {
        // Arrange
        int tamanoVaso = 3; // Vaso grande
        int cantidadCafe = 10;
        int cantidadAzucar = 150; // Más azúcar del disponible

        // Act
        string resultado = maquinaDeCafe.PrepararCafe(tamanoVaso, cantidadCafe, cantidadAzucar);

        // Assert
        Assert.AreEqual("No hay suficiente azúcar", resultado);
    }

    [Test]
    public void PrepararCafe_VasoNoDisponible_RetornaMensajeNoVaso()
    {
        // Arrange
        int tamanoVaso = 4; // Tamaño no existente

        // Act
        string resultado = maquinaDeCafe.PrepararCafe(tamanoVaso, 5, 0);

        // Assert
        Assert.AreEqual("Vaso no disponible", resultado);
    }
}
