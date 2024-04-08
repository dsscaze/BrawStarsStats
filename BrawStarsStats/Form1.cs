using Newtonsoft.Json;
using RestSharp;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace BrawStarsStats
{
    public partial class Form1 : Form
    {
        private Timer tmrPadrao;

        public Form1()
        {
            InitializeComponent();

            tmrPadrao = new Timer();
            //tmrPadrao.AutoReset = false;
            tmrPadrao.Enabled = true;
            tmrPadrao.Interval = 5000;
            tmrPadrao.Tick += TmrPadrao_Tick;
            //tmrPadrao.Elapsed += TmrPadrao_Elapsed;
        }

        private void TmrPadrao_Tick(object sender, EventArgs e)
        {
            Player();
            UltimaBatalha();
            AtualizarData();
        }

        //private void TmrPadrao_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    Player();
        //    UltimaBatalha();
        //    AtualizarData();
        //}

        private void AtualizarData()
        {
            lbAtualizacao.Text = "Atualizado em " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Player();
            UltimaBatalha();
            AtualizarData();
            tmrPadrao.Start();
        }

        private int vitorias = 0;
        private int derrotas = 0;
        private int trofeus = 0;
        private int vitoriasInicio = 0;
        private int trofeusInicio = 0;

        private void Player()
        {
            var client = new RestClient("https://api.brawlstars.com/v1/players/%2322POYYPRC");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjIwOWMzZjc3LWU5YWQtNGE2NS04YjA5LWUyNmFlMmI1Yzg4ZCIsImlhdCI6MTcxMjMzMTY4Miwic3ViIjoiZGV2ZWxvcGVyL2ZhNGZkOTc0LTA2MDUtMWIxMi1hZmQ0LTQwNjcwYTljNzQzOCIsInNjb3BlcyI6WyJicmF3bHN0YXJzIl0sImxpbWl0cyI6W3sidGllciI6ImRldmVsb3Blci9zaWx2ZXIiLCJ0eXBlIjoidGhyb3R0bGluZyJ9LHsiY2lkcnMiOlsiNDUuMTg2LjIxNy4xMjgiXSwidHlwZSI6ImNsaWVudCJ9XX0.7ofpP_-V5bc0QGpKi-FtlJl0eGvMgHonlSY79XbRFqNZlyteMuAg2KhSq1g5IRV4aFDYOkJIEV5CP3e4NUh4SA");
            IRestResponse response = client.Execute(request);
            PlayerRequest resultPlayer = JsonConvert.DeserializeObject<PlayerRequest>(response.Content);
            
            if (vitoriasInicio <= 0)
            {
                vitoriasInicio = resultPlayer.SoloVictories + resultPlayer.DuoVictories + resultPlayer._3vs3Victories;
            }

            vitorias = resultPlayer.SoloVictories + resultPlayer.DuoVictories + resultPlayer._3vs3Victories;

            if (trofeusInicio <= 0)
            {
                trofeusInicio = resultPlayer.Trophies;
            }

            trofeus = resultPlayer.Trophies;

            lbVitoria.Text = "Total de vitórias: " + vitorias;
            lbTrofeus.Text = "Total de Troféus: " + trofeus;

            lbVitoriasSaldo.Text = "Saldo de vitórias: " + (vitorias - vitoriasInicio);
            lbTrofeusSaldo.Text = "Saldo de troféus: " + (trofeus - trofeusInicio);
        }

        private void UltimaBatalha()
        {
            var client = new RestClient("https://api.brawlstars.com/v1/players/%2322POYYPRC/battlelog");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjIwOWMzZjc3LWU5YWQtNGE2NS04YjA5LWUyNmFlMmI1Yzg4ZCIsImlhdCI6MTcxMjMzMTY4Miwic3ViIjoiZGV2ZWxvcGVyL2ZhNGZkOTc0LTA2MDUtMWIxMi1hZmQ0LTQwNjcwYTljNzQzOCIsInNjb3BlcyI6WyJicmF3bHN0YXJzIl0sImxpbWl0cyI6W3sidGllciI6ImRldmVsb3Blci9zaWx2ZXIiLCJ0eXBlIjoidGhyb3R0bGluZyJ9LHsiY2lkcnMiOlsiNDUuMTg2LjIxNy4xMjgiXSwidHlwZSI6ImNsaWVudCJ9XX0.7ofpP_-V5bc0QGpKi-FtlJl0eGvMgHonlSY79XbRFqNZlyteMuAg2KhSq1g5IRV4aFDYOkJIEV5CP3e4NUh4SA");
            IRestResponse response = client.Execute(request);
            dynamic resultBattle = JsonConvert.DeserializeObject(response.Content);
            if (resultBattle.items != null)
            {
                if (resultBattle.items.Count > 0)
                {
                    DateTime d = DateTime.ParseExact(resultBattle.items[0].battleTime.ToString().Replace(".000Z", ""), "yyyyMMddTHHmmss", CultureInfo.InvariantCulture);
                    d = d.AddHours(-3);

                    string resultado = resultBattle.items[0].battle.result;
                    switch (resultado)
                    {
                        case "victory":
                            resultado = "Vitória";
                            break;
                        case "defeat":
                            resultado = "Derrota";
                            break;
                        default:
                            resultado = "Empate";
                            break;
                    }

                    lbUltimaBatalha.Text = "Última Batalha: " + d.ToString("dd/MM/yyyy HH:mm:ss") + " Resultado: " + resultado;
                }
            }
        }
    }

}