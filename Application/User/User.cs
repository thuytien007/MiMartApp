namespace Application.User
{
    public class User
    {
        //JWT là Json Web Token(xác thực quyền truy cập Authentication), sau khi user dnhap vô rồi thì làm dc những gì
        //JWT gồm 3 phần header, payload và chữ ký cách nhau dấu chấm
        public string DisplayName{get; set;}
        public string Token{get; set;}
        //UserName dùng làm key cho việc đăng ký tạo ra token nên nó k đc trùng,còn DisplayName dùng hiển thị
        public string UserName{get; set;}
        public string Image{get; set;}
    }
}