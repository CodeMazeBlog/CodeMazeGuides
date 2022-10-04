using FanIn_Fan_out.Shared.Application.DataObjects;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanIn_Fan_out.Functions.Functions.Orchestrators
{
    public static class OrchestrationFunctions
    {
        [FunctionName("RunOrchestrationFunctions")]
        public static async Task<IEnumerable<StatisticProductDTO>> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            // Récupération de la liste des produits
            IEnumerable<int> products = await context.CallActivityAsync<IEnumerable<int>>("GetProductsIds", string.Empty);

            var tasks = new Task<IEnumerable<SalesOrderDetailDTO>>[products.Count()];

            // Parcourir la liste des produits pour récupérer les ventes de chaque produit
            for(int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = context.CallActivityAsync<IEnumerable<SalesOrderDetailDTO>>("GetSalesOrderDetails", products.ElementAt(i));
            }
            await Task.WhenAll(tasks);

            IEnumerable<SalesOrderDetailDTO> salesOrderDetails = Enumerable.Empty<SalesOrderDetailDTO>();

            foreach (var item in tasks)
            {
                salesOrderDetails = salesOrderDetails.Union(item.Result);
            }

            // Agrégation des ventes pour chaque produit
            IEnumerable<StatisticProductDTO> result = await context.CallActivityAsync<IEnumerable<StatisticProductDTO>>("GetStatisticsProduct", salesOrderDetails);
            return result;
        }
    }
}