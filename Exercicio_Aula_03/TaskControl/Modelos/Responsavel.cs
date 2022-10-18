namespace TaskControl.Modelos
{
    public class Responsavel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Nome}";
        }
    }
}