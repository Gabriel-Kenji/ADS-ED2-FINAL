namespace ADS_ED2_FINAL.Model
{
    public class Equipamento
    {
        public int Id;
        public string Nome;
        public bool Avariado;

        public Equipamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Avariado = false;
        }
        
        public Equipamento()
        {
            Id = 0;
            Nome = "";
            Avariado = false;
        }

        public void IsAvariado()
        {
            Avariado = true;
        }
    }
}