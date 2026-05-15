using LittleTigerV2.Data;
using LittleTigerV2.Models;

namespace LittleTigerV2.Repositories
{
    public class ApostaRepository : IApostaRepository
    {
        private readonly TigrinhoDbContext _context;

        public ApostaRepository(TigrinhoDbContext context) => _context = context;

        public void SalvarAposta(Aposta aposta)
        {
            _context.Apostas.Add(aposta);
            _context.SaveChanges();
        }
        
        public Aposta ObterUltimaPorIp(string ip)
        {
            return _context.Apostas
                .Where(a => a.UsuarioIp == ip)
                .OrderByDescending(a => a.DataAposta)
                .FirstOrDefault();
        }
        
        public void DeletarPorIp(string ip)
        {
            var apostas = _context.Apostas.Where(a => a.UsuarioIp == ip);
            _context.Apostas.RemoveRange(apostas);
            _context.SaveChanges();
        }
    }
}