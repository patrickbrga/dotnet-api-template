# dotnet-api-template

# **Hero API**

**💬 Colocando em prática todo o conhecimento adquirido desde 2019 que entrei na programação**

----------------
## Esse repositório tem como objetivo, implementar uma API do zero. E testar novas funcionalidades.

API:
- ✅ Criar Web API
- ✅ Configurar camada de IoC
    - ✅ MediatR
    - ✅ Entity
    - ✅ Serilog
        - ⛔ Plugar ElasticSearch
    - ✅ AutoFac
- ⛔ Criar Job/Workers
    - ✅ Quartz
        - ✅ Crystal Quartz
    - ⬜ Hangfire *(💭 Num sei, não gostei muito...)*
- ⛔ Criar filas
    - ⬜ Rabbit MQ
    - ✅ Kafka
    - ⬜ Amazon SQS *(💭 Tem pagar?!)*
- ✅ Criar docker-compose.yaml
    - ✅ PostgreSQL
    - ✅ Redis
    - ✅ NginX *(Load balance e Proxy Reverso)*
    - ✅ ELK *(💭 Pesquisar porque usar o LogStash)*
- ⬜ Testes Unitários
    - ⬜ Code Covareged *(💭 Preciso usar o Cake)*

Infra/Suporte:
- ⬜ New Relic *(💭 Muito interessante... Fiquei intrigado com ELK APM, realemnte curioso...)*
- ✅ SonarQube


----------------

## Pensamentos Avulsos durante as implementações

### Plugar ElasticSearch 
> *💭 Se eu soubesse do ódio que eu iria passar, nem teria começado kkkk.*

A implementação de código mais fácil que eu já vi... Meu maior problema é dentro dos containers criados no Docker... Quando sobe a aplicação ele não cria o index dentro do Elasticsearch...
(Tentei criar network entre eles, tentei criar passar direto o *http://elasticsearch:9200* pra definir a chamada dentro do container e nada...)

Mas rodando a aplicação normalmente funciona!!! 😡 Devo ter gasto umas 5hr tentando e não consegui... Deixa pra outra hora...


### Quartz.Net e Crystal Quartz
> *💭 Rapaz... foi chato encontrar a forma certa de implementar o tanto o Quartz.Net quanto o Crystal Quartz...*

Como não havia uma boa documentação para o .Net 6, de ambos, tive que ir procurando as interfaces antigas dentro da nova estrutura do **WebApplication** como era feito e ir encontrando os métodos, sem falar no problema de injeção de depencência...

Mas depois de um pouco de paciência e insistência deu bom...A baixo segue os trechos de código que coloquei pra conseguir implementar.

**Program.cs**
```cs
IScheduler scheduler = await app.Services.GetService<ISchedulerFactory>()
                                         .GetScheduler();

var job = JobBuilder.Create<HeroesSyncJob>()
                    .WithIdentity(HeroesSyncJob.JobKey)
                    .Build();

var trigger = TriggerBuilder.Create()
    .WithIdentity(HeroesSyncJob.TriggerKey)
    .WithCronSchedule("0 0/1 * 1/1 * ? *")
    .Build();

await scheduler.ScheduleJob(job, trigger);

// Precisei fazer esse mapeamento de rota pra conseguir adicionar
// a interface do Crystal
app.Map(string.Empty, app =>
{
    app.UseCrystalQuartz(() => scheduler);
});
```

**Injeção de Depêndencia do Autofac**
```cs
//O if é pra injetar somente se for o Jobs.
if (assembly.GetName().Name == "Jobs")
{
    builder.RegisterModule(new QuartzAutofacFactoryModule());
    builder.RegisterModule(new QuartzAutofacJobsModule(assembly));
}
```

