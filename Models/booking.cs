using Microsoft.EntityFrameworkCore;

public class booking {
   public long Id {get; set;}
    public string nombre {get; set;}
    public string fecha {get; set;}
    public string medico {get; set;}
    public string lugar {get; set;}
    public int precio {get; set;}
    public string secreto {get; set;}
    
}