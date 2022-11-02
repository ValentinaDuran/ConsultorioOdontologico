namespace ConsultorioOdontologico.Client.Servicios
{
    public interface IHttpService
    {
        Task<HttpRespuesta<object>> Delete(string url);

        //HttpClient Http { get; }

        Task<HttpRespuesta<T>> Get<T>(string url);
        Task<HttpRespuesta<object>> Post<T>(string url, T enviar);
        Task<HttpRespuesta<object>> Put<T>(string url, T enviar);
    }
}