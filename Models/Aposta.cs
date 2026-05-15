using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LittleTigerV2.Models
{
    public class Aposta
    {
        public int Id { get; set; }
        public string UsuarioIp { get; set; }
        public string ResultadoSlots { get; set; }
        public bool Ganhou { get; set; }
        public DateTime DataAposta { get; set; } = DateTime.Now;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorSimulado { get; set; }
        
    }
}