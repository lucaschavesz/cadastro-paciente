using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using cad_pacientes.Models;

namespace cad_pacientes.DAO
{
    public class PacienteDAO
    {
        public void Inserir(PacienteViewModel paciente)
        {
            string sql =
            "insert into Pacientes (Id, Data_nascimento, Nome, NomeResponsavel)" +
            " values (@Id, @Data_nascimento, @Nome, @NomeResponsavel)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(paciente));
        }
        public void Alterar(PacienteViewModel paciente)
        {
            string sql =
            "update Pacientes set" +
            " Data_nascimento = @Data_nascimento," +
            " Nome = @Nome," +
            " NomeResponsavel = @NomeResponsavel" +
            " where Id = @Id";
            HelperDAO.ExecutaSQL(sql, CriaParametros(paciente));
        }
        private SqlParameter[] CriaParametros(PacienteViewModel paciente)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("Id", paciente.Id);
            parametros[1] = new SqlParameter("Data_nascimento", paciente.Data_nascimento);
            parametros[2] = new SqlParameter("Nome", paciente.Nome);

            if (paciente.NomeResponsavel == null)
            {
                parametros[3] = new SqlParameter("NomeResponsavel", DBNull.Value);
            } 
            else
            {
                parametros[3] = new SqlParameter("NomeResponsavel", paciente.NomeResponsavel);
            }
            
            return parametros;
        }
        public void Excluir(int id)
        {
            string sql = "delete Pacientes where id = " + id;
            HelperDAO.ExecutaSQL(sql, null);
        }
        private PacienteViewModel MontaPaciente(DataRow registro)
        {
            PacienteViewModel p     = new PacienteViewModel();
            p.Id                    = Convert.ToInt32(registro["Id"]);
            p.Data_nascimento       = Convert.ToDateTime(registro["Data_nascimento"]);
            p.Nome                  = registro["Nome"].ToString();

            if (registro["NomeResponsavel"] != DBNull.Value)
            {
                p.NomeResponsavel = Convert.ToString(registro["NomeResponsavel"]);
            }

            return p;
        }

        public PacienteViewModel Consulta(int id)
        {
                    string sql = "select * from Pacientes where id = " + id;
                    DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
                    if (tabela.Rows.Count == 0)
                        return null;
                    else
                        return MontaPaciente(tabela.Rows[0]);
        }
        public List<PacienteViewModel> Listagem()
        {
            List<PacienteViewModel> lista = new List<PacienteViewModel>();
            string sql = "select * from Pacientes order by Nome";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaPaciente(registro));
            return lista;
        }

        public int ProximoId()
        {
            string sql = "select isnull(max(id) +1, 1) as 'MAIOR' from pacientes";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }

    }
}
