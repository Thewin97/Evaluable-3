public class Tarea{
    public int ID { get; set; }
    public string? Nombre { get; set; }
    public string? Desc { get; set; }
    public bool Prioridad {get; set;}
    public Tipos Tipo { get; set; }
    


    public Tarea(){}

    public Tarea(int ID,string Nombre, string Desc, bool prioridad, Tipos tipo){
        this.ID = ID;
        this.Tipo = tipo;
        this.Nombre = Nombre;
        this.Desc = Desc;
        this.Prioridad = prioridad;      
    }

    public void MostrarDatos()
    {
        Console.WriteLine("ID: "+ID);
        Console.WriteLine("Nombre: "+Nombre);
        Console.WriteLine("Descripcion: "+Desc);
        Console.WriteLine("Prioridad: "+Prioridad);
        Console.WriteLine("Tipo: "+Tipo);        
    }
    
}