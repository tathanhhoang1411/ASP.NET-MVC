drop database NhaHang
Create database NhaHang
use NhaHang
/*Món ăn*/
Create table MonAn
(
TenMonAn nvarchar(50) not null ,
IdMonAn int  IDENTITY(100,1) PRIMARY KEY not null , /*trường này là khóa chính và sẽ tự động tăng lên 1 (bắt đầu từ 100) */
MoTa nvarchar(255) not null,
GiaBan money not null,
AnhMonAn varchar(255) not null,
IdLoaiMonAn int  not null,
SDTTaiKhoan nvarchar(255) not null,/*Xác định ADmin nào là người đã thêm món ăn */
SoLuong int not null,
TrangThai int  not null/*nếu TrangThai=1 thì hiện, =0 thì ẩn*/
)
insert into  MonAn values (N'Roasted chicken with chili salt',N'With full nutrition...',300000,'https://images.unsplash.com/photo-1555939594-58d7cb561ad1?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8Zm9vZHxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60',1,N'0325793505',20,1)
insert into  MonAn values (N'Water Melon',N'Enjoy the sweetness...',40000,'https://images.unsplash.com/photo-1597306691225-69ef217a43cc?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8ZnJ1aXQlMjBqdWljZXN8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60',2,N'0325793505',5,1)
insert into  MonAn values (N'Grilled meat',N'Enjoy this moment...',80000,'https://images.unsplash.com/photo-1601356616077-695728ae17cb?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTV8fGx1bmNofGVufDB8fDB8fHww&auto=format&fit=crop&w=500&q=60',3,N'0325793505',20,1)
insert into  MonAn values (N'Salad',N'Fresh vegetables...',60000,'https://images.unsplash.com/photo-1490645935967-10de6ba17061?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTR8fGx1bmNofGVufDB8fDB8fHww&auto=format&fit=crop&w=500&q=60',4,N'0325793505',10,1)
insert into  MonAn values (N'milk',N'yummy...',20000,'https://images.unsplash.com/photo-1634141510639-d691d86f47be?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTR8fG1pbGt8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60',4,N'0325793505',10,1)
/*Loại món ăn*/
Create table Category(
ID int IDENTITY(1,1) PRIMARY KEY not null,
LoaiMonAn nvarchar(255) not null,
TrangThai int not null /*nếu TrangThai=1 thì hiện, =0 thì ẩn*/
)
insert into  Category values(N'Food',1)
insert into  Category values(N'Fruit juice',1)
insert into  Category values(N'Lunch',1)
insert into  Category values(N'Breakfast',1)
insert into  Category values(N'party',1)

/*Tài khoản */
Create table TaiKhoan(
SDT nvarchar(255)  PRIMARY KEY not null,
Email nvarchar(30) not null,
DiaChi nvarchar(255) not null,
LoaiTK tinyint not null, /*LoaiTK=1 là TK admin, nếu không phải thì là các loại hạng tk người dùng khác*/
MatKhau varchar(255) not null,
TrangThai int not null,/*nếu TrangThai=1 thì bth , =0 thì khóa */
Avatar varchar(255) not null
)
insert into TaiKhoan values(N'0325793505',N'Hoang@gmail.com',N'132 Nguyễn Hữu Cảnh, Bình Thạnh, TP.HCM',1,'123abc',1,N'https://images.unsplash.com/photo-1543610892-0b1f7e6d8ac1?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8YXZhdGFyJTIwYXNpYW58ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60')
insert into TaiKhoan values(N'0339646365',N'Hoa@gmail.com',N'1/2 Nguyễn Hữu Cảnh, Bình Thạnh, TP.HCM',2,'123abc',1,N'https://images.unsplash.com/photo-1569913486515-b74bf7751574?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTh8fGF2YXRhciUyMGFzaWFufGVufDB8fDB8fHww&auto=format&fit=crop&w=500&q=60')
insert into TaiKhoan values(N'0987545310',N'Khanh@gmail.com',N'48 Phạm Huy Thông,Q.Gò Vấp, TP.HCM',2,'123abc',1,N'https://images.unsplash.com/photo-1569913486515-b74bf7751574?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTh8fGF2YXRhciUyMGFzaWFufGVufDB8fDB8fHww&auto=format&fit=crop&w=500&q=60')
ALTER TABLE MonAn
 ADD FOREIGN KEY (SDTTaiKhoan) REFERENCES TaiKhoan(SDT);
/* giỏ hàng*/
create table GioHang(
ID int IDENTITY(100,1) PRIMARY KEY not null ,
SDT nvarchar(255) not null,
TongGia money not null,
NgayTao datetime not null,
)

insert into GioHang values(N'0339646365',60000,N'2023-06-20 9:30:00')
insert into GioHang values(N'0987545310',30000,N'2022-06-1 9:30:00')
ALTER TABLE GioHang
 ADD FOREIGN KEY (SDT) REFERENCES TaiKhoan(SDT);

/*chi tiết giỏ hàng*/
create table ChiTietGioHang(
ID int IDENTITY(100,1) PRIMARY KEY not null,
ID_GioHang int  not null ,
ID_MonAn int  not null,
SoLuong int not null,
Gia money not null,
GhiChu nvarchar(255) not null,
NgayDat datetime not null,
ThayDoiCuoiCung datetime not null
)

ALTER TABLE ChiTietGioHang
 ADD FOREIGN KEY (ID_GioHang) REFERENCES GioHang(ID);
 ALTER TABLE ChiTietGioHang
 ADD FOREIGN KEY (ID_MonAn) REFERENCES MonAn(IdMonAn);
 insert into ChiTietGioHang values (100,100,1,60000,N'Đừng quá cay',N'2023-06-20 9:30:00',N'2023-06-30')
 insert into ChiTietGioHang values (101,104,3,30000,N'Xin hãy giao đến Công ty ABC',N'2023-06-20 9:30:00',N'2023-06-30')
 insert into ChiTietGioHang values (101,103,1,30000,N'Hãy thêm gia vị đậm đà',N'2023-06-20 9:30:00',N'2023-06-30')
 /**/
 select*from GioHang
 delete from GioHang