using LittleTigerV2.Models;
using LittleTigerV2.Repositories;
using System;
using System.Linq;

namespace LittleTigerV2.Services
{
    public class SorteioService : ISorteioService
    {
        private readonly string[] _simbolos = { "🐅", "💰", "🍊", "🔔", "🧧" };
        private readonly IApostaRepository _repository;

        public SorteioService(IApostaRepository repository)
        {
            _repository = repository;
        }
        
        public ResultadoGiro ObterEstadoAtual(string ip)
        {
            var ultimaAposta = _repository.ObterUltimaPorIp(ip);

            if (ultimaAposta == null)
            {
                return new ResultadoGiro(); // Retorna o padrão ❓|❓|❓
            }

            // Divide a string "🐅|💰|🍊" de volta em um array
            var slots = ultimaAposta.ResultadoSlots.Split('|');

            return new ResultadoGiro
            {
                Slot1 = slots.ElementAtOrDefault(0) ?? "❓",
                Slot2 = slots.ElementAtOrDefault(1) ?? "❓",
                Slot3 = slots.ElementAtOrDefault(2) ?? "❓",
                Venceu = ultimaAposta.Ganhou,
                Mensagem = "Este foi o seu último resultado!"
            };
        }
        
        public ResultadoGiro RealizarSorteio(string ip)
        {
            var rnd = new Random();
            
            string s1 = _simbolos[rnd.Next(_simbolos.Length)];
            string s2 = _simbolos[rnd.Next(_simbolos.Length)];
            string s3 = _simbolos[rnd.Next(_simbolos.Length)];

            bool venceu = (s1 == s2 && s2 == s3);

            var novaAposta = new Aposta
            {
                UsuarioIp = ip,
                ResultadoSlots = $"{s1}|{s2}|{s3}",
                Ganhou = venceu,
                DataAposta = DateTime.Now,
                ValorSimulado = 10.00m 
            };

            _repository.SalvarAposta(novaAposta);

            return new ResultadoGiro
            {
                Slot1 = s1,
                Slot2 = s2,
                Slot3 = s3,
                Venceu = venceu,
                Mensagem = venceu ? "✨ O TIGRINHO SOLTOU A CARTA! ✨" : "O Tigre está faminto... tente de novo!"
            };
        }
    }
}