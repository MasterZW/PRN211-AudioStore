Electronic Accessories Project
# PRN211 - AudioStore - MVC

## Hướng dẫn sử dụng git cho repo chung
- **Clone this repo** --> `git clone https://github.com/FUniversityProjects/PRN211-AudioStore.git`
- **Kiểm tra trạng thái file/folder sau khi code** --> `git status`
- **Add các file/folder đã thay đổi** --> `git add .` hoặc `git add <folder/file>`
- **Tạo commit sau khi add file/folder vào stage** --> `git commit -m "<message>"`
- *Lưu ý khi tạo commit: message phải có ngày/tháng/năm commit và thông tin tổng quát về commit*
  - VD: *03/07/2022 - Thêm ProductController.cs và View giỏ hàng*
- **Tạo nhánh mới (dành cho lần đầu trước khi push code, các lần sau không cần)** --> `git branch -M <tên nhánh>`
- **Đẩy code lên nhánh (dành cho lần đầu push lên nhánh mới)** --> `git push origin -u <tên nhánh>`
- **Đẩy code lên nhánh (dành cho các lần sau)** --> `git push`
- **Di chuyển sang các nhánh khác** --> `git checkout <tên nhánh>`
- **Kéo code từ trên github về** --> `git pull`

## Hướng dẫn sử dụng các folder/file trong dự án chung

**1. Các quy định về folders/files chung cần lưu ý**
- Thư mục `Controllers`:
  - Các file controller được sử dụng chung như `HomeController` và `AdminController` sẽ nằm bên trong folder Controllers.
  - Các thư mục của mỗi cá nhân sẽ đồng cấp với 2 file trên và nằm trong folder Controllers.
  - *Lưu ý: controller chỉ sử dụng cho việc routing và nhận dữ liệu từ client truyền về*.
- Thư mục `Models`:
  - *Mục này không cần lưu ý, và không được sử dụng tuỳ ý khi chưa xin phép, mọi thắc mắc hoặc góp ý nhắn trên group zalo hoặc discord.*
- Thư mục `Views`:
  - Chứa các trang được cắt từ template.
  - Các trang định dạng `_Partials` được chứa bên trong folder `Share` cho mục đích sử dụng chung.
  - Định dạng layout từ file `_ViewStart.cshtml`.
  - Các trang tương ứng với một controller phải được chứa bên trong thư mục tương ứng. VD: *thư mục Admin chứa Admin.cshtml.*
  - Khi có 1 trang đại diện cũng **bắt buộc** tạo thư mục để chứa. Hỗ trợ việc maintain và staging code.
- Thư mục `wwwroot`:
  - Chứa các trang định dạng tại frontend/UI
  - Folder `css`: chứa các file *.css
  - *Lưu ý: các file css riêng lẻ cho từng thành phần phải được tạo riêng để setup. Dùng site.css để import các file css thành phần.*
  - Folder `js`: chứa các file định dạng *.js. Các file phải được đặt tên giải nghĩa cho mục đích của file đó. VD: *slide.js*
  - Folder `lib`: chứa các library chung trên toàn hệ thống như: *Bootstrap, jQuery, CKEditor, slickslider...*
  - Folder `fontawesome`: chứa thư viện icon miễn phí của fontawesome.
- File `Startup.cs`:
  - Dùng để đăng ký các sự kiện (service.Add...)
  - Dùng để configuration với session/cookie
- File `appsettings.json`:
  - Dùng để tuỳ chỉnh kết nối database bằng Code-First
  - Hiện tại file này được ẩn đi do vấn đề tên của `Server=...`
  - Mọi người có thể tạo thêm file tên appsettings.json và thêm các thông tin được gửi trên group discord vào dự án.
- Folder `Migrations`:
  - Được dùng để định dạng version migrations và update database
  - Hiện tại file này được ẩn đi. Sẽ cập nhật lại trong thời gian tới...
- File `.gitignore`:
  - *Không cần chú ý đến file này*

**2. Quy định việc tạo các folder/file mới**
- Tại project chung, có thể tạo thêm folders khác như *Utils, Helpers, Filters, Tests, Hubs...* để chứa các module hỗ trợ.
- Tại project chung, có thể tạo các file đơn lẻ như *App.config, bundleconfig.json, fakeData.json...* để dùng chung cho toàn hệ thống.
- *Lưu ý: không tuỳ ý tạo các file config đơn lẻ, khuyến khích sử dụng folder Utils hoặc Helper để dễ maintain*

### Các lệnh CLI hỗ trợ
**1. Setting Entity Framework**
- Phần này không cần vì project chung đã add package sẵn.
```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.17
```
```
dotnet tool install --global dotnet-ef --version 5.0.17
```
```
dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.17
```
```
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 5.0.17
```

**2. Migrations DB**
- Lệnh đầu tiên chỉ sử dụng 1 lần khi lần đầu pull code về.
- Lệnh `database update` sử dụng sau khi mỗi lần pull code tổng ở nhánh `main` về.
```
dotnet ef migrations add InitializeDB
```
```
dotnet ef database update
```

**3. Setting DBContext**
- Thư viện hỗ trợ, hiện tại không cần quan tâm mục này.
```
dotnet add package System.Data.Entity.Repository
```
