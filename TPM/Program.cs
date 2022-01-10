// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

Console.WriteLine("[The Main Program]");

RuntimeHelpers.RunClassConstructor(typeof(HoaDon.Service).TypeHandle);
RuntimeHelpers.RunClassConstructor(typeof(CuaHang.Service).TypeHandle);
RuntimeHelpers.RunClassConstructor(typeof(LenDonHang.LenDonHangService).TypeHandle);

RuntimeHelpers.RunClassConstructor(typeof(CacKhuyenMaiDangChay.ServiceCacKhuyenMaiDangChay).TypeHandle);
RuntimeHelpers.RunClassConstructor(typeof(LenKeHoachKhuyenMai.ServiceLenKeHoachKhuyenMai).TypeHandle);
RuntimeHelpers.RunClassConstructor(typeof(CacKhuyenMaiHoanThanh.ServiceCacKhuyenMaiHoanThanh).TypeHandle);
RuntimeHelpers.RunClassConstructor(typeof(PhanTichKhuyenMai.ServicePhanTichKhuyenMai).TypeHandle);

LenKeHoachKhuyenMai.ServiceLenKeHoachKhuyenMai.PostToCacKhuyenMaiDangChayService();
CacKhuyenMaiDangChay.ServiceCacKhuyenMaiDangChay.PostToCacKhuyenMaiDangChayService();
PhanTichKhuyenMai.ServicePhanTichKhuyenMai.GetCacKhuyenMaiHoanThanh();
