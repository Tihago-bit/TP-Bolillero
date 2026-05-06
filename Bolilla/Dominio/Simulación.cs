using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dominio
{
    public class Simulacion
    {
        // Simulación sin hilos
        public long SimularSinHilos(Bolillero bolillero, List<int> jugada, int cantidadSimulaciones)
        {
            long ganadas = 0;

            for (int i = 0; i < cantidadSimulaciones; i++)
            {
                // Clonar bolillero para no modificar el original
                Bolillero clon = (Bolillero)bolillero.Clone();

                if (clon.Jugar(jugada))
                    ganadas++;
            }

            return ganadas;
        }

        // Simulación con hilos
        public long SimularConHilos(Bolillero bolillero, List<int> jugada, int cantidadSimulaciones, int cantidadHilos)
        {
            long totalGanadas = 0;
            int simulacionesPorHilo = cantidadSimulaciones / cantidadHilos;
            int simulacionesRestantes = cantidadSimulaciones % cantidadHilos;

            List<Task<long>> tareas = new List<Task<long>>();

            for (int i = 0; i < cantidadHilos; i++)
            {
                int simulacionesHilo = simulacionesPorHilo;
                if (i == 0) simulacionesHilo += simulacionesRestantes; // el primer hilo se queda con las que sobran

                tareas.Add(Task.Run(() =>
                {
                    long ganadasHilo = 0;
                    // Cada hilo trabaja con su propio clon
                    Bolillero clon = (Bolillero)bolillero.Clone();

                    for (int j = 0; j < simulacionesHilo; j++)
                    {
                        Bolillero juego = (Bolillero)clon.Clone(); // clonar por cada simulación
                        if (juego.Jugar(jugada))
                            ganadasHilo++;
                    }

                    return ganadasHilo;
                }));
            }

            Task.WaitAll(tareas.ToArray());

            foreach (var tarea in tareas)
                totalGanadas += tarea.Result;

            return totalGanadas;
        }
    }
}