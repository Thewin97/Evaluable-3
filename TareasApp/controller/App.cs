
public class App
{
    private Dictionary<int, Tarea> Tareas;    

    public App()
    {
        Tareas = new Dictionary<int,Tarea>();   
    }

    public void CrearTarea()
    {
        Tarea Tarea = new Tarea((Tareas.Count+1),PedirDatos(1),PedirDatos(2),PedirPrioridad(),PedirTipo());
        Tareas.Add(Tarea.ID,Tarea);
        
    }

    public void ExportarTareas(String path)
{
    if (!File.Exists(path))
    {
        File.Create(path).Close();
    }
        FileStream fileStream = new FileStream(path, FileMode.Truncate);
        StreamWriter writer = null;

        try
        {
            writer = new StreamWriter(fileStream);
            foreach (Tarea t in Tareas.Values)
            {
                writer.WriteLine(t.ID + "," + t.Nombre + "," + t.Desc + "," + t.Prioridad + "," + t.Tipo);
                
            }
            Console.WriteLine("Se han exportado "+Tareas.Count+" tareas.");
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {        
            try
            {
                writer?.Close();
                fileStream.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }    
}

    public void ImportarTareas(String path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }           
            FileStream fileStream = new FileStream(path, FileMode.Open);            
            StreamReader streamReader = null;
    
    try
    {        
        streamReader = new StreamReader(fileStream);
        String? linea = null;
        while ((linea = streamReader.ReadLine()) != null)
        {
            String[] campos = linea.Split(',');
            Tareas.Add(int.Parse(campos[0]), new Tarea(int.Parse(campos[0]), campos[1], campos[2], bool.Parse(campos[3]), Enum.Parse<Tipos>(campos[4]))); 
        
        }
        Console.WriteLine("Se han importado "+Tareas.Count+" tareas.");
    }
    catch (IOException e)
    {
        Console.WriteLine("Error" +e.Message);
    }catch (Exception e)
    {
        Console.WriteLine("Error" +e.Message);
    }
    finally
    {
        try
        {
            streamReader?.Close();
            fileStream.Close();
        }
        catch (IOException e)
        {
            Console.WriteLine("Error al cerrar." + e.Message);
        }
    }
    }
    public void BuscarTareaPorTipo()
    {
        Tipos tipo = PedirTipo();
        foreach (Tarea t in Tareas.Values)
        {       
            if(tipo == t.Tipo)    
            {
                t.MostrarDatos();
            }
        }
    }

    public void BuscarTarea(int ID)
    {
        if(Tareas.ContainsKey(ID))
        {
            Tareas.TryGetValue(ID,out Tarea? Tarea);
            Tarea?.MostrarDatos();            
        }
        else Console.WriteLine("No se encontro ninguna tarea con el ID "+ID);
    }

    public void BorrarTarea(int ID){
        if(Tareas.Remove(ID))
        {
            Console.WriteLine("Tarea borrada con éxito.");
        }
        else Console.WriteLine("No se encontro ninguna tarea con el ID "+ID);
    }

    public string? PedirDatos(int ID)
    {
        switch(ID)
        {
            case 1:
                Console.Write("Ingresa el nombre de la Tarea: ");  
                return Console.ReadLine();
            case 2: 
                Console.Write("Ingresa la descripcion de la Tarea: ");
                return Console.ReadLine();                      
            default: return "Error";
        }
    }


    public bool PedirPrioridad()
    {
        Console.Write("Es una tarea prioritaria? (S/N): ");
        string? respuesta = Console.ReadLine();
        if(respuesta == "S" || respuesta == "s")
        {
            return true;
        }
        else if(respuesta == "N" || respuesta == "n")
        {
            return false;
        }
        else
        {
            Console.WriteLine("Error, ingresa S o N");
            return PedirPrioridad();
        }        
    }
    public Tipos PedirTipo()
    {   
        int count = 0;
                foreach(Tipos tipo in Enum.GetValues(typeof(Tipos)))
                {
                    count++;
                    Console.WriteLine(count+"- "+tipo);
                }
                Console.Write("Ingresa el tipo de la tarea: ");
                if(int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch(opcion)
                    {
                        case 1: 
                        return Tipos.Persona;
                        case 2:
                        return Tipos.Trabajo;
                        case 3:
                        return Tipos.Ocio;
                        default: return PedirTipo();
                    } 
                }
                else {
                    Console.WriteLine("Ha ocurrido un error, intentalo denuevo.");
                    return PedirTipo();
                }              
    }

}