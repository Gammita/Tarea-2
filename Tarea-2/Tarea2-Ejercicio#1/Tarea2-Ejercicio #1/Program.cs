using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Empleado> empleados = new List<Empleado>();
        bool continuar = true;

        while (continuar)
        {
            // Crear una nueva instancia de Empleado
            Empleado empleado = new Empleado();

            // Solicitar y leer los datos del empleado
            Console.Write("Cedula: ");
            empleado.Cedula = Console.ReadLine();

            Console.Write("Nombre Empleado: ");
            empleado.Nombre = Console.ReadLine();

            Console.Write("Tipo de Empleado (1-Operario, 2-Tecnico, 3-Profesional): ");
            empleado.Tipo = int.Parse(Console.ReadLine());

            Console.Write("Cantidad de Horas Laboradas: ");
            empleado.HorasLaboradas = double.Parse(Console.ReadLine());

            Console.Write("Precio por Hora: ");
            empleado.PrecioHora = double.Parse(Console.ReadLine());

            // Calcular el salario ordinario
            empleado.SalarioOrdinario = empleado.HorasLaboradas * empleado.PrecioHora;

            // Calcular el aumento según el tipo de empleado
            if (empleado.Tipo == 1)
            {
                empleado.Aumento = empleado.SalarioOrdinario * 0.15;
            }
            else if (empleado.Tipo == 2)
            {
                empleado.Aumento = empleado.SalarioOrdinario * 0.10;
            }
            else if (empleado.Tipo == 3)
            {
                empleado.Aumento = empleado.SalarioOrdinario * 0.05;
            }

            // Calcular el salario bruto y neto
            empleado.SalarioBruto = empleado.SalarioOrdinario + empleado.Aumento;
            empleado.DeduccionCCSS = empleado.SalarioBruto * 0.0917;
            empleado.SalarioNeto = empleado.SalarioBruto - empleado.DeduccionCCSS;

            // Mostrar los resultados del empleado
            Console.WriteLine("\nResultados:");
            Console.WriteLine($"Cedula: {empleado.Cedula}");
            Console.WriteLine($"Nombre Empleado: {empleado.Nombre}");
            Console.WriteLine($"Tipo Empleado: {empleado.Tipo}");
            Console.WriteLine($"Salario por Hora: {empleado.PrecioHora}");
            Console.WriteLine($"Cantidad de Horas: {empleado.HorasLaboradas}");
            Console.WriteLine($"Salario Ordinario: {empleado.SalarioOrdinario}");
            Console.WriteLine($"Aumento: {empleado.Aumento}");
            Console.WriteLine($"Salario Bruto: {empleado.SalarioBruto}");
            Console.WriteLine($"Deducción CCSS: {empleado.DeduccionCCSS}");
            Console.WriteLine($"Salario Neto: {empleado.SalarioNeto}\n");

            empleados.Add(empleado);

            // Preguntar si se desea continuar
            Console.Write("¿Desea registrar otro empleado? (s/n): ");
            continuar = Console.ReadLine().ToLower() == "s";
        }

        // Estadísticas
        int countOperarios = 0, countTecnicos = 0, countProfesionales = 0;
        double acumuladoOperarios = 0, acumuladoTecnicos = 0, acumuladoProfesionales = 0;

        foreach (var emp in empleados)
        {
            if (emp.Tipo == 1)
            {
                countOperarios++;
                acumuladoOperarios += emp.SalarioNeto;
            }
            else if (emp.Tipo == 2)
            {
                countTecnicos++;
                acumuladoTecnicos += emp.SalarioNeto;
            }
            else if (emp.Tipo == 3)
            {
                countProfesionales++;
                acumuladoProfesionales += emp.SalarioNeto;
            }
        }

        // Mostrar estadísticas
        Console.WriteLine("\nEstadísticas:");
        Console.WriteLine($"Cantidad Empleados Tipo Operarios: {countOperarios}");
        Console.WriteLine($"Acumulado Salario Neto para Operarios: {acumuladoOperarios}");
        Console.WriteLine($"Promedio Salario Neto para Operarios: {(countOperarios > 0 ? acumuladoOperarios / countOperarios : 0)}");
        Console.WriteLine($"Cantidad Empleados Tipo Técnicos: {countTecnicos}");
        Console.WriteLine($"Acumulado Salario Neto para Técnicos: {acumuladoTecnicos}");
        Console.WriteLine($"Promedio Salario Neto para Técnicos: {(countTecnicos > 0 ? acumuladoTecnicos / countTecnicos : 0)}");
        Console.WriteLine($"Cantidad Empleados Tipo Profesionales: {countProfesionales}");
        Console.WriteLine($"Acumulado Salario Neto para Profesionales: {acumuladoProfesionales}");
        Console.WriteLine($"Promedio Salario Neto para Profesionales: {(countProfesionales > 0 ? acumuladoProfesionales / countProfesionales : 0)}");
    }
}

class Empleado
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public int Tipo { get; set; }
    public double HorasLaboradas { get; set; }
    public double PrecioHora { get; set; }
    public double SalarioOrdinario { get; set; }
    public double Aumento { get; set; }
    public double SalarioBruto { get; set; }
    public double DeduccionCCSS { get; set; }
    public double SalarioNeto { get; set; }
}
