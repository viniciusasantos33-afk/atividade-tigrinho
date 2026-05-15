using LittleTigerV2.Models;

namespace LittleTigerV2.Services
{
    public interface ISorteioService
    {
        ResultadoGiro RealizarSorteio(string ip); 
        ResultadoGiro ObterEstadoAtual(string ip);
    }
}