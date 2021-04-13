using Microsoft.EntityFrameworkCore;

public class paciente
{
    public long Id {get; set;}
    public string nombre {get; set;}
    public string prescripciones {get; set;}
    public string diagnostico {get; set;}
    public string examenes {get; set;}
    public string comentarios {get; set;}
    public string secreto {get; set;}
}