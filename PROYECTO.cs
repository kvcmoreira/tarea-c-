using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Crear conjuntos de ciudadanos
        HashSet<string> ciudadanos = GenerarCiudadanos(500);
        HashSet<string> vacunadosPfizer = GenerarCiudadanos(75, ciudadanos);
        HashSet<string> vacunadosAstrazeneca = GenerarCiudadanos(75, ciudadanos);
        
        // Listado de ciudadanos que no se han vacunado
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(vacunadosPfizer);
        noVacunados.ExceptWith(vacunadosAstrazeneca);
        
        // Listado de ciudadanos que han recibido ambas vacunas
        HashSet<string> vacunadosAmbas = new HashSet<string>(vacunadosPfizer);
        vacunadosAmbas.IntersectWith(vacunadosAstrazeneca);
        
        // Listado de ciudadanos que solo han recibido Pfizer
        HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstrazeneca);
        
        // Listado de ciudadanos que solo han recibido AstraZeneca
        HashSet<string> soloAstrazeneca = new HashSet<string>(vacunadosAstrazeneca);
        soloAstrazeneca.ExceptWith(vacunadosPfizer);
        
        // Mostrar reporte en consola
        MostrarReporte(noVacunados, vacunadosAmbas, soloPfizer, soloAstrazeneca);
        
        // Generar reporte en archivo de texto
        GenerarReporte(noVacunados, vacunadosAmbas, soloPfizer, soloAstrazeneca);
        
        Console.WriteLine("\nReporte generado exitosamente: reporte_vacunacion.txt");
    }
    
    static HashSet<string> GenerarCiudadanos(int cantidad, HashSet<string> existentes = null)
    {
        HashSet<string> ciudadanos = existentes ?? new HashSet<string>();
        Random rand = new Random();
        while (ciudadanos.Count < cantidad)
        {
            ciudadanos.Add("Ciudadano_" + rand.Next(1, 10000));
        }
        return ciudadanos;
    }
    
    static void MostrarReporte(HashSet<string> noVacunados, HashSet<string> vacunadosAmbas, HashSet<string> soloPfizer, HashSet<string> soloAstrazeneca)
    {
        Console.WriteLine("\n==========================");
        Console.WriteLine(" REPORTE DE VACUNACIÓN COVID-19 ");
        Console.WriteLine("==========================\n");
        
        Console.WriteLine($"Ciudadanos no vacunados: {noVacunados.Count}");
        Console.WriteLine($"Ciudadanos vacunados con ambas vacunas: {vacunadosAmbas.Count}");
        Console.WriteLine($"Ciudadanos vacunados solo con Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Ciudadanos vacunados solo con AstraZeneca: {soloAstrazeneca.Count}");
    }

    static void GenerarReporte(HashSet<string> noVacunados, HashSet<string> vacunadosAmbas, HashSet<string> soloPfizer, HashSet<string> soloAstrazeneca)
    {
        using (StreamWriter sw = new StreamWriter("reporte_vacunacion.txt"))
        {
            sw.WriteLine("Reporte de Vacunación COVID-19\n");
            sw.WriteLine($"Ciudadanos no vacunados: {noVacunados.Count}");
            sw.WriteLine($"Ciudadanos vacunados con ambas vacunas: {vacunadosAmbas.Count}");
            sw.WriteLine($"Ciudadanos vacunados solo con Pfizer: {soloPfizer.Count}");
            sw.WriteLine($"Ciudadanos vacunados solo con AstraZeneca: {soloAstrazeneca.Count}");
        }
    }
}
