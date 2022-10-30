namespace ConsultorioOdontologico.Client.Servicios
{
    public interface IHttpService
    {
        //HttpClient Http { get; }

        Task<HttpRespuesta<T>> Get<T>(string url);
    }
}