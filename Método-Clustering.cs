using System;
using System.IO;
using System.Data;

namespace K_means
{
    public class Program
    {

        #region Variaveis
        public static double[] centro = new double[8];
        public static double[] soma = new double[8];
        public static DataTable[] Kmeans = new DataTable[8];
        public static DataTable[] kAux = new DataTable[8];
        #endregion

        const string caminho = @"C:\Users\stella.moreira\Downloads\";
        const string arquivo = @"Grupo de Pessoas.txt";
        public static void Main(string[] args)
        {
            DataTable dtInfo = new DataTable("info");
            dtInfo.Columns.Add("UserID", typeof(long));
            dtInfo.Columns.Add("Sexo", typeof(string));
            dtInfo.Columns.Add("Idade", typeof(long));
            dtInfo.Columns.Add("Ocupacao", typeof(long));
            dtInfo.Columns.Add("CodigoPostal", typeof(string));

            //Definindo Centro de Cada Grupo
            for (int i = 1; i < 8; i++)
            {
                Console.Write("\n\t\tDefina o valor para o Centro [" + i + "]: ");
                centro[i] = int.Parse(Console.ReadLine());
            }

            bool igual = false;

            //Elementos de Cada Grupo
            for (int i = 1; i <= 7; i++)
            {
                soma[i] = 0;
            }

            LerArquivo(dtInfo);

            //Representação de Grupos
            for (int i = 1; i <= 7; i++)
            {
                Kmeans[i] = dtInfo.Clone();
                kAux[i] = dtInfo.Clone();
            }

            int cont = 0;
            //enquanto a ultima iteração for diferente da anterior, a execução continua
            while (!igual)
            {
                cont++;
                clear(Kmeans[1], Kmeans[2], Kmeans[3], Kmeans[4], Kmeans[5], Kmeans[6], Kmeans[7]);
                #region Definindo idade de acordo com seu centro
                foreach (DataRow row in dtInfo.Rows)
                {
                    double numero = Convert.ToDouble(row["Idade"]);

                    if (Math.Abs(centro[1] - numero) <= Math.Abs(centro[2] - numero) &&
                         Math.Abs(centro[1] - numero) <= Math.Abs(centro[3] - numero) &&
                         Math.Abs(centro[1] - numero) <= Math.Abs(centro[4] - numero) &&
                         Math.Abs(centro[1] - numero) <= Math.Abs(centro[5] - numero) &&
                         Math.Abs(centro[1] - numero) <= Math.Abs(centro[6] - numero) &&
                         Math.Abs(centro[1] - numero) <= Math.Abs(centro[7] - numero))
                    {
                        Kmeans[1].ImportRow(row);
                        soma[1] += numero;
                    }
                    else if (Math.Abs(centro[2] - numero) <= Math.Abs(centro[1] - numero) &&
                              Math.Abs(centro[2] - numero) <= Math.Abs(centro[3] - numero) &&
                              Math.Abs(centro[2] - numero) <= Math.Abs(centro[4] - numero) &&
                              Math.Abs(centro[2] - numero) <= Math.Abs(centro[5] - numero) &&
                              Math.Abs(centro[2] - numero) <= Math.Abs(centro[6] - numero) &&
                              Math.Abs(centro[2] - numero) <= Math.Abs(centro[7] - numero))
                    {
                        Kmeans[2].ImportRow(row);
                        soma[2] += numero;
                    }
                    else if (Math.Abs(centro[3] - numero) <= Math.Abs(centro[1] - numero) &&
                              Math.Abs(centro[3] - numero) <= Math.Abs(centro[2] - numero) &&
                              Math.Abs(centro[3] - numero) <= Math.Abs(centro[4] - numero) &&
                              Math.Abs(centro[3] - numero) <= Math.Abs(centro[5] - numero) &&
                              Math.Abs(centro[3] - numero) <= Math.Abs(centro[6] - numero) &&
                              Math.Abs(centro[3] - numero) <= Math.Abs(centro[7] - numero))
                    {
                        Kmeans[3].ImportRow(row);
                        soma[3] += numero;
                    }
                    else if (Math.Abs(centro[4] - numero) <= Math.Abs(centro[1] - numero) &&
                              Math.Abs(centro[4] - numero) <= Math.Abs(centro[2] - numero) &&
                              Math.Abs(centro[4] - numero) <= Math.Abs(centro[3] - numero) &&
                              Math.Abs(centro[4] - numero) <= Math.Abs(centro[5] - numero) &&
                              Math.Abs(centro[4] - numero) <= Math.Abs(centro[6] - numero) &&
                              Math.Abs(centro[4] - numero) <= Math.Abs(centro[7] - numero))
                    {
                        Kmeans[4].ImportRow(row);
                        soma[4] += numero;
                    }
                    else if (Math.Abs(centro[5] - numero) <= Math.Abs(centro[1] - numero) &&
                              Math.Abs(centro[5] - numero) <= Math.Abs(centro[2] - numero) &&
                              Math.Abs(centro[5] - numero) <= Math.Abs(centro[3] - numero) &&
                              Math.Abs(centro[5] - numero) <= Math.Abs(centro[4] - numero) &&
                              Math.Abs(centro[5] - numero) <= Math.Abs(centro[6] - numero) &&
                              Math.Abs(centro[5] - numero) <= Math.Abs(centro[7] - numero))
                    {
                        Kmeans[5].ImportRow(row);
                        soma[5] += numero;
                    }
                    else if (Math.Abs(centro[6] - numero) <= Math.Abs(centro[1] - numero) &&
                              Math.Abs(centro[6] - numero) <= Math.Abs(centro[2] - numero) &&
                              Math.Abs(centro[6] - numero) <= Math.Abs(centro[3] - numero) &&
                              Math.Abs(centro[6] - numero) <= Math.Abs(centro[4] - numero) &&
                              Math.Abs(centro[6] - numero) <= Math.Abs(centro[5] - numero) &&
                              Math.Abs(centro[6] - numero) <= Math.Abs(centro[7] - numero))
                    {
                        Kmeans[6].ImportRow(row);
                        soma[6] += numero;
                    }
                    else if (Math.Abs(centro[7] - numero) <= Math.Abs(centro[1] - numero) &&
                              Math.Abs(centro[7] - numero) <= Math.Abs(centro[2] - numero) &&
                              Math.Abs(centro[7] - numero) <= Math.Abs(centro[3] - numero) &&
                              Math.Abs(centro[7] - numero) <= Math.Abs(centro[4] - numero) &&
                              Math.Abs(centro[7] - numero) <= Math.Abs(centro[5] - numero) &&
                              Math.Abs(centro[7] - numero) <= Math.Abs(centro[6] - numero))
                    {
                        Kmeans[7].ImportRow(row);
                        soma[7] += numero;
                    }
                    #endregion

                }

                //Valida se o grupo é igual ao anterior
                 if (Kmeans[1].Rows.Count == kAux[1].Rows.Count &&
                     Kmeans[2].Rows.Count == kAux[2].Rows.Count &&
                     Kmeans[3].Rows.Count == kAux[3].Rows.Count &&
                     Kmeans[4].Rows.Count == kAux[4].Rows.Count &&
                     Kmeans[5].Rows.Count == kAux[5].Rows.Count &&
                     Kmeans[6].Rows.Count == kAux[6].Rows.Count &&
                     Kmeans[7].Rows.Count == kAux[7].Rows.Count)
                {
                    igual = true;
                }


                //calulo dos novos centros apos a iteração
                for (int i = 1; i <= 7; i++)
                {
                    centro[i] = soma[i] / Kmeans[i].Rows.Count;
                }

                clear(kAux[1], kAux[2], kAux[3], kAux[4], kAux[5], kAux[6], kAux[7]);

                for (int i = 1; i <= 7; i++)
                {
                    kAux[i] = Kmeans[i].Copy();
                }
            }

            Console.Write("\n\t\t Número de Iteração: " + cont);

            //Gera Arquivos 
            for (int i = 1; i <= 7; i++)
            {
                GeraArquivo(Kmeans[i], centro[i], 00+i);
            }

            Console.WriteLine($"\n\n Arquivos Criados");
            Console.ReadLine();
        }

        public static void clear(DataTable p1, DataTable p2, DataTable p3, DataTable p4, DataTable p5, DataTable p6, DataTable p7)
        {
            p1.Rows.Clear();
            p2.Rows.Clear();
            p3.Rows.Clear();
            p4.Rows.Clear();
            p5.Rows.Clear();
            p6.Rows.Clear();
            p7.Rows.Clear();
        }

        #region Lê o arquivo e extrai informações
        private static void LerArquivo(DataTable dtInfo)
        {
            StreamReader jun = new StreamReader(caminho + arquivo);

            string arq = jun.ReadToEnd();
            string[] linhas = arq.Split('\n');
            foreach (string str in linhas)
            {
                string[] info = str.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                DataRow row = dtInfo.NewRow();
                row["UserID"] = Convert.ToInt64(info[0]);
                row["Sexo"] = info[1];
                row["Idade"] = Convert.ToInt64(info[2]);
                row["Ocupacao"] = Convert.ToInt64(info[3]);
                row["CodigoPostal"] = info[4];

                dtInfo.Rows.Add(info[0], info[1], info[2], info[3], info[4]);
            }
        }
        #endregion

        #region Gerador de Informações
        private static void GeraArquivo(DataTable informacoesGrupo, double mediaIdade, long codGrupo)
        {
            long qtdPessoas = informacoesGrupo.Rows.Count;
            string nomeArquivo = $@"{caminho}{qtdPessoas}_{mediaIdade}_{codGrupo}.txt";

            string cabecalho = @"UserID::Sexo::Idade::Ocupação::CodigoPostal";

            using (StreamWriter novoArq = new StreamWriter(nomeArquivo))
            {
                novoArq.WriteLine(cabecalho);
                foreach (DataRow row in informacoesGrupo.Rows)
                {
                    novoArq.WriteLine($"{row[0].ToString()}::{row[1].ToString()}::{row[2].ToString()}::{row[3].ToString()}::{row[4].ToString()}");
                }
            }
        }
        #endregion
    }
}
