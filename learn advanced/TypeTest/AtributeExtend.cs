using System.ComponentModel.DataAnnotations;

namespace TypeTest
{
  class User3
  {
    [Required(ErrorMessage ="Name is required")]
    [StringLength(50, MinimumLength =3, ErrorMessage ="Tên phải dài từ 3-50 ký tự")]
    public string Name {set;get;}

    [Range(18,80,ErrorMessage ="Tên phải trong khoảng 18-80 ký tự")]
    public int Age {set;get;}

    [Phone(ErrorMessage =("Không đúng định dạng số điện thoại"))]
    public string Phone{set;get;}

    [EmailAddress(ErrorMessage ="Email không đúng định dạng")]
    public string Email {set;get;}
  }

 partial class typePractice
 {
  public static void Test4()
  {
    User3 user3 = new User3()
    {
      Name = "y",
      Age=80,
      Phone="980980",
      Email="dang@dfjdlf"
    };

    // thực hiện kiếm tra thì sử dụng ValidationContext với tham số khởi tạo là 1 đối tượng 

    ValidationContext context = new ValidationContext(user3);

    var result = new List<ValidationResult>();
    // nếu kết quả trả vê true nếu check đúng; 
    /* gọi phương thức tĩnh tryValidateObject cho đối tượng user3 với ngữ cảnh là context
    , lưu vào danh sách result các lỗi kiểm tra nếu có. 
    tham số true để kiểm tra các thuộc tính của user 
    */
    bool kq = Validator.TryValidateObject(user3,context,result,true);
    if ( !kq)
    {
      result.ToList().ForEach(
        (e)=>{
          Console.WriteLine(e.MemberNames.First());
          Console.WriteLine(e.ErrorMessage);
        }
      );
    }
  }
  


 }
}