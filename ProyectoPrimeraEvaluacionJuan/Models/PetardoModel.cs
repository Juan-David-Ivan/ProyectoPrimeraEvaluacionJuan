using Newtonsoft.Json;

namespace ProyectoPrimeraEvaluacionJuan.Models;

public class PetardoModel
{
    [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Id { get; set; }
    
    [JsonProperty("peligroso")]
    public bool peligroso { get; set; }
    
    [JsonProperty("tipo")]
    public string Tipo { get; set; }
    
    [JsonProperty("potencia")]
    public int potencia { get; set; }
    
    [JsonProperty("fechaEnvio")]
    public int fechaEnvio { get; set; }
    
}