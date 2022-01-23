using DIO.Series.Enum;

namespace DIO.Series.Classes
{
    public class Serie : EntidadeBase
    {
        private GeneroEnum Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        public Serie(int id, GeneroEnum genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
        }
    }
}