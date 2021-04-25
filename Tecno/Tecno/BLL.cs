using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace BusinessLogicLayer
{
    public class BLL
    {
        public class Clientes
        {
            static public object loadpic()
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", 1),
             };
                return dal.executarScalar("select Img from Imagem where id=1", sqlParams);

            }
            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("select * from Login", null);
            }

            static public int insertLogin(string password, string user)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@password", password),
                 new SqlParameter("@user", user),
           };

                return dal.executarNonQuery("INSERT into Login (password,user) VALUES(@password,@user)", sqlParams);
            }
        }
        public class Pessoa
        {

            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("select * from Pessoa", null);

            }
            static public int insertCliente(string nome, string emaill, string idade, string sexo, string altura,string peso)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@nome", nome),
                new SqlParameter("@emaill",emaill),
                new SqlParameter("@idade",idade),
                new SqlParameter("@sexo",sexo),
                new SqlParameter("@altura",altura),
                new SqlParameter("@peso",peso),
           };

                return dal.executarNonQuery("INSERT into Pessoa (nome,emaill,idade,sexo,altura,peso) VALUES(@nome,@emaill,@idade,@sexo,@altura,@peso)", sqlParams);
            }
            static public DataTable queryCliente_Like(String Pesquisa)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Pesquisa", Pesquisa + "%")
                };
                return dal.executarReader("select * from Pessoa where Nome like @Pesquisa or email like @Pesquisa", sqlParams);
            }
            static public DataTable queryCliente(int id)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id)
                };
                return dal.executarReader("select * from Clientes where ID=@id", sqlParams);
            }

            static public DataTable queryLogin(int id, string password)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id),
                 new SqlParameter("@passord", password)
                };
                return dal.executarReader("select * from Login where ID=@id and password=@password", sqlParams);
            }

            static public DataTable queryCliente_3(int id)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id)
                };
                return dal.executarReader("select * from Clientes where ID=@id", sqlParams);
            }
            static public int updateCliente(string id, string nome, string email)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id),
                new SqlParameter("@nome", nome),
                new SqlParameter("@email", email),
            };
                return dal.executarNonQuery("update [Pessoa] set [nome]=@nome, [email]=@email where [id]=@id", sqlParams);
            }
            static public int deleteCliente(string id, string nome, string email)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id),
                new SqlParameter("@nome", nome),
                new SqlParameter("@email", email),

            };
                return dal.executarNonQuery("Delete From Pessoa WHERE[id]=@id", sqlParams);
            }
            static public int alterarPerfil(string utilizador, String password, string imagem)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]{
                    new SqlParameter("@utilizador", utilizador),
                    new SqlParameter("@password", password),
                    new SqlParameter("@imagem", imagem)};

                return dal.executarNonQuery("update [utilizadores] set [password]=@password, [imagem]=@imagem where [utilizador]=@utilizador", sqlparams);
            }

            static public int alterarEstado(string utilizador, int estado)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]{
                    new SqlParameter("@utilizador", utilizador),
                    new SqlParameter("@estado", estado)};

                return dal.executarNonQuery("update utilizadores set estado=@estado where utilizador=@utilizador", sqlparams);
            }

        }
    }
}