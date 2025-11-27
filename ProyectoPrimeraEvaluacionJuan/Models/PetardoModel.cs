using Newtonsoft.Json;

namespace ProyectoPrimeraEvaluacionJuan.Models;

public class PetardoModel
{
    [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Id { get; set; }
    
    [JsonProperty("codigo")]
    public string Codigo { get; set; }
    
    [JsonProperty("tipo")]
    public string Tipo { get; set; }
    
    [JsonProperty("potencia")]
    public int potencia { get; set; }
    
}