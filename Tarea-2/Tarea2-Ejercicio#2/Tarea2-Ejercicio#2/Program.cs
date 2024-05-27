using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Venta> ventas = new List<Venta>();
        bool continuar = true;

        // Variables para estadísticas
        int cantidadSol = 0, cantidadSombra = 0, cantidadPreferencial = 0;
        double acumuladoSol = 0, acumuladoSombra = 0, acumuladoPreferencial = 0;

        while (continuar)
        {
            // Crear una nueva instancia de Venta
            Venta venta = new Venta();

            // Solicitar y leer los datos de la venta
            Console.Write("Número de Factura: ");
            venta.NumeroFactura = int.Parse(Console.ReadLine());

            Console.Write("Cédula: ");
            venta.Cedula = Console.ReadLine();

            Console.Write("Nombre del Comprador: ");
            venta.Nombre = Console.ReadLine();

            // Solicitar la localidad y validar el valor
            Console.Write("Localidad (1- Sol Norte/Sur, 2- Sombra Este/Oeste, 3- Preferencial): ");
            venta.Localidad = int.Parse(Console.ReadLine());

            // Solicitar la cantidad de entradas y validar el valor
            while (true)
            {
                Console.Write("Cantidad de Entradas (máximo 4): ");
                venta.CantidadEntradas = int.Parse(Console.ReadLine());
                if (venta.CantidadEntradas > 0 && venta.CantidadEntradas <= 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("La cantidad de entradas debe ser entre 1 y 4.");
                }
            }

            // Determinar el precio por entrada y el nombre de la localidad
            if (venta.Localidad == 1)
            {
                venta.NombreLocalidad = "Sol Norte/Sur";
                venta.PrecioEntrada = 10500;
            }
            else if (venta.Localidad == 2)
            {
                venta.NombreLocalidad = "Sombra Este/Oeste";
                venta.PrecioEntrada = 20500;
            }
            else if (venta.Localidad == 3)
            {
                venta.NombreLocalidad = "Preferencial";
                venta.PrecioEntrada = 25500;
            }

            // Calcular el subtotal, cargos por servicios y total a pagar
            venta.Subtotal = venta.CantidadEntradas * venta.PrecioEntrada;
            venta.CargosServicios = venta.CantidadEntradas * 1000;
            venta.TotalPagar = venta.Subtotal + venta.CargosServicios;

            // Mostrar los resultados de la venta
            Console.WriteLine("\nDetalles de la Venta:");
            Console.WriteLine($"Número de Factura: {venta.NumeroFactura}");
            Console.WriteLine($"Cédula: {venta.Cedula}");
            Console.WriteLine($"Nombre del Comprador: {venta.Nombre}");
            Console.WriteLine($"Localidad: {venta.NombreLocalidad}");
            Console.WriteLine($"Cantidad de Entradas: {venta.CantidadEntradas}");
            Console.WriteLine($"Subtotal: {venta.Subtotal}");
            Console.WriteLine($"Cargos por Servicios: {venta.CargosServicios}");
            Console.WriteLine($"Total a Pagar: {venta.TotalPagar}\n");

            // Agregar la venta a la lista de ventas
            ventas.Add(venta);

            // Actualizar las estadísticas
            if (venta.Localidad == 1)
            {
                cantidadSol += venta.CantidadEntradas;
                acumuladoSol += venta.Subtotal;
            }
            else if (venta.Localidad == 2)
            {
                cantidadSombra += venta.CantidadEntradas;
                acumuladoSombra += venta.Subtotal;
            }
            else if (venta.Localidad == 3)
            {
                cantidadPreferencial += venta.CantidadEntradas;
                acumuladoPreferencial += venta.Subtotal;
            }

            // Preguntar si se desea continuar
            Console.Write("¿Desea registrar otra venta? (s/n): ");
            continuar = Console.ReadLine().ToLower() == "s";
        }

        // Mostrar las estadísticas
        Console.WriteLine("\nEstadísticas:");
        Console.WriteLine($"Cantidad Entradas Localidad Sol Norte/Sur: {cantidadSol}");
        Console.WriteLine($"Acumulado Dinero Localidad Sol Norte/Sur: {acumuladoSol}");
        Console.WriteLine($"Cantidad Entradas Localidad Sombra Este/Oeste: {cantidadSombra}");
        Console.WriteLine($"Acumulado Dinero Localidad Sombra Este/Oeste: {acumuladoSombra}");
        Console.WriteLine($"Cantidad Entradas Localidad Preferencial: {cantidadPreferencial}");
        Console.WriteLine($"Acumulado Dinero Localidad Preferencial: {acumuladoPreferencial}");
    }
}

class Venta
{
    public int NumeroFactura { get; set; }
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public int Localidad { get; set; }
    public int CantidadEntradas { get; set; }
    public string NombreLocalidad { get; set; }
    public double PrecioEntrada { get; set; }
    public double Subtotal { get; set; }
    public double CargosServicios { get; set; }
    public double TotalPagar { get; set; }
}
