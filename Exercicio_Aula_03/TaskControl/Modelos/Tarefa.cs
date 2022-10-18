namespace TaskControl.Modelos
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Responsavel { get; set; }
        public Status Situacao { get; set; }

        public override string ToString()
        {
            return $"Id:{Id} Nome:{Nome} Descricao:{Descricao} Responsavel:{Responsavel} Situacao:{Situacao}";
        }
    }
}