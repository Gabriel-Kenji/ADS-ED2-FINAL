using System;
using System.Collections.Generic;

namespace ADS_ED2_FINAL.Model
{
    public class Contrato
    {
        public int id;
        public int idTipo;
        public Queue<Equipamento> EquipamentosList;
        public bool status;
        public DateTime IncioDate;
        public DateTime FinalDate;
        
        public Contrato(int id, int idTipo, Queue<Equipamento> equipamentosList)
        {
            this.id = id;
            this.idTipo = idTipo;
            EquipamentosList = equipamentosList;
            status = false;
            IncioDate = DateTime.Now;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public int IdTipo
        {
            get => idTipo;
            set => idTipo = value;
        }

        public Queue<Equipamento> EquipamentosList1
        {
            get => EquipamentosList;
            set => EquipamentosList = value;
        }

        public bool Status
        {
            get => status;
            set => status = value;
        }

        public DateTime IncioDate1
        {
            get => IncioDate;
            set => IncioDate = value;
        }

        public DateTime FinalDate1
        {
            get => FinalDate;
            set => FinalDate = value;
        }
    }
}