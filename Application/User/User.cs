namespace Application.User
{
    public class User
    {
        //JWT là Json Web Token(xác thực quyền truy cập Authentication), sau khi user dnhap vô rồi thì làm dc những gì
        //JWT gồm 3 phần header, payload và chữ ký cách nhau dấu chấm, project này dùng HS512 để mã hóa
        public string DisplayName{get; set;}
        public string Token{get; set;}
        public string UserName{get; set;}
        public string Avatar{get; set;}
    }
}