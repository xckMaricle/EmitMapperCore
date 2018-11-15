using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using AutoMapper;
using EmitMapperCore;

namespace EmitMapperCore.Test
{
    public class BasicInfo1
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
    }



    public class BasicInfo2
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
    }

    public class BasicTest
    {
        static List<BasicInfo1> GetTestData()
        {
            var result = new List<BasicInfo1>();
            for (int i = 0; i < 10000000; i++)
            {
                result.Add(new BasicInfo1
                {
                    ID = Guid.NewGuid(),
                    Age = i,
                    Name = $"Basic-{i}",
                    Birthday = DateTime.Now,
                    Email = $"Basic-{i}@test.com"
                });
            }
            return result;
        }


        public static void BasicCompare()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<BasicInfo1, BasicInfo2>();
            });
            var list = GetTestData();
            var time = Stopwatch.StartNew();
            var hand = new List<BasicInfo2>();
            foreach (var item in list)
            {
                hand.Add(new BasicInfo2
                {
                    ID = item.ID,
                    Age = item.Age,
                    Name = item.Name,
                    Birthday = item.Birthday,
                    Email = item.Email
                });
            }
            Console.WriteLine($"Handwriting:{time.ElapsedMilliseconds} ms");
            time.Restart();
            var emitmap = ObjectMapperManager.DefaultInstance.GetMapper<List<BasicInfo1>, List<BasicInfo2>>().Map(list);
            time.Stop();
            Console.WriteLine($"EmitMapperCore:{time.ElapsedMilliseconds} ms");
            time.Restart();
            var automap = Mapper.Map<List<BasicInfo2>>(list);
            time.Stop();
            Console.WriteLine($"AutoMapper:{time.ElapsedMilliseconds} ms");
        }
    }
}
