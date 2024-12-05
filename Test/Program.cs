using AutomationTest.Core;
using Gherkin;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Test.Agendamento;
using Test.Cadastro;
using Test.Login;
namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            InitializeSettings(host.Services);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                })
                .UseWindowsService();

        private static void InitializeSettings(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

             //   Settings.Initialize(configuration);
            }
        }
    }

    public class Worker : BackgroundService
    {
        private static SeleniumHelper Selenium = new SeleniumHelper(new ConfigurationHelper());
        private readonly ILogger<Worker> _logger;
        private Timer _timer;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Serviço em execução...");

            // Alterado para executar a cada minuto
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(0));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _logger.LogInformation($"Execução do trabalho: {DateTime.Now}");

            Console.WriteLine(".:: 1. Iniciar testes em QA");

            LoginAplicacao.Logar(Selenium);

            Profissional.Profissionais(Selenium);

            Cliente.Clientes(Selenium);

            Servico.servicos(Selenium);

            ServicoRealizado.ServicosRealizados(Selenium);

            //Selenium.Dispose();

            // Voltar pag anterio
            //Selenium.BackNavigation(2);

            Console.WriteLine(".:: Fim do exemplo");

        }

        public override Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Serviço parando.");
            _timer?.Change(Timeout.Infinite, 0);
            return base.StopAsync(stoppingToken);
        }

        //public override void Dispose()
        //{
        //    _timer?.Dispose();
        //    base.Dispose();
        //}
    }
}