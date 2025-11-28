using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Collections;
using Newtonsoft.Json;
using ProyectoPrimeraEvaluacionJuan.Models;

namespace ProyectoPrimeraEvaluacionJuan.Services;

public class APIService
{
     private HttpClient client;

    public APIService()
    {
        client = new HttpClient();
        client.BaseAddress = new Uri("http://192.160.50.23:7000/");
        client.DefaultRequestHeaders.Add("apikey", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyAgCiAgICAicm9sZSI6ICJhbm9uIiwKICAgICJpc3MiOiAic3VwYWJhc2UtZGVtbyIsCiAgICAiaWF0IjogMTY0MTc2OTIwMCwKICAgICJleHAiOiAxNzk5NTM1NjAwCn0.dc_X5iR_VP_qT0zsiyj_I_OZ2T9FtRU2BBNWN8Bu4GE");
        
    }

    public async Task CrearPetardo(PetardoModel petardo)
    {
        var jsonProduct = JsonConvert.SerializeObject(petardo);
        var request = new HttpRequestMessage(HttpMethod.Post, "rest/v1/petardo")
        {
            Content = new StringContent(jsonProduct, Encoding.UTF8, "application/json")
        };
        var response = await client.SendAsync(request);
    }

    public async Task<bool> EliminarPetardo(PetardoModel p)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, "rest/v1/petardo?id=eq." + p.Id);
        request.Headers.Add("Prefer", "return=representation");
        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("ERROR AL ELIMINAR PETARDO STATUS: "+response.StatusCode);
        }
        var body = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrEmpty(body))
        {
            throw new Exception("Error AL ELIMINAR PETARDO STATUS: "+response.StatusCode);
        }
        return true;
        
    }
    
    public async Task<bool> ModificarPetardo(PetardoModel petardo)
    {
        var jsonProduct = JsonConvert.SerializeObject(petardo);
        var request = new HttpRequestMessage(HttpMethod.Patch, "rest/v1/producto_ejemplo?id=eq."+petardo.Id)
        {
            Content = new StringContent(jsonProduct, Encoding.UTF8, "application/json")
        };
        request.Headers.Add("Prefer", "return=representation"); 
        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
           
            throw new Exception("ERROR AL ACTUALIZAR PETARDO STATUS: "+response.StatusCode);
            
        }
        
        var body = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrEmpty(body))
        {
            throw new Exception("Error AL ACTUALIZAR PETARDO STATUS: "+response.StatusCode);
        }
        return true;
    }

    public async Task<AvaloniaList<PetardoModel>> ObtenerPetardos()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "rest/v1/petardo");
        var response = await client.SendAsync(request);
        var listaString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AvaloniaList<PetardoModel>>(listaString);
    }
}