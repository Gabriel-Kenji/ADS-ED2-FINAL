using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADS_ED2_FINAL.Model;

namespace ADS_ED2_FINAL
{
    public partial class Form1 : Form
    {
        List<TipoEquipamento> tipoEquipamentos = new List<TipoEquipamento>();
        private List<Contrato> _contratos = new List<Contrato>();

        public Form1()
        {
            InitializeComponent();
            tipoEquipamentos.Add(new TipoEquipamento(1, "tipo 1", 5));
            tipoEquipamentos.Add(new TipoEquipamento(2, "tipo 2", 10));
            tipoEquipamentos.Add(new TipoEquipamento(3, "tipo 3", 20));
            atualizaComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                tipoEquipamentos.Add(new TipoEquipamento(int.Parse(textBox1.Text), textBox2.Text, float.Parse(textBox3.Text)));
                atualizaComboBox();
                textBox1.Text = null;
                textBox2.Text = null;
                MessageBox.Show("TIPO CADASTRADO COM SUCESSO!!!");
            }
            else
            {
                MessageBox.Show("PREENCHA OS CAMPOS", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var tipoEquipamento in tipoEquipamentos)
            {
                if (tipoEquipamento.name == comboTipos.SelectedItem)
                {
                    Equipamento equipamento = new Equipamento(int.Parse(textBox4.Text), textBox3.Text);
                    tipoEquipamento.Equipamentos.Enqueue(equipamento);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var tipoEquipamento in tipoEquipamentos)
            {
                if (tipoEquipamento.name == comboTipos2.SelectedItem)
                {
                    foreach (var equipamento in tipoEquipamento.Equipamentos)
                    {
                        listBox1.Items.Add("ID: " + equipamento.Id.ToString() + " - NOME: " + equipamento.Nome +
                                           " - AVARIADO: " + (equipamento.Avariado ? "Sim" : "Não"));
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int idTipo = 0;
            Queue<Equipamento> equipamentosEmpres = new Queue<Equipamento>();
            foreach (var tipoEquipamento in tipoEquipamentos)
            {
                if (tipoEquipamento.name == comboTipos3.SelectedItem)
                {
                    idTipo = tipoEquipamento.id;
                    int contAvariados = 0;
                    int aa = int.Parse(textBox8.Text);
                    for (int i = 0; i < int.Parse(textBox8.Text);)
                    {
                        Equipamento equipamento = tipoEquipamento.Equipamentos.Dequeue();
                        if (!equipamento.Avariado)
                        {
                            equipamentosEmpres.Enqueue(equipamento);
                            i++;
                        }
                        else
                        {
                            tipoEquipamento.Equipamentos.Enqueue(equipamento);
                            contAvariados++;
                        }

                        if (contAvariados == tipoEquipamento.Equipamentos.Count &&
                            tipoEquipamento.Equipamentos.Count != 0)
                        {
                            i = int.Parse(textBox8.Text);
                        }
                    }
                }
            }

            _contratos.Add(new Contrato(int.Parse(textBox9.Text), idTipo, equipamentosEmpres));
            atualizaComboContratoId();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var contrato in _contratos)
            {
                if (contrato.id.ToString() == contratoId1.SelectedItem.ToString())
                {
                    label14.Text = "ID: " + contrato.id.ToString();
                    foreach (var tipoEquipamento in tipoEquipamentos)
                    {
                        if (tipoEquipamento.id == contrato.idTipo)
                        {
                            label13.Text = "Tipo: " + tipoEquipamento.name;

                            label37.Text = "Valor Diario: R$" +
                                           (tipoEquipamento.valor * contrato.EquipamentosList.Count).ToString();
                        }
                    }

                    label15.Text = "Quantidade: " + contrato.EquipamentosList.Count.ToString();

                    label19.Text = "Status: " + (contrato.status ? "Liberado" : "Não Liberado");

                    listBox2.Items.Clear();
                    foreach (var equipamento in contrato.EquipamentosList)
                    {
                        listBox2.Items.Add("ID: " + equipamento.Id.ToString() + " - NOME: " + equipamento.Nome +
                                           " - AVARIADO: " + (equipamento.Avariado ? "Sim" : "Não"));
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (var contrato in _contratos)
            {
                if (contrato.id.ToString() == contratoId2.SelectedItem.ToString())
                {
                    contrato.status = true;
                    atualizaComboContratoIdLiberado();
                    atualizaComboContratoId();
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            foreach (var contrato in _contratos)
            {
                if (contrato.id.ToString() == contratoLiberado.SelectedItem.ToString())
                {
                    label26.Text = "ID: " + contrato.id.ToString();
                    foreach (var tipoEquipamento in tipoEquipamentos)
                    {
                        if (tipoEquipamento.id == contrato.idTipo)
                        {
                            label25.Text = "Tipo: " + tipoEquipamento.name;
                            
                            label39.Text = "Valor Diario: R$" +
                                           (tipoEquipamento.valor * contrato.EquipamentosList.Count).ToString();
                        }
                    }

                    label24.Text = "Quantidade: " + contrato.EquipamentosList.Count.ToString();

                    label22.Text = "Status: " + (contrato.status ? "Liberado" : "Não Liberado");

                    listBox3.Items.Clear();
                    foreach (var equipamento in contrato.EquipamentosList)
                    {
                        listBox3.Items.Add("ID: " + equipamento.Id.ToString() + " - NOME: " + equipamento.Nome +
                                           " - AVARIADO: " + (equipamento.Avariado ? "Sim" : "Não"));
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (var contrato in _contratos)
            {
                if (contrato.id.ToString() == contratoLiberado2.SelectedItem.ToString())
                {
                    foreach (var tipoEquipamento in tipoEquipamentos)
                    {
                        if (tipoEquipamento.id == contrato.idTipo)
                        {
                            label34.Text = "Tipo: " + tipoEquipamento.name;
                            contrato.FinalDate1 = DateTime.Now;
                            int dias = (int)(contrato.FinalDate1 - contrato.IncioDate1).TotalDays;
                            label38.Text = "VALOR FINAL: R$" + (tipoEquipamento.valor * contrato.EquipamentosList.Count() * ( dias >= 1 ? dias : 1) ).ToString();
                        }
                    }

                    label31.Text = contrato.EquipamentosList.Count.ToString();

                    label35.Text = contrato.EquipamentosList.Peek().Id.ToString();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Contrato _contrato = new Contrato(0,0,new Queue<Equipamento>());
            bool finalizado = false;
            foreach (var contrato in _contratos.Select((item, index) => (item, index)))
            {
                _contrato = contrato.item;
                if (contrato.item.id.ToString() == contratoLiberado2.SelectedItem.ToString())
                {
                    if (contrato.item.EquipamentosList.Peek().Id.ToString() == label35.Text)
                    {
                        if (radioButton1.Checked)
                        {
                            contrato.item.EquipamentosList.Peek().Avariado = true;
                        }

                        if (radioButton2.Checked)
                        {
                            contrato.item.EquipamentosList.Peek().Avariado = false;
                        }

                        foreach (var tipoEquipamento in tipoEquipamentos)
                        {
                            if (tipoEquipamento.id == contrato.item.idTipo)
                            {
                                tipoEquipamento.Equipamentos.Enqueue(contrato.item.EquipamentosList.Dequeue());
                                if (contrato.item.EquipamentosList.Count() > 0)
                                {
                                    MessageBox.Show("EQUIPAMENTO ENTREGE \n\n FALTAM " +
                                                    contrato.item.EquipamentosList.Count().ToString() + "PARA SER ENTREGUE");

                                    label31.Text = contrato.item.EquipamentosList.Count.ToString();

                                    label35.Text = contrato.item.EquipamentosList.Peek().Id.ToString();
                                }
                                else
                                {
                                    finalizado = true;
                                    MessageBox.Show("TODOS OS EQUIPAMENTOS ENTREGUES CONTRATO VAI SER ENCERRADO");
                                    
                                    label31.Text = "";

                                    label35.Text = "";
                                }
                            }
                        }
                    }
                }
            }
            if (finalizado)
            {
                _contratos.Remove(_contrato);
                atualizaComboContratoIdLiberado();
                atualizaComboContratoId();
            }
        }

        public void atualizaComboBox()
        {
            comboTipos.Items.Clear();
            comboTipos2.Items.Clear();
            comboTipos3.Items.Clear();
            foreach (var tipoEquipamento in tipoEquipamentos)
            {
                comboTipos.Items.Add(tipoEquipamento.name);
                comboTipos2.Items.Add(tipoEquipamento.name);
                comboTipos3.Items.Add(tipoEquipamento.name);
            }
        }

        private void atualizaComboContratoId()
        {
            contratoId2.Items.Clear();
            contratoId1.Items.Clear();
            foreach (var contrato in _contratos)
            {
                if (!contrato.status)
                {
                    contratoId2.Items.Add(contrato.id.ToString());
                }

                contratoId1.Items.Add(contrato.id.ToString());
            }
        }

        private void atualizaComboContratoIdLiberado()
        {
            contratoLiberado.Items.Clear();
            contratoLiberado2.Items.Clear();
            foreach (var contrato in _contratos)
            {
                if (contrato.status)
                {
                    contratoLiberado.Items.Add(contrato.id.ToString());
                    contratoLiberado2.Items.Add(contrato.id.ToString());
                }
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

    }
}