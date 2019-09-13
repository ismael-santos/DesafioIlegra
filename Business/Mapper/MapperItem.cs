using Interface.Mapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mapper
{
    public class MapperItem : IMapper<string, List<Item>>
    {
        private MapperItem() { }

        public static MapperItem Instance => new MapperItem();

        public List<Item> Map(string @in)
        {
            List<Item> result = new List<Item>();

            string itemData = @in.Replace("[", string.Empty)
                                 .Replace("]", string.Empty);

            List<string> allItemList = itemData.Split(',').ToList();

            allItemList.ForEach(item => 
            {
                List<string> itemDetail = item.Split('-').ToList();

                result.Add(new Item
                {
                    ID = itemDetail[0],
                    Quantity = Convert.ToInt32(itemDetail[1]),
                    Price = Convert.ToDecimal(itemDetail[2].Replace(".", ",")) //Considerar as casas decimais
                });
            });

            return result;
        }
    }
}
