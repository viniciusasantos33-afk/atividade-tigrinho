using LittleTigerV2.Models;

namespace LittleTigerV2.Repositories
{
    public interface IApostaRepository
    {
        void SalvarAposta(Aposta aposta);
        Aposta ObterUltimaPorIp(string ip); 
    }
}