using Data_Homework_.Entities;
using Data_Homework_.Uow;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollectionSystem.Utilities;

namespace TrashCollectionSystem.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class KMeansController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<KMeansController> _logger;

        public KMeansController(ILogger<KMeansController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public List<List<Container>> GetClusteredContainers(int vehicleId, int N)
        {
            var containers = unitOfWork.Container.GetAll().Where(x => x.VehicleId == vehicleId).ToList(); //GetAll metotuyla VehicleId'li verileri seçip containers değişkenine atadık
            double[][] rawData = new double[containers.Count()][]; // initialize

            for (int i = 0; i < containers.Count(); i++) // containers elemanı kadar döndük
            {
                rawData[i] = new double[] { (double)containers[i].Longitude, (double)containers[i].Latitude }; // kütüphanede kullanılmak üzere enlem ve boylamları rawDataya atıyoruz
              
            }
            
            int[] clustering = KMeans.Cluster(rawData, N); //kütüphanedeki cluster metotuna rawData ve N değişkenlerimizi gönderdik
            int groupCount = clustering.Distinct().Count(); //kaç tane grup olduğuna baktık

            List<List<Container>> list = new List<List<Container>>(); // Yeni liste içinde liste yarattık
            for (int i = 0; i < groupCount; i++) //for döngüsünde grup sayısı kadar dönüyoruz
            {
                List<Container> list2 = new List<Container>(); // Yeni liste yarattık
                list.Add(list2); // list2'yi list'e atadık
 
            }
            for (int j = 0; j < clustering.Count(); j++) // tüm clustering içinde dönüyoruz
            {
                list[clustering[j]].Add(containers[j]); // ilgili gruplara gerçek veri dolduruluyor

            }
            return list;
        }
    }
}
