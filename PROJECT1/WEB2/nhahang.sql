﻿Create database NhaHang
use NhaHang
Create table MonAn
(
TenMonAn nvarchar(50) not null ,
IdMonAn int  IDENTITY(100,1) PRIMARY KEY not null , /*trường này là khóa chính và sẽ tự động tăng lên 1 (bắt đầu từ 100) */
MoTa nvarchar(255) not null,
GiaBan money not null,
AnhMonAn varchar(255) not null,
IdLoaiMonAn int  not null,
SDTTaiKhoan nvarchar(255) not null,
TrangThai int  not null/*nếu TrangThai=1 thì hiện, =0 thì ẩn*/
)
insert into  MonAn values (N'Roasted chicken with chili salt',N'With full nutrition...',300000,'https://images.unsplash.com/photo-1555939594-58d7cb561ad1?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8Zm9vZHxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60',1,N'0325793505',1)
insert into  MonAn values (N'Water Melon',N'Enjoy the sweetness...',40000,'https://images.unsplash.com/photo-1597306691225-69ef217a43cc?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8ZnJ1aXQlMjBqdWljZXN8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60',2,N'0325793505',1)
insert into  MonAn values (N'Grilled meat',N'Enjoy this moment...',80000,'https://images.unsplash.com/photo-1601356616077-695728ae17cb?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTV8fGx1bmNofGVufDB8fDB8fHww&auto=format&fit=crop&w=500&q=60',3,N'0325793505',1)
insert into  MonAn values (N'Salad',N'Fresh vegetables...',60000,'https://images.unsplash.com/photo-1490645935967-10de6ba17061?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTR8fGx1bmNofGVufDB8fDB8fHww&auto=format&fit=crop&w=500&q=60',4,N'0325793505',1)

Create table Category(
ID int  IDENTITY(1,1) PRIMARY KEY not null,
LoaiMonAn nvarchar(255) not null,
TrangThai int not null /*nếu TrangThai=1 thì hiện, =0 thì ẩn*/
)
insert into  Category values(N'Food',1)
insert into  Category values(N'Fruit juice',2)
insert into  Category values(N'Lunch',3)
insert into  Category values(N'Breakfast',4)
Create table TaiKhoan(
SDT nvarchar(255)  PRIMARY KEY not null,
Email nvarchar(30) not null,
DiaChi nvarchar(255) not null,
LoaiTK tinyint not null, /*LoaiTK=1 là TK admin, nếu không phải thì là các loại hạng tk người dùng khác*/
MatKhau varchar(255) not null,
TrangThai int not null/*nếu TrangThai=1 thì bth , =0 thì khóa */
)
insert into TaiKhoan values(N'0325793505',N'Hoàng@gmail.com',N'132 Nguyễn Hữu Cảnh, Bình Thạnh, TP.HCM',1,'123abc',1)
insert into TaiKhoan values(N'0339646365',N'Hoa@gmail.com',N'132 Nguyễn Hữu Cảnh, Bình Thạnh, TP.HCM',2,'123abc',1)




ALTER TABLE MonAn
 ADD FOREIGN KEY (SDTTaiKhoan) REFERENCES TaiKhoan(SDT);