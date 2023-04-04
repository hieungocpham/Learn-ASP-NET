using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace asp03 {
    public static class RequestProcess {
        public static async Task<string> FormProcess (HttpRequest request) {
            //Xử lý đọc dữ liệu Form - khi post - dữ liệu này trình  bày trên Form
            string hovaten = "";
            bool luachon = false;
            string email = "";
            string password = "";
            string thongbao = "";

            // Đọc dữ liệu từ Form do truy vấn gửi đến (chỉ xử lý khi là post)
            if (request.Method == "POST") {
                IFormCollection _form = request.Form;

                email = _form["email"].FirstOrDefault () ?? "";
                hovaten = _form["hovaten"].FirstOrDefault () ?? "";
                password = _form["password"].FirstOrDefault () ?? "";
                luachon = (_form["luachon"].FirstOrDefault () == "on");

                thongbao = $@"Dữ liệu post - email: {email} 
                              - hovaten: {hovaten} - password: {password} 
                              - luachon: {luachon} ";

                // var filePath = Path.GetTempFileName();
                // Xử lý nếu có file upload (hình ảnh,  ... )
                if (_form.Files.Count > 0) {
                    string thongbaofile = "Các file đã upload: ";
                    foreach (IFormFile formFile in _form.Files) {
                        if (formFile.Length > 0) {
                            var filePath = "wwwroot/upload/" + formFile.FileName; // Lấy tên  file
                            if (!Directory.Exists ("wwwroot/upload/")) Directory.CreateDirectory ("wwwroot/upload/");
                            thongbaofile += $"{filePath} {formFile.Length} bytes";
                            using (var stream = new FileStream (filePath, FileMode.Create)) // Mở stream để lưu file, lưu file ở thư mục wwwroot/upload/
                            {
                                await formFile.CopyToAsync (stream);
                            }
                        }

                    }
                    thongbao += "<br>" + thongbaofile;
                }

            }
            string format = await File.ReadAllTextAsync ("formtest.html"); // Đọc nội dung HTML từ file
            string formhtml = string.Format (format, hovaten, email, luachon ? "checked" : "");
            return formhtml + thongbao;
        }
    
    }

}