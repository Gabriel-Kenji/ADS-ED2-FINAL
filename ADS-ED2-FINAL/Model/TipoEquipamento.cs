using System.Collections.Generic;

namespace ADS_ED2_FINAL.Model
{
    public class TipoEquipamento
    {
        public int id;
        public string name;
        public Queue<Equipamento> Equipamentos;
        public float valor;

        public TipoEquipamento(int id, string name, float valor)
        {
            this.id = id;
            this.name = name;
            this.valor = valor;
            Equipamentos = new Queue<Equipamento>();
        }

        public TipoEquipamento()
        {
            this.id = 0;
            this.name = "";
            Equipamentos = new Queue<Equipamento>();
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }
        
        
    }
}