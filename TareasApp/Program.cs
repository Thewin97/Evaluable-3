class Program
{
    static void Main(string[] args)
    {
       App miapp = new App();
       bool salida = false;
       do
       {
       Console.WriteLine("/*** MENU ***/");
       Console.WriteLine("1. - Crear tarea");
       Console.WriteLine("2. - Buscar tarea por tipo");
       Console.WriteLine("3. - Eliminar tarea por ID");
       Console.WriteLine("4. - Exportar tareas");
       Console.WriteLine("5. - Importar tareas");
       Console.WriteLine("6. - Salir");
       Console.Write("Elige una opción: ");
       if(int.TryParse(Console.ReadLine(), out int opcion2))
       {
        switch(opcion2)
        {
            case 1: {
                miapp.CrearTarea();
                break;
            }
            case 2: {
                miapp.BuscarTareaPorTipo();
                break;
            }
            case 3: {
                Console.Write("Indica el ID de la tarea a borrar: ");
                miapp.BorrarTarea(int.Parse(Console.ReadLine()));
                break;
            }
            case 4: {
                    miapp.ExportarTareas("tareas.txt");            
                break;
            }
            case 5: {
                    miapp.ImportarTareas("tareas.txt");                
                break;
            }
            case 6: {
                Console.WriteLine("Hasta luego");
                salida = true;
                break;
            }
            default: {
                Console.WriteLine("Error de selección, intenta denuevo.");
                break;
            }
        }
       }
       else {
        Console.WriteLine("Entrada incorrecta");
       }    
       }
       while(!salida);  
    }
}