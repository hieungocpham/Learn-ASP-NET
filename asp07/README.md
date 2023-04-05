cài 2 thư viện:
dotnet add package MailKit
dotnet add package MimeKit

cấu hình MailSettings trong appsetting.json
tạo lớp MailSettings trong Service
đăng ký dịch vụ
services.AddOptions ();                                         // Kích hoạt Options
var mailsettings = _configuration.GetSection ("MailSettings");  // đọc config
services.Configure<MailSettings> (mailsettings);                // đăng ký để Inject
tạo SendMailService 