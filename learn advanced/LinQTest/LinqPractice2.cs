namespace LinQTest
{
  partial class LinqPractice
  {
    public static void QueryAdvancedLinQ ()
    {
      List<Product> products;
      List<Brand> brands;
      Data(out brands, out products);

      //(1): from cacphantu in nhomphantu
      //  dieu kien : where, orderby, let tenbien=??....
      //(2) lay phan tu select, group by ==> tra ve kieu IEnumrable

      // var kqLog = from pro in products
      //             select $"{pro.Name} : {pro.Price}";
      // kqLog.ToList().ForEach((p)=>Console.WriteLine(p));



      // gia sp <= 500, mau xanh , sap xep tu cao den thap
      // var kq = from pro in products
      //          from color in pro.Colors
      //          where pro.Price <=500&& color=="Xanh"
      //          orderby pro.Price descending // neu ko co descending thi loc tu cao den thap
      //          select new {
      //           Ten = pro.Name,
      //           Gia = pro.Price,
      //           Mau = string.Join(",",pro.Colors)
      //          };
      // kq.ToList().ForEach((e)=>Console.WriteLine(e));

      // gom nhom san pham theo gia
      // var kq = from p in products 
      //         group p by p.Price;
      //   kq.ToList().ForEach(
      //     (pro)=>{
      //       Console.WriteLine(pro.Key);
      //       pro.ToList().ForEach((e)=>{
      //         Console.WriteLine(e);
      //       });
      //     }
      //   );


      // gom nhóm sản phẩm theo giá từ thấp lên cao
      //  var kq = from p in products 
      //         group p by p.Price into gr
      //         orderby gr.Key
      //         select gr;
      //   kq.ToList().ForEach(
      //     (pro)=>{
      //       Console.WriteLine(pro.Key);
      //       pro.ToList().ForEach((e)=>{
      //         Console.WriteLine(e);
      //       });
      //     }
      //   );

      // gom nhóm sản phẩm theo giá từ thấp lên cao - ví dụ với let
      //  var kq = from p in products 
      //         group p by p.Price into gr
      //         orderby gr.Key
      //         let sl = "Số lượng : "+ gr.Count()
      //         select new{
      //           Gia = gr.Key,
      //           listSP = gr.ToList(),
      //           soluong =sl
      //         };
      //   kq.ToList().ForEach(
      //     (pro)=>{
      //       Console.WriteLine(pro.Gia);
      //       Console.WriteLine(pro.soluong);
      //       pro.listSP.ForEach((e)=>{
      //         Console.WriteLine(e);
      //       });

      //     }
      //   );

      // Left join join : 

      // var kq = from product in products
      //         join brand in brands on product.Brand equals brand.ID into t
      //         from b in t.DefaultIfEmpty()
      //         select new {
      //           Ten = product.Name,
      //           Gia = product.Price,
      //           ThuongHieu = (b!=null)? b.Name: "No brand"
      //         };

      // kq.ToList().ForEach((e)=>{
      //   Console.WriteLine(e);
      // });


      // var kq = from product in products
      //         join brand in brands on product.Brand equals brand.ID
      //         into ljoin
      //         from b in ljoin.DefaultIfEmpty()
      //         select new {
      //           ten = product.Name,
      //           thuongHieu = (b== null)?"No-brand":b.Name
      //         };
      //   kq.ToList().ForEach(
      //     (pro)=>{
      //       Console.WriteLine(pro);
      //     });
      
      


    }
  }
}