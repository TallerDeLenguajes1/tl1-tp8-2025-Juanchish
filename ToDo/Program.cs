// See https://aka.ms/new-console-template for more information
using EspacioTarea;

// punto 2

Console.WriteLine("Ingrese una cantidad de tareas:");
string? cant = Console.ReadLine();
bool result = int.TryParse(cant, out int cantTareas);

List<Tarea> tareasPendientes = new List<Tarea>();

if (result && cantTareas > 0)
{
    for (int i = 0; i < cantTareas; i++)
    {
        int id = i + 1;
        Console.WriteLine("\nTarea n" + id);

        Console.WriteLine("Ingrese una descripcion:");
        string? descrp = Console.ReadLine();

        if (string.IsNullOrEmpty(descrp))
        {
            Console.WriteLine("\n\tDescripcion ingresada no válida\n");
            i--;
            continue;
        }

        Console.WriteLine("Ingrese una duracion, entre 10 y 100:");
        string? durac = Console.ReadLine();
        bool res = int.TryParse(durac, out int tiempo);

        if (res && tiempo >= 10 && tiempo <= 100)
        {
            tareasPendientes.Add(new Tarea(id, descrp, tiempo));
        }
        else
        {
            Console.WriteLine("\n\tDuracion ingresada no válida\n");
            i--;
        }
    }
}
else
{
    Console.WriteLine("Numero ingresado no valido");
}


// punto 3

List<Tarea> tareasRealizadas = new List<Tarea>();

Console.WriteLine("\nDesea mover alguna tarea? s/n");
string? mover = Console.ReadLine();
string? repetir;


if (mover == "s")
{
    do
    {
        Tarea? tareaAMover = null;

        Console.WriteLine("\nIngrese el id de la tarea a buscar:");
        string? idMov = Console.ReadLine();
        bool moverId = int.TryParse(idMov, out int idMover);

        if (moverId)
        {
            foreach (var item in tareasPendientes)
            {
                if (item.TareaID == idMover)
                {
                    tareaAMover = item;
                    break;
                }
            }

            if (tareaAMover != null)
            {
                tareasPendientes.Remove(tareaAMover);
                tareasRealizadas.Add(tareaAMover);
            }
            else
            {
                Console.WriteLine("Tarea no encontrada");
            }
        }

        Console.WriteLine("Mover otra tarea? s/n");
        repetir = Console.ReadLine();
    } while (repetir == "s");
}

Console.WriteLine("\n----------Mostrando la lista de pendientes----------");
foreach (var tarea in tareasPendientes)
{
    Console.WriteLine($"Tarea n{tarea.TareaID}, Descripcion: {tarea.Descripcion}, Duracion: {tarea.Duracion}");
}


Console.WriteLine("\n----------Mostrando la lista de realizadas----------");
foreach (var tarea in tareasRealizadas)
{
    Console.WriteLine($"Tarea n{tarea.TareaID}, Descripcion: {tarea.Descripcion}, Duracion: {tarea.Duracion}");
}

// punto 4

void MostrarPorDescripcion(string descripcion)
{
    Tarea? tareaBuscada = null;

    Console.WriteLine("\nIngrese la descripcion de la tarea a mover:");
    string? buscarDescripcion = Console.ReadLine();

    foreach (var item in tareasPendientes)
    {
        if (item.Descripcion == buscarDescripcion)
        {
            tareaBuscada = item;
            Console.WriteLine($"\n----------Mostrando la tarea con la descripcion buscada {buscarDescripcion}----------");

            foreach (var tarea in tareasPendientes)
            {
                Console.WriteLine($"Tarea n{tarea.TareaID}, Descripcion: {tarea.Descripcion}, Duracion: {tarea.Duracion}");
            }
        }
    }
}


MostrarPorDescripcion("hola1");