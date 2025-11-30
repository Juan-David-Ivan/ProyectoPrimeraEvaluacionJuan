using System;
using Newtonsoft.Json;

namespace ProyectoPrimeraEvaluacionJuan.Models;

public class PetardoModel
{
    [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Id { get; set; }
    
    [JsonProperty("nombre")]
    public string nombre { get; set; }
    
    [JsonProperty("peligroso")]
    public bool peligroso { get; set; }
    
    [JsonProperty("tipo")]
    public string Tipo { get; set; }
    
    [JsonProperty("potencia")]
    public int potencia { get; set; }
    
    [JsonProperty("fechaRecogida")]
    public DateTime fechaRecogida { get; set; }
    
}