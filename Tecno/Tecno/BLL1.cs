using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using BusinessLogicLayer;
using System.Text;

namespace BusinessLogicLayer
{
    public class BLL1
    {
        public class Login
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
                return dal.executarReader("select * from Imagem", null);
            }

            static public int insertResult(int Questionário, decimal imc )
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Questionário", Questionário),
                 new SqlParameter("@imc", imc),
           };

                return dal.executarNonQuery("INSERT into Resultado (Questionário,imc) VALUES(@Questionário,@imc)", sqlParams);
            }
        }


        public class Resultados
        {
            static public Object queryimc()
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                

                };
                return dal.executarScalar("select avg (imc) from Resultado where imc>18", sqlParams);
            }
            static public Object queryidade()
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{


                };
                return dal.executarScalar("select avg (idade) from Pessoa", sqlParams);
            }
            static public Object queryquestionário()
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{


                };
                return dal.executarScalar("select avg (Questionário) from Resultado", sqlParams);
            }
        }
            public class Logins
        {
            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("select * from Login", null);
            }
            static public int insertLogin(string password, string usere, bool adm)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@password", password),
                new SqlParameter("@usere", usere),
                 new SqlParameter("@adm", adm),


           };

                return dal.executarNonQuery("INSERT into Login (password,usere,adm) VALUES(@password,@usere,@adm)", sqlParams);
            }
            static public DataTable Selectresults(String nome)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@nome", nome + "%")
                };
                return dal.executarReader("select * from Clientes where Nome like @nome", sqlParams);
            }
            static public DataTable queryCliente(int id) {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id)
                };
                return dal.executarReader("select * from Clientes where ID=@id", sqlParams);
            }


            static public DataTable queryLogin(string password, string usere)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                 new SqlParameter("@password", password),
                 new SqlParameter("@usere", usere),
                };
                return dal.executarReader("select * from Login where password=@password and usere=@usere " , sqlParams);
            }
            static public DataTable queryUser(string usere)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                 new SqlParameter("@usere", usere),
                };
                return dal.executarReader("select * from Login where usere=@usere ", sqlParams);
            }


        }

        static public DataTable queryCliente_3(int id)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id)
                };
                return dal.executarReader("select * from Clientes where ID=@id", sqlParams);
            }
            static public int updateCliente(string id, string nome, string morada, string telefone)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id),
                new SqlParameter("@nome", nome),
                new SqlParameter("@morada", morada),
                new SqlParameter("@telefone", telefone)
            };
                return dal.executarNonQuery("update [Clientes] set [nome]=@nome, [morada]=@morada, [telefone]=@telefone where [id]=@id", sqlParams);
            }
            static public int deleteCliente(string id)            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id),
               
            };
                return dal.executarNonQuery("Delete From Clientes WHERE[id]=@id", sqlParams);
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
